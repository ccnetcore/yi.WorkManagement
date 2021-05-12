using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CC.GraduationProject.Model
{
    public partial class DataContext :DbContext
    {
        public DbSet<student> student { get; set; }
        public DbSet<teacher> teacher { get; set; }
        public DbSet<comment> comment { get; set; }
        public DbSet<curriculum> curriculum { get; set; }
        public DbSet<discuss> discuss { get; set; }
        public DbSet<student__curriculum> student__curriculum { get; set; }
        public DbSet<student__work> student__work { get; set; }
        public DbSet<work> work { get; set; }
        public DbSet<version> version { get; set; }
        public DbSet<question_choice> question_choice { get; set; }
        public DbSet<question_fill> question_fill { get; set; }
        public DbSet<question_judgment> question_judgment { get; set; }
    }
}