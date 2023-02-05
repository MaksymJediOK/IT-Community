﻿using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public interface IPostsService
    {
        List<PostPreviewDto> GetPostPreview();
        public List<PostPreviewDto> GetSortedFilteredPostPreview(string? orderBy, string? dateFilter, List<int>? tagIds = null);
        Task<PostFullDto> GetPost(int id);
        Task CreatePost(PostCreateDto postCreateDto, string userId);
        Task EditPost(PostCreateDto postCreateDto, string userId, int postId);
        Task DeletePost(int id);
        bool IsExist(int id);
    }
}
