using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengersController : ControllerBase
    {
        private static List<Passenger> passengers = new List<Passenger>()
        {
            new Passenger{Id=1,Name="avital",CountryOrigin="israel",DestinationCountry="new york", NumBag=1},
            new Passenger{Id=2,Name="mimi",CountryOrigin="turkia",DestinationCountry="budapest", NumBag=3}
        };
        private int countId = 3;
        // GET: api/<PassengersController>
        [HttpGet]
        public IEnumerable<Passenger> Get()
        {
            return passengers;
        }

        // GET api/<PassengersController>/5
        [HttpGet("{id}")]
        public Passenger Get(int id)
        {
            Passenger foundPassenger = passengers.Find(e => e.Id == id);
            if (foundPassenger == null)
            {
                return null;
            }
            return foundPassenger;
        }

        // POST api/<PassengersController>
        [HttpPost]
        public Passenger Post([FromBody] Passenger newPassenger)
        {

            passengers.Add(new Passenger { Id = countId, Name = newPassenger.Name, CountryOrigin = newPassenger.CountryOrigin, DestinationCountry = newPassenger.DestinationCountry, NumBag = newPassenger.NumBag }); 
            countId++;
            return (passengers[passengers.Count - 1]);
        }

        // PUT api/<PassengersController>/5
        [HttpPut("{id}")]
        public Passenger Put(int id, [FromBody] Passenger updateP)
        {
            int index = passengers.FindIndex((Passenger e) => { return e.Id == id; });
            passengers[index].Name = updateP.Name;
            passengers[index].CountryOrigin = updateP.CountryOrigin;
            passengers[index].DestinationCountry = updateP.DestinationCountry;
            passengers[index].NumBag= updateP.NumBag;
            return updateP;
        }

        // DELETE api/<PassengersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            int index = passengers.FindIndex((Passenger e) => { return e.Id == id; });
            passengers.RemoveAt(index);
        }
    }
}
