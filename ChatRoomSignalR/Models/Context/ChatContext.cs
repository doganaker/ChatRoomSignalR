using ChatRoomSignalR.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatRoomSignalR.Models.Context
{
    public class ChatContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=localhost\SQLEXPRESS;database=ChatDB;trusted_connection=true;");
        }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
