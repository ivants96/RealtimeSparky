using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealtimeSparky.Model;

namespace RealtimeSparky.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private SparkyContext _db;           

        public DataController(SparkyContext db)
        {
            _db = db;
        }

        [HttpGet]
        public Sparkyvalues Get()
        {             
            var message = _db.Sparkyvalues.OrderByDescending(m => m.Id).FirstOrDefault();
            return message;           
        }

    }
}