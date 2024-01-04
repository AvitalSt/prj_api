using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Flights : ControllerBase
    {
        private static List<Flight> flightss = new List<Flight>()
        {
            new Flight{FlightNum=100, Date=new DateTime(),LeavingTime= new DateTime(),ArrivalTime=new DateTime(),TerminalNum=50},
            new Flight{FlightNum=101, Date=new DateTime(),LeavingTime= new DateTime(),ArrivalTime=new DateTime(),TerminalNum=52}
        };
        private int countFlight = 102;
        // GET: api/<Flights>
        [HttpGet]
        public IEnumerable<Flight> Get()
        {
            return flightss;
        }

        // GET api/<Flights>/5
        [HttpGet("{flightNum}")]
        public Flight Get(int flightNum)
        {
            Flight foundFly = flightss.Find(e => e.FlightNum == flightNum);
            if (foundFly == null)
            {
                return null;
            }
            return foundFly;
        }

        // POST api/<Flights>
        [HttpPost]
   
        public Flight Post([FromBody] Flight newF)
        {
            flightss.Add(new Flight { FlightNum = countFlight, Date = newF.Date, LeavingTime = newF.LeavingTime, ArrivalTime = newF.ArrivalTime, TerminalNum = newF.TerminalNum });
            countFlight++;
            return (flightss[flightss.Count - 1]);
        }

        // PUT api/<Flights>/5
        [HttpPut("{flightNum}")]
       
        public Flight Put(int flightNum, [FromBody] Flight updateF)
        {
            int index = flightss.FindIndex((Flight e) => { return e.FlightNum == flightNum; });
            flightss[index].Date = updateF.Date;
            flightss[index].LeavingTime = updateF.LeavingTime;
            flightss[index].ArrivalTime = updateF.ArrivalTime;
            flightss[index].TerminalNum = updateF.TerminalNum;
            return updateF;
        }

        // DELETE api/<Flights>/5
        [HttpDelete("{flightNum}")]
        public void Delete(int flightNum)
        {
            int index = flightss.FindIndex((Flight e) => { return e.FlightNum == flightNum; });
            flightss.RemoveAt(index);
        }
    }
}
