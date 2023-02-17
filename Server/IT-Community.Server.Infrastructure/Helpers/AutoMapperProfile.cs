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
        public AutoMapperProfile(IWebHostEnvironment _webHostEnvironment)
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
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, x.Thumbnail)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.Tags.ToList()))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(x => x.Likes.Count));

            CreateMap<Post, PostFullDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.imagesPath, x.Thumbnail)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.Tags.ToList()))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(x => x.Comments.ToList()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(x => x.Likes.Count))
                .ForMember(dest => dest.ForumName, opt => opt.MapFrom(x => x.Forum.Name));

            CreateMap<PostCreateDto, Post>();

            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();

            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyEditDto, Company>();

            CreateMap<Company, CompanyFullDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.companiesImagesPath, x.Thumbnail)));

            CreateMap<Company, CompanyPreviewDto>()
                    .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.companiesImagesPath, x.Thumbnail)));
        }
    }
}
