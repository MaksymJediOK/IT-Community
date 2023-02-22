using Ardalis.Specification;
using IT_Community.Server.Core.Entities.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Specifications
{
    public static class Answers
    {
        public class ByVacancyAndUserId : Specification<Answer>
        {
            public ByVacancyAndUserId(int vacancyId, string userId)
            {
                Query
                    .Where(x => x.VacancyId == vacancyId && x.UserId == userId);
            }
        }

        public class WithUser : Specification<Answer>
        {
            public WithUser()
            {
                Query
                    .Include(x => x.User);
            }
        }
    }
}
