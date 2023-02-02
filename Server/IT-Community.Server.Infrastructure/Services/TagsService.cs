using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Infrastructure.Dtos.TagsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var tags1 = tags.Select(t => _mapper.Map(t, new TagDto())).ToList();
            return tags1;
        }
        public async Task DeleteTag(int tagId)
        {
            _unitOfWork.TagRepository.Delete(tagId);
            await _unitOfWork.SaveAsync();
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
