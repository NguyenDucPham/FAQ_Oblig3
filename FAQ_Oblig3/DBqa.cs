using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using FAQ_Oblig3.Models;

namespace FAQ_Oblig3
{
    public class DBqa
    {
        private readonly Faqcontext _context;
        public DBqa(Faqcontext context)
        {
            _context = context;
        }

        public List<Qa> questans()
        {
            List<Qa> alleqa = _context.QAer.Select(k => new Qa()
            {
                Id = k.Id,
                Type = k.Type,
                Question = k.Question,
                Answer = k.Answer,
                Likes = k.Likes,
                Dislikes = k.Dislikes

            }).ToList();
            return alleqa;


        }


        public bool lagreQa(Qa innqa)
        {
            var nyQa = new Qa
            {
                //Id = innqa.Id,
                Type = innqa.Type,
                Question = innqa.Question,
                //Likes = innqa.Likes,
                //Dislikes = innqa.Dislikes
            };

            try
            {
                // lagre qa
                _context.QAer.Add(nyQa);
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
       /* public Qa hentQa(int id)
        {

            //QA enDBqa = _context.Kunder.Find(id); kan ikke brukes da vi ikke har lazy loading
            Qa enDBQa = _context.QAer.FirstOrDefault(k => k.Id == id);

            var enQa = new Qa()
            {
                Id = enDBQa.Id,
                Type = enDBQa.Type,
                Question = enDBQa.Question,
                Answer = enDBQa.Answer,
                Likes = enDBQa.Likes,
                Dislikes = enDBQa.Dislikes,
            };
            return enQa;
        }*/
        public bool endreQa(int id, Qa innqa)
        {
            // finn qa
            Qa funnetQa = _context.QAer.FirstOrDefault(k => k.Id == id);
            if (funnetQa == null)
            {
                return false;
            }
            // legg inn ny verdier i denne fra innKunde
            funnetQa.Type = funnetQa.Type;
            funnetQa.Question = funnetQa.Question;
            funnetQa.Answer = funnetQa.Answer;
            funnetQa.Likes = innqa.Likes;
            funnetQa.Dislikes = innqa.Dislikes;



            try
            {
                // lagre QA
                _context.SaveChanges();
            }
            catch (Exception feil)
            {
                return false;
            }
            return true;
        }
    }
}
