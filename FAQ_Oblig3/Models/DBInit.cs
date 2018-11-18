using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FAQ_Oblig3.Models;

namespace FAQ_Oblig3.Models
{
    public class DBInit
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<Faqcontext>();
            context.Database.EnsureCreated();
            if (!context.QAer.Any())
            {
                context.Add(new Qa
                {
                    Type = "Nedlasting",
                    Question = "hvordan laster man ned?",
                    Answer = "Får en link tilsendt epost med nedlastingsmulighet",
                    Likes = 30,
                    Dislikes = 4,
                    
                });
                context.Add(new Qa
                {
                    Type = "Betaling",
                    Question = "Hva betaler man med?",
                    Answer = "Penger!",
                    Likes = 10,
                    Dislikes = 4,
                    
                });
                context.Add(new Qa
                {
                    Type = "Morro",
                    Question = "hvordan stjeler man filmer?",
                    Answer = "YOU Wish!!!",
                    Likes = 1030,
                    Dislikes = 4,
                 
                });
                context.Add(new Qa
                {
                    Type = "Nedlasting",
                    Question = "hvordan laster man ned?",
                    Answer = "Får en link tilsendt epost med nedlastingsmulighet",
                   
                    Dislikes = 4,

                });
                context.Add(new Qa
                {
                    Type = "Nedlasting",
                    Question = "hvordan laster man ned?",
                    Answer = "Får en link tilsendt epost med nedlastingsmulighet",
                    Likes = 30,
                

                });
            }
            context.SaveChanges();
        }
    }
}

