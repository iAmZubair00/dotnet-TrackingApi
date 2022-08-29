using Core.Entities;
using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class IssueRepository : Repository<Issue>, IIssueRepository
    {
        public IssueRepository(PlutoContext context)
            : base(context)
        {
        }


        public PlutoContext PlutoContext
        {
            get { return Context as PlutoContext; }
        }
    }
}