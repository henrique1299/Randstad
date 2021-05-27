using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Randstad.Models;

namespace Randstad.Controllers
{
    [Route("api/Convert")]
    [ApiController]
    public class ConvertController : ControllerBase
    {
        private readonly RandstadContext _context;

        public ConvertController(RandstadContext context)
        {
            _context = context;
        }

        // GET: api/Convert
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Convert>>> GetConvert()
        {
            return await _context.Convert.ToListAsync();
        }

        // GET: api/Convert/90-70
        [HttpGet("{id1}-{id2}")]
        public async Task<ActionResult<Models.Convert>> GetConvert(int id1, int id2)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.coinlore.net/api/ticker/?id=" + id1);
                WebResponse response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);

                String responseFromServer = reader.ReadToEnd();

                double price1 = getPrice(responseFromServer);

                request = (HttpWebRequest)WebRequest.Create("https://api.coinlore.net/api/ticker/?id=" + id2);
                response = request.GetResponse();
                dataStream = response.GetResponseStream();

                reader = new StreamReader(dataStream);

                responseFromServer = reader.ReadToEnd();

                double price2 = getPrice(responseFromServer);

                response.Close();

                double convertRate = price2 / price1;

                Models.Convert convert = new Models.Convert();

                convert.id1 = id1;
                convert.id2 = id2;
                convert.converted = Math.Round((price1 * convertRate), 2);

                return convert;
            }
            catch
            {
                return BadRequest();
            }
        }
        public double getPrice(string json)
        {
            var coin = JsonSerializer.Deserialize<List<Rootobject>>(json);

            return double.Parse(coin[0].price_usd, CultureInfo.InvariantCulture);
        }

        /*
        // PUT: api/Convert/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConvert(int id, Models.Convert convert)
        {
            if (id != convert.convertId)
            {
                return BadRequest();
            }

            _context.Entry(convert).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConvertExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Convert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Models.Convert>> PostConvert(Models.Convert convert)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.coinlore.net/api/ticker/?id=" + convert.id1);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();

            StreamReader reader = new StreamReader(dataStream);

            String responseFromServer = reader.ReadToEnd();

            double price1 = getPrice(responseFromServer);

            request = (HttpWebRequest)WebRequest.Create("https://api.coinlore.net/api/ticker/?id=" + convert.id2);
            response = request.GetResponse();
            dataStream = response.GetResponseStream();

            reader = new StreamReader(dataStream);

            responseFromServer = reader.ReadToEnd();

            double price2 = getPrice(responseFromServer);

            response.Close();

            double convertRate = price1 / price2;

            price1 *= convertRate;

            return CreatedAtAction(nameof(GetConvert), new { id = convert.convertId }, convert);
        }
 

        // DELETE: api/Convert/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConvert(int id)
        {
            var convert = await _context.Convert.FindAsync(id);
            if (convert == null)
            {
                return NotFound();
            }

            _context.Convert.Remove(convert);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConvertExists(int id)
        {
            return _context.Convert.Any(e => e.convertId == id);
        }
        */
    }
}
