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
    [Route("/api/feature")]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IFeatureRepository repository;

        public FeaturesController(IMapper mapper, IFeatureRepository repository)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<KeyValuePairResource>> GetFeatures()
        {
            var features = await repository.GetFeatures();

            return mapper.Map<List<Feature>, List<KeyValuePairResource>>(features);
        }
    }
}