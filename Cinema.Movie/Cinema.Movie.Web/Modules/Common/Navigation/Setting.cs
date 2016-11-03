using Cinema.Movie.Configuration.Entities;
using Serenity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Movie.Modules.Common.Navigation
{
    public static class Setting
    {
        public static string Language()
        {
            return "en";
        }
        public static string Theme()
        {
            var theme = "blue";
            using (var connection = SqlConnections.NewFor<SettingsRow>())
            {
                connection.List<SettingsRow>().ForEach(i=> {
                    if (i.Setting=="Theme")
                    {
                        theme= i.Value;
                    };
                });
            }
            return theme;
        }

    }
}