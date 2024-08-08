namespace MSGarnet_server
{
    public interface IGarnetClient
    {
        Task<string> getValue(string key);
        Task<string> setValue(string key, string value);
    }
}
