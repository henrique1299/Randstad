using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Randstad.Models;

namespace Randstad.Controllers
{
    [Route("api/Coins")]
    [ApiController]
    public class CoinsController : ControllerBase
    {
        private readonly RandstadContext _context;

        public CoinsController(RandstadContext context)
        {
            _context = context;
        }

        // GET: api/Coins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coin>>> GetCoins()
        {
            return await _context.Coins.ToListAsync();
        }

        // GET: api/Coins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coin>> GetCoin(int id)
        {
            var coin = await _context.Coins.FindAsync(id);

            if (coin == null)
            {
                return NotFound();
            }

            return coin;
        }

        // POST: api/Coins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coin>> PostCoin(Coin coin)
        {
            _context.Coins.Add(coin);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCoin), new { id = coin.id }, coin);
        }

        /*           


        // PUT: api/Coins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoin(int id, Coin coin)
        {
            if (id != coin.id)
            {
                return BadRequest();
            }

            _context.Entry(coin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoinExists(id))
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
                
        // DELETE: api/Coins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoin(int id)
        {
            var coin = await _context.Coins.FindAsync(id);
            if (coin == null)
            {
                return NotFound();
            }

            _context.Coins.Remove(coin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoinExists(int id)
        {
            return _context.Coins.Any(e => e.id == id);
        }
        */
    }
}
