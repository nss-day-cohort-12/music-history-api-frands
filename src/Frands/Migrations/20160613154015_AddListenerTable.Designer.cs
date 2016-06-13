using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Frands.Models;

namespace Frands.Migrations
{
    [DbContext(typeof(FrandsDbContext))]
    [Migration("20160613154015_AddListenerTable")]
    partial class AddListenerTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20901")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Frands.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlbumName");

                    b.Property<string>("AlbumsHref");

                    b.Property<string>("Artist");

                    b.Property<string>("YearReleased");

                    b.HasKey("AlbumId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Frands.Models.Listener", b =>
                {
                    b.Property<int>("ListenerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmailAddress");

                    b.Property<string>("UserName");

                    b.HasKey("ListenerId");

                    b.ToTable("Listener");
                });

            modelBuilder.Entity("Frands.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<string>("Artist");

                    b.Property<int>("ListenerId");

                    b.Property<string>("Title");

                    b.Property<string>("TracksHref");

                    b.HasKey("TrackId");

                    b.ToTable("Track");
                });
        }
    }
}
