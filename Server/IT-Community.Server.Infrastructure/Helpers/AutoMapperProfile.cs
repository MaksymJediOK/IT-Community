using AutoMapper;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Infrastructure.Dtos.AnswerDTOs;
using IT_Community.Server.Infrastructure.Dtos.CategoryDTOs;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using IT_Community.Server.Infrastructure.Dtos.UserDTOs;
using IT_Community.Server.Infrastructure.Dtos.VacancyDTOs;
using IT_Community.Server.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace IT_Community.Server.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(IServer _server)
        {
            /*            CreateMap<Post, PostPreviewDto>()
                            .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
                            .ForMember(dest => dest.Tags, opt => opt.MapFrom(c => c.Tags.ToList()))
                            .ForMember(dest => dest.Likes, opt => opt.MapFrom(c => c.Likes.Count))
                            .ForMember(dest => dest.Comments, opt => opt.MapFrom(c => c.Comments.Count));*/
            CreateMap<User, UserPostDto>();
            CreateMap<User, UserFullDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.usersImagesPath, x.ProfilePhoto)));

            CreateMap<Comment, CommentPostDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(dest => dest.ReplyList, opt => opt.MapFrom(c => c.Comments));
            CreateMap<CommentCreateDto, Comment>();

            CreateMap<Post, PostPreviewDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.postsImagesPath, x.Thumbnail)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.Tags.ToList()))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(x => x.Comments.Count))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(x => x.Likes.Count));

            CreateMap<Post, PostFullDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.postsImagesPath, x.Thumbnail)))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(x => x.Tags.ToList()))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(x => x.Comments.ToList()))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(x => x.Likes.Count))
                .ForMember(dest => dest.ForumName, opt => opt.MapFrom(x => x.Forum.Name));

            CreateMap<PostCreateDto, Post>();

            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyEditDto, Company>();

            CreateMap<Company, CompanyFullDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.companiesImagesPath, x.Thumbnail)));

            CreateMap<Company, CompanyPreviewDto>()
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.companiesImagesPath, x.Thumbnail)));

            CreateMap<VacancyCreateDto, Vacancy>();
            CreateMap<VacancyEditDto, Vacancy>();
            CreateMap<Vacancy, VacancyPreviewDto>()
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(c => c.Company.Name))
                .ForMember(dest => dest.ImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.companiesImagesPath, x.Company.Thumbnail)));
            CreateMap<Vacancy, VacancyFullDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(c => c.Company.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(c => c.Company.Description))
                .ForMember(dest => dest.CompanyEmployeesAmount, opt => opt.MapFrom(c => c.Company.EmployeesAmount))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(c => c.Category.Name))
                .ForMember(dest => dest.CompanyImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.companiesImagesPath, x.Company.Thumbnail)))
                .ForMember(dest => dest.UserImageSrc, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.usersImagesPath, x.User.ProfilePhoto)));

            CreateMap<AnswerCreateDto, Answer>();
            CreateMap<Answer, AnswerPreviewDto>()
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
               .ForMember(dest => dest.ResumePath, opt => opt.MapFrom(x => Path.Combine(_server.Features.Get<IServerAddressesFeature>().Addresses.FirstOrDefault(), WebConstants.usersCVsPath, x.ResumePath)));
        }
    }
}
