using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Dominio;


namespace Persistencia;
public class IncidenceContext : DbContext {
    public IncidenceContext(DbContextOptions<IncidenceContext> options) : base(options) { 

    }
        public DbSet<User> ?Users { get; set; }
        public DbSet<Person> ?Persons { get; set; }
        public DbSet<TypeIncidence> ? TypeIncedences { get; set; }
        public DbSet<State> ? State { get; set; }
        public DbSet<Rol> ? Rols { get; set; }
        public DbSet<Place> ? Places { get; set; }
        public DbSet<Peripheral> ? Peripherals { get; set; }
        public DbSet<LevelIncidence> ? LevelIncidences { get; set; }
        public DbSet<Incidence> ? Incidence { get; set; }
        public DbSet<DocumentType> ? DocumentTypes { get; set; }
        public DbSet<DetailIncidence> ? DetailIncidences { get; set; }
        public DbSet<ContactType> ? ContactTypes { get; set; }
        public DbSet<Contact> ? Contacts { get; set; }
        public DbSet<CategoryContact> ? CategoryContacts { get; set; }
        public DbSet<AreaUser> ? AreaUsers { get; set; }
        public DbSet<Area> ? Areas { get; set; }
        public DbSet<Address> ? Addresses { get; set; }
        public DbSet<City> ? Cities { get; set; }
        public DbSet<Region> ? Regions { get; set; }
        public DbSet<Country> ? Countries { get; set; }

        

       protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}