using Microsoft.AspNetCore.Mvc;
using MSGarnet_server;

namespace MSGarnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MSGarnetDemoController : ControllerBase
    {
        private readonly ILogger<MSGarnetDemoController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IGarnetClient _garnetClient;

        public MSGarnetDemoController(ILogger<MSGarnetDemoController> logger, HttpClient httpClient, IHttpClientFactory httpClientFactory, IGarnetClient garnetClient)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _garnetClient = garnetClient;
        }

        [HttpPost]
        [Route("Get")]
        public async Task<string> Get([FromBody]ParamsMopdel model)
        {
            var getValue = await _garnetClient.getValue(model.key);
            return getValue;

            //// same GarnetClient
            //using var db = new Garnet.client.GarnetClient(Address, Port, null);
            //await db.ConnectAsync();
            //var dataValue = await db.StringGetAsync(key);

        }


        [HttpPost]
        [Route("Set")]
        public async Task<string> Set([FromBody]ParamsMopdel model)
        {
            //// same GarnetClient
            //var setValue = await _garnetClient.setValue(model.key, model.value);
            //return setValue;

            using var db = new Garnet.client.GarnetClient("127.0.0.1", 44351, null);
            await db.ConnectAsync();
            var response = db.StringSetAsync(model.key, model.value);
            return model.key + " :: " + model.value;
        }

    }
}
