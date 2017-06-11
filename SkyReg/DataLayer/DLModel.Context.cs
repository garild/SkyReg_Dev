﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class DLModelContainer : DbContext
    {
        public DLModelContainer()
            : base()
        {
            this.Database.Connection.ConnectionString = DatabaseConfig.ConnectionString;
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Parachute>()
            //.HasOptional(p => p.FlightsElem)
            //.WithOptionalPrincipal(o => o.Parachute)
            //.Map(x => x.MapKey("FlightsElem_Id"));
        }

        public virtual DbSet<PaymentsSetting> PaymentsSetting { get; set; }
        public virtual DbSet<GlobalSetting> GlobalSetting { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<UsersType> UsersType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Airplane> Airplane { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<FlightsElem> FlightsElem { get; set; }
        public virtual DbSet<Parachute> Parachute { get; set; }
        public virtual DbSet<Group> Group { get; set; }
    }
}
