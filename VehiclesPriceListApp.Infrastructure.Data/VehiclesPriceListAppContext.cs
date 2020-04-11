using VehiclesPriceListApp.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace VehiclesPriceListApp.Infrastructure.Data
{
    public class VehiclesPriceListAppContext : DbContext
    {
        public VehiclesPriceListAppContext(DbContextOptions<VehiclesPriceListAppContext> opt) 
            : base(opt) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildVehiclePriceListItem(modelBuilder);

            BuildVehicleOwner(modelBuilder);

            modelBuilder.Entity<VehicleMenufacturer>()
              .Property(m => m.Name)
              .HasMaxLength(50)
              ;

            modelBuilder.Entity<VehicleMenufacturingOrigin>()
             .Property(mo => mo.Name)
             .HasMaxLength(50)
             ;
            
            modelBuilder.Entity<VehicleStatus>()
             .Property(s => s.Name)
             .HasMaxLength(50)
             ;

            modelBuilder.Entity<VehicleType>()
             .Property(t => t.Name)
             .HasMaxLength(50)
             ;      
        }

        public DbSet<VehiclePriceListItem> VehiclePriceListItem { get; set; }
        public DbSet<VehicleMenufacturingOrigin> VehicleMenufacturingOrigin { get; set; }
        public DbSet<VehicleMenufacturer> VehicleMenufacturer { get; set; }
        public DbSet<VehicleType> VehicleType { get; set; }
        public DbSet<VehicleOwner> VehicleOwner { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        private void BuildVehiclePriceListItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehiclePriceListItem>()
               .HasOne(m => m.VehicleMenufacturer)
               .WithMany(item => item.VehiclePriceListItem)
               .HasForeignKey(id => id.VehicleMenufacturerId)
               ;

            modelBuilder.Entity<VehiclePriceListItem>()
                .HasOne(mo => mo.VehicleMenufacturingOrigin)
                .WithMany(item => item.VehiclePriceListItem)
                .HasForeignKey(id => id.VehicleMenufacturingOriginId)
                ;

            modelBuilder.Entity<VehiclePriceListItem>()
                .HasOne(o => o.VehicleOwner)
                .WithMany(item => item.VehiclePriceListItem)
                .HasForeignKey(id => id.VehicleOwnerId)
                ;

            modelBuilder.Entity<VehiclePriceListItem>()
                .Property(item => item.AskingPrice)
                .HasMaxLength(20)
                ;

            modelBuilder.Entity<VehiclePriceListItem>()
                .Property(item => item.Color)
                .HasMaxLength(50)
                ;

            modelBuilder.Entity<VehiclePriceListItem>()
              .Property(item => item.EngineType)
              .HasMaxLength(10)
              ;
        }

        private void BuildVehicleOwner(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleOwner>()
           .Property(o => o.FirstName)
           .HasMaxLength(50)
           ;

            modelBuilder.Entity<VehicleOwner>()
            .Property(o => o.LastName)
            .HasMaxLength(50)
            ;

            modelBuilder.Entity<VehicleOwner>()
            .Property(o => o.Telephone)
            .HasMaxLength(50)
            ;
        }
    }


}