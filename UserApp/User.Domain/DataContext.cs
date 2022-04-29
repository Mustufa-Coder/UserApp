namespace User.Domain
{
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {
        // protected readonly IConfiguration Configuration;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .ToTable("Users");

            modelBuilder.Entity<User>()
                        .Property(s => s.Age)
                        .IsRequired(false);

            modelBuilder.Entity<User>()
                        .Property(s => s.FirstName)
                        .HasMaxLength(250)
                        .IsRequired();

            modelBuilder.Entity<User>()
                        .Property(s => s.LastName)
                        .HasMaxLength(250)
                        .IsRequired();

            modelBuilder.Entity<User>()
                        .Property(s => s.Email)
                        .HasMaxLength(250)
                        .IsRequired();

            modelBuilder.Entity<User>()
                        .HasData(
                             new User {Id = 1, FirstName = "Mustufa", LastName = "Udegadhwala", Age = 27, Email = "mustufa@gmail.com"},
                             new User {Id = 2, FirstName = "Naresh", LastName  = "Parmar", Age      = 32, Email = "naresh@gmail.com"}
                         );
        }

        public DbSet<User> Users { get; set; }
    }
}