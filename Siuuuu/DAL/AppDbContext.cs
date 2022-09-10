using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestorauntWebAppp.Models.Buy;
using Siuuuu.Models.Account;
using Siuuuu.Models.Adres;
using Siuuuu.Models.Booking;
using Siuuuu.Models.Buy;
using Siuuuu.Models.Curious;
using Siuuuu.Models.Customer;
using Siuuuu.Models.Cv;
using Siuuuu.Models.HomePage;
using Siuuuu.Models.Karoke;
using Siuuuu.Models.Mail;
using Siuuuu.Models.Menu;
using Siuuuu.Models.Mus;
using Siuuuu.Models.Odemek;
using Siuuuu.Models.Paid;

namespace Siuuuu.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {

    
            public AppDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<KarokeInformation> informations { get; set; }
            public DbSet<KarokeConcept> concepts { get; set; }
            public DbSet<KarokeImage> karokeImages { get; set; }
            public DbSet<KarokeQuestion> karokeQuestions { get; set; }
            public DbSet<KarokeRezerevation> karokeRezerevations { get; set; }
            public DbSet<CustomeHuman> customeHumen { get; set; }
            public DbSet<CustomerJobAndCareer> customerJobAndCareers { get; set; }
            public DbSet<Curior> curiors { get; set; }
            public DbSet<CuriorOne> curiorOnes { get; set; }
            public DbSet<CuriorTwo> curiorTwos { get; set; }
            public DbSet<CuriorThree> curiorThree { get; set; }
            public DbSet<CuriorDescription1> curiorDescriptions { get; set; }
            public DbSet<CuriorDescription2> curiorDescription2s { get; set; }
            public DbSet<CuriorDescription3> curiorDescription3s { get; set; }
            public DbSet<CuriorDescription4> curiorDescription4s { get; set; }
            public DbSet<HomeMainImage> homeMainImages { get; set; }
            public DbSet<HomeManifestDescriptionn> homeManifestDescriptionns { get; set; }
            public DbSet<HomeDescriptionOne> homeDescriptionOnes { get; set; }
            public DbSet<HomeImageOne> homeImageOnes { get; set; }
            public DbSet<HomeImageTwo> homeImageTwos { get; set; }
            public DbSet<HomeTxt1> homeTxt1s { get; set; }
            public DbSet<HomeTxt2> homeTxt2s { get; set; }
            public DbSet<HomeBestFood> homeBestFoods { get; set; }
            public DbSet<HomeIcon> homeIcons { get; set; }
            public DbSet<CvForm> cvForms { get; set; }
            public DbSet<Email> emails { get; set; }
            public DbSet<Catagory> catagories { get; set; }
            public DbSet<Product> products { get; set; }
            public DbSet<Booking> bookings { get; set; }
            public DbSet<BookingTable> bookingTables { get; set; }
          
            public DbSet<Paidd> paidds { get; set; }
            public DbSet<BuyDesc> buyDescs { get; set; }
            public DbSet<BuyProduct> buyProducts { get; set; }
            public DbSet<Adres> adres { get; set; }
            public DbSet<Mu> mus { get; set; }
            public DbSet<Detail> details { get; set; }
            public DbSet<Middle> middles { get; set; }
            public DbSet<MiddleStol> middleStols { get; set; }
            public DbSet<ProMasa> proMasas { get; set; }
            public DbSet<ProRoom> proRooms { get; set; }
            public DbSet<Top> tops { get; set; }



        }
    }

