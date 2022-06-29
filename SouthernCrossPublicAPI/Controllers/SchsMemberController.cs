using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SouthernCrossPublicAPI.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SouthernCrossPublicAPI.Controllers
{
    /// <summary>
    /// API controller class for manage the member search activity 
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class SchsMemberController : ControllerBase
    {
        private IConfiguration _config;
        private IHostingEnvironment _env;

        public SchsMemberController(IConfiguration configuration, IHostingEnvironment env)
        {
            _config = configuration;
            _env = env;
        }

        /// <summary>
        /// API start point
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Southern Cross Public API Started.");
        }

        /// <summary>
        /// Method for manage the members search functionality
        /// </summary>
        /// <param name="policyNumber"></param>
        /// <param name="memberCardNumber"></param>
        /// <returns>Filtered member list</returns>

        [HttpGet]
        [Route("[action]/{policyNumber}/{memberCardNumber?}")]
        public ActionResult SearchMembers(string policyNumber, string memberCardNumber)
        {
            if (string.IsNullOrWhiteSpace(policyNumber))
            {
                throw new Exception("Invalid Parameters");
            }

            // Search members base on inputs
            var searchResult = GetAllMembers().Where(a => a.policyNumber == policyNumber &&
            (string.IsNullOrWhiteSpace(memberCardNumber) || a.memberCardNumber == memberCardNumber)).ToList();

            return Ok(searchResult);
        }

        /// <summary>
        /// Method for extract members from MOCK_DATA json file as SchsMember list 
        /// </summary>
        /// <returns> SchsMember List</returns>
        private List<SchsMember> GetAllMembers()
        {
            List<SchsMember> members = new List<SchsMember>();

            //Generate the mock data file path
            string filepath = $"{_env.ContentRootPath}{_config["MOCK_DATA"]}";

            using (StreamReader streamReader = new StreamReader(filepath))
            {
                string json = streamReader.ReadToEnd();
                members = JsonConvert.DeserializeObject<List<SchsMember>>(json);
            }
            return members;
        }
    }
}
