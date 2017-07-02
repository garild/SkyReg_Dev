namespace DataLayer.Entities.DBContext
{
    using DataLayer.Models;
    using System.Data.Entity;

    public partial class SkyRegContext : DbContext
    {
        public SkyRegContext()
            : base(DatabaseConfig.ConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

       
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<DefinedUserType> DefinedUserType { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightsElem> FlightsElem { get; set; }
        public virtual DbSet<GlobalSetting> GlobalSetting { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Parachute> Parachute { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentsSetting> PaymentsSetting { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<ReportedUsers> ReportedUsers { get; set; }
        public virtual DbSet<Supervisors> Supervisors { get; set; }

        //public virtual DbSet<UsersType> UsersType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>()
                .HasMany(e => e.Flight)
                .WithOptional(e => e.Airplane)
                .HasForeignKey(e => e.Airplane_Id);

            modelBuilder.Entity<DefinedUserType>()
                .Property(e => e.Value)
                .HasPrecision(8, 2);

            modelBuilder.Entity<DefinedUserType>()
                .HasMany(e => e.User)
                .WithMany(e => e.DefinedUserType)
                .Map(m => { m.ToTable("UsersType");
                    m.MapLeftKey("DefinedUserType_Id");
                    m.MapRightKey("User_Id");
                    });

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

            modelBuilder.Entity<FlightsElem>()
              .HasMany(e => e.Parachute)
              .WithMany(e => e.FlightsElem);

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
        }

    }
}
