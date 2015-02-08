using EduPortal.Core.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduPortal.Core.EF
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
            : base("EduPortal")
        {
            //Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext,//EduPortal.Core.EF>());
        }
        public ApplicationDbContext(string db_name)
            : base(db_name)
        {
            //Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, System.Data.Entity.ModelConfiguration.Configuration>());
        }

        public DbSet<SchoolBranch> SchoolBranches { get; set; }

        public DbSet<ClassLevel> ClassLevel { get; set; }

        public DbSet<Subject> Subject { get; set; }

        public DbSet<Lecture> Lecture { get; set; }

        public DbSet<AcademicSession> AcademicSession { get; set; }

        public DbSet<AssessmentScore> AssessmentScore { get; set; }

        public DbSet<AttendanceEntry> AttendanceEntry { get; set; }

        public DbSet<Custodian> Custodian { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<StudentSubject> StudentSubject { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Configuration conf = new Configuration();
        //    base.OnModelCreating(modelBuilder);
        //}
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
