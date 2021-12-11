using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Odev3_Data;
using Odev3_Data.DTOs;
using Odev3_Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace Odev3_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [LoginControl(new int[] {1,2})]
        public IActionResult GetAll(string email, string password)
        {
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(_context.Products.ToList()));
        }

        [HttpGet("{Id}")]
        [LoginControl(new int[] { 1, 2 })]
        public IActionResult GetById(int Id, string email, string password)
        {
            if (_context.Products.Any(x => x.Id == Id))
            {
                return Ok(_mapper.Map<ProductDTO>(_context.Products.Single(x => x.Id == Id)));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [LoginControl(new int[] { 1, 2 })]
        public IActionResult AddProduct([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        [LoginControl(new int[] { 1 })]
        public IActionResult DeleteProduct(int Id, string email, string password)
        {
            if (_context.Products.Any(x => x.Id == Id))
            {
                Product product = _context.Products.Single(y => y.Id == Id);
                _context.Products.Remove(product);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{Id}")]
        [LoginControl(new int[] { 1 })]
        public IActionResult UpdateProduct([FromBody] ProductDTO productDTO, int Id)
        {
            if (_context.Products.Any(x => x.Id == Id))
            {
                Product updatedProduct = _context.Products.Single(x => x.Id == Id);
                productDTO.Id = Id;
                _mapper.Map<Product>(productDTO);
                _mapper.Map<ProductDTO, Product>(productDTO, updatedProduct);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
