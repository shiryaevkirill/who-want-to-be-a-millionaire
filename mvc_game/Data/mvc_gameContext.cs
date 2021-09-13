using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_game.Models;

namespace mvc_game.Data
{
    public class mvc_gameContext : DbContext
    {
        public mvc_gameContext (DbContextOptions<mvc_gameContext> options)
            : base(options)
        {
        }

        public DbSet<mvc_game.Models.Answer> Answer { get; set; }

        public DbSet<mvc_game.Models.Question> Question { get; set; }
    }
}
