using System.Data.Entity;
using Clinica.Dominio;
using Clinica.Dominio.Entidades;

namespace Clinica.Infra.Dados.Contexto
{
	public class ClinicaContexto : DbContext
	{
		public DbSet<Medico> Medicos { get; set; }

		public DbSet<Passiente> Passientes { get; set; }

		public DbSet<Consulta> Consultas { get; set; }

		public ClinicaContexto() : base("ClinicaDB")
		{
			Configuration.LazyLoadingEnabled = true;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Medico>()
				.ToTable("TBMedico");

			modelBuilder.Entity<Medico>()
				.HasKey(p => p.Id);

			modelBuilder.Entity<Medico>()
				.Property(p => p.Nome)
				  .HasColumnType("varchar")
				  .HasMaxLength(150)
				  .IsRequired();

			modelBuilder.Entity<Medico>()
				.Property(p => p.Telefone)
				  .HasColumnType("varchar")
				  .HasMaxLength(15)
				  .IsRequired();

			modelBuilder.Entity<Medico>()
				.Property(p => p.CRM)
				  .HasColumnType("varchar")
				  .HasMaxLength(15)
				  .IsRequired();

			modelBuilder.Entity<Passiente>()
				.ToTable("TBPassiente");

			modelBuilder.Entity<Passiente>()
				.HasKey(p => p.Id);

			modelBuilder.Entity<Passiente>()
				.Property(p => p.Nome)
				  .HasColumnType("varchar")
				  .HasMaxLength(150)
				  .IsRequired();

			modelBuilder.Entity<Consulta>()
				.ToTable("TBConsulta");

			modelBuilder.Entity<Consulta>()
				.HasKey(p => p.Id);

			modelBuilder.Entity<Consulta>()
			  .Property(p => p.DataConsulta)
				.HasColumnType("datetime")
				.IsRequired();

			modelBuilder.Entity<Consulta>()
				.Property(p => p.Id_Medico);

			modelBuilder.Entity<Consulta>()
				.Property(p => p.Id_Passiente);

			modelBuilder.Entity<Consulta>()
				.Property(p => p.Observacoes)
				  .HasColumnType("varchar")
				  .HasMaxLength(250);
		}
	}
}