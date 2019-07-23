﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AccountOwnerServer.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ValuesController : ControllerBase
    //{
    //    private readonly ILoggerManager _logger;

    //    public ValuesController(ILoggerManager logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<string> Get()
    //    {
    //        _logger.LogInfo("Here is info message from our values controller.");
    //        _logger.LogDebug("Here is debug message from our values controller.");
    //        _logger.LogWarn("Here is warn message from our values controller.");
    //        _logger.LogError("Here is error message from our values controller.");

    //        return new string[] { "value1", "value2" };
    //    }

    //    //// GET api/values
    //    //[HttpGet]
    //    //public ActionResult<IEnumerable<string>> Get()
    //    //{
    //    //    return new string[] { "value1", "value2" };
    //    //}

    //    // GET api/values/5
    //    [HttpGet("{id}")]
    //    public ActionResult<string> Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/values
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/values/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/values/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;

        public ValuesController(IRepositoryWrapper repoWrapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var domesticAccounts = _repoWrapper.Account.FindByCondition(x => x.AccountType.Equals("Domestic"));
            var owners = _repoWrapper.Owner.FindAll();

            RegisterLog();

            return new string[] { domesticAccounts.First().AccountId.ToString(), owners.First().Address.ToString() };
        }

        private void RegisterLog()
        {
            _logger.LogInfo("Here is info message from our values controller.");
            _logger.LogDebug("Here is debug message from our values controller.");
            _logger.LogWarn("Here is warn message from our values controller.");
            _logger.LogError("Here is error message from our values controller.");
        }
    }
}
