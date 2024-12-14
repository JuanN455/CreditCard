using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditCard.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly CreditCardDbContext dbContext;
        public CreditCardController(CreditCardDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("CardList")]
        public async Task<IActionResult> Get()
        {
            var cardList = await dbContext.CreditCards.ToListAsync();
            return StatusCode(StatusCodes.Status200OK, cardList);
        }
        [HttpGet]
        [Route("Get/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var Card = await dbContext.CreditCards.FirstOrDefaultAsync(e => e.Id == id);
            return StatusCode(StatusCodes.Status200OK, Card);
        }
        [HttpPost   ]
        [Route("New")]
        public async Task<IActionResult> New([FromBody] ViewModel.CreditCardViewModel newObject)
        {

            try
            {
                var card = new Models.CreditCard()
                {
                    Id = Guid.NewGuid(),
                    CardholderName = newObject.CardholderName,
                    CardNumber = newObject.CardNumber,
                    ExpiryDate = newObject.ExpiryDate,
                    Cvv = newObject.Cvv,
                };
                await dbContext.CreditCards.AddAsync(card);
                await dbContext.SaveChangesAsync();
                return StatusCode(201, card);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] Models.CreditCard newObject)
        {
            dbContext.CreditCards.Update(newObject);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { massege = "ok" });
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var Card = await dbContext.CreditCards.FirstOrDefaultAsync(e => e.Id == id);
            dbContext.CreditCards.Remove(Card);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, new { massege = "ok" });
        }

    }
}
