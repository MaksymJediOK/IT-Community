using AutoMapper;
using IT_Community.Server.Core;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.GenericRepository;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
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
        public PostsService(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            this._unitOfWork = _unitOfWork;
            _mapper = mapper;
        }
        public List<PostPreviewDto> GetPostPreview()
        {
            var posts = _unitOfWork.PostRepository.GetAll(includeProperties:"User,Tags,Comments,Likes");
            List<PostPreviewDto> result = posts.Select(post => _mapper.Map<PostPreviewDto>(post)).ToList();
/*            foreach (var post in posts)
            {
                result.Add(new PostPreviewDto
                {
                    Id = post.Id,
                    Title = post.Title,
                    Views = post.Views,
                    Date = post.Date,
                    Thumbnail = post.Thumbnail,
                    UserId = post.UserId,
                    UserName = post.User.UserName,
                    Tags = post.Tags.Count(),
                    Likes = post.Likes.Count(),
                    Comments = post.Comments.Count()
                });
            }*/
            return result;
        }
    }
}
