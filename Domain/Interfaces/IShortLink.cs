using Domain.Interfaces.Generics;
using Entidades.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IShortLink : IGeneric<ShortLink>
    {
        Task Patch(int id,JsonPatchDocument objeto);
    }
}
