using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FAQ_Oblig3.Models;

namespace FAQ_Oblig3.Controllers
{
   // [Route("api/[controller]")]
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly Faqcontext _context;
        public FaqController(Faqcontext context)
        {
            _context = context;
        }





        [Route("/api/liste")]
        [HttpGet]
        public JsonResult Liste()
        {
            var faqDB = new DBqa(_context);
            List<Qa> alleQA = faqDB.questans();
            return new JsonResult(alleQA);
        }

        // GET api/FAQ/5

        /* [HttpGet("{id}")]
         public JsonResult Get(int id)
         {
             var faqDB = new DBqa(_context);
             Qa enQA = faqDB.hentQa(id);
             return Json(enQA);
         }*/
         
        // POST api/Kunde
        [Route("/api/poste")]
        [HttpPost]
        public JsonResult Post([FromBody]Qa innqa)
        {
            if (ModelState.IsValid)
            {
                var faqDB = new DBqa(_context);
                bool OK = faqDB.lagreQa(innqa);
                if (OK)
                {
                    return Json("OK");
                }
            }
            return Json("Kunne ikke sette inn qa i DB");
        }
/*
        // PUT api/Kunde/5
        [HttpPut("{id}")]
       
        public JsonResult Put(int id, [FromBody]Qa innqa)
        {
            if (ModelState.IsValid)
            {
                var faqDB = new DBqa(_context);
                bool OK = faqDB.endreQa(id, innqa);
                if (OK)
                {
                    return Json("OK");
                }
            }
            return Json("Kunne ikke endre qa i DB");
        }
        */

    }
}
