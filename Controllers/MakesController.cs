using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarShowRoom.Controllers.Resources;
using CarShowRoom.Models;
using CarShowRoom.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarShowRoom.Controllers
{
    [Route("/api/make")]
    public class MakesController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public MakesController(AppDbContext context, IMapper mapper)
        {
            this.mapper = mapper;
            this.context = context;

        }

        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await context.Makes.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}