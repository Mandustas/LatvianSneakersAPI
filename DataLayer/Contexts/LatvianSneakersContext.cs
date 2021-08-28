using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Contexts
{
    public class LatvianSneakersContext : DbContext
    {
        public LatvianSneakersContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageOfOrder> ImagesOfOrder { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Lang> Langs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ProductSize>()
            //  .HasKey(e => new { e.ProductId, e.SizeId });


            modelBuilder.Entity<Banner>(
                entity =>
                {
                    entity.HasOne(d => d.Lang)
                        .WithMany(p => p.Banners)
                        .HasForeignKey("LangId");
                });
            modelBuilder.Entity<Image>(
                entity =>
                {
                    entity.HasOne(d => d.Product)
                        .WithMany(p => p.Images)
                        .HasForeignKey("ProductId");
                });
            modelBuilder.Entity<ImageOfOrder>(
                entity =>
                {
                    entity.HasOne(d => d.Order)
                        .WithMany(p => p.Images)
                        .HasForeignKey("OrderId");
                });
            modelBuilder.Entity<Product>(
                entity =>
                {
                    entity.HasOne(d => d.Brand)
                        .WithMany(p => p.Products)
                        .HasForeignKey("BrandId");
                });
            modelBuilder.Entity<Product>(
                entity =>
                {
                    entity.HasOne(d => d.Model)
                        .WithMany(p => p.Products)
                        .HasForeignKey("ModelId");
                });
            
            modelBuilder.Entity<Model>(
                entity =>
                {
                    entity.HasOne(d => d.Brand)
                        .WithMany(p => p.Models)
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict);
                });



            modelBuilder
                .Entity<Product>()
                .HasMany(c => c.Sizes)
                .WithMany(s => s.Products)
                .UsingEntity<ProductSize>(
                j => j
                    .HasOne(pt => pt.Size)
                    .WithMany(t => t.ProductSizes)
                    .HasForeignKey(pt => pt.SizeId),
                j => j
                    .HasOne(pt => pt.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(pt => pt.ProductId),
                j =>
                {
                    j.HasKey(t => new { t.ProductId, t.SizeId });
                });



            modelBuilder.Entity<Size>().HasData(
                new Size[]
                {
                    new Size { Id = 1, Value="EUR 36"},
                    new Size { Id = 2, Value="EUR 37"},
                    new Size { Id = 3, Value="EUR 38"},
                    new Size { Id = 4, Value="EUR 39"},
                    new Size { Id = 5, Value="EUR 40"},
                    new Size { Id = 6, Value="EUR 41"},
                    new Size { Id = 7, Value="EUR 42"},
                    new Size { Id = 8, Value="EUR 43"},
                    new Size { Id = 9, Value="EUR 44"},
                    new Size { Id = 10, Value="EUR 45"},
                    new Size { Id = 11, Value="EUR 46"},
                    new Size { Id = 12, Value="EUR 47"},
                });
            modelBuilder.Entity<Review>().HasData(
                new Review[]
                {
                    new Review { Id = 1, Path="https://sun9-29.userapi.com/impg/KKIKOAbrbxQ10r-leSVK6kuxNhGrT3KhwHQFHg/Em8-Ra9S0Ig.jpg?size=738x1600&quality=96&sign=f9793e2fc7b1bc0716d01f0b1038a4c9&type=album"},
                    new Review { Id = 2, Path="https://sun9-50.userapi.com/impg/QtYSdIRo6HjuGGXPwPXXUVHOdx1ioTc9LPdsDw/WnLfiUqHT5Y.jpg?size=738x1600&quality=96&sign=256f1d05f3c25c87a607c1869fe5eda7&type=album"},
                });

            modelBuilder.Entity<Brand>().HasData(
                new Brand[]
                {
                    new Brand { Id = 1, Title="Nike"},
                    new Brand { Id = 2, Title="Adidas"},
                });

            modelBuilder.Entity<Model>().HasData(
                new Model[]
                {
                    new Model { Id = 1, Title="Nike Air Force",BrandId=1},
                    new Model { Id = 2, Title="Nike Jordan",BrandId=1},
                    new Model { Id = 3, Title="Adidas Ozweego",BrandId=2},
                    new Model { Id = 4, Title="Adidas ZX",BrandId=2},
                });

            modelBuilder.Entity<Product>().HasData(
                new Product[]
                {
                    new Product { Id = 1, DateCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473).AddMinutes(20), BrandId=1, Discount=200, Title="Nike Air Force 1", IsNew=true, IsPopular=true, IsSale=false, ModelId=1, Price=250 },
                    new Product { Id = 2, DateCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473).AddMinutes(21),BrandId=1, Title="Nike Jordan 1 Low", IsNew=false, IsPopular=true, IsSale=false, ModelId=2, Price=300 },
                    new Product { Id = 3, DateCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473).AddMinutes(22), BrandId=2, Title="Adidas Ozweego Pride", IsNew=true, IsPopular=false, IsSale=false, ModelId=3, Price=500 },
                    new Product { Id = 4, DateCreate=new DateTime(2021, 5, 9, 7, 4, 48, 278, DateTimeKind.Local).AddTicks(3473).AddMinutes(23), BrandId=2, Title="Adidas ZX 750", IsNew=false, IsPopular=false, IsSale=false, ModelId=4, Price=150 },
                });


            modelBuilder.Entity<ProductSize>().HasData(
                new ProductSize[]
                {
                    new ProductSize { ProductId=1,  SizeId=6},
                    new ProductSize { ProductId=1,  SizeId=7},
                    new ProductSize { ProductId=1,  SizeId=8},
                    new ProductSize { ProductId=1,  SizeId=9},
                    new ProductSize { ProductId=2,  SizeId=5},
                    new ProductSize { ProductId=2,  SizeId=10},
                    new ProductSize { ProductId=3,  SizeId=2},
                    new ProductSize { ProductId=3,  SizeId=3},
                    new ProductSize { ProductId=3,  SizeId=4},
                    new ProductSize { ProductId=3,  SizeId=5},
                    new ProductSize { ProductId=3,  SizeId=6},
                    new ProductSize { ProductId=3,  SizeId=7},
                    new ProductSize { ProductId=4,  SizeId=12},
                });

            modelBuilder.Entity<Order>().HasData(
                new Order[]
                {
                    new Order { Id = 1 },
                    new Order { Id = 2 },
                });


            modelBuilder.Entity<Image>().HasData(
                new Image[]
                {
                    new Image { Id = 1, Path="https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album",ProductId=1},
                    new Image { Id = 2, Path="https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album",ProductId=1},
                    new Image { Id = 3, Path="https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album",ProductId=1},
                    new Image { Id = 4, Path="https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album",ProductId=2},
                    new Image { Id = 5, Path="https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album",ProductId=2},
                    new Image { Id = 6, Path="https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album",ProductId=3},
                    new Image { Id = 7, Path="https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album",ProductId=4},
                });


            modelBuilder.Entity<ImageOfOrder>().HasData(
                new ImageOfOrder[]
                {
                    new ImageOfOrder { Id = 1, Path="https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album", IsVideo=false, OrderId=1},
                    new ImageOfOrder { Id = 2, Path="https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album", IsVideo=false, OrderId=1},
                    new ImageOfOrder { Id = 3, Path="https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album", IsVideo=false, OrderId=1},
                    new ImageOfOrder { Id = 4, Path="https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album", IsVideo=true, OrderId=1},
                    new ImageOfOrder { Id = 5, Path="https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album", IsVideo=false, OrderId=2},
                    new ImageOfOrder { Id = 6, Path="https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album", IsVideo=false, OrderId=2},

                });

            modelBuilder.Entity<Banner>().HasData(
                new Banner[]
                {
                    new Banner { Id = 1, Path="https://sun2.megafon-nn.userapi.com/impg/I1FMk1QP3-5AKjE2tIz7WXpzAP7CFf2dRPpadg/tKy87HiLsCQ.jpg?size=825x350&quality=96&sign=4c339bff3d2c2a57d5d1c18bc0fff836&type=album", Order=3, LangId=1},
                    new Banner { Id = 2, Path="https://sun9-76.userapi.com/impg/rHgrE4QUq72s_vr2iG44Ds6Y5uK6ZpUrFEVg-A/a8FZaxsEnwg.jpg?size=825x350&quality=96&sign=214e12be2bea072d961169a42b1d5022&type=album", Order=2, LangId=1},
                    new Banner { Id = 3, Path="https://sun9-31.userapi.com/impg/nNE3Z4Dn-r3--b7G4sZqNvwSU5jzBxNNxg_XJA/WkIwtqBE9r0.jpg?size=825x350&quality=96&sign=e9b0d055db91b7936f364e62da99b569&type=album", Order=1, LangId=1},
                });

            modelBuilder.Entity<Lang>().HasData(
                new Lang[]
                {
                    new Lang { Id = 1, Title="en"},
                    new Lang { Id = 2, Title="ru"},
                    new Lang { Id = 3, Title="lv"},
                });
        }
    }
}
