using System;
using System.Collections.Generic;
using System.Data.Entity;
using GyandhaaraLibrary.DataModel;
using System.IO;
using System.Drawing;
using System.Web;
using System.Linq;

namespace GyandhaaraLibrary.Data
{
    public class DataContextInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            base.Seed(context);
            try
            {
                AddGenreData(context);
                AddLanguageData(context);
                AddAddressData(context);
                AddSupplierData(context);
                AddPhotoData(context);
                AddBookData(context);
            }
            catch (Exception ex)
            {
            }
        }

        private void AddGenreData(DataContext context)
        {
            List<Genre> genrelist = new List<Genre>
            {
                new Genre { Name = "Health & Wellness", CreatedOn = DateTime.Now, CreatedBy=1},
                new Genre { Name = "Computer & Programming", CreatedOn = DateTime.Now, CreatedBy=1},
                new Genre { Name = "History", CreatedOn = DateTime.Now, CreatedBy=1},
                new Genre { Name = "Romance", CreatedOn = DateTime.Now, CreatedBy=1},
            };
            genrelist.ForEach(x => context.Genre.Add(x));
            context.SaveChanges();
        }

        private void AddLanguageData(DataContext context)
        {
            List<Language> languagelist = new List<Language>
            {
                new Language { Name = "English", CreatedOn = DateTime.Now, CreatedBy=1},
                new Language { Name = "Hindi", CreatedOn = DateTime.Now, CreatedBy=1},
                new Language { Name = "Marathi", CreatedOn = DateTime.Now, CreatedBy=1},
                new Language { Name = "Telugu", CreatedOn = DateTime.Now, CreatedBy=1},
            };
            languagelist.ForEach(x => context.Language.Add(x));
            context.SaveChanges();
        }

        private void AddAddressData(DataContext context)
        {
            List<Address> addressList = new List<Address>
            {
                new Address { Street = "Madhapur", City = "Hyderabad", State= "Telangana", Country ="India", ZipCode = "500081",  CreatedOn = DateTime.Now, CreatedBy =1},
                new Address { Street = "Swargate", City = "Pune", State= "Maharastra", Country ="India", ZipCode = "411042",  CreatedOn = DateTime.Now, CreatedBy =1, },
                new Address { Street = "Shivaji chowk", City = "solapur", State= "Maharastra", Country ="India", ZipCode = "413228",  CreatedOn = DateTime.Now, CreatedBy =1 }
            };
            addressList.ForEach(x => context.Address.Add(x));
            context.SaveChanges();
        }

        private void AddSupplierData(DataContext context)
        {
            List<Supplier> supplierlist = new List<Supplier>
            {
                 new Supplier
                {
                    Name = "GyanDhaara Book Store",
                    Email ="support@gyandhaara.com",
                    Contact ="123",
                    CreatedOn = DateTime.Now,
                    CreatedBy =1,
                    AddressID = 1
                },
                  new Supplier
                {
                    Name = "Kalpana Book Store",
                    Email ="kalpanab",
                    Contact ="123",
                    CreatedOn = DateTime.Now,
                    CreatedBy =1,
                    AddressID = 2
                },
                   new Supplier
                {
                    Name = "Ankita Book Store",
                    Email ="ankitabookstore@gmail.com",
                    Contact ="123",
                    CreatedOn = DateTime.Now,
                    CreatedBy =1,
                    AddressID = 3
                },
            };
            supplierlist.ForEach(x => context.Supplier.Add(x));
            context.SaveChanges();
        }

        private void AddPhotoData(DataContext context)
        {
            List<Photo> photoList = new List<Photo>
            {
                new Photo {  FileName ="yoga", Image =getFileBytes("\\Content\\booksImages\\yoga.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="sohum", Image =getFileBytes("\\Content\\booksImages\\sohum.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="csharp6", Image =getFileBytes("\\Content\\booksImages\\csharp6.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="manualtesting", Image =getFileBytes("\\Content\\booksImages\\manualtesting.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="dawnkiss", Image =getFileBytes("\\Content\\booksImages\\dawnkiss.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="lovestories", Image =getFileBytes("\\Content\\booksImages\\lovestories.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="ufo", Image =getFileBytes("\\Content\\booksImages\\ufo.png"),  CreatedOn = DateTime.Now, CreatedBy=1},
                new Photo {  FileName ="aleingods", Image =getFileBytes("\\Content\\booksImages\\aleingods.png"),  CreatedOn = DateTime.Now, CreatedBy=1}
            };
            photoList.ForEach(x => context.Photo.Add(x));
            context.SaveChanges();
        }

        private void AddBookData(DataContext context)
        {
            List<Book> bookList = new List<Book>
            {
                new Book //add new book with photo ID =1
                {
                    Code="20161015",
                    Title = "YOGA STORIES",
                    Description="5 stories on the yoga",
                    Edition = "1st",
                    Isbn="2016-10-15",
                    TotalPages=145,
                    Author="balaji Hambeere",
                    Price = 150.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate = DateTime.Today.AddDays(45),
                    EntryDate = DateTime.Now,
                    RackNumber =1,
                    PurchasedBy = "Hambeere",
                    GenreID =1,
                    SupplierID =1,
                    LanguageID=4,
                    PhotoID = 1,
                    CreatedOn = DateTime.Now,
                    CreatedBy =1
                },
                new Book//add new book with photo ID =2
                {
                    Code="20161016",
                    Title = "SOHUM YOGAM",
                    Description="Inhale exhale technique",
                    Edition = "1st",
                    Isbn="2016-10-16",
                    TotalPages=45,
                    Author="balaji Hambeere",
                    Price = 200.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(60),
                    EntryDate = DateTime.Now,
                    RackNumber =1,
                    PurchasedBy = "Hambeere",
                    GenreID =1,
                    SupplierID =1,
                    LanguageID=4,
                    PhotoID = 2,
                    CreatedOn = DateTime.Today.AddDays(1),
                    CreatedBy =1
                },
                new Book //add new book with photo ID =3
                {
                    Code="20161017",
                    Title = "C# 6.0",
                    Description="C# Framework 6.0",
                    Edition = "1st",
                    Isbn="2016-10-17",
                    TotalPages=45,
                    Author="balaji Hambeere",
                    Price = 160.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(50),
                    EntryDate = DateTime.Now,
                    RackNumber =2,
                    PurchasedBy = "Hambeere",
                    GenreID =2,
                    SupplierID =2,
                    LanguageID=1,
                    PhotoID = 3,
                    CreatedOn = DateTime.Today.AddDays(2),
                    CreatedBy =1
                },
                new Book //add new book with photo ID =4
                {
                    Code="20161017",
                    Title = "Manual Testing",
                    Description="Manual Testing",
                    Edition = "1st",
                    Isbn="2016-10-17",
                    TotalPages=45,
                    Author="Ankita Hambeere",
                    Price = 180.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(50),
                    EntryDate = DateTime.Now,
                    RackNumber =2,
                    PurchasedBy = "Hambeere",
                    GenreID =2,
                    SupplierID =2,
                    LanguageID=1,
                    PhotoID = 4,
                    CreatedOn = DateTime.Today.AddDays(2),
                    CreatedBy =1
                },
                new Book //add new book with photo ID =5
                {
                    Code="20161018",
                    Title = "A Dawn Kiss",
                    Description="Kiss at morning",
                    Edition = "1st",
                    Isbn="2016-10-18",
                    TotalPages=130,
                    Author="Balaji Hambeere",
                    Price = 400.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(30),
                    EntryDate = DateTime.Now,
                    RackNumber =4,
                    PurchasedBy = "Hambeere",
                    GenreID =2,
                    SupplierID =2,
                    LanguageID=2,
                    PhotoID = 5,
                    CreatedOn = DateTime.Today.AddDays(3),
                    CreatedBy =1
                },
                   new Book //add new book with photo ID =6
                {
                    Code="20161018",
                    Title = "Love stories",
                    Description="Love stories",
                    Edition = "1st",
                    Isbn="2016-10-18",
                    TotalPages=120,
                    Author="Balaji Hambeere",
                    Price = 110.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(30),
                    EntryDate = DateTime.Now,
                    RackNumber =4,
                    PurchasedBy = "Hambeere",
                    GenreID =2,
                    SupplierID =2,
                    LanguageID=2,
                    PhotoID = 6,
                    CreatedOn = DateTime.Today.AddDays(3),
                    CreatedBy =1
                },

                new Book //add new book with photo ID =7
                {
                    Code="20161018",
                    Title = "ufo",
                    Description="Unidentified flying objects",
                    Edition = "1st",
                    Isbn="2016-10-18",
                    TotalPages=45,
                    Author="Ankita Hambeere",
                    Price = 180.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(80),
                    EntryDate = DateTime.Now,
                    RackNumber =3,
                    PurchasedBy = "Hambeere",
                    GenreID =2,
                    SupplierID =2,
                    LanguageID=2,
                    PhotoID = 7,
                    CreatedOn = DateTime.Today.AddDays(3),
                    CreatedBy =1
                },
                new Book //add new book with photo ID =8
                {
                    Code="20161018",
                    Title = "Alein Gods",
                    Description="Alein Gods",
                    Edition = "1st",
                    Isbn="2016-10-18",
                    TotalPages=45,
                    Author="Ankita Hambeere",
                    Price = 180.00M,
                    Publisher="Gyandhaara.com",
                    PublishDate =  DateTime.Today.AddDays(80),
                    EntryDate = DateTime.Now,
                    RackNumber =3,
                    PurchasedBy = "Hambeere",
                    GenreID =2,
                    SupplierID =2,
                    LanguageID=2,
                    PhotoID = 8,
                    CreatedOn = DateTime.Today.AddDays(3),
                    CreatedBy =1
                }
            };
            bookList.ForEach(x => context.Book.Add(x));
            context.SaveChanges();
        }

        #region Image
        public byte[] imageToByteArray(Image imageIn, string fileName)
        {
            Image newImage = Image.FromFile(fileName);
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
        #endregion
    }
}
