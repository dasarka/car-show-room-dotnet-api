using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using CarShowRoom.Models;

namespace CarShowRoom.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        [Required]
        public ContactResource Contact { get; set; }
        public ICollection<int> Features { get; set; }

        // Todo: should be removed
        // public Model Model { get; set; }
        // public DateTime LastUpdate { get; set; }


        public VehicleResource()
        {
            Features = new Collection<int>();
        }
    }
}