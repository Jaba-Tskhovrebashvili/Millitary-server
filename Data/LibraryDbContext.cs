using Microsoft.EntityFrameworkCore;
using MillitaryService.Models;

namespace MillitaryService.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Personnel> Personnel { get; set; }
        public DbSet<Ranks> Ranks { get; set; }
        public DbSet<MilitaryUnits> MilitaryUnits { get; set; }
        public DbSet<UnitTypes> UnitTypes { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<PersonnelAssignments> PersonnelAssignments { get; set; }
        public DbSet<LeaveRequests> LeaveRequests { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<PersonnelCourses> PersonnelCourses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Personnel>()
            .HasIndex(a => a.PersonalNumber)
            .IsUnique(true);

            modelBuilder.Entity<Personnel>()
            .HasOne(p => p.Rank)
            .WithMany()
            .HasForeignKey(p => p.RankId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MilitaryUnits>()
            .HasOne(p => p.UnitType)
            .WithMany()
            .HasForeignKey(p => p.UnitTypeId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MilitaryUnits>()
            .HasOne(p => p.ParentUnit)
            .WithMany(p => p.SubUnits)
            .HasForeignKey(p => p.ParentUnitId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonnelAssignments>()
            .HasOne(p => p.Personnel)
            .WithMany()
            .HasForeignKey(p => p.PersonnelId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<PersonnelAssignments>()
            .HasOne(p => p.militaryUnit)
            .WithMany()
            .HasForeignKey(p => p.MilitaryUnitId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonnelAssignments>()
            .HasOne(p => p.position)
            .WithMany()
            .HasForeignKey(p => p.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LeaveRequests>()
            .HasOne(p => p.Personnel)
            .WithMany()
            .HasForeignKey(p => p.PersonnelId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonnelCourses>()
            .HasOne(p => p.Personnel)
            .WithMany()
            .HasForeignKey(p => p.PersonnelId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PersonnelCourses>()
             .HasOne(p => p.Course)
             .WithMany()
             .HasForeignKey(p => p.CourseId)
             .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
