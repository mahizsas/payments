﻿using System.Collections.Concurrent;
using System.Linq;
using System.Web.Http;
using Payments.Api.Models;

namespace Payments.Api.Controllers
{
    public class ResidenceController : ApiController
    {
        private static ConcurrentBag<Residence> residents;

        public ResidenceController()
        {
            // hack to fill residents bag if it is null
            if (residents == null)
            {
                FillResidentsBag();
            }
        }
        
        public IHttpActionResult Get()
        {
            return Ok(residents);
        }

        public IHttpActionResult Get(int id)
        {
            var resident = residents.SingleOrDefault(r => r.Id == id);
            if (resident == null)
            {
                return NotFound();
            }

            return Ok(resident);
        }

        private void FillResidentsBag()
        {
            residents = new ConcurrentBag<Residence>();

            residents.Add(new Residence
            {
                Id = 2732,
                Homeowner = new Homeowner
                {
                    Name = "Mike and Leann Cordenoy",
                    Address = "2732 N Barley Sheaf Road",
                    City = "Coatesville",
                    State = "PA",
                    Zip = "19320"
                }
            });

            residents.Add(new Residence
            {
                Id = 2734,
                Homeowner = new Homeowner
                {
                    Name = "Cory and Francine Goodman",
                    Address = "2734 N Barley Sheaf Road",
                    City = "Coatesville",
                    State = "PA",
                    Zip = "19320"
                }
            });

            residents.Add(new Residence
            {
                Id = 2719,
                Homeowner = new Homeowner
                {
                    Name = "Jack Movelle",
                    Address = "21482 Avenida Modellandro",
                    City = "San Dimas",
                    State = "CA",
                    Zip = "91573"
                }
            });

            residents.Add(new Residence
            {
                Id = 2714,
                Homeowner = new Homeowner
                {
                    Name = "Jim Mentle and Melissa Sass",
                    Address = "2714 N Barley Sheaf Road",
                    City = "Coatesville",
                    State = "PA",
                    Zip = "19320"
                }
            });
        }
    }
}