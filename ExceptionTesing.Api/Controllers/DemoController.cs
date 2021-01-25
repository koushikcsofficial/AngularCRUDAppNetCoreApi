using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExceptionTesing.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            int t = 5;
            var mm = t.ToString().Split(',')[1];
            var t1 = t / (t - t);
            return t1.ToString();
        }

        [HttpGet("{word}")]
        public string GetNull(string word)
        {
            string name = null;
            //name = null;
            return name;
        }

        [HttpGet("{id}")]
        public string GetException(int id)
        {
            string word = "test";
            if (word.Length > 0)
            {
                //throw new AppException("My Custom Exception");
            }
            int t = id;
            var t1 = t / (t - t);
            return word;
        }
        [HttpGet]
        public IEnumerable<string> GetExample()
        {
            string[] arrRetValues = null;
            if (arrRetValues.Length > 0)
            { }
            return arrRetValues;
        }
    }
}
