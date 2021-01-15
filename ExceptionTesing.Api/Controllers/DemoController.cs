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
            var t1 = t / (t - t);
            return t1.ToString();
        }
        [HttpGet("{id,name}")]
        public string GetException(int id, string name)
        {
            string word = "test";
            if (word.Length > 0)
            {
                //throw new AppException("My Custom Exception");
            }
            int t = id;
            var t1 = t / (t - t);
            return word+name;
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
