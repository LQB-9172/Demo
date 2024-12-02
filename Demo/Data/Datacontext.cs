using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Demo.Data
{
    public class Datacontext : IdentityDbContext<AppUser>
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RefreshToken>()
            .HasOne(rt => rt.User)
            .WithMany()
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        }
        #region DbSet
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Lesson>? Lessons { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Audio>? Audios { get; set; }
        public DbSet<Exercise>? Exercises { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Progress>? Progresses { get; set; }
        public DbSet<Question>? Questions { get; set; }
        public DbSet<Test>? Tests { get; set; }
        #endregion
    }
}
