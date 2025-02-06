﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie.Persistence.Context;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Movie.Persistence.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Movie.Domain.Entities.Cast", b =>
                {
                    b.Property<int>("CastID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cast_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CastID"));

                    b.Property<string>("Biography")
                        .HasColumnType("text")
                        .HasColumnName("biography");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Overview")
                        .HasColumnType("text")
                        .HasColumnName("overview");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("CastID")
                        .HasName("pk_casts");

                    b.ToTable("casts", (string)null);
                });

            modelBuilder.Entity("Movie.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CategoryID")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Movie.Domain.Entities.Movie", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("movie_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MovieID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("release_date");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("integer")
                        .HasColumnName("release_year");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("MovieID")
                        .HasName("pk_movies");

                    b.ToTable("movies", (string)null);
                });

            modelBuilder.Entity("Movie.Domain.Entities.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("review_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ReviewID"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("review_date");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean")
                        .HasColumnName("status");

                    b.HasKey("ReviewID")
                        .HasName("pk_reviews");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("Movie.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("tag_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TagID"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("TagID")
                        .HasName("pk_tags");

                    b.ToTable("tags", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
