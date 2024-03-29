﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AbonnementsAPi.Models;
using System.Net.Http;

namespace AbonnementsAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MagazinesController : ControllerBase
    {
        private readonly AbonnementsAPIContext _context;

        public MagazinesController(AbonnementsAPIContext context)
        {
            _context = context;
            
        }

        // GET: api/Magazines
        [HttpGet]
        public object GetMagazines()
        {
          
            
                return _context.Magazines;
           
          
        }

        // GET: api/Magazines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMagazines([FromRoute] int id)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var magazines = await _context.Magazines.FindAsync(id);

            if (magazines == null)
            {
                return NotFound();
            }

            return Ok(magazines);
        }

        // PUT: api/Magazines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMagazines([FromRoute] int id, [FromBody] Magazines magazines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != magazines.magId)
            {
                return BadRequest();
            }

            _context.Entry(magazines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MagazinesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Magazines
        [HttpPost]
        public async Task<IActionResult> PostMagazines([FromBody] Magazines magazines)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Magazines.Add(magazines);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMagazines", new { id = magazines.magId }, magazines);
        }

        // DELETE: api/Magazines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMagazines([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var magazines = await _context.Magazines.FindAsync(id);
            if (magazines == null)
            {
                return NotFound();
            }

            _context.Magazines.Remove(magazines);
            await _context.SaveChangesAsync();

            return Ok(magazines);
        }

        private bool MagazinesExists(int id)
        {
            return _context.Magazines.Any(e => e.magId == id);
        }
    }
}