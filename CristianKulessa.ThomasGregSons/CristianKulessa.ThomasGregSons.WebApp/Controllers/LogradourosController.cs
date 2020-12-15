using CristianKulessa.ThomasGregSons.Domain.Entities;
using CristianKulessa.ThomasGregSons.Domain.Services;
using CristianKulessa.ThomasGregSons.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CristianKulessa.ThomasGregSons.WebApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogradourosController : ControllerBase
    {
        private readonly LogradouroService service;

        public LogradourosController(LogradouroService service)
        {
            this.service = service;
        }
        [HttpGet("{clienteId}")]
        public ActionResult<IEnumerable<LogradouroModel>> Get(int clienteId)
        {
            try
            {
                var response = service.Select()
                    .Where(p => p.ClienteId == clienteId)
                    .Select(p => new LogradouroModel()
                    {
                        Id = p.Id,
                        ClienteId = p.ClienteId,
                        Nome = p.Nome,
                        Numero = p.Numero,
                        Complemento = p.Complemento,
                        Bairro = p.Bairro,
                        Cidade = p.Cidade,
                        Estado = p.Estado
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
        [HttpGet]
        public ActionResult<LogradouroModel> Get(int clienteId, int id)
        {
            try
            {
                var entity = service.Select(clienteId, id);
                if (entity == null)
                {
                    return NotFound();
                }
                var response = new LogradouroModel()
                {
                    Id = entity.Id,
                    ClienteId = entity.ClienteId,
                    Nome = entity.Nome,
                    Numero = entity.Numero,
                    Complemento = entity.Complemento,
                    Bairro = entity.Bairro,
                    Cidade = entity.Cidade,
                    Estado = entity.Estado
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
        public IActionResult Post(LogradouroModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                service.Insert(
                    new Logradouro
                    {
                        Id = model.Id,
                        ClienteId = model.ClienteId,
                        Nome = model.Nome,
                        Numero = model.Numero,
                        Complemento = model.Complemento,
                        Bairro = model.Bairro,
                        Cidade = model.Cidade,
                        Estado = model.Estado
                    });
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut]
        public ActionResult Put(LogradouroModel model)
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
                service.Update(new Logradouro()
                {
                    Id = model.Id,
                    ClienteId = model.ClienteId,
                    Nome = model.Nome,
                    Numero = model.Numero,
                    Complemento = model.Complemento,
                    Bairro = model.Bairro,
                    Cidade = model.Cidade,
                    Estado = model.Estado
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
