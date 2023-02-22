using IT_Community.Server.Infrastructure.Dtos.AnswerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Interfaces
{
    public interface IAnswerService
    {
        Task CreateAnswer(AnswerCreateDto createAnswerDto, string userId);
    }
}
