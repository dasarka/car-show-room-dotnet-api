using System;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using CarShowRoom.Models;
using CarShowRoom.Persistance;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CarShowRoom.Controllers.Resources
{
    [Route("/api/vehicle/{vehicleId}/photos")]
    public class PhotoController : ControllerBase
    {
        private readonly IHostingEnvironment host;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        private readonly PhotoSettings photoSettings;
        public PhotoController(
            IHostingEnvironment host,
            IVehicleRepository repository,
            IUnitOfWork uow,
            IMapper mapper,
            IOptionsSnapshot<PhotoSettings> options)
        {
            this.mapper = mapper;
            this.uow = uow;
            this.repository = repository;
            this.host = host;
            this.photoSettings = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {
            var vehicle = await repository.GetVehicle(vehicleId, includeRelated: false);
            if (vehicle == null)
            {
                return NotFound();
            }

            if (file == null)
            {
                return BadRequest("Null file");
            }

            if (file.Length == 0)
            {
                return BadRequest("Empty file");
            }

            if (file.Length > photoSettings.MaxBytes)
            {
                return BadRequest("Maximum file size exceed");
            }
            if (!photoSettings.IsSupported(file.FileName))
            {
                return BadRequest("Invalid file type");
            }

            var uploadsFolderPath = Path.Combine(host.WebRootPath, "upload");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            // generate new file name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            vehicle.Photos.Add(photo);
            await uow.CompleteAsync();

            var result = mapper.Map<Photo, PhotoResource>(photo);
            return Ok(result);
        }
    }
}