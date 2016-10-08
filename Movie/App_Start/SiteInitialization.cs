﻿namespace Movie
{
    //using Administration;
    using Serenity;
    using Serenity.Abstractions;
    using Serenity.Data;
    using System;
    using System.Configuration;

    public static partial class SiteInitialization
    {
        public static void ApplicationStart()
        {
            try
            {
                SqlSettings.AutoQuotedIdentifiers = true;
                Serenity.Web.CommonInitialization.Run();
                
            }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }

            foreach (var databaseKey in databaseKeys)
            {
                EnsureDatabase(databaseKey);
            }
        }

        public static void ApplicationEnd()
        {
        }
    }
}