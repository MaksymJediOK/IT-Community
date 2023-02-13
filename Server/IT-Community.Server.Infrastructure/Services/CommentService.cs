using AutoMapper;
using IT_Community.Server.Core.DataAccess;
using IT_Community.Server.Core.Entities;
using IT_Community.Server.Infrastructure.Dtos.CommentDTOs;
using IT_Community.Server.Infrastructure.Dtos.PostDtos;
using IT_Community.Server.Infrastructure.Exceptions;
using IT_Community.Server.Infrastructure.Interfaces;
using IT_Community.Server.Infrastructure.Resources;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public List<CommentPostDto> GetCommentsWithReplies(int postId)
        {
            var commentList = _mapper.Map<List<CommentPostDto>>
                (_unitOfWork.CommentRepository.GetAll(x => x.PostId == postId && x.ParentId == null, includeProperties: new[] {"Comments"}));
            foreach(var comment in commentList)
            {
                LoadComments(comment, postId);
            }

            return commentList;
        }

        private void LoadComments(CommentPostDto comment, int postId)
        {
            foreach(var c in comment.ReplyList)
            {
                c.ReplyList = _mapper.Map<List<CommentPostDto>>(_unitOfWork.CommentRepository.GetAll(x => x.PostId == postId && x.ParentId == c.Id, includeProperties: new[] { "Comments" }));
                foreach(var c2 in c.ReplyList)
                {
                    LoadComments(c2, postId);
                }
            }
        }

        private List<CommentPostDto> GetAllReplies(ref List<CommentPostDto> comments, int parentId)
        {
            List<CommentPostDto> innerComments = comments;

            return comments.Where(x => x.ParentId == parentId).Select(m => new CommentPostDto()
            {
                Id = m.Id,
                UserId = m.UserId,
                UserName = m.UserName,
                Date = m.Date,
                PostId = m.PostId,
                Body = m.Body,
                ParentId = parentId,
                ReplyList = innerComments.Where(x => x.ParentId == m.Id).Count() > 0 ? GetAllReplies(ref innerComments, m.Id) : null
            }).ToList();
        }

        public async Task CreateComment(CommentCreateDto commentCreateDto, string userId)
        {
            var commentToCreate = _mapper.Map<Comment>(commentCreateDto);
            commentToCreate.Date = DateTime.Now;

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            commentToCreate.UserId = userId;

            await _unitOfWork.CommentRepository.Insert(commentToCreate);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateComment(CommentUpdateDto commentUpdateDto, string userId)
        {
            if (!IsExist(commentUpdateDto.CommentId))
            {
                throw new HttpException(ErrorMessages.CommentDoesNotExist, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var commentToEdit = _unitOfWork.CommentRepository.GetById(commentUpdateDto.CommentId);

            if (commentToEdit.UserId != userId && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            commentToEdit.Body = commentUpdateDto.Body;

            _unitOfWork.CommentRepository.Update(commentToEdit);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteComment(int commentId, string userId)
        {
            if (!IsExist(commentId))
            {
                throw new HttpException(ErrorMessages.CommentDoesNotExist, HttpStatusCode.BadRequest);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new HttpException(ErrorMessages.InvalidUserId, HttpStatusCode.BadRequest);
            }

            var commentToEdit = _unitOfWork.CommentRepository.GetById(commentId);

            if (commentToEdit.UserId != userId && !await _userManager.IsInRoleAsync(user, "Admin"))
            {
                throw new HttpException(ErrorMessages.InvalidPermission, HttpStatusCode.BadRequest);
            }

            _unitOfWork.CommentRepository.Delete(commentId);
            await _unitOfWork.SaveAsync();
        }

        public bool IsExist(int id)
        {
            if (id <= 0) return false;

            var comment = _unitOfWork.CommentRepository.GetById(id);

            if (comment == null) return false;
            return true;
        }
    }
}
