using SLS.MVVM.Model;
using SLS.Services;
using SLS.Services.Logger;
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
            "Amazon", "Google", "New World", "SendGrid", "Azure", "Black Desert Online", "Project Zomboid", "AppleStore",
            "GeForcePlay", "Acer", "Djinny", "Goha", "BattleOfTheNations", "YouTube", "TicToc"
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

        public static List<LoggModel> GetLoggList()
        {
            var random = new Random();
            List<LoggModel> loggs = new List<LoggModel>();

            foreach(var name in _resourceNames)
            {
                var index = random.Next(1, 5);

                switch (index)
                {
                    case 1:
                        loggs.Add(ActionLogger.AddedResource(name));
                        break;

                    case 2:
                        loggs.Add(ActionLogger.AddedEmptyResource());
                        break;

                    case 3:
                        loggs.Add(ActionLogger.RemovedResource(name));
                        break;

                    case 4:
                        loggs.Add(ActionLogger.ChangedResource(name));
                        break;
                }
            }

            return loggs;
        }
    }
}
