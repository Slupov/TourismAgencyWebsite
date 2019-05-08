using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MatinloAdventures.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MatinloAdventures.Data.Helpers
{
    public static class MatinloAdventuresDbContextExtensions
    {
        public static void EnsureSeedData(this MatinloAdventuresDbContext context, ApplicationUser admin)
        {
            if (context.Database.GetPendingMigrations().Any()) return;

            SeedTourPackages(context);
            SeedTourPackageComments(context, admin.Id);
            SeedBlogPosts(context, admin.Id);
            SeedFaqs(context);
        }

        private static void SeedTourPackages(MatinloAdventuresDbContext context)
        {
            if (context.TourPackages.Any()) return;

            var packagesToSeed = new TourPackage[]
            {
                new TourPackage()
                {
                    Destination = "Phillipines",
                    Name = "Budget",
                    TransportationPrice = 50,
                    AccomodationPrice = 40,
                    AdventuresPrice = 20
                },

                new TourPackage()
                {
                    Destination = "Phillipines",
                    Name = "Normal",
                    TransportationPrice = 83,
                    AccomodationPrice = 60,
                    AdventuresPrice = 40
                },

                new TourPackage()
                {
                    Destination = "Phillipines",
                    Name = "Luxury",
                    TransportationPrice = 125,
                    AccomodationPrice = 115,
                    AdventuresPrice = 215
                },

                new TourPackage()
                {
                    Destination = "Kaspichan,Bulgaria",
                    Name = "Евтинджос",
                    TransportationPrice = 1.60m,
                    AccomodationPrice = 15.99m,
                    AdventuresPrice = 0
                }
            };

            context.TourPackages.AddRange(packagesToSeed);
            context.SaveChanges();
        }

        private static void SeedTourPackageComments(MatinloAdventuresDbContext context, string userId)
        {
            if (context.TourPackageComments.Any()) return;

            var tourPackageComments = new TourPackageComment[]
            {
                new TourPackageComment()
                {
                    Username = "Иван Пешев",
                    Content =
                        "Цените са годни и за пенсионери. Лично аз поех по бюджетния вариант и си прекарах чудесно. Ако търсите лукс ще трябва да имате по-дълбок джоб, но все пак сте на другия край на света.",
                    DateCreated = new DateTime(2018, 6, 15, 19, 23, 34)
                },
                new TourPackageComment()
                {
                    Username = "Лорем Ипсимов",
                    Content =
                        "Мнооооого скъпо бе колеги. Колко са далече Филипините? С колело мога ли да стигна за ден-два? Имам и Пежо 96та година на газ, ако е по-далечко.",
                    DateCreated = new DateTime(2018, 6, 17, 22, 09, 01)
                },
                new TourPackageComment()
                {
                    Username = "Харалампи Лампов",
                    Content =
                        "Мен цените ме устройват. Аз съм си баровец така или иначе. Отивам на СПА във Филипините :))).",
                    DateCreated = new DateTime(2018, 6, 18, 07, 33, 40)
                }
            };

            context.TourPackageComments.AddRange(tourPackageComments);
            context.SaveChanges();
        }

        private static void SeedBlogPosts(MatinloAdventuresDbContext context, string userId)
        {
            if (context.BlogPosts.Any()) return;

            var blogPosts = new BlogPost[]
            {
                new BlogPost()
                {
                    Comments = new List<BlogComment>()
                    {
                        new BlogComment()
                        {
                            DateAdded = DateTime.Now.AddDays(2).AddMinutes(1000),
                            IsEdited = false,
                            Message =
                                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed eu lacinia risus. Aliquam enim lorem, efficitur id neque sed, luctus commodo leo. Donec blandit auctor justo, vitae varius tortor congue et. Nulla eu massa ut urna pharetra hendrerit vitae ac urna.",
                            UserId = userId
                        },
                        new BlogComment()
                        {
                            DateAdded = DateTime.Now.AddDays(4).AddMinutes(600),
                            IsEdited = false,
                            Message =
                                "Nullam tincidunt blandit odio, quis feugiat diam cursus hendrerit. Donec finibus diam quis lorem tincidunt tempus. Sed gravida ornare velit. Phasellus vestibulum nibh aliquet, accumsan ex elementum, interdum urna.",
                            UserId = userId
                        }
                    },
                    Content =
                        "Praesent luctus tellus felis, quis imperdiet justo facilisis eu. Pellentesque et facilisis diam. Sed leo odio, faucibus ac tristique quis, cursus non purus. Morbi cursus purus elit, ac tincidunt lacus scelerisque et. Donec quis quam ac ex tincidunt sollicitudin. Sed ac nisl blandit, maximus velit in, scelerisque sem. Cras non consectetur metus. Aenean sed massa ultrices, finibus tortor in, molestie mi. Pellentesque dolor massa, lobortis quis purus vitae, porttitor vehicula ante. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Maecenas pretium consequat rhoncus. Nunc rhoncus, ligula sit amet dignissim porttitor, magna lorem vulputate neque, nec feugiat neque justo id leo. In consequat nisi non elementum tempus. Curabitur eu nibh suscipit, rutrum diam eget, lacinia nulla.",
                    DateCreated = DateTime.Now,
                    Title = "Praesent luctus 2019"
                },
                new BlogPost()
                {
                    Comments = new List<BlogComment>()
                    {
                        new BlogComment()
                        {
                            DateAdded = DateTime.Now.AddDays(2).AddMinutes(1000),
                            IsEdited = false,
                            Message =
                                "Nulla eu massa ut urna pharetra hendrerit vitae ac urna. ",
                            UserId = userId
                        },
                        new BlogComment()
                        {
                            DateAdded = DateTime.Now.AddDays(2).AddMinutes(234),
                            IsEdited = false,
                            Message =
                                "Test, test, test. Nullam tincidunt blandit odio, quis feugiat diam cursus hendrerit. Donec finibus diam quis lorem tincidunt tempus. Sed gravida ornare velit. Phasellus vestibulum nibh aliquet, accumsan ex elementum, interdum urna.",
                            UserId = userId
                        }
                    },
                    Content =
                        "Nulla tincidunt bibendum justo ut blandit. Morbi eget orci rutrum, laoreet justo vel, sodales neque. Sed ut sapien sit amet nisl pharetra cursus iaculis id sapien. Nunc cursus lectus sit amet gravida ullamcorper. Sed facilisis feugiat nibh, a laoreet nisi. Sed a nisl nulla. Vestibulum ut neque venenatis, gravida neque ut, el...",
                    DateCreated = DateTime.Now,
                    Title = "Nulla tincidunt"
                }
            };

            context.BlogPosts.AddRange(blogPosts);
            context.SaveChanges();
        }

        private static void SeedFaqs(MatinloAdventuresDbContext context)
        {
            if (context.Faqs.Any()) return;

            var faqs = new Faq[]
            {
                new Faq()
                {
                    Title = "До къде организираме пътешествия?",
                    Content = "Организираме приключения и почивки из невероятните филипински острови. Част от местата, които можете да видите с нас включват Бохол, Панглао, Себу, Ослоб, Бадиан, Корон, Барас, Манила"
                },
                new Faq()
                {
                    Title = "Какво можем да видим на едно пътешествие?",
                    Content = "Всичко което държавата предлага като природни забележителности, флора и фауна. От причудливи скали и златни пясъци до плуване с тигрови акули"
                }
                ,
                new Faq()
                {
                    Title = "Скъпо ли е едно пътуване до Филипините през Matinlo Adventures?",
                    Content = "Вярваме, че финансовото състояние на човек не бива да бъде пречка пред него да изпита удоволствието от пътуването. Затова предлагаме различни пакети подходящи за джоба на всекиго. Имаме бюджетен, среден и лукс пакет. Цените за тях може да намерите в секция <a href=\"/tourpackages\">\"Цени\"</a>"
                }
            };

            context.Faqs.AddRange(faqs);
            context.SaveChanges();
        }
    }
}