using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CreditcardApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrediCardAppController : ControllerBase
    {
        private readonly CreditCardDBContext _context;
        public CrediCardAppController(CreditCardDBContext context)
        {
            _context = context;            
        }

        // GET: api/CreditCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCardDetail>>> GetCreditCard()
        {

            //var creditcarddetails= await _context.CreditCardDetails.OrderByDescending(x => x.Id).ToListAsync();
            //if (_context.CreditCardDetails == null || creditcarddetails.Count==0)
            //{
            //    return NotFound();
            //}
            //return creditcarddetails;

            if (_context.CreditCardDetails == null)
            {
                return NotFound();
            }
            return await _context.CreditCardDetails.OrderByDescending(x => x.Id).ToListAsync();
        }

        // GET: api/CreditCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCardDetail>> GetCreditCard(int id)
        {
            if (_context.CreditCardDetails == null)
            {
                return NotFound();
            }
            var creditCard = await _context.CreditCardDetails.FindAsync(id);

            if (creditCard == null)
            {
                return NotFound();
            }

            return creditCard;
        }
        // POST: api/CreditCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreditCardDetail>> PostCreditCard(CreditCardDetail creditCard)
        {
            if (_context.CreditCardDetails == null)
            {
                return Problem("Entity set 'ASPNetCore_ReactJs_CRUDContext.CreditCard'  is null.");
            }
            _context.CreditCardDetails.Add(creditCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCreditCard", new { id = creditCard.Id }, creditCard);
        }

        // PUT: api/CreditCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCreditCard(int id, CreditCardDetail creditCard)
        {
            if (id != creditCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(creditCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CreditCardExists(id))
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
        private bool CreditCardExists(int id)
        {
            return (_context.CreditCardDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // DELETE: api/CreditCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCreditCard(int id)
        {
            if (_context.CreditCardDetails == null)
            {
                return NotFound();
            }
            var creditCard = await _context.CreditCardDetails.FindAsync(id);
            if (creditCard == null)
            {
                return NotFound();
            }

            _context.CreditCardDetails.Remove(creditCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
