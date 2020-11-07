using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiactlanAPI.Context
{
    public class MiactlanDbContext : DbContext
    {
        public MiactlanDbContext(DbContextOptions<MiactlanDbContext> options) : base(options)
        {
        }
    }
}
