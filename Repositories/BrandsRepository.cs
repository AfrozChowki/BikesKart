using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BikesKart.DbContexts;
using BikesKart.Models;

namespace BikesKart.Repositories
{
    public class BrandsRepository
    {
        private readonly BikeStoresContext _context;

        public BrandsRepository(BikeStoresContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrands()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            var brand = await _context.Brands.FindAsync(id);

            return brand;
        }

        //// PUT: api/Brands/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutBrand(int id, Brand brand)
        //{
        //    if (id != brand.BrandId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(brand).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!BrandExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Brands
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        //{
        //    _context.Brands.Add(brand);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetBrand", new { id = brand.BrandId }, brand);
        //}

        //// DELETE: api/Brands/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteBrand(int id)
        //{
        //    var brand = await _context.Brands.FindAsync(id);
        //    if (brand == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Brands.Remove(brand);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool BrandExists(int id)
        {
            return _context.Brands.Any(e => e.BrandId == id);
        }
    }
}
