using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PRM392_Backend.Domain.Models;

namespace PRM392_Backend.Infrastructure.Configuration
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(e => e.ID);
            builder.Property(e => e.StoreName).IsRequired().HasMaxLength(100);
            builder.HasMany(e => e.Products).WithOne(e => e.Store).OnDelete(DeleteBehavior.Restrict);
            builder.Property(e => e.Address).IsRequired();
            builder.Property(e => e.ImageUrl).IsRequired();
            builder.Property(e => e.Rating).IsRequired();
            builder.Property(e => e.IsActive).IsRequired();
            builder.HasData(
                new Store
                {
                    ID = Guid.Parse("deb70b97-b1fc-48f6-860c-fe9c15bcc4c7"),
                    StoreName = "Burger Haven",
                    Address = "123 Main St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRRL5AQ1LfPEz2Lvc0fjQhFYCmQ09vVmpzpA&s",
                    Rating = 5,
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("275dd30a-7b06-465a-9731-e0b75f2b4441"),
                    StoreName = "Pizza Paradise",
                    Address = "45 Sakura Ave, District 2, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS1_Yesq9xjLKw2mvgZNgk0BcjtZ8_9rzg8jg&s",
                    Rating = 4,
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("0edc6c88-6d86-42e7-9e1c-ff5821f8e366"),
                    StoreName = "Cool Refreshments",
                    Address = "78 Elm St, District 3, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcROBn_ESD2kvsswrE6qRJOM1IPhS8JtBE4ddQ&s",
                    Rating = 5,
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("b1658d47-bc38-4690-9035-85c2e2d85d7c"),
                    StoreName = "Sweet Indulgence",
                    Address = "12 Greenway Dr, District 5, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRSwI0EgrEZKcx6VRufT4vhMgjDQL35kdv8GA&s",
                    Rating = 4,
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("036975aa-0bae-455a-a559-d0c914a43b27"),
                    StoreName = "Crispy Corner",
                    Address = "99 Fiesta Ln, District 7, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDStT3T--pHLciOb93FLN1Nlmvp8Bzqg3wPw&s",
                    Rating = 4,
                    IsActive = true
                },
                new Store
                {
                    ID = Guid.Parse("b7b2e729-13b0-44cf-b4f9-616bffebda5d"),
                    StoreName = "The Burger Joint",
                    Address = "456 Pham Ngoc Thach St, District 3, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQQigCssnKf-N2zAzzOsWJtl6_A_J1t1oPjig&s",
                    Rating = 4,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("4fbb2d9c-9eb2-4098-aed3-bbb7303e58c5"),
                    StoreName = "Alfredo's Pizzeria",
                    Address = "22 Nguyen Thi Minh Khai St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS6YlQuV6RqkMK4oQPLkZGwf50JO-0owQaQKg&s",
                    Rating = 5,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("df8b5e1a-c3b3-47e0-b59f-7c559b3bde59"),
                    StoreName = "Trattoria Antonio",
                    Address = "58 Le Loi St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWJbbHgN1qGYIeMiAqYxFiavSbahUYHE0e2g&s",
                    Rating = 5,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("fd9dbb8e-6f91-45c9-bb9e-517bd4d129ab"),
                    StoreName = "Sushi World",
                    Address = "25 Le Thanh Ton St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://sushiworld.com.vn/wp-content/uploads/2020/10/logo-sushi-world.png",
                    Rating = 4,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("6d2f69e3-678b-4937-bd1d-06e9b37056e0"),
                    StoreName = "Ming's Chinese Restaurant",
                    Address = "18 Nguyen Thi Minh Khai St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ-4e_x-a_vkQT8gM247nyzTaksk99MInwAXA&s",
                    Rating = 5,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("6d0ab2e1-5b77-4d9a-b678-63f1a52cf274"),
                    StoreName = "Shogun Burger",
                    Address = "34 Le Lai St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSJeYIrTFi95VInO-ft4pLYqMUSvzE_iWcu9A&s",
                    Rating = 5,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("c3e07e4f-118e-43c5-9a3e-66057c5bc038"),
                    StoreName = "The Pizza Company",
                    Address = "100 Nguyen Thi Minh Khai, District 1, Ho Chi Minh City",
                    ImageUrl = "https://play-lh.googleusercontent.com/vDn0tgGBTcZ_Q8QhSdjuhvMNA4GUJK8VS_pZ0Fy-miUMDodMNeUbDfjMGEwFB1vERPQ",
                    Rating = 4,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("ec2d6842-2177-4852-8f3e-52d99ed8a1b5"),
                    StoreName = "Cucina Italian Restaurant",
                    Address = "17A Hai Ba Trung St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRhoacfNPgi_5pAVK08-wLGYwLfaE3FsqNA1w&s",
                    Rating = 5,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("ad94e519-8ee5-442e-b013-df96cb74594b"),
                    StoreName = "Sushi Tei",
                    Address = "27 Ton Duc Thang St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://www.sushiteivietnam.com/wp-content/uploads/2024/08/logo-scaled.webp",
                    Rating = 4,
                    IsActive = true,
                },
                new Store
                {
                    ID = Guid.Parse("d13d2d4a-639d-4f28-a073-d3eaf8c2a3f6"),
                    StoreName = "Kong's Asian Cuisine Restaurant",
                    Address = "5 Le Duan St, District 1, Ho Chi Minh City",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSR11F0IgZlK1JbWkggHGMf2GxTr64MAt3HfQ&s",
                    Rating = 5,
                    IsActive = true,
                }
            );

        }
    }
}
