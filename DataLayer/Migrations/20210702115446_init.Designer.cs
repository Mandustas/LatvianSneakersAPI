﻿// <auto-generated />
using System;
using DataLayer.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations
{
    [DbContext(typeof(LatvianSneakersContext))]
    [Migration("20210702115446_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataLayer.Models.Banner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Banners");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Order = 3,
                            Path = "https://sun2.megafon-nn.userapi.com/impg/I1FMk1QP3-5AKjE2tIz7WXpzAP7CFf2dRPpadg/tKy87HiLsCQ.jpg?size=825x350&quality=96&sign=4c339bff3d2c2a57d5d1c18bc0fff836&type=album"
                        },
                        new
                        {
                            Id = 2,
                            Order = 2,
                            Path = "https://sun9-76.userapi.com/impg/rHgrE4QUq72s_vr2iG44Ds6Y5uK6ZpUrFEVg-A/a8FZaxsEnwg.jpg?size=825x350&quality=96&sign=214e12be2bea072d961169a42b1d5022&type=album"
                        },
                        new
                        {
                            Id = 3,
                            Order = 1,
                            Path = "https://sun9-31.userapi.com/impg/nNE3Z4Dn-r3--b7G4sZqNvwSU5jzBxNNxg_XJA/WkIwtqBE9r0.jpg?size=825x350&quality=96&sign=e9b0d055db91b7936f364e62da99b569&type=album"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Nike"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Adidas"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Path = "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            Path = "https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            Path = "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 4,
                            Path = "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 5,
                            Path = "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 6,
                            Path = "https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 7,
                            Path = "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album",
                            ProductId = 4
                        });
                });

            modelBuilder.Entity("DataLayer.Models.ImageOfOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsVideo")
                        .HasColumnType("bit");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("ImagesOfOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsVideo = false,
                            OrderId = 1,
                            Path = "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album"
                        },
                        new
                        {
                            Id = 2,
                            IsVideo = false,
                            OrderId = 1,
                            Path = "https://sun9-65.userapi.com/impg/2oNBWX3eqqEZ-o9Hh1HSViKyat8mHpAXBqVt0Q/IIba8yAhB4w.jpg?size=255x255&quality=96&sign=2cc1025050face68687b16b92a5efedf&type=album"
                        },
                        new
                        {
                            Id = 3,
                            IsVideo = false,
                            OrderId = 1,
                            Path = "https://sun9-11.userapi.com/impg/86sOSCeIWARW-BcX901uyA2Ob8_Wr0lfTC_WeA/xTSPOHIb6Hg.jpg?size=255x255&quality=96&sign=54f21ebc92f37effa881f973758fd95f&type=album"
                        },
                        new
                        {
                            Id = 4,
                            IsVideo = true,
                            OrderId = 1,
                            Path = "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album"
                        },
                        new
                        {
                            Id = 5,
                            IsVideo = false,
                            OrderId = 2,
                            Path = "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album"
                        },
                        new
                        {
                            Id = 6,
                            IsVideo = false,
                            OrderId = 2,
                            Path = "https://sun9-54.userapi.com/impg/JLpJr7cUWS6bCnNVYCW3SprZuCgPg1RTXiXhAg/V0Y-Nv518mY.jpg?size=255x255&quality=96&sign=6f2419d7cbde4448f6d47875e431d918&type=album"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Models");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Title = "Nike Air Force"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Title = "Nike Jordan"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 2,
                            Title = "Adidas Ozweego"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            Title = "Adidas ZX"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPopular")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSale")
                        .HasColumnType("bit");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            DateCreate = new DateTime(2021, 5, 9, 7, 24, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            Discount = 200m,
                            IsNew = true,
                            IsPopular = true,
                            IsSale = false,
                            ModelId = 1,
                            Price = 250m,
                            Title = "Nike Air Force 1"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            DateCreate = new DateTime(2021, 5, 9, 7, 25, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            Discount = 0m,
                            IsNew = false,
                            IsPopular = true,
                            IsSale = false,
                            ModelId = 2,
                            Price = 300m,
                            Title = "Nike Jordan 1 Low"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 2,
                            DateCreate = new DateTime(2021, 5, 9, 7, 26, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            Discount = 0m,
                            IsNew = true,
                            IsPopular = false,
                            IsSale = false,
                            ModelId = 3,
                            Price = 500m,
                            Title = "Adidas Ozweego Pride"
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 2,
                            DateCreate = new DateTime(2021, 5, 9, 7, 27, 48, 278, DateTimeKind.Local).AddTicks(3473),
                            Discount = 0m,
                            IsNew = false,
                            IsPopular = false,
                            IsSale = false,
                            ModelId = 4,
                            Price = 150m,
                            Title = "Adidas ZX 750"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.ProductSize", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "SizeId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductSizes");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            SizeId = 6
                        },
                        new
                        {
                            ProductId = 1,
                            SizeId = 7
                        },
                        new
                        {
                            ProductId = 1,
                            SizeId = 8
                        },
                        new
                        {
                            ProductId = 1,
                            SizeId = 9
                        },
                        new
                        {
                            ProductId = 2,
                            SizeId = 5
                        },
                        new
                        {
                            ProductId = 2,
                            SizeId = 10
                        },
                        new
                        {
                            ProductId = 3,
                            SizeId = 2
                        },
                        new
                        {
                            ProductId = 3,
                            SizeId = 3
                        },
                        new
                        {
                            ProductId = 3,
                            SizeId = 4
                        },
                        new
                        {
                            ProductId = 3,
                            SizeId = 5
                        },
                        new
                        {
                            ProductId = 3,
                            SizeId = 6
                        },
                        new
                        {
                            ProductId = 3,
                            SizeId = 7
                        },
                        new
                        {
                            ProductId = 4,
                            SizeId = 12
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Path = "https://sun9-29.userapi.com/impg/KKIKOAbrbxQ10r-leSVK6kuxNhGrT3KhwHQFHg/Em8-Ra9S0Ig.jpg?size=738x1600&quality=96&sign=f9793e2fc7b1bc0716d01f0b1038a4c9&type=album"
                        },
                        new
                        {
                            Id = 2,
                            Path = "https://sun9-50.userapi.com/impg/QtYSdIRo6HjuGGXPwPXXUVHOdx1ioTc9LPdsDw/WnLfiUqHT5Y.jpg?size=738x1600&quality=96&sign=256f1d05f3c25c87a607c1869fe5eda7&type=album"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = "EUR 36"
                        },
                        new
                        {
                            Id = 2,
                            Value = "EUR 37"
                        },
                        new
                        {
                            Id = 3,
                            Value = "EUR 38"
                        },
                        new
                        {
                            Id = 4,
                            Value = "EUR 39"
                        },
                        new
                        {
                            Id = 5,
                            Value = "EUR 40"
                        },
                        new
                        {
                            Id = 6,
                            Value = "EUR 41"
                        },
                        new
                        {
                            Id = 7,
                            Value = "EUR 42"
                        },
                        new
                        {
                            Id = 8,
                            Value = "EUR 43"
                        },
                        new
                        {
                            Id = 9,
                            Value = "EUR 44"
                        },
                        new
                        {
                            Id = 10,
                            Value = "EUR 45"
                        },
                        new
                        {
                            Id = 11,
                            Value = "EUR 46"
                        },
                        new
                        {
                            Id = 12,
                            Value = "EUR 47"
                        },
                        new
                        {
                            Id = 13,
                            Value = "EUR 48"
                        });
                });

            modelBuilder.Entity("DataLayer.Models.Image", b =>
                {
                    b.HasOne("DataLayer.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataLayer.Models.ImageOfOrder", b =>
                {
                    b.HasOne("DataLayer.Models.Order", "Order")
                        .WithMany("Images")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DataLayer.Models.Model", b =>
                {
                    b.HasOne("DataLayer.Models.Brand", "Brand")
                        .WithMany("Models")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.HasOne("DataLayer.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Model", "Model")
                        .WithMany("Products")
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Model");
                });

            modelBuilder.Entity("DataLayer.Models.ProductSize", b =>
                {
                    b.HasOne("DataLayer.Models.Product", "Product")
                        .WithMany("ProductSizes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataLayer.Models.Size", "Size")
                        .WithMany("ProductSizes")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DataLayer.Models.Brand", b =>
                {
                    b.Navigation("Models");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Model", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataLayer.Models.Order", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("DataLayer.Models.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ProductSizes");
                });

            modelBuilder.Entity("DataLayer.Models.Size", b =>
                {
                    b.Navigation("ProductSizes");
                });
#pragma warning restore 612, 618
        }
    }
}
