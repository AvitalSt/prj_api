using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PilotsController : ControllerBase
    {
        private static List<Pilot> Pilots = new List<Pilot>()
        {
            new Pilot{Id =1, Name = "avi",NumWorker=10,Vetek=5 ,Company="el al"},
            new Pilot{Id =2, Name = "dani",NumWorker=11,Vetek=6 ,Company="arkia"},
            new Pilot{Id =3, Name = "simi",NumWorker=12,Vetek=7 ,Company="mmm"},
        };
        private int countId = 4;
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Pilot> Get()
        {
            return Pilots;
        }

        // GET api/<EventsController>/5
        [HttpGet("{id}")]
        public Pilot Get(int id)
        {
            Pilot foundPilot = Pilots.Find(e => e.Id == id);
            if (foundPilot == null) {
                return null; }
            return foundPilot;
        }

        // POST api/<EventsController>
        [HttpPost]
        public Pilot Post([FromBody] Pilot newPilot)
        {
            Pilots.Add(new Pilot { Id = countId, Name = newPilot.Name, NumWorker = newPilot.NumWorker, Vetek = newPilot.Vetek, Company = newPilot.Company);
            countId++;
            return (Pilots[Pilots.Count -1]);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public Pilot Put(int id, [FromBody] Pilot updatePilot)
        {
            int index = Pilots.FindIndex((Pilot e) => { return e.Id == id; });
            Pilots[index].Name=updatePilot.Name;
            Pilots[index].NumWorker=updatePilot.NumWorker;
            Pilots[index].Vetek=updatePilot.Vetek;  
            Pilots[index].Company=updatePilot.Company;
            return updatePilot;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = Pilots.FindIndex((Pilot e) => { return e.Id == id; });
            Pilots.RemoveAt(index);
        }
    }
}
