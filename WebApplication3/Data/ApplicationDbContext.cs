using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AparatViewModel> Aparaty { get; set; }
        public DbSet<AparatKategoria> Kategorie { get; set; }
        public DbSet<ObiektywViewModel> Obiektywy { get; set; }
        public DbSet<Bagnet> Bagnety { get; set; }
    }
}

