using System;
using System.Collections.Generic;
using System.Linq;
using HNB_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NS_HNB_Client.DAL;

namespace NS_HNB_Client.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class HnbClientController : ControllerBase
    {
        private readonly HNBContext _context;

        public HnbClientController(HNBContext context)
        {
            _context = context;
        }

        [HttpGet("data")]
        public IEnumerable<HnbApiResponse> GetData()
        {            
            return _context.Courses.Where(c => c.datum_primjene == _context.Courses.Max(c2 => c2.datum_primjene)).ToArray();
        }

        [HttpPost("save")]
        public void SaveData([FromBody]IEnumerable<HnbApiResponse> data)
        {
            foreach (HnbApiResponse course in data)
            {
                _context.Courses.Add(new Models.NS_HNB_Model
                {
                    broj_tecajnice = course.broj_tecajnice,
                    datum_primjene = course.datum_primjene,
                    drzava = course.drzava,
                    drzava_iso = course.drzava_iso,
                    jedinica = course.jedinica,
                    kupovni_tecaj = course.kupovni_tecaj,
                    prodajni_tecaj = course.prodajni_tecaj,
                    sifra_valute = course.sifra_valute,
                    srednji_tecaj = course.srednji_tecaj,
                    valuta = course.valuta,
                });
            }
            _context.SaveChanges();
        }
    }
}