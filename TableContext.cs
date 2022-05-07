using FinalProjesi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProjesi.Context
{
    public class TableContext : DbContext
    {
        
        public TableContext(DbContextOptions<TableContext> options) : base(options){}
        public DbSet<Uyeler> Uyelers { get; set; }

    }
}