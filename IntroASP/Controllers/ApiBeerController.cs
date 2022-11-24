﻿using IntroASP.Models;
using IntroASP.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //hereda de ControllerBase y retornará automaticamente un json
    public class ApiBeerController : ControllerBase
    {
        private readonly PubContext _context;
        public ApiBeerController(PubContext context) 
        {
            _context = context;
        }

        public async Task<List<BeerBrandViewModel>> Get() 
        {
            return await _context.Beers.Include(b=>b.Brand)
                .Select(b=>new BeerBrandViewModel
                {
                    Name = b.Name,
                    Brand = b.Brand.Name
                })
                .ToListAsync();
        }
    }
}
