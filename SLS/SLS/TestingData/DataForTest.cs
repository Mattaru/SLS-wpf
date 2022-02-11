using SLS.MVVM.Model;
using SLS.Services.Interfaces;
using SLS.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SLS.TestingData
{
    internal static class DataForTest
    {
        public static IEnumerable<ResourceModel> Resources => GetResourceList();

        public static IEnumerable<LoggModel> Loggs => GetLoggList();

        private static readonly ILogger Logger = new ActionLogger();

        private static string[] _resourceNames = new string[] 
        {
            "Mail.ru", "GirtHub", "WorldOfWorcraft", "Gmail.com", "Facebook", "Instagram", "Telegram", "Escape from Tarkov",
            "Final Fantasy IV", "LinkedIn", "VK", "Twitter", "Stackowerflow", "Windows", "Lineage 2", "Twich", "Ebay",
            "Amazon", "Google", "New World", "SendGrid", "Azure", "Black Desert Online", "Project Zomboid", "AppleStore",
            "GeForcePlay", "Acer", "Djinny", "Goha", "BattleOfTheNations", "YouTube", "TicToc"
        };

        private static IEnumerable<ResourceModel> GetResourceList()
        {
            for (int i = 0; i < _resourceNames.Length; i++)
            {
                var resource = new ResourceModel()
                {
                    Name = _resourceNames[i],
                    Login = $"{String.Concat(_resourceNames[i].Where(c => !Char.IsWhiteSpace(c)))}Login",
                    Password = Guid.NewGuid().ToString(),
                };

                yield return resource;
            }
        }

        private static IEnumerable<LoggModel> GetLoggList()
        {
            var random = new Random();

            foreach(var name in _resourceNames)
            {
                var index = random.Next(1, 5);

                switch (index)
                {
                    case 1:
                        yield return Logger.AddedResource(name);
                        break;

                    case 2:
                        yield return Logger.AddedEmptyResource();
                        break;

                    case 3:
                        yield return Logger.RemovedResource(name);
                        break;

                    case 4:
                        yield return Logger.ChangedResource(name);
                        break;
                }
            }
        }
    }
}
