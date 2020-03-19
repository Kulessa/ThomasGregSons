using CristianKulessa.ThomasGregSons.Domain.Entities;
using CristianKulessa.ThomasGregSons.Domain.Services.Interfaces;
using CristianKulessa.ThomasGregSons.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CristianKulessa.ThomasGregSons.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService service;

        public ClientesController(IClienteService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClienteModel>> Get()
        {
            try
            {
                var response = service.Select()
                    .Select(p => new ClienteModel()
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Email = p.Email,
                        Logotipo = p.Logotipo
                    }).ToList();
                if (response == null || response.Count == 0)
                {
                    return NotFound();
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<ClienteModel> Get(int id)
        {
            try
            {
                var entity = service.Select(id);
                if (entity == null)
                {
                    return NotFound();
                }
                var response = new ClienteModel()
                {
                    Id = entity.Id,
                    Nome = entity.Nome,
                    Email = entity.Email,
                    Logotipo = entity.Logotipo
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e);
                throw;
            }
        }
        [HttpPost]
        public IActionResult Post(ClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                service.Insert(
                    new Cliente
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        Email = model.Email,
                        Logotipo = model.Logotipo
                    });
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        public ActionResult Put(ClienteModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (!service.Exists(model.Id))
                {
                    return NotFound();
                }
                service.Update(new Cliente()
                {
                    Id = model.Id,
                    Nome = model.Nome,
                    Email = model.Email,
                    Logotipo = model.Logotipo
                });
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!service.Exists(model.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (service.Exists(id))
                {
                    return NotFound();
                }
                service.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
