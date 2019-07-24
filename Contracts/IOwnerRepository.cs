using Entities.Models;
using Entities.ExtendedModels;
using System.Collections.Generic;
using System;


namespace Contracts
{
    public interface IOwnerRepository : IRepositoryBase<Owner>
    {
        IEnumerable<Owner> GetAllOwners();
        Owner GetOwnerById(Guid ownerId);
        OwnerExtended GetOwnerWithDetails(Guid ownerId);
    }
}