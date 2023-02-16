using AutoMapper;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using IT_Community.Server.Infrastructure.Utilities;
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
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(dest => dest.ReplyList, opt => opt.MapFrom(c => c.Comments));
            CreateMap<CommentCreateDto, Comment>();

            CreateMap<Post, PostPreviewDto>()
                .ConvertUsing<PostWithImgSourceConverter>();
            CreateMap<Post, PostFullDto>()
                .ConvertUsing<PostWithFullInformationConverter>();
            CreateMap<PostCreateDto, Post>();

            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();

            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyEditDto, Company>();
            CreateMap<Company, CompanyPreviewDto>()
                .ConvertUsing<CompanyWithImgSourceConverter>();
            CreateMap<Company, CompanyFullDto>()
                .ConvertUsing<CompanyWithFullInformationConverter>();
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
            destination.ImageSrc = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, source.Thumbnail);
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
            destination.ImageSrc = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, source.Thumbnail);
            destination.Tags = mapper.Map<List<TagDto>>(source.Tags.ToList());
            destination.UserId = source.UserId;
            destination.UserName = source.User.UserName;
            destination.Likes = source.Likes.Count;
            destination.Comments = source.Comments.Count;

            return destination;
        }
    }

    public class CompanyWithImgSourceConverter : ITypeConverter<Company, CompanyPreviewDto>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper mapper;

        public CompanyWithImgSourceConverter(IWebHostEnvironment _webHostEnvironmen, IMapper mapper)
        {
            this.mapper = mapper;
             this._webHostEnvironment = _webHostEnvironmen;
        }

        public CompanyPreviewDto Convert(Company source, CompanyPreviewDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.ImageSrc = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.companiesImagesPath, source.Thumbnail);
            destination.EmployeesAmount = source.EmployeesAmount;

            return destination;
        }
    }

    public class CompanyWithFullInformationConverter : ITypeConverter<Company, CompanyFullDto>
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper mapper;

        public CompanyWithFullInformationConverter(IWebHostEnvironment _webHostEnvironmen, IMapper mapper)
        {
            this.mapper = mapper;
             this._webHostEnvironment = _webHostEnvironmen;
        }

        public CompanyFullDto Convert(Company source, CompanyFullDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Name = source.Name;
            destination.Description = source.Description;
            destination.Site = source.Site;
            destination.ImageSrc = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.companiesImagesPath, source.Thumbnail);
            destination.EmployeesAmount = source.EmployeesAmount;

            return destination;
        }
    }
}
