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
    public class AcceptorsController : ApiController
    {
        private MyDbContext _context;

        public AcceptorsController()
        {
            _context = new MyDbContext();
        }


        public IHttpActionResult GetAcceptor(int id)
        {
            var acceptors = _context.Acceptors.SingleOrDefault(c => c.id == id);

            if (acceptors == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Acceptors, AcceptorsDto>(acceptors));

        }
        public IHttpActionResult GetDonor(string query = null)
        {
            var donorsQuery = _context.Acceptors
                  .Include(c => c.BloodType)
                  .Include(c => c.Gender);

            if (!String.IsNullOrWhiteSpace(query))
                donorsQuery = donorsQuery.Where(c => c.name.Contains(query));

            var donorsDto = donorsQuery
                .ToList()
                .Select(Mapper.Map<Acceptors, AcceptorsDto>);
            return Ok(donorsDto);
        }
        [HttpPost]
        public IHttpActionResult CreateDonor(AcceptorsDto donorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var donor = Mapper.Map<AcceptorsDto, Acceptors>(donorDto);
            _context.Acceptors.Add(donor);
            _context.SaveChanges();

            donorDto.id = donorDto.id;
            return Created(new Uri(Request.RequestUri + "/" + donor.id), donorDto);

        }
        [HttpPut]
        public void UpdateDonor(int id, AcceptorsDto donorDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var donorInDb = _context.Acceptors.SingleOrDefault(c => c.id == id);

            if (donorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(donorDto, donorInDb);

            _context.SaveChanges();
        }
        [HttpDelete]
        public void DeleteDonor(int id)
        {
            var donorInDb = _context.Acceptors.SingleOrDefault(c => c.id == id);

            if (donorInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Acceptors.Remove(donorInDb);
            _context.SaveChanges();
        }
    }
}
