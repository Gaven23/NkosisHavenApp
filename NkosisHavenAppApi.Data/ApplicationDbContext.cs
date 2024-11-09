using Microsoft.EntityFrameworkCore;
using NkosisHavenAppApi.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace NkosisHavenAppApi.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		internal DbSet<Patient> Artefact { get; set; }
		internal DbSet<Appointment> DocumentLogs { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Patient>(entity =>
			{
				entity.HasKey(e => e.PatientId);
			});

			modelBuilder.Entity<Appointment>(entity =>
			{
				entity.HasKey(e => e.AppointmentId);
			});
		}
	}
}