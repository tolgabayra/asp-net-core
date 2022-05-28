using InternetProgramlamaFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace InternetProgramlamaFinal.Context
{
    public class TableContext : DbContext
    {
        public TableContext(DbContextOptions<TableContext> options) : base(options){}
        
        public DbSet<Uyeler> Uyelers { get; set; }
        public DbSet<Kurslar> Kurslars { get; set; }
        public DbSet<Etkinlikler> Etkinliklers { get; set; }
        public DbSet<Egitmenler> Egitmenlers { get; set; }
        public DbSet<Salonlar> Salonlars { get; set; }
        public DbSet<User> Users { get; set; }


    }
}