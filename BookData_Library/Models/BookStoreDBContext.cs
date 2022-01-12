using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookData_Library.Models
{
    public partial class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
        {
        }

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BookStoreDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("Author_Id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("First_Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Last_Name");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PublishedDate)
                    .HasColumnType("date")
                    .HasColumnName("Published_Date");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.Property(e => e.Rating).HasColumnType("decimal(4, 2)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TotalPage).HasColumnName("Total_Page");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__Books__Publisher__25869641");
            });

            modelBuilder.Entity<BookAuthor>(entity =>
            {
                entity.ToTable("Book_Authors");

                entity.Property(e => e.BookAuthorId).HasColumnName("Book_Author_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Book_Auth__Book___2A4B4B5E");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.BookAuthors)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__Book_Auth__Publi__2B3F6F97");
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Book_Genre");

                entity.Property(e => e.BookGenreId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Book_Genre_Id");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.GenreId).HasColumnName("Genre_Id");

                entity.HasOne(d => d.Book)
                    .WithMany()
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__Book_Genr__Book___300424B4");

                entity.HasOne(d => d.Genre)
                    .WithMany()
                    .HasForeignKey(d => d.GenreId)
                    .HasConstraintName("FK__Book_Genr__Genre__30F848ED");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreId).HasColumnName("Genre_Id");

                entity.Property(e => e.Genre1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Genre");

                entity.Property(e => e.ParentId).HasColumnName("Parent_Id");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK__Genres__Parent_I__2E1BDC42");
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("Publisher");

                entity.Property(e => e.PublisherId).HasColumnName("Publisher_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
