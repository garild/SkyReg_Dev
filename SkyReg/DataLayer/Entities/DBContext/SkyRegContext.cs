namespace DataLayer.Entities.DBContext
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkyRegContext : DbContext
    {
        public SkyRegContext()
            : base(DatabaseConfig.ConnectionString)
        {
            Database.CommandTimeout = 5;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<Airplane> Airplane { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<FlightsElem> FlightsElem { get; set; }
        public DbSet<GlobalSetting> GlobalSetting { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Parachute> Parachute { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<PaymentsSetting> PaymentsSetting { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<DefinedUserType> DefinedUserType { get; set; }
        public DbSet<UsersType> UsersType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>()
                .HasMany(e => e.Flight)
                .WithOptional(e => e.Airplane)
                .HasForeignKey(e => e.Airplane_Id);

            modelBuilder.Entity<Flight>()
                .HasMany(e => e.FlightsElem)
                .WithOptional(e => e.Flight)
                .HasForeignKey(e => e.Flight_Id);

            modelBuilder.Entity<FlightsElem>()
                .HasMany(e => e.Payment)
                .WithOptional(e => e.FlightsElem)
                .HasForeignKey(e => e.FlightsElem_Id);

            modelBuilder.Entity<FlightsElem>()
                .HasMany(e => e.Parachute)
                .WithMany(e => e.FlightsElem)
                .Map(m => m.ToTable("FlightsElemParachute"));

            modelBuilder.Entity<GlobalSetting>()
                .Property(e => e.CamPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Group)
                .HasForeignKey(e => e.Group_Id);

            modelBuilder.Entity<Parachute>()
                .Property(e => e.RentValue)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Parachute>()
                .Property(e => e.AssemblyValue)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Value)
                .HasPrecision(8, 2);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Count)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PaymentsSetting>()
                .Property(e => e.Value)
                .HasPrecision(8, 2);

            modelBuilder.Entity<PaymentsSetting>()
                .Property(e => e.Count)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PaymentsSetting>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.PaymentsSetting)
                .HasForeignKey(e => e.PaymentsSetting_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.FlightsElem)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Operator)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Order)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Parachute)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.User_Id);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Payment)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DefinedUserType>()
                .Property(e => e.Value)
                .HasPrecision(8, 2);

        }
    }
}
