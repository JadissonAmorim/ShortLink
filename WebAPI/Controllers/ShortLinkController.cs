using AutoMapper;
using Domain.Interfaces;
using Domain.Services;
using Entidades.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DTOs;

namespace WebAPI.Controllers
{
    public class ShortLinkController : Controller
    {
        private readonly IMapper _IMapper;
        private readonly IShortLink _IShortLink;
        private readonly IServiceShortLink _IServiceShortLink;


        public ShortLinkController(IMapper iMapper, IShortLink iShortLink, IServiceShortLink iServiceShortLink)
        {
            _IMapper = iMapper;
            _IShortLink = iShortLink;
            _IServiceShortLink = iServiceShortLink;
        }

        [Produces("application/json")]
        [HttpPost("/api/Add")]

        public async Task<ActionResult<ShortLink>> Add([FromBody] ShortLinkDTO ShortLinkDto)
        {
            var shortLink = _IMapper.Map<ShortLink>(ShortLinkDto);
            var result = await _IServiceShortLink.Add(shortLink);
            if (!result)
            {
                return BadRequest("Informe um link válido");
            }
            return Ok("https://localhost:7269/api/" + shortLink.ShortenLink);
        }

        [Produces("application/json")]
        [HttpGet("/api/{shortlink}")]

        public async Task<ActionResult> RedirectLink([FromRoute] string shortlink)
        {
            var link = await _IShortLink.GetById(p => p.ShortenLink.Contains(shortlink));
            if (link == null)
            {

                return BadRequest();
            }
            var linkredirect = link.Link;
            return Redirect(linkredirect);
        }

        [Produces("application/json")]
        [HttpGet("/api/List")]
        public async Task<ActionResult<List<ShortLink>>> List()
        {
            var Links = await _IShortLink.List();
            return Links;
        }

        [Produces("application/json")]
        [HttpDelete("/api/Delete/{id}")]
        public async Task<ActionResult<ShortLinkDTO>> Delete(int id)
        {
            var ShortLink = await _IShortLink.GetById(shortlink => shortlink.Id == id);
            if (ShortLink == null)
            {
                return BadRequest($"{id} não encontrado.");
            }
            await _IShortLink.Delete(ShortLink);
            return Ok();
        }

        [Produces("application/json")]
        [HttpPatch("/api/Patch/{id}")]
        public async Task<ActionResult> Patch([FromRoute] int id, [FromBody] JsonPatchDocument link)
        {
            
            await _IShortLink.Patch(id, link);
            return Ok();
        }
    }

}
