namespace vessaApi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=vessaDbEntities")
        {
        }

        public virtual DbSet<chat> chats { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Toilet> Toilets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Toilet>()
                .Property(e => e.zip)
                .IsUnicode(false);

            modelBuilder.Entity<Toilet>()
                .Property(e => e.opening)
                .HasPrecision(0);

            modelBuilder.Entity<Toilet>()
                .Property(e => e.closing)
                .HasPrecision(0);

            modelBuilder.Entity<Toilet>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.Toilet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.chats)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reviews)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
