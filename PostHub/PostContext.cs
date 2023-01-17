using Microsoft.EntityFrameworkCore;
using PostHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostHub
{
    public class PostContext : DbContext
    {
        public DbSet<PostModel> Posts { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PostHubDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(cs);
        }
    }
}
