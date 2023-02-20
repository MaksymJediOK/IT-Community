using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Interfaces;
using IT_Community.Server.Infrastructure.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public class TagsService : ITagsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<TagDto> GetTags()
        {
            var tags = _unitOfWork.TagRepository.GetAll();
            var tagDtos = _mapper.Map<List<TagDto>>(tags);
            return tagDtos;
        }

        public async Task BatchCreateTags(List<string> tagNames)
        {
            var tagDtos = tagNames.Select(x => new TagDto { Name = x.Trim() }).ToList();
            var existingTags = GetTags();
            var tagsToCreate = tagDtos.Where(t => !existingTags.Any(et => et.Name == t.Name)).ToList();
            if (tagsToCreate.Count > 0)
            {
                var tags = _mapper.Map<List<Tag>>(tagsToCreate);
                foreach (var tag in tags)
                {
                    _unitOfWork.TagRepository.Insert(tag);
                }
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new HttpException("All of the tags already exist in the database", HttpStatusCode.BadRequest);
            }
        }

        public async Task DeleteTag(int tagId)
        {
            if (IsExist(tagId))
            {
                _unitOfWork.TagRepository.Delete(tagId);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                throw new HttpException("Tag not found", HttpStatusCode.NotFound);
            }
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var tag = _unitOfWork.TagRepository.GetById(id);

            if(tag==null) return false;
            return true;
        }
    }
}
