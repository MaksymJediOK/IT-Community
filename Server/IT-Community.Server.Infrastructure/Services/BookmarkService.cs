using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace IT_Community.Server.Infrastructure.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookmarkService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task ToggleBookmark(int postId, string userId)
        {
            var post = _unitOfWork.PostRepository.GetById(postId);
            if (post == null)
            {
                throw new HttpException("Post not found", HttpStatusCode.NotFound);
            }

            var bookmark = _unitOfWork.BookmarkRepository.GetAll(l => l.PostId == postId && l.UserId == userId).FirstOrDefault();
            if (bookmark == null)
            {
                bookmark = new Bookmark
                {
                    PostId = postId,
                    UserId = userId
                };
                _unitOfWork.BookmarkRepository.Insert(bookmark);
            }
            else
            {
                _unitOfWork.BookmarkRepository.Delete(bookmark);
            }
            await _unitOfWork.SaveAsync();
        }

        public List<PostPreviewDto> GetBookmarkedPosts(string userId)
        {
            var posts = _unitOfWork.PostRepository.GetAll().Where(p => p.Bookmarks.Any(l => l.UserId == userId));
            return _mapper.Map<List<PostPreviewDto>>(posts);
        }

        public async Task<JsonResult> IsBookmarked(int postId, string userId)
        {
            var isBookmarked = _unitOfWork.BookmarkRepository.GetAll(b => b.UserId == userId && b.PostId == postId).Any();
            return new JsonResult(new { IsBookmarked = isBookmarked });
        }
    }
}