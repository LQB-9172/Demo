using Microsoft.EntityFrameworkCore;

namespace test.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) : base(options)
        {

        }


        #region DbSet
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Audio> Audios { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Progress> Progresses { get; set; }
       public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        #endregion
    }
}
