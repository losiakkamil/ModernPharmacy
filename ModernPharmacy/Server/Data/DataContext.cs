using Microsoft.EntityFrameworkCore;
using ModernPharmacy.Shared.Entities;

namespace ModernPharmacy.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            modelBuilder.Entity<Pharmacy>()
                .HasOne<Address>(p => p.Address)
                .WithOne(a => a.Pharmacy)
                .HasForeignKey<Address>(a => a.PharmacyId);
            
            modelBuilder.Entity<SubstanceSubstanceCategory>()
                .HasKey(ssc => new { ssc.SubstanceId, ssc.SubstanceCategoryId });

            modelBuilder.Entity<DrugSubstance>()
                .HasKey(ssc => new { ssc.SubstanceId, ssc.DrugId });

            modelBuilder.Entity<Drug>()
                .HasOne<Product>(d => d.Product)
                .WithOne(p => p.Drug)
                .HasForeignKey<Product>(d => d.DrugId);
            
            modelBuilder.Entity<DifferentProduct>()
                .HasOne<Product>(p => p.Product)
                .WithOne(p => p.DifferentProduct)
                .HasForeignKey<Product>(d => d.DifferentProductId);

            modelBuilder.Entity<ArticleTag>()
                .HasKey(at => new { at.ArticleId, at.TagId });


            modelBuilder.Entity<ArticleTag>()
                .HasOne<Tag>(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId);

            modelBuilder.Entity<ArticleTag>()
                .HasOne<Article>(at => at.Article)
                .WithMany(article => article.ArticleTags)
                .HasForeignKey(at => at.ArticleId);

            #region HasData           

            modelBuilder.Entity<SubstanceCategory>().HasData(
                    new SubstanceCategory { Id = 1, Name = "Painkiller", Description = "Description Painkiller" },
                    new SubstanceCategory { Id = 2, Name = "Sleeping pills", Description = "Description Sleeping pills"},
                    new SubstanceCategory { Id = 3, Name = "Antihistamines", Description = "Description Antihistamines" },
                    new SubstanceCategory { Id = 4, Name = "Antypsychotic", Description = "Description Antipsychotic" }
                );

            modelBuilder.Entity<Substance>().HasData(
                    new Substance { Id = 1, Name = "Paracetamol", Description = "Description Paracetamol"  },
                    new Substance { Id = 2, Name = "Ibuprofen", Description = "Description Ibuprofen" },
                    new Substance { Id = 3, Name = "Tramadol", Description = "Description Tramadol" },
                    new Substance { Id = 4, Name = "Valeriana", Description = "Description Valeriana" },
                    new Substance { Id = 5, Name = "Zaleplon", Description = "Description Zaleplon" },
                    new Substance { Id = 6, Name = "Eszopiclone", Description = "Description Eszopiclone" },
                    new Substance { Id = 7, Name = "Cetirizine", Description = "Description Cetirizine" },
                    new Substance { Id = 8, Name = "Clemastine", Description = "Description Clemastine" },
                    new Substance { Id = 9, Name = "Dimenhydrinate", Description = "Description Dimenhydrinate" }
                );            
            
            modelBuilder.Entity<Pharmacy>().HasData(
                    new Pharmacy { Id = 1, ContactEmail = "slowik@apteka.pl", ContactNumber = "723171222", Name = "Slownik", HasPrescriptionDrugs = true  },
                    new Pharmacy { Id = 2, ContactEmail = "drugaapteka@apteka.pl", ContactNumber = "594034033", Name = "DrugaApteka", HasPrescriptionDrugs = true },
                    new Pharmacy { Id = 3, ContactEmail = "szczecinska@apteka.pl", ContactNumber = "660650444", Name = "Szczecinska", HasPrescriptionDrugs = false},
                    new Pharmacy { Id = 4, ContactEmail = "gryficka@wp.pl", ContactNumber = "594033222", Name = "Gryficka", HasPrescriptionDrugs = false },
                    new Pharmacy { Id = 5, ContactEmail = "kamil-losiak@wp.pl", ContactNumber = "730660434", Name = "ModernPharmacy", HasPrescriptionDrugs = true }
                );

            modelBuilder.Entity<Address>().HasData(
                    new Address { Id = 1, PharmacyId = 1, City = "Międzylesie", PostalCode = "57530", Street = "Graniczna 7" },
                    new Address { Id = 2, PharmacyId = 2, City = "Wrocław", PostalCode = "21599", Street = "Wolności 22c" },
                    new Address { Id = 3, PharmacyId = 3, City = "Szczecin", PostalCode = "35300", Street = "Słowiańska 3" },
                    new Address { Id = 4, PharmacyId = 4, City = "Gryfice", PostalCode = "64554", Street = "Poniatowska 4" },
                    new Address { Id = 5, PharmacyId = 5, City = "Gryfice", PostalCode = "72-300", Street = "Grunwaldzka 3" }
                );

            modelBuilder.Entity<Drug>().HasData(
                    new Drug { Id = 1, Name = "Apap", Description = "Description Apap", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 500, NumberOfTablets = 10 },
                    new Drug { Id = 2, Name = "Apap", Description = "Description Apap", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 500, NumberOfTablets = 5 },
                    new Drug { Id = 3, Name = "Apap", Description = "Description Apap", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 500, NumberOfTablets = 20 },
                    new Drug { Id = 4, Name = "Tylenol", Description = "Description Tylenol", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 500, NumberOfTablets = 100 },
                    new Drug { Id = 5, Name = "Nurofen", Description = "Description Nurofen", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 200, NumberOfTablets = 20 },
                    new Drug { Id = 6, Name = "Ibuprom", Description = "Description Ibuprom", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 200, NumberOfTablets = 10 },
                    new Drug { Id = 7, Name = "Tramal retard", Description = "Description Tramal Retard", PrescriptionRequired = true, LumpSumDrug = true, MilligramsPerTablets = 100, NumberOfTablets = 50 },
                    new Drug { Id = 8, Name = "Valeriana", Description = "Description Valeriana", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 2500, NumberOfTablets = 60 },
                    new Drug { Id = 9, Name = "Morfeo", Description = "Description Morfeo", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 10, NumberOfTablets = 10 },
                    new Drug { Id = 10, Name = "Sonata", Description = "Description Sonata", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 10, NumberOfTablets = 10 },
                    new Drug { Id = 11, Name = "Aviomarin", Description = "Description Aviomarin", PrescriptionRequired = false, LumpSumDrug = false, MilligramsPerTablets = 500, NumberOfTablets = 5 },
                    new Drug { Id = 12, Name = "Zirtec", Description = "Description Zirtec", PrescriptionRequired = true, LumpSumDrug = true, MilligramsPerTablets = 10, NumberOfTablets = 20 }
                );

            modelBuilder.Entity<SubstanceSubstanceCategory>().HasData(
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 1, SubstanceCategoryId = 1, SubstanceId = 1 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 2, SubstanceCategoryId = 1, SubstanceId = 2 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 3, SubstanceCategoryId = 1, SubstanceId = 3 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 4, SubstanceCategoryId = 2, SubstanceId = 4 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 5, SubstanceCategoryId = 2, SubstanceId = 5 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 6, SubstanceCategoryId = 2, SubstanceId = 6 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 7, SubstanceCategoryId = 3, SubstanceId = 7 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 8, SubstanceCategoryId = 3, SubstanceId = 8 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 9, SubstanceCategoryId = 3, SubstanceId = 9 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 10, SubstanceCategoryId = 4, SubstanceId = 7 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 11, SubstanceCategoryId = 4, SubstanceId = 6 },
                    new SubstanceSubstanceCategory { SubstanceSubstanceCategoryId = 12, SubstanceCategoryId = 4, SubstanceId = 4 }
                );

            modelBuilder.Entity<DrugSubstance>().HasData(
                    new DrugSubstance { DrugSubstanceId = 1, DrugId = 1, SubstanceId = 1 },
                    new DrugSubstance { DrugSubstanceId = 2, DrugId = 2, SubstanceId = 1 },
                    new DrugSubstance { DrugSubstanceId = 3, DrugId = 3, SubstanceId = 1 },
                    new DrugSubstance { DrugSubstanceId = 4, DrugId = 4, SubstanceId = 2 },
                    new DrugSubstance { DrugSubstanceId = 5, DrugId = 5, SubstanceId = 2 },
                    new DrugSubstance { DrugSubstanceId = 6, DrugId = 6, SubstanceId = 2 },
                    new DrugSubstance { DrugSubstanceId = 7, DrugId = 7, SubstanceId = 3 },
                    new DrugSubstance { DrugSubstanceId = 8, DrugId = 8, SubstanceId = 4 },
                    new DrugSubstance { DrugSubstanceId = 9, DrugId = 9, SubstanceId = 5 },
                    new DrugSubstance { DrugSubstanceId = 10, DrugId = 10, SubstanceId = 5 },
                    new DrugSubstance { DrugSubstanceId = 11, DrugId = 12, SubstanceId = 9 },
                    new DrugSubstance { DrugSubstanceId = 12, DrugId = 11, SubstanceId = 7}
                );

            modelBuilder.Entity<Tag>().HasData(
                    new Tag { Id = 1, Name = "drug" },
                    new Tag { Id = 2, Name = "sleep" },
                    new Tag { Id = 3, Name = "bacteria" },
                    new Tag { Id = 4, Name = "suplements" },
                    new Tag { Id = 5, Name = "hygiene" },
                    new Tag { Id = 6, Name = "children" },
                    new Tag { Id = 7, Name = "pain" },
                    new Tag { Id = 8, Name = "insonomia" },
                    new Tag { Id = 9, Name = "brain" },
                    new Tag { Id = 10, Name = "heart" },
                    new Tag { Id = 11, Name = "diabetes" },
                    new Tag { Id = 12, Name = "bow" },
                    new Tag { Id = 13, Name = "anxiety" },
                    new Tag { Id = 14, Name = "fatigue" },
                    new Tag { Id = 15, Name = "depression" },
                    new Tag { Id = 16, Name = "health" },
                    new Tag { Id = 17, Name = "cold" },
                    new Tag { Id = 18, Name = "flu"}
                );
            
            modelBuilder.Entity<Article>().HasData(
                    new Article { Id = 1, Title = "Antibiotics", PagePath = "Antibiotics", CreatedById = 1, CreatedDate = DateTime.Today, ImagePath = "articleImages/antibiotics.jpg", Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                    new Article { Id = 2, Title = "Nootropics", PagePath = "Nootropics", CreatedById = 1, CreatedDate = DateTime.Today, ImagePath = "articleImages/nootropics.jpg", Text = "<b>Lorem Ipsum is simply dummy text</b> of the printing<strong> and typesetting </strong> industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                    new Article { Id = 3, Title = "Painkillers", PagePath = "Painkillers", CreatedById = 1, CreatedDate = DateTime.Today, ImagePath = "articleImages/painkillers.jpg", Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                    new Article { Id = 4, Title = "Antiepileptic", PagePath = "Antiepileptic", CreatedById = 1, CreatedDate = DateTime.Today, ImagePath = "articleImages/antiepileptic.jpg", Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                    new Article { Id = 5, Title = "SleepHigiene", PagePath = "SleepHigiene", CreatedById = 1, CreatedDate = DateTime.Today, ImagePath = "articleImages/sleep.jpg", Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." },
                    new Article { Id = 6, Title = "Vitamins", PagePath = "Vitamins", CreatedById = 1, CreatedDate = DateTime.Today, ImagePath = "articleImages/vitamins.jpg", Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum." }
                    );

            modelBuilder.Entity<ArticleTag>().HasData(
                    new ArticleTag { ArticleTagId = 1, ArticleId = 1, TagId = 1 },
                    new ArticleTag { ArticleTagId = 2, ArticleId = 1, TagId = 3 },
                    new ArticleTag { ArticleTagId = 3, ArticleId = 1, TagId = 16 },
                    new ArticleTag { ArticleTagId = 4, ArticleId = 1, TagId = 18 },

                    new ArticleTag { ArticleTagId = 5, ArticleId = 2, TagId = 1 },
                    new ArticleTag { ArticleTagId = 6, ArticleId = 2, TagId = 4 },
                    new ArticleTag { ArticleTagId = 7, ArticleId = 2, TagId = 9 },

                    new ArticleTag { ArticleTagId = 8, ArticleId = 3, TagId = 1 },
                    new ArticleTag { ArticleTagId = 9, ArticleId = 3, TagId = 7 },
                    new ArticleTag { ArticleTagId = 10, ArticleId = 3, TagId = 18 },       

                    new ArticleTag { ArticleTagId = 11, ArticleId = 5, TagId = 1 },
                    new ArticleTag { ArticleTagId = 12, ArticleId = 5, TagId = 2 },
                    new ArticleTag { ArticleTagId = 13, ArticleId = 5, TagId = 8 },

                    new ArticleTag { ArticleTagId = 14, ArticleId = 6, TagId = 4 },
                    new ArticleTag { ArticleTagId = 15, ArticleId = 6, TagId = 16 },

                    new ArticleTag { ArticleTagId = 16, ArticleId = 4, TagId = 1 }
                );

            modelBuilder.Entity<DifferentProduct>().HasData(
                    new DifferentProduct { Id = 1, Name = "needle", Description = "Needle Description"},
                    new DifferentProduct { Id = 2, Name = "bandages", Description = "Bandages Description" },
                    new DifferentProduct { Id = 3, Name = "atomizer", Description = "Atomizer Description" },
                    new DifferentProduct { Id = 4, Name = "hydrogen dioxide", Description = "Hydrogen Dioxide Description" },
                    new DifferentProduct { Id = 5, Name = "bacteriostatic water", Description = "Bacteriostatic Water Description" },
                    new DifferentProduct { Id = 6, Name = "urine cup", Description = "Urine Cup Description" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { Id = 1, DrugId = 1, ProposedPrice = 17.99m },
                    new Product { Id = 2, DrugId = 2, ProposedPrice = 15.20m },
                    new Product { Id = 3, DrugId = 3, ProposedPrice = 12.59m },
                    new Product { Id = 4, DrugId = 4, ProposedPrice = 10.99m },
                    new Product { Id = 5, DrugId = 5, ProposedPrice = 2.39m },
                    new Product { Id = 6, DrugId = 6, ProposedPrice = 10.99m },
                    new Product { Id = 7, DrugId = 7, ProposedPrice = 20.29m },
                    new Product { Id = 8, DrugId = 8, ProposedPrice = 34.99m },
                    new Product { Id = 9, DrugId = 9, ProposedPrice = 23.99m },
                    new Product { Id = 10, DrugId = 10, ProposedPrice = 7.99m },
                    new Product { Id = 11, DrugId = 11, ProposedPrice = 41.99m },
                    new Product { Id = 12, DrugId = 12, ProposedPrice = 37.99m },
                    new Product { Id = 13, DifferentProductId = 1, ProposedPrice = 23.99m },
                    new Product { Id = 14, DifferentProductId = 2, ProposedPrice = 54.99m },
                    new Product { Id = 15, DifferentProductId = 3, ProposedPrice = 23.99m },
                    new Product { Id = 16, DifferentProductId = 4, ProposedPrice = 13.99m },
                    new Product { Id = 17, DifferentProductId = 5, ProposedPrice = 11.99m },
                    new Product { Id = 18, DifferentProductId = 6, ProposedPrice = 4.99m }
                );

            modelBuilder.Entity<ProductState>().HasData(
                    new ProductState { Id = 1, PharmacyId = 1, AmountOfProducts = 12, ProductId = 1, PriceForOne = 20.99m},
                    new ProductState { Id = 2, PharmacyId = 1, AmountOfProducts = 32, ProductId = 2, PriceForOne = 17.99m },
                    new ProductState { Id = 3, PharmacyId = 1, AmountOfProducts = 23, ProductId = 3, PriceForOne = 15.99m },
                    new ProductState { Id = 4, PharmacyId = 1, AmountOfProducts = 66, ProductId = 4, PriceForOne = 12.99m },
                    new ProductState { Id = 5, PharmacyId = 1, AmountOfProducts = 11, ProductId = 5, PriceForOne = 3.99m },
                    new ProductState { Id = 6, PharmacyId = 1, AmountOfProducts = 3, ProductId = 6, PriceForOne = 12.99m },
                    new ProductState { Id = 7, PharmacyId = 1, AmountOfProducts = 3, ProductId = 7, PriceForOne = 22.99m },
                    new ProductState { Id = 8, PharmacyId = 1, AmountOfProducts = 55, ProductId = 8, PriceForOne = 35.99m },
                    new ProductState { Id = 9, PharmacyId = 1, AmountOfProducts = 33, ProductId = 9, PriceForOne = 27.99m },
                    new ProductState { Id = 10, PharmacyId = 1, AmountOfProducts = 21, ProductId = 10, PriceForOne = 9.99m },
                    new ProductState { Id = 11, PharmacyId = 1, AmountOfProducts = 11, ProductId = 11, PriceForOne = 44.99m },
                    new ProductState { Id = 12, PharmacyId = 1, AmountOfProducts = 32, ProductId = 12, PriceForOne = 40.99m },
                    new ProductState { Id = 13, PharmacyId = 1, AmountOfProducts = 12, ProductId = 13, PriceForOne = 25.99m },
                    new ProductState { Id = 14, PharmacyId = 1, AmountOfProducts = 34, ProductId = 14, PriceForOne = 55.99m },
                    new ProductState { Id = 15, PharmacyId = 1, AmountOfProducts = 11, ProductId = 15, PriceForOne = 26.99m },
                    new ProductState { Id = 16, PharmacyId = 1, AmountOfProducts = 3, ProductId = 16, PriceForOne = 16.99m },
                    new ProductState { Id = 17, PharmacyId = 1, AmountOfProducts = 4, ProductId = 17, PriceForOne = 13.99m },
                    new ProductState { Id = 18, PharmacyId = 1, AmountOfProducts = 5, ProductId = 18, PriceForOne = 6.99m },

                    new ProductState { Id = 19, PharmacyId = 2, AmountOfProducts = 24, ProductId = 1, PriceForOne = 21.99m },
                    new ProductState { Id = 20, PharmacyId = 2, AmountOfProducts = 22, ProductId = 2, PriceForOne = 18.99m },
                    new ProductState { Id = 21, PharmacyId = 2, AmountOfProducts = 23, ProductId = 3, PriceForOne = 16.99m },
                    new ProductState { Id = 22, PharmacyId = 2, AmountOfProducts = 53, ProductId = 5, PriceForOne = 4.99m },
                    new ProductState { Id = 23, PharmacyId = 2, AmountOfProducts = 22, ProductId = 6, PriceForOne = 13.99m },
                    new ProductState { Id = 24, PharmacyId = 2, AmountOfProducts = 4, ProductId = 7, PriceForOne = 23.99m },
                    new ProductState { Id = 25, PharmacyId = 2, AmountOfProducts = 4, ProductId = 8, PriceForOne = 36.99m },
                    new ProductState { Id = 26, PharmacyId = 2, AmountOfProducts = 33, ProductId = 10, PriceForOne = 10.99m },
                    new ProductState { Id = 27, PharmacyId = 2, AmountOfProducts = 0, ProductId = 11, PriceForOne = 45.99m },
                    new ProductState { Id = 28, PharmacyId = 2, AmountOfProducts = 12, ProductId = 12, PriceForOne = 41.99m },
                    new ProductState { Id = 29, PharmacyId = 2, AmountOfProducts = 22, ProductId = 14, PriceForOne = 56.99m },
                    new ProductState { Id = 30, PharmacyId = 2, AmountOfProducts = 53, ProductId = 15, PriceForOne = 27.99m },
                    new ProductState { Id = 31, PharmacyId = 2, AmountOfProducts = 2, ProductId = 16, PriceForOne = 17.99m },
                    new ProductState { Id = 32, PharmacyId = 2, AmountOfProducts = 2, ProductId = 17, PriceForOne = 14.99m },
                    new ProductState { Id = 33, PharmacyId = 2, AmountOfProducts = 7, ProductId = 18, PriceForOne = 7.99m },

                    new ProductState { Id = 34, PharmacyId = 3, AmountOfProducts = 8, ProductId = 1, PriceForOne = 22.99m },
                    new ProductState { Id = 35, PharmacyId = 3, AmountOfProducts = 5, ProductId = 2, PriceForOne = 18.99m },
                    new ProductState { Id = 36, PharmacyId = 3, AmountOfProducts = 4, ProductId = 4, PriceForOne = 14.99m },
                    new ProductState { Id = 37, PharmacyId = 3, AmountOfProducts = 4, ProductId = 5, PriceForOne = 5.99m },
                    new ProductState { Id = 38, PharmacyId = 3, AmountOfProducts = 7, ProductId = 6, PriceForOne = 13.99m },
                    new ProductState { Id = 39, PharmacyId = 3, AmountOfProducts = 34, ProductId = 7, PriceForOne = 23.99m },
                    new ProductState { Id = 40, PharmacyId = 3, AmountOfProducts = 64, ProductId = 8, PriceForOne = 37.99m },
                    new ProductState { Id = 41, PharmacyId = 3, AmountOfProducts = 33, ProductId = 9, PriceForOne = 28.99m },
                    new ProductState { Id = 42, PharmacyId = 3, AmountOfProducts = 5, ProductId = 10, PriceForOne = 12.99m },
                    new ProductState { Id = 43, PharmacyId = 3, AmountOfProducts = 1, ProductId = 11, PriceForOne = 48.99m },
                    new ProductState { Id = 44, PharmacyId = 3, AmountOfProducts = 34, ProductId = 12, PriceForOne = 44.99m },
                    new ProductState { Id = 45, PharmacyId = 3, AmountOfProducts = 54, ProductId = 13, PriceForOne = 27.99m },
                    new ProductState { Id = 46, PharmacyId = 3, AmountOfProducts = 0, ProductId = 14, PriceForOne = 59.99m },
                    new ProductState { Id = 47, PharmacyId = 3, AmountOfProducts = 0, ProductId = 15, PriceForOne = 28.99m },
                    new ProductState { Id = 48, PharmacyId = 3, AmountOfProducts = 0, ProductId = 16, PriceForOne = 19.99m },
                    new ProductState { Id = 49, PharmacyId = 3, AmountOfProducts = 7, ProductId = 17, PriceForOne = 15.99m }

                );
            #endregion
            
        }
        public DbSet<SubstanceCategory> SubstanceCategories { get; set; }
        public DbSet<Substance> Substances { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<SubstanceSubstanceCategory> SubstanceSubstanceCategories { get; set; }
        public DbSet<DrugSubstance> DrugSubstances { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DifferentProduct> DifferentProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductState> ProductStates { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
    }
}
