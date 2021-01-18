using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using BloodBankManegmentSystem.Models;
using AutoMapper;
using BloodBankManegmentSystem.Dtos;
using System;
using System.Data.Entity;

namespace BloodBankManegmentSystem.Controllers.Api
{
    public class DonorsController : ApiController
    {
        private MyDbContext _context;

        public DonorsController()
        {
            _context = new MyDbContext();
        }

       
        public IHttpActionResult GetDonor(int id)
        {
            var donors = _context.Donors.SingleOrDefault(c => c.id == id);
            
          if(donors == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Donors, DonorsDto>(donors));

        }
        public IHttpActionResult GetDonor(string query = null)
        {
            var donorsQuery = _context.Donors
                  .Include(c => c.BloodType)
                  .Include(c => c.Gender);

            if (!String.IsNullOrWhiteSpace(query))
                donorsQuery = donorsQuery.Where(c => c.name.Contains(query));

            var donorsDto = donorsQuery
                .ToList()
                .Select(Mapper.Map<Donors, DonorsDto>);
               return Ok(donorsDto);
        }
        [HttpPost]
        public IHttpActionResult CreateDonor(DonorsDto donorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();    
            }

            var donor = Mapper.Map<DonorsDto, Donors>(donorDto);
            _context.Donors.Add(donor);
            _context.SaveChanges();

            donorDto.id = donorDto.id;
            return Created(new Uri(Request.RequestUri + "/" + donor.id), donorDto);

        }
        [HttpPut]
        public void UpdateDonor(int id, DonorsDto donorDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var donorInDb = _context.Donors.SingleOrDefault(c => c.id == id);

            if (donorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(donorDto, donorInDb);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteDonor(int id)
        {
            var donorInDb = _context.Donors.SingleOrDefault(c => c.id == id);

            if (donorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Donors.Remove(donorInDb);
            _context.SaveChanges();
        }
    }
}
