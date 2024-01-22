using globalmsgAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace globalmsgAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageContext _messageContext;
        public MessageController(MessageContext messageContext)
        {
            _messageContext = messageContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
            if (_messageContext.Messages == null)
            {
                return NotFound();
            }
            return await _messageContext.Messages.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(int id)
        {
            if (_messageContext.Messages == null)
            {
                return NotFound();
            }
            var message = await _messageContext.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound(id);
            }
            return message;
        }

        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            _messageContext.Messages.Add(message);
            await _messageContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMessages), new { id = message.ID }, message);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutMessage(int id, Message message)
        {
            if(id != message.ID)
            {
                return BadRequest();
            }
            _messageContext.Entry(message).State = EntityState.Modified;
            try
            {
                await _messageContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            if(_messageContext.Messages == null)
            {
                return NotFound();
            }
            var message = await _messageContext.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound(id);
            }
            _messageContext.Messages.Remove(message);
            await _messageContext.SaveChangesAsync();
            return Ok();
        }

    }
}
