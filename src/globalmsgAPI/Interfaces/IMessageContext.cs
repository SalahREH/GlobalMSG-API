using globalmsgAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace globalmsgAPI.Interfaces
{
    public interface IMessageContext
    {
        DbSet<Message> Messages { get; set; }
        int SaveChanges();
    }
}
