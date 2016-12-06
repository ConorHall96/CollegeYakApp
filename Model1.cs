namespace CollegeYakApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ALERT> ALERTs { get; set; }
        public virtual DbSet<COLLEGE> COLLEGEs { get; set; }
        public virtual DbSet<FOLLOWING> FOLLOWINGs { get; set; }
        public virtual DbSet<MEMBER> MEMBERs { get; set; }
        public virtual DbSet<POST> POSTs { get; set; }
        public virtual DbSet<REPORT> REPORTs { get; set; }
        public virtual DbSet<VOTE> VOTEs { get; set; }
        public virtual DbSet<POST_VIEW> POST_VIEW { get; set; }
        public virtual DbSet<VOTEDOWN_VIEW> VOTEDOWN_VIEW { get; set; }
        public virtual DbSet<VOTEUP_VIEW> VOTEUP_VIEW { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ALERT>()
                .Property(e => e.ALERT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ALERT>()
                .Property(e => e.ALERT_TYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ALERT>()
                .Property(e => e.ALERTED_USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<ALERT>()
                .Property(e => e.POST_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<ALERT>()
                .HasOptional(e => e.VOTE)
                .WithRequired(e => e.ALERT);

            modelBuilder.Entity<ALERT>()
                .HasOptional(e => e.REPORT)
                .WithRequired(e => e.ALERT);

            modelBuilder.Entity<ALERT>()
                .HasOptional(e => e.MEMBER1)
                .WithMany(e => e.ALERTs1);

            modelBuilder.Entity<COLLEGE>()
                .Property(e => e.COLLEGE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE>()
                .Property(e => e.ABBREVIATION)
                .IsUnicode(false);

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.POSTs)
                .WithRequired(e => e.COLLEGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<COLLEGE>()
                .HasMany(e => e.MEMBERs)
                .WithRequired(e => e.COLLEGE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FOLLOWING>()
                .Property(e => e.FOLLOWING_ID)
                .IsUnicode(false);

            modelBuilder.Entity<FOLLOWING>()
                .Property(e => e.FOLLOWING_UN)
                .IsUnicode(false);

            modelBuilder.Entity<FOLLOWING>()
                .Property(e => e.FOLLOWER_UN)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.COLLEGE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.CONFIRM_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.ACTIVE_ACCOUNT)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .Property(e => e.LOGGED_IN)
                .IsUnicode(false);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.ALERTs)
                .WithOptional(e => e.MEMBER)
                .HasForeignKey(e => e.ALERTED_USERNAME);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.FOLLOWINGs)
                .WithOptional(e => e.MEMBER)
                .HasForeignKey(e => e.FOLLOWER_UN);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.FOLLOWINGs1)
                .WithOptional(e => e.MEMBER1)
                .HasForeignKey(e => e.FOLLOWING_UN);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.POSTs)
                .WithRequired(e => e.MEMBER)
                .HasForeignKey(e => e.USERNAME_OP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.VOTEs)
                .WithRequired(e => e.MEMBER)
                .HasForeignKey(e => e.USERNAME_POSTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.REPORTs)
                .WithOptional(e => e.MEMBER)
                .HasForeignKey(e => e.USERNAME_REPORTER);

            modelBuilder.Entity<MEMBER>()
                .HasMany(e => e.VOTEs1)
                .WithRequired(e => e.MEMBER1)
                .HasForeignKey(e => e.USERNAME_VOTER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.POST_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<POST>()
                .Property(e => e.COLLEGE_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.USERNAME_OP)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.VISIBILITY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<REPORT>()
                .Property(e => e.REPORT_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<REPORT>()
                .Property(e => e.USERNAME_REPORTER)
                .IsUnicode(false);

            modelBuilder.Entity<VOTE>()
                .Property(e => e.VOTE_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VOTE>()
                .Property(e => e.POST_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VOTE>()
                .Property(e => e.USERNAME_VOTER)
                .IsUnicode(false);

            modelBuilder.Entity<VOTE>()
                .Property(e => e.USERNAME_POSTER)
                .IsUnicode(false);

            modelBuilder.Entity<VOTE>()
                .Property(e => e.VOTE_TYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<POST_VIEW>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<POST_VIEW>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<VOTEDOWN_VIEW>()
                .Property(e => e.USERNAME_VOTER)
                .IsUnicode(false);

            modelBuilder.Entity<VOTEDOWN_VIEW>()
                .Property(e => e.POST_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VOTEDOWN_VIEW>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<VOTEDOWN_VIEW>()
                .Property(e => e.Total_Down_Votes)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VOTEUP_VIEW>()
                .Property(e => e.USERNAME_VOTER)
                .IsUnicode(false);

            modelBuilder.Entity<VOTEUP_VIEW>()
                .Property(e => e.POST_ID)
                .HasPrecision(38, 0);

            modelBuilder.Entity<VOTEUP_VIEW>()
                .Property(e => e.DETAILS)
                .IsUnicode(false);

            modelBuilder.Entity<VOTEUP_VIEW>()
                .Property(e => e.Total_Up_Votes)
                .HasPrecision(38, 0);
        }
    }
}
