using JPFigure.Entities;
using JPFigure.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace JPFigure
{
	public class JPFigureContext : DbContext
	{
		public DbSet<Figure> Figures { get; set; } = null!;
		public DbSet<Character> Characters { get; set; } = null!;
		public DbSet<Series> Series { get; set; } = null!;
		public DbSet<Manufacture> Manufactures { get; set; } = null!;
		public DbSet<User> Users { get; set; } = null!;

		static JPFigureContext()
			=> NpgsqlConnection.GlobalTypeMapper.MapEnum<FigureScale>()
												.MapEnum<FigureType>()
												.MapEnum<GundamType>();

		// để trống để tránh bị lỗi
		public JPFigureContext(DbContextOptions<JPFigureContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.HasPostgresEnum<FigureScale>()
								   .HasPostgresEnum<FigureType>()
								   .HasPostgresEnum<GundamType>()
								   .HasPostgresEnum<FigureScale>();

			modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = "Admin", Email = "admin@gmail.com", Password = "admin", Role="Admin" });
		}
	}
}
