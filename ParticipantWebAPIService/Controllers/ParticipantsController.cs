using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ParticipantWebAPIService.Models;

namespace ParticipantWebAPIService.Controllers
{
    public class ParticipantsController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            ParticipantsDbEntities entities = new ParticipantsDbEntities();
            var result = entities.Participants.ToArray();
            return Json(result);
        }

        // GET api/values/5
        public Participants Get(string initials)
        {
            ParticipantsDbEntities entities = new ParticipantsDbEntities();
            return entities.Participants.FirstOrDefault(x => x.initials == initials);
        }

        [HttpDelete]
        public void Delete(string initials)
        {
            ParticipantsDbEntities entities = new ParticipantsDbEntities();
            //Participants participant = new Participants();
            var p = entities.Participants.Where(x => x.initials == initials).FirstOrDefault();
            
            entities.Participants.Remove(p);
            entities.SaveChanges();
        }

        public void Post([FromBody]Participants participants)
        {
            ParticipantsDbEntities entities = new ParticipantsDbEntities();
            entities.Participants.Add(participants);
            entities.SaveChanges();
        }
        

        public IHttpActionResult Options()
        {
            HttpContext.Current.Response.AppendHeader("Allow", "GET, OPTIONS");
            return Ok();
        }
    }
}
