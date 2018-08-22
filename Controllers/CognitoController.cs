using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using test_cognito;

namespace test_cognito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CognitoController : ControllerBase
    {
        private readonly IAmazonCognitoIdentityProvider client;
        private readonly ILogger<CognitoController> logger;

        public CognitoController(
            IAmazonCognitoIdentityProvider client,
            ILogger<CognitoController> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        // POST api/cognito/signup
        [HttpPost("signup")]
        public async Task<ActionResult<SignUpResponse>> Signup([FromBody] SignUpRequest request)
        {
            var result = await this.client.SignUpAsync(request).ConfigureAwait(false);
            this.logger.LogInformation("Successful cognito request");
            return new OkObjectResult(result);
        }
    }
}
