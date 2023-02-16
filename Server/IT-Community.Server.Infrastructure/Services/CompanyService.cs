using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Core.Entities.Vacancies;
using IT_Community.Server.Infrastructure.Dtos.CompanyDTOs;
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
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IT_Community.Server.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly UserManager<User> _userManager;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment webHostEnvironment, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        public async Task CreateCompany(CompanyCreateDto companyCreateDto, string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            if (user.CompanyId != null)
            {
                throw new HttpException("You already have registered company", HttpStatusCode.BadRequest);
            }

            var company = _mapper.Map<Company>(companyCreateDto);

            var companyForCheck = _unitOfWork.CompanyRepository.GetFirstBySpec(new Companies.ByName(company.Name));

            if (companyForCheck != null)
            {
                throw new HttpException("The company name is already taken", HttpStatusCode.BadRequest);
            }

            company.Thumbnail = await SaveImage(companyCreateDto.ImageFile);
            company.IsApproved = false;

            await _unitOfWork.CompanyRepository.Insert(company);
            await _unitOfWork.SaveAsync();

            user.CompanyId = _unitOfWork.CompanyRepository.GetFirstBySpec(new Companies.ByName(company.Name)).Id;
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateCompany(CompanyEditDto companyEditDto, string userId)
        {
            if (!IsExist(companyEditDto.Id))
            {
                throw new HttpException(ErrorMessages.CompanyDoesNotExist, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var companyForCheck = _unitOfWork.CompanyRepository.GetFirstBySpec(new Companies.ByName(companyEditDto.Name));

            if (companyForCheck != null)
            {
                throw new HttpException("The company name is already taken", HttpStatusCode.BadRequest);
            }

            var companyToEdit = _unitOfWork.CompanyRepository.GetFirstBySpec(new Companies.ByIdWithUsers(companyEditDto.Id));

            if (!companyToEdit.Users.Any(x => x.Id == userId) && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            if (companyEditDto.ImageFile != null)
            {
                DeleteImage(companyToEdit.Thumbnail);
                companyToEdit.Thumbnail = await SaveImage(companyEditDto.ImageFile);
            }

            _mapper.Map(companyEditDto, companyToEdit);

            _unitOfWork.CompanyRepository.Update(companyToEdit);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteCompany(int companyId, string userId)
        {
            if (!IsExist(companyId))
            {
                throw new HttpException(ErrorMessages.CompanyDoesNotExist, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var companyToDelete = _unitOfWork.CompanyRepository.GetFirstBySpec(new Companies.ByIdWithUsers(companyId));

            if (!companyToDelete.Users.Any(x => x.Id == userId) && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            DeleteImage(companyToDelete.Thumbnail);
            _unitOfWork.CompanyRepository.Delete(companyId);
            user.CompanyId = null;
            await _unitOfWork.SaveAsync();
        }


        public List<CompanyPreviewDto> GetAllCompanyPreviews()
        {
            return _unitOfWork.CompanyRepository.GetAll().Select(c => _mapper.Map(c, new CompanyPreviewDto())).ToList();
        }


        public async Task<CompanyFullDto> GetCompany(int id)
        {
            if(!IsExist(id))
            {
                throw new HttpException(ErrorMessages.CompanyDoesNotExist, HttpStatusCode.BadRequest);
            }
            else
            {
                return _mapper.Map(_unitOfWork.CompanyRepository.GetById(id), new CompanyFullDto());
            }
        }

        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string imageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName).Take(10).ToArray()).Replace(' ', '-');
            imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(imageFile.FileName);
            var folder = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.companiesImagesPath);
            var imagePath = Path.Combine(folder, imageName);

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            return imageName;
        }

        public void DeleteImage(string imageName)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, WebConstants.companiesImagesPath, imageName);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var post = _unitOfWork.CompanyRepository.GetById(id);

            if (post == null) return false;
            return true;
        }
    }
}
