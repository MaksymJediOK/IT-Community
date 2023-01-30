using AutoMapper;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            /*            CreateMap<Post, PostPreviewDto>()
                            .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
                            .ForMember(dest => dest.Tags, opt => opt.MapFrom(c => c.Tags.ToList()))
                            .ForMember(dest => dest.Likes, opt => opt.MapFrom(c => c.Likes.Count))
                            .ForMember(dest => dest.Comments, opt => opt.MapFrom(c => c.Comments.Count));*/
            CreateMap<User, UserPostDto>();

            CreateMap<Comment, CommentPostDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName));

            CreateMap<Post, PostPreviewDto>()
                .ConvertUsing<PostWithImgSourceConverter>();
            CreateMap<Post, PostFullDto>()
                .ConvertUsing<PostWithFullInformationConverter>();
            CreateMap<PostCreateDto, Post>();

            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
        }
    }

    public class PostWithFullInformationConverter : ITypeConverter<Post, PostFullDto>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper mapper;

        public PostWithFullInformationConverter(IWebHostEnvironment _webHostEnvironmen, IMapper mapper)
        {
            this.mapper = mapper;
            this._webHostEnvironment = _webHostEnvironmen;
        }

        public PostFullDto Convert(Post source, PostFullDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Title = source.Title;
            destination.Description = source.Description;
            destination.Body = source.Body;
            destination.Views = source.Views;
            destination.Date = source.Date;
            destination.Thumbnail = source.Thumbnail;
            destination.ImageSrc = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", source.Thumbnail);
            destination.ForumId = source.ForumId;
            destination.ForumName = source.Forum.Name;
            destination.Tags = mapper.Map<List<TagDto>>(source.Tags.ToList());
            destination.UserId = source.UserId;
            destination.UserName = source.User.UserName;
            destination.Likes = source.Likes.Count;
            destination.Comments = mapper.Map<List<CommentPostDto>>(source.Comments.ToList());

            return destination;
        }
    }

    public class PostWithImgSourceConverter : ITypeConverter<Post, PostPreviewDto>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper mapper;

        public PostWithImgSourceConverter(IWebHostEnvironment _webHostEnvironmen, IMapper mapper)
        {
            this.mapper = mapper;
             this._webHostEnvironment = _webHostEnvironmen;
        }

        public PostPreviewDto Convert(Post source, PostPreviewDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Title = source.Title;
            destination.Views = source.Views;
            destination.Date = source.Date;
            destination.Thumbnail = source.Thumbnail;
            destination.ImageSrc = Path.Combine(_webHostEnvironment.ContentRootPath, "Images", source.Thumbnail);
            destination.Tags = mapper.Map<List<TagDto>>(source.Tags.ToList());
            destination.UserId = source.UserId;
            destination.UserName = source.User.UserName;
            destination.Likes = source.Likes.Count;
            destination.Comments = source.Comments.Count;

            return destination;
        }
    }
}
