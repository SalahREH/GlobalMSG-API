﻿using Microsoft.EntityFrameworkCore;

namespace globalmsgAPI.Models
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
            
        }
        public DbSet<Message> Messages { get; set; }
    }
}
