using SLS.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SLS.TstingData
{
    internal static class TestingData
    {
        private static string[] _resourceNames = new string[] 
        {
            "Mail.ru", "GirtHub", "WorldOfWorcraft", "Gmail.com", "Facebook", "Instagram", "Telegram", "Escape from Tarkov",
            "Final Fantasy IV", "LinkedIn", "VK", "Twitter", "Stackowerflow", "Windows", "Lineage 2", "Twich", "Ebay",
            "Amazon", "Google", "New World", "SendGrid", "Azure", "Black Desert Online"
        };

        public static List<ResourceModel> GetResourceList()
        {
            List<ResourceModel> resources = new List<ResourceModel>();

            for (int i = 0; i < _resourceNames.Length; i++)
            {
                var resource = new ResourceModel()
                {
                    Name = _resourceNames[i],
                    Login = $"{String.Concat(_resourceNames[i].Where(c => !Char.IsWhiteSpace(c)))}Login",
                    Password = Guid.NewGuid().ToString(),
                };

                resources.Add(resource);
            }

            return resources;
        }
    }
}
