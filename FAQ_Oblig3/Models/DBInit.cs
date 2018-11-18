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
                    Type = "Betaling",
                    Question = "Kan man låne penger?",
                    Answer = "Yeah!",
                    Likes = 10,
                    Dislikes = 4,

                });
                context.Add(new Qa
                {
                    Type = "Betaling",
                    Question = "Hva med bitcoin?",
                    Answer = "OHyeah!",
                    Likes = 10,
                    Dislikes = 4,

                });
                context.Add(new Qa
                {
                    Type = "Film",
                    Question = "hvordan stjeler man filmer?",
                    Answer = "YOU Wish!!!",
                    Likes = 1030,
                    Dislikes = 4,
                 
                });
                context.Add(new Qa
                {
                    Type = "Film",
                    Question = "hvordan unngår man filmer?",
                    Answer = "det er vanskelig",
                    Likes = 1030,
                    Dislikes = 4,

                });
                context.Add(new Qa
                {
                    Type = "Film",
                    Question = "list over de beste filmene?",
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
                    Question = "hvorfor kan man ikke bare bruke piratebay?",
                    Answer = "fullt lovlig",
                    Likes = 30,
                

                });
            }
            context.SaveChanges();
        }
    }
}

