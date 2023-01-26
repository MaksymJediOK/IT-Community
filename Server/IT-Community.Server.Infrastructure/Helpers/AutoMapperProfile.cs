using AutoMapper;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostPreviewDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(c => c.User.UserName))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(c => c.Tags.Count))
                .ForMember(dest => dest.Likes, opt => opt.MapFrom(c => c.Likes.Count))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(c => c.Comments.Count));
        }
    }
}
