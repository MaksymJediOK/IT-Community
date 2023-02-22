using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Infrastructure.Dtos.AnswerDTOs;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Interfaces;
using IT_Community.Server.Infrastructure.Resources;
using IT_Community.Server.Infrastructure.Specifications;
using IT_Community.Server.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AnswerService(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateAnswer(AnswerCreateDto createAnswerDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, System.Net.HttpStatusCode.BadRequest); 
            }

            var answer = _unitOfWork.AnswerRepository.GetFirstBySpec(new Answers.ByVacancyAndUserId(createAnswerDto.VacancyId, userId));

            if(answer != null)
            {
                DeleteFile(answer.ResumePath);
                answer.ResumePath = await SaveFile(createAnswerDto.CVFile);
                answer.Description = createAnswerDto.Description;

                _unitOfWork.AnswerRepository.Update(answer);
            }
            else
            {
                var answerToCreate = _mapper.Map<Answer>(createAnswerDto);
                answerToCreate.ResumePath = await SaveFile(createAnswerDto.CVFile);
                answerToCreate.UserId = user.Id;

                await _unitOfWork.AnswerRepository.Insert(answerToCreate);
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<string> SaveFile(IFormFile cvFile)
        {
            string cvName = new string(Path.GetFileNameWithoutExtension(cvFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            cvName = cvName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(cvFile.FileName);

            var folder = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.usersCVsPath);
            var filePath = Path.Combine(folder, cvName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await cvFile.CopyToAsync(fileStream);
            }
            return cvName;
        }

        public void DeleteFile(string fileName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.usersCVsPath, fileName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }
    }
}
