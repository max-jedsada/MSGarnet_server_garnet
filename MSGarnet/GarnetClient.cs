
namespace MSGarnet_server
{
    public class GarnetClient : IGarnetClient
    {
        private readonly string Address = "127.0.0.1";
        private readonly int Port = 44351;

        public async Task<string> getValue(string key)
        {
            using var db = new Garnet.client.GarnetClient(Address, Port, null);
            await db.ConnectAsync();
            var dataValue = await db.StringGetAsync(key);
            return dataValue ?? "";
        }

        public async Task<string> setValue(string key, string value)
        {
            using var db = new Garnet.client.GarnetClient(Address, Port, null);
            await db.ConnectAsync();
            var response = db.StringSetAsync(key, value);

            return response.Result.ToString();
        }

    }
}
