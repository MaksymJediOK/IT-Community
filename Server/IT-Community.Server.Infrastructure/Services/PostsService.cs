using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Resources;
using IT_Community.Server.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace IT_Community.Server.Infrastructure.Services
{
    public class PostsService : IPostsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<User> _userManager;
        public PostsService(IUnitOfWork _unitOfWork, IMapper mapper, IWebHostEnvironment _webHostEnvironment, UserManager<User> userManager)
        {
            this._unitOfWork = _unitOfWork;
            _mapper = mapper;
            this._webHostEnvironment = _webHostEnvironment;
            _userManager = userManager;
        }
        public List<PostPreviewDto> GetPostPreview()
        {
            var posts = _unitOfWork.PostRepository.GetAll();
            var posts1 = _mapper.Map<List<PostPreviewDto>>(posts);

            return posts1;
        }

        public List<PostPreviewDto> GetSortedFilteredPostPreview(string? searchString, string? orderBy, string? dateFilter, List<int>? tagIds = null)
        {
            var posts = _unitOfWork.PostRepository.GetAll();

            if (searchString != null)
            {
                posts = posts.Where(p => p.Title.ToLower().Contains(searchString.ToLower()));
            }

            if (dateFilter != null)
            {
                switch (dateFilter)
                {
                    case "Today":
                        posts = posts.Where(p => p.Date >= DateTime.Now.AddDays(-1));
                        break;
                    case "Week":
                        posts = posts.Where(p => p.Date >= DateTime.Now.AddDays(-7));
                        break;
                    case "Months":
                        posts = posts.Where(p => p.Date >= DateTime.Now.AddMonths(-1));
                        break;
                    case "Year":
                        posts = posts.Where(p => p.Date >= DateTime.Now.AddYears(-1));
                        break;
                    default:
                        break;
                }
            }

            if (tagIds != null)
            {
                var tags = new List<Tag>();
                foreach (var id in tagIds)
                {
                    var tag = _unitOfWork.TagRepository.GetById(id);
                    if (tag != null)
                    {
                        tags.Add(tag);
                    }
                }

                foreach (var t in tags)
                {
                    posts = posts.Where(x => x.Tags.Contains(t));
                }
            }

            if (orderBy != null)
            {
                switch (orderBy)
                {
                    case "Popularity":
                        posts = posts.OrderByDescending(x => x.Views).ThenByDescending(x => x.Likes.Count);
                        break;
                    case "NewOnTop":
                        posts = posts.OrderByDescending(x => x.Date);
                        break;
                    case "OldOnTop":
                        posts = posts.OrderBy(x => x.Date);
                        break;
                    default:
                        posts = posts.OrderByDescending(x => x.Views).ThenByDescending(x => x.Likes.Count);
                        break;
                }
            }
            else
            {
                posts = posts.OrderByDescending(x => x.Views).ThenByDescending(x => x.Likes.Count);
            }

            return _mapper.Map<List<PostPreviewDto>>(posts);
        }

        public async Task CreatePost(PostCreateDto postCreateDto, string userId)
        {
            var postToCreate = _mapper.Map<Post>(postCreateDto);
            postToCreate.Date = DateTime.Now;
            postToCreate.UserId = userId;
            if (postCreateDto.TagsId != null)
            {
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
            }
            postToCreate.Thumbnail = await SaveImage(postCreateDto.ImageFile);
            await _unitOfWork.PostRepository.Insert(postToCreate);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditPost(PostCreateDto postEditDto, string userId, int postId)
        {
            if (!IsExist(postId))
            {
                throw new HttpException(ErrorMessages.ArcticleDoesNotExist, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var postToEdit = _unitOfWork.PostRepository.GetById(postId);

            if (postToEdit.UserId != userId && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            if (postEditDto.TagsId != null)
            {
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
            }

            if (postEditDto.ImageFile != null)
            {
                DeleteImage(postToEdit.Thumbnail);
                postToEdit.Thumbnail = await SaveImage(postEditDto.ImageFile);
            }

            if (postToEdit.Title != postEditDto.Title)
                postToEdit.Title = postEditDto.Title;
            if (postToEdit.Description != postEditDto.Description)
                postToEdit.Description = postEditDto.Description;
            if (postToEdit.Body != postEditDto.Body)
                postToEdit.Body = postEditDto.Body;


            _unitOfWork.PostRepository.Update(postToEdit);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeletePost(int postId, string userId)
        {
            if (!IsExist(postId))
            {
                throw new HttpException(ErrorMessages.ArcticleDoesNotExist, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var postDelete = _unitOfWork.PostRepository.GetById(postId);

            if (postDelete.UserId != userId && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            DeleteImage(postDelete.Thumbnail);
            _unitOfWork.PostRepository.Delete(postId);
            await _unitOfWork.SaveAsync();
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var post = _unitOfWork.PostRepository.GetById(id);

            if (post == null) return false;
            return true;
        }


        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, imageName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            return imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        public async Task<PostFullDto> GetPost(int postId, string userId = null)
        {
            if (!IsExist(postId))
            {
                return new PostFullDto();
            }

            var post = _unitOfWork.PostRepository.GetById(postId);
            post.Views++;
            _unitOfWork.PostRepository.Update(post);
            await _unitOfWork.SaveAsync();
            var postToSend = _mapper.Map<PostFullDto>(post);

            if (!string.IsNullOrEmpty(userId))
            {
                var isBookmarked = _unitOfWork.BookmarkRepository.GetAll(b => b.UserId == userId && b.PostId == post.Id).Any();
                postToSend.IsBookmarked = isBookmarked;
            }

            return postToSend;
        }
    }
}
