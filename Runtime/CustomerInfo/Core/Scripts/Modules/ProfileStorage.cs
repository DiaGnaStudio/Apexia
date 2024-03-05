using CustomerInfo.Data;

namespace CustomerInfo.Core.Module
{
    public class ProfileStorage
    {
        private ClientInfo client;

        public void Add(ClientInfo client) =>
            this.client = client;

        public ClientInfo Get() =>
            this.client;
    }
}