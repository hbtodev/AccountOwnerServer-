using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using System.Linq;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) 
            :  base(repositoryContext)
        {

        }
        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                 .OrderBy(ow => ow.Name)
                 .ToList();
        }
   
    }
}
