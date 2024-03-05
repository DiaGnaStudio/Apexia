using ClientConfigs.Provider;
using ClientConfigs.Provider.Data;
using CustomerInfo.Data;
using System;
using UnityEngine;

namespace CustomerInfo.Core.Module
{
    public class ClientLoader
    {
        public void Load(string firstName, string lastName, string phone, string email, Action<ClientInfo> onLoad)
        {
            ClientConfigsService.Send(firstName, lastName, phone, email, Get, Error);

            void Get(Client client)
            {
                onLoad.Invoke(new(client.id, client.first_name, client.last_name, client.email, client.phone));
            }

            void Error(string message)
            {
                Debug.LogError(message);
            }
        }
    }
}