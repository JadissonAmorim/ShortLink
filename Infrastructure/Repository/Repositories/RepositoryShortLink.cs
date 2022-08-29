using Domain.Interfaces;
using Entidades.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryShortLink : RepositoryGeneric<ShortLink>, IShortLink
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;

        public RepositoryShortLink()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Patch(int id, JsonPatchDocument Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                var ShortLink = await GetById(objeto => objeto.Id == id);
                if (ShortLink != null)
                {

                        Objeto.ApplyTo(ShortLink);
                        data.Update(ShortLink);
                        await data.SaveChangesAsync();

                }
            }
        }
       
    }
}
