﻿using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LikeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ToggleLike(int postId, string userId)
        {
            var post = _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                throw new HttpException("Post not found", HttpStatusCode.NotFound);
            }

            var like = _unitOfWork.LikeRepository.GetAll(l => l.PostId == postId && l.UserId == userId).FirstOrDefault();
            if (like == null)
            {
                like = new Like
                {
                    PostId = postId,
                    UserId = userId
                };
                _unitOfWork.LikeRepository.Insert(like);
            }
            else
            {
                _unitOfWork.LikeRepository.Delete(like);
            }
            await _unitOfWork.SaveAsync();
        }

        public List<PostPreviewDto> GetLikedPosts(string userId)
        {
            var posts = _unitOfWork.PostRepository.GetAll().Where(p => p.Likes.Any(l => l.UserId == userId));
            return posts.Select(p => _mapper.Map(p, new PostPreviewDto())).ToList();
        }
    }
}
