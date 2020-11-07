using MiactlanAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MiactlanAPI.Context
{
    public class MiactlanDbContext : IdentityDbContext<Usuario>
    {
        public MiactlanDbContext(DbContextOptions<MiactlanDbContext> options) : base(options)
        {
        }
    }
}
