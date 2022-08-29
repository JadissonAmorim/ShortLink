using Domain.Interfaces;
using Entidades.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ServiceShortLink : IServiceShortLink
    {

        private readonly IShortLink _IShortLink;

        public ServiceShortLink(IShortLink IShortLink)
        {
            _IShortLink = IShortLink;
        }

        public async Task<bool> Add(ShortLink Objeto)
        {
            if (!ValidLink(Objeto.Link))
            {
                return false;
            }
            Objeto.ShortenLink = GenerateShortLink();
            await _IShortLink.Add(Objeto);
            return true;
        }


        public string GenerateShortLink()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            return finalString;
        }

        public bool ValidLink(string Link)
        {
            Uri uriResult;
            bool result = Uri.TryCreate(Link, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
    }
}
