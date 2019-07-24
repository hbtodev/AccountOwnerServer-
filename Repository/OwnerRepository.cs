using System;
using System.Collections.Generic;
using System.Text;
using Contracts;
using Entities;
using Entities.Models;
using Entities.ExtendedModels;
using System.Linq;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext) 
            :  base(repositoryContext)
        {

        }

        public void CreateOwner(Owner owner)
        {
            owner.Id = new Guid();
            Create(owner);
        }

        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                 .OrderBy(ow => ow.Name)
                 .ToList();
        }

        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(owner => owner.Id.Equals(ownerId))
                .DefaultIfEmpty(new Owner())                
                .FirstOrDefault();
         }

        public OwnerExtended GetOwnerWithDetails(Guid ownerId)
        {
            return new OwnerExtended(GetOwnerById(ownerId))
            {
                Accounts = RepositoryContext.Accounts.Where(a => a.OwnerId.Equals(ownerId))
            };
        }

       
    }
}
