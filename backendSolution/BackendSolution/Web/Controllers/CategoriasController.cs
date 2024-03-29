﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades.Almacén;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextSistema _context;

        public CategoriasController(DbContextSistema context)
        {
            _context = context;
        }

        //GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> Listar()
        {
            var categoria = await _context.Categorias.ToListAsync();
            return categoria.Select(c => new CategoriaViewModel
            {
                idcategoria = c.idcategoria,
                nombre = c.nombre,
                descripcion = c.descripcion,
                condicion = c.condicion
            });
        }
        //GET: api/Categorias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(new CategoriaViewModel
            {
                idcategoria = categoria.idcategoria,
                nombre = categoria.nombre,
                descripcion = categoria.descripcion,
                condicion = categoria.condicion
            });
        }
        public async Task<ActionResult> Actualizar([FromBody]ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.idcategoria <= 0)
            {
                return BadRequest();
            }
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == model.idcategoria);
            if (categoria == null)
            {
                return NotFound();
            }
            //El usuario solo puede modificar el nombre y la descripcion de la categoria
            categoria.nombre = model.nombre;
            categoria.descripcion = model.descripcion;

            try
            {//Cuando realiza el cambio de forma exitosa llama la funcion SaveChangeAsync
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //En caso de no poder guardar los cambios en los campos nombre descripcion
                return BadRequest();
            }
            return Ok();
        }
        //POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody]CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Categoria categoria = new Categoria
            {
                nombre = model.nombre,
                descripcion = model.descripcion,
                condicion = true
            };
            _context.Categorias.Add(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }
        //DELETE: api/Categorias/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            _context.Categorias.Remove(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            return Ok();
        }

        //PUT: api/Categorias/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute]int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            categoria.condicion = false;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();
            }
            return Ok();
        }

        //PUT: api/Categorias/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute]int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }
            categoria.condicion = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //Guardar Excepcion
                return BadRequest();
            }
            return Ok();
        }


        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }
    }
}