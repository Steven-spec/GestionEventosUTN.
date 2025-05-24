using Microsoft.EntityFrameworkCore;
using Libreria.Modelo;

namespace GestionEventosAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<Ponente> Ponentes { get; set; }
        public DbSet<EventoPonente> EventoPonentes { get; set; }
        public DbSet<Participante> Participantes { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Certificado> Certificados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventoPonente>()
                .HasKey(ep => new { ep.EventoId, ep.PonenteId });

            modelBuilder.Entity<EventoPonente>()
                .HasOne(ep => ep.Evento)
                .WithMany(e => e.EventoPonentes)
                .HasForeignKey(ep => ep.EventoId);

            modelBuilder.Entity<EventoPonente>()
                .HasOne(ep => ep.Ponente)
                .WithMany(p => p.EventoPonentes)
                .HasForeignKey(ep => ep.PonenteId);

            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasPrecision(10, 2);
        }
    }
}
