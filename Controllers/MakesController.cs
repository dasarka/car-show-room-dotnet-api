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
        private readonly IMapper mapper;
        private readonly IMakeRepository repository;

        public MakesController(IMapper mapper, IMakeRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;

        }

        [HttpGet]
        public async Task<IEnumerable<MakeResource>> GetMakes()
        {
            var makes = await repository.GetMakes();

            return mapper.Map<List<Make>, List<MakeResource>>(makes);
        }
    }
}