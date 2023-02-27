using Ardalis.Specification;
using IT_Community.Server.Core.Entities.Vacancies;

namespace IT_Community.Server.Infrastructure.Specifications
{
    public static class Vacancies
    {
        public class ByIdWithCompaniesAndAdmins : Specification<Vacancy>
        {
            public ByIdWithCompaniesAndAdmins(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Company)
                    .ThenInclude(x => x.Users);
            }
        }
        public class GetAllWithCompanies : Specification<Vacancy>
        {
            public GetAllWithCompanies()
            {
                Query
                    .Include(x => x.Company);
            }
        }

        public class GetAllWithCompaniesUsersCategories : Specification<Vacancy>
        {
            public GetAllWithCompaniesUsersCategories(int id)
            {
                Query
                    .Include(x => x.Company)
                    .Include(x => x.User)
                    .Include(x => x.Category);
            }
        }
    }
}
