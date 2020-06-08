namespace ss3d_server_browser_shared.Models.News
{
    public class RpcDataNewsRequest
    {
        public int Server { get; set; }
        public string Category { get; set; }
        public int StartIndex { get; set; }
        public int Count { get; set; }
    }
}