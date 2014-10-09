using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salesforce.Common;
using Salesforce.Force;

namespace Demo1
{
    class Program
    {
        private static string _securityToken = "";
        private static string _clientId = "";
        private static string _clientSecret = "";
        private static string _username = "";
        private static string _password = "" + _securityToken;

        static void Main(string[] args)
        {
            var auth = new AuthenticationClient();
            auth.UsernamePasswordAsync(_clientId, _clientSecret, _username, _password).Wait();

            var client = new ForceClient(auth.InstanceUrl, auth.AccessToken, auth.ApiVersion);

            var results = client.QueryAsync<dynamic>("SELECT Id, Name, Description FROM Account");
            results.Wait();

            var accounts = results.Result.records;

            Console.WriteLine(accounts.Count);
        }
    }
}
