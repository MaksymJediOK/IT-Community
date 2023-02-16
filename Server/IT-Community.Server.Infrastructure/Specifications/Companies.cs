using Ardalis.Specification;
using IT_Community.Server.Core.Entities.Vacancies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT_Community.Server.Infrastructure.Specifications
{
    public static class Companies
    {
        public class ByName : Specification<Company>
        {
            public ByName(string name)
            {
                Query
                    .Where(x => x.Name == name);
            }
        }

        public class ByIdWithUsers : Specification<Company>
        {
            public ByIdWithUsers(int id)
            {
                Query
                    .Where(x => x.Id == id)
                    .Include(x => x.Users);
            }
        }
    }
}
