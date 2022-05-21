using API_C.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_C.ICollections
{
    interface IRolesCollection
    {
        Task<Roles> GetRol(string id);
    }
}
