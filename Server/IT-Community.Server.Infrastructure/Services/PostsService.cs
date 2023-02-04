using AutoMapper;
using IT_Community.Server.Core;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.GenericRepository;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public class PostsService : IPostsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostsService(IUnitOfWork _unitOfWork, IMapper mapper, IWebHostEnvironment _webHostEnvironment)
        {
            this._unitOfWork = _unitOfWork;
            _mapper = mapper;
            this._webHostEnvironment = _webHostEnvironment;
        }
        public List<PostPreviewDto> GetPostPreview()
        {
            var posts = _unitOfWork.PostRepository
                .GetAll(/*includeProperties: new[] { nameof(Post.User), nameof(Post.Tags), nameof(Post.Comments), nameof(Post.Likes) }*/);
            var posts1 = posts.Select(p=>_mapper.Map(p, new PostPreviewDto())).ToList();
            //var posts1 = _mapper.Map(posts, new List<PostPreviewDto>());

            return posts1;
        }
        public async Task CreatePost(PostCreateDto postCreateDto, string userId)
        {
            var postToCreate = _mapper.Map<Post>(postCreateDto);
            postToCreate.Date = DateTime.Now;
            postToCreate.UserId = userId;
            var query = _unitOfWork.TagRepository.GetAll().ToList();
            List<Tag> list = new List<Tag>();
            foreach (var item in postCreateDto.TagsId)
            {
                var tag = query.FirstOrDefault(x => x.Id == item);
                if (tag != null)
                {
                    list.Add(tag);
                }
            }
            postToCreate.Tags = list;
            postToCreate.Thumbnail = await SaveImage(postCreateDto.ImageFile);
            await _unitOfWork.PostRepository.Insert(postToCreate);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditPost(PostCreateDto postEditDto, string userId, int postId)
        {
            /*var postToEdit = _mapper.Map<Post>(postEditDto);*/
            var postToEdit = _unitOfWork.PostRepository.GetById(postId);
            List<Tag> list = new List<Tag>();
            foreach (var item in postEditDto.TagsId)
            {
                var tag = _unitOfWork.TagRepository.GetById(item);
                if (tag != null)
                {
                    list.Add(tag);
                }
            }
            postToEdit.Tags = list;

            if (postEditDto.ImageFile != null)
            {
                DeleteImage(postToEdit.Thumbnail);
                postToEdit.Thumbnail = await SaveImage(postEditDto.ImageFile);
            }
            if(postToEdit.Title!=postEditDto.Title)
                postToEdit.Title=postEditDto.Title;
            if(postToEdit.Description!=postEditDto.Description)
                postToEdit.Description=postEditDto.Description;
            if(postToEdit.Body!=postEditDto.Body)
                postToEdit.Body =postEditDto.Body;


            _unitOfWork.PostRepository.Update(postToEdit);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeletePost(int postId)
        {
            var postDelete = _unitOfWork.PostRepository.GetById(postId);
            DeleteImage(postDelete.Thumbnail);
            _unitOfWork.PostRepository.Delete(postId);
            await _unitOfWork.SaveAsync();
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var post = _unitOfWork.PostRepository.GetById(id);

            if(post==null) return false;
            return true;
        }


        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff")+Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, WebConstants.imagesPath, imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.ContentRootPath, WebConstants.imagesPath, imageName);
            if(System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        public async Task<PostFullDto> GetPost(int id)
        {
            if (IsExist(id))
            {
                var post = _unitOfWork.PostRepository.GetById(id);
                post.Views++;
                _unitOfWork.PostRepository.Update(post);
                await _unitOfWork.SaveAsync();
                var postToSend = _mapper.Map(post, new PostFullDto());
                return postToSend;
            }
            else
            {
                return new PostFullDto();
            }
        }
    }
}
