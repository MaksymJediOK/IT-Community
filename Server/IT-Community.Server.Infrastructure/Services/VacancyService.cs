using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Infrastructure.Dtos.VacancyDTOs;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Interfaces;
using IT_Community.Server.Infrastructure.Resources;
using IT_Community.Server.Infrastructure.Specifications;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VacancyService(UserManager<User> userManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task CreateVacancy(VacancyCreateDto vacancyCreateDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.NotFound);
            }
            else if (user.CompanyId == null)
            {
                throw new HttpException(ErrorMessages.CompanyNotRegistered, HttpStatusCode.NotFound);
            }

            var category = _unitOfWork.CategoryRepository.GetById(vacancyCreateDto.CategoryId);

            if (category == null)
            {
                throw new HttpException(ErrorMessages.CategoryDoesNotExist, HttpStatusCode.NotFound);
            }

            var vacancy = _mapper.Map<Vacancy>(vacancyCreateDto);

            vacancy.UserId = userId;
            vacancy.CompanyId = (int)user.CompanyId;
            vacancy.Date = DateTime.Now;

            await _unitOfWork.VacancyRepository.Insert(vacancy);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteVacancy(int id, string userId)
        {
            if (!IsExist(id))
            {
                throw new HttpException(ErrorMessages.VacancyDoesNotExist, HttpStatusCode.NotFound);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.NotFound);
            }

            var vacancyToDelete = _unitOfWork.VacancyRepository.GetFirstBySpec(new Vacancies.ByIdWithCompaniesAndAdmins(id));

            if (!await _userManager.IsInRoleAsync(user, "Admin") && !vacancyToDelete.Company.Users.Any(x => x.Id.Contains(userId)))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            _unitOfWork.VacancyRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task EditVacancy(VacancyEditDto vacancyEditDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.NotFound);
            }
            else if (user.CompanyId == null)
            {
                throw new HttpException(ErrorMessages.CompanyNotRegistered, HttpStatusCode.NotFound);
            }

            if (!IsExist(vacancyEditDto.Id))
            {
                throw new HttpException(ErrorMessages.ArcticleDoesNotExist, HttpStatusCode.BadRequest);
            }

            var category = _unitOfWork.CategoryRepository.GetById(vacancyEditDto.CategoryId);

            if (category == null)
            {
                throw new HttpException(ErrorMessages.CategoryDoesNotExist, HttpStatusCode.NotFound);
            }

            var vacancyToEdit = _unitOfWork.VacancyRepository.GetFirstBySpec(new Vacancies.ByIdWithCompaniesAndAdmins(vacancyEditDto.Id));

            if (!await _userManager.IsInRoleAsync(user, "Admin") && !vacancyToEdit.Company.Users.Any(x => x.Id.Contains(userId)))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            _mapper.Map(vacancyEditDto, vacancyToEdit);

            _unitOfWork.VacancyRepository.Update(vacancyToEdit);
            await _unitOfWork.SaveAsync();
        }

        public List<VacancyPreviewDto> GetVacanciesPreviews()
        {
            var vacancies = _unitOfWork.VacancyRepository.GetListBySpec(new Vacancies.GetAllWithCompanies());
            return _mapper.Map<List<VacancyPreviewDto>>(vacancies);
        }

        public VacancyFullDto GetVacancy(int id)
        {
            var vacancy = _unitOfWork.VacancyRepository.GetFirstBySpec(new Vacancies.GetAllWithCompaniesUsersCategories(id));
            return _mapper.Map<VacancyFullDto>(vacancy);
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var post = _unitOfWork.VacancyRepository.GetById(id);

            if (post == null) return false;
            return true;
        }
    }
}
