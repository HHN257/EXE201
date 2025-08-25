using Microsoft.EntityFrameworkCore;
using SmartTravel.Domain.Entities;

namespace SmartTravel.Infrastructure.Data
{
    public class SmartTravelDbContext : DbContext
    {
        public SmartTravelDbContext(DbContextOptions<SmartTravelDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceReview> ServiceReviews { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<TourGuide> TourGuides { get; set; }
        public DbSet<TourGuideReview> TourGuideReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure User entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Configure Category entity
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
            });

            // Configure Service entity
            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.ProviderName).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Services)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure ServiceReview entity
            modelBuilder.Entity<ServiceReview>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Rating).IsRequired();
                entity.HasOne(e => e.Service)
                    .WithMany(s => s.Reviews)
                    .HasForeignKey(e => e.ServiceId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Booking entity
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.BookingReference).IsRequired().HasMaxLength(100);
                entity.HasIndex(e => e.BookingReference).IsUnique();
                entity.HasOne(e => e.User)
                    .WithMany(u => u.Bookings)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Service)
                    .WithMany(s => s.Bookings)
                    .HasForeignKey(e => e.ServiceId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure UserPreference entity
            modelBuilder.Entity<UserPreference>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PreferenceKey).IsRequired().HasMaxLength(100);
                entity.HasOne(e => e.User)
                    .WithMany(u => u.UserPreferences)
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure CurrencyRate entity
            modelBuilder.Entity<CurrencyRate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FromCurrency).IsRequired().HasMaxLength(10);
                entity.Property(e => e.ToCurrency).IsRequired().HasMaxLength(10);
                entity.Property(e => e.Rate).IsRequired();
                entity.HasIndex(e => new { e.FromCurrency, e.ToCurrency }).IsUnique();
            });

            // Configure TourGuide entity
            modelBuilder.Entity<TourGuide>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(150);
                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            // Configure TourGuideReview entity
            modelBuilder.Entity<TourGuideReview>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Rating).IsRequired();
                entity.HasOne(e => e.TourGuide)
                    .WithMany(tg => tg.Reviews)
                    .HasForeignKey(e => e.TourGuideId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Accommodation", Description = "Hotel booking services", Icon = "hotel", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Transportation", Description = "Local transportation services", Icon = "car", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Food & Dining", Description = "Food delivery and restaurant services", Icon = "restaurant", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Entertainment", Description = "Entertainment and leisure activities", Icon = "entertainment", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Long Distance Travel", Description = "Inter-city transportation", Icon = "bus", DisplayOrder = 5 }
            );

            // Seed data for Services
            modelBuilder.Entity<Service>().HasData(
                // Accommodation
                new Service { Id = 1, Name = "Traveloka", Description = "Book hotels, flights, and activities", ProviderName = "Traveloka", CategoryId = 1, IsPopular = true, DisplayOrder = 1 },
                new Service { Id = 2, Name = "Klook", Description = "Travel experiences and activities", ProviderName = "Klook", CategoryId = 1, IsPopular = true, DisplayOrder = 2 },
                new Service { Id = 3, Name = "Agoda", Description = "Hotel booking platform", ProviderName = "Agoda", CategoryId = 1, DisplayOrder = 3 },
                
                // Transportation
                new Service { Id = 4, Name = "Grab", Description = "Ride-hailing and food delivery", ProviderName = "Grab", CategoryId = 2, IsPopular = true, DisplayOrder = 1 },
                new Service { Id = 5, Name = "Be", Description = "Vietnamese ride-hailing app", ProviderName = "Be", CategoryId = 2, DisplayOrder = 2 },
                new Service { Id = 6, Name = "XanhSM", Description = "Electric taxi service", ProviderName = "XanhSM", CategoryId = 2, DisplayOrder = 3 },
                new Service { Id = 7, Name = "BusMap", Description = "Public bus information", ProviderName = "BusMap", CategoryId = 2, DisplayOrder = 4 },
                
                // Food & Dining
                new Service { Id = 8, Name = "GrabFood", Description = "Food delivery service", ProviderName = "Grab", CategoryId = 3, IsPopular = true, DisplayOrder = 1 },
                new Service { Id = 9, Name = "ShopeeFood", Description = "Food delivery platform", ProviderName = "Shopee", CategoryId = 3, DisplayOrder = 2 },
                new Service { Id = 10, Name = "BeFood", Description = "Food delivery service", ProviderName = "Be", CategoryId = 3, DisplayOrder = 3 },
                
                // Entertainment
                new Service { Id = 11, Name = "CGV Cinemas", Description = "Movie ticket booking", ProviderName = "CGV", CategoryId = 4, DisplayOrder = 1 },
                new Service { Id = 12, Name = "Lotte Cinema", Description = "Movie ticket booking", ProviderName = "Lotte", CategoryId = 4, DisplayOrder = 2 },
                
                // Long Distance Travel
                new Service { Id = 13, Name = "Phương Trang", Description = "Inter-city bus service", ProviderName = "Phương Trang", CategoryId = 5, DisplayOrder = 1 },
                new Service { Id = 14, Name = "Limousine", Description = "Premium bus service", ProviderName = "Limousine", CategoryId = 5, DisplayOrder = 2 }
            );

            // Seed data for Currency Rates
            modelBuilder.Entity<CurrencyRate>().HasData(
                new CurrencyRate { Id = 1, FromCurrency = "VND", ToCurrency = "USD", Rate = 0.000041m, LastUpdated = DateTime.UtcNow },
                new CurrencyRate { Id = 2, FromCurrency = "VND", ToCurrency = "EUR", Rate = 0.000038m, LastUpdated = DateTime.UtcNow },
                new CurrencyRate { Id = 3, FromCurrency = "VND", ToCurrency = "JPY", Rate = 0.0061m, LastUpdated = DateTime.UtcNow },
                new CurrencyRate { Id = 4, FromCurrency = "VND", ToCurrency = "KRW", Rate = 0.054m, LastUpdated = DateTime.UtcNow },
                new CurrencyRate { Id = 5, FromCurrency = "VND", ToCurrency = "GBP", Rate = 0.000032m, LastUpdated = DateTime.UtcNow }
            );
        }
    }
}
