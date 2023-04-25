﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public AppliancesStoreDbContext context { get; set; }
        public ReviewController()
        {
            context = new AppliancesStoreDbContext();
        }
        [HttpGet("GetReviews")]
        public List<ReviewsProduct> GetReviews() => context.ReviewsProduct.Include(x=> x.Users).ToList();
        
    }
}
