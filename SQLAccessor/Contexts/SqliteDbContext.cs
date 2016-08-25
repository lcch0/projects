using System.Data.Entity;
using SQLAccessor.Mappings;

namespace SQLAccessor.Contexts
{
	public class SqliteDbContext : DbContext
	{
		public SqliteDbContext(string configString) : base(configString)
		{
			
		}

		public DbSet<User> User { get; set; }
		public DbSet<Project> Project { get; set; }
		public DbSet<Activity> Activity { get; set; }
		public DbSet<Draft> Draft { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<User>().HasKey(t => t.UserId);
			modelBuilder.Entity<Project>().HasKey(t => t.Id);
			modelBuilder.Entity<Activity>().HasKey(t => t.Id);
			modelBuilder.Entity<Draft>().HasKey(t => t.Id);

			//proj to activity
			modelBuilder.Entity<Project>().HasMany(t => t.Activities);
		}
	}
}
