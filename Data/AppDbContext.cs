using Microsoft.EntityFrameworkCore;
using reservations_api.Models.Entities;

namespace reservations_api.Data;

public class AppDbContext : DbContext
{
    private static readonly Guid ClassroomA101Id = Guid.Parse("11111111-1111-1111-1111-111111111111");
    private static readonly Guid ClassroomB202Id = Guid.Parse("22222222-2222-2222-2222-222222222222");
    private static readonly Guid ClassroomLab01Id = Guid.Parse("33333333-3333-3333-3333-333333333333");
    private static readonly Guid UserRachelId = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");
    private static readonly Guid UserStudentId = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Classroom> Classrooms => Set<Classroom>();
    public DbSet<Reservation> Reservations => Set<Reservation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(user => user.Email)
            .IsUnique();

        modelBuilder.Entity<Reservation>()
            .HasOne(reservation => reservation.User)
            .WithMany(user => user.Reservations)
            .HasForeignKey(reservation => reservation.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(reservation => reservation.Classroom)
            .WithMany(classroom => classroom.Reservations)
            .HasForeignKey(reservation => reservation.ClassroomId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = UserRachelId,
                Name = "Rachel Student",
                Email = "rachel@demo.edu",
                Password = "123456"
            },
            new User
            {
                Id = UserStudentId,
                Name = "Alex Student",
                Email = "alex@demo.edu",
                Password = "123456"
            });

        modelBuilder.Entity<Classroom>().HasData(
            new Classroom
            {
                Id = ClassroomA101Id,
                Name = "A-101",
                Capacity = 30,
                Location = "Building A - First Floor"
            },
            new Classroom
            {
                Id = ClassroomB202Id,
                Name = "B-202",
                Capacity = 40,
                Location = "Building B - Second Floor"
            },
            new Classroom
            {
                Id = ClassroomLab01Id,
                Name = "LAB-01",
                Capacity = 25,
                Location = "Engineering Labs"
            });
    }
}
