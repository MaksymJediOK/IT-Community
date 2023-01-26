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
            var posts = _unitOfWork.PostRepository
                .GetAll(includeProperties: new[] { nameof(Post.User), nameof(Post.Tags), nameof(Post.Comments), nameof(Post.Likes) });
            return _mapper.Map<List<PostPreviewDto>>(posts);
        }
    }
}
