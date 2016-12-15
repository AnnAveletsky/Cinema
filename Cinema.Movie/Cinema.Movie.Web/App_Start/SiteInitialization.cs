namespace Cinema.Movie
{
    using Administration;
    using Serenity;
    using Serenity.Abstractions;
    using Serenity.Data;
    using System;
    using System.Configuration;
    using Administration.Entities;
    using Configuration.Entities;
    using System.Collections.Generic;
    using System.IO;
    using System.Web.Hosting;

    public static partial class SiteInitialization
    {
        public static void ApplicationStart()
        {
            try
            {
                SqlSettings.AutoQuotedIdentifiers = true;
                Serenity.Web.CommonInitialization.Run();

                var registrar = Dependency.Resolve<IDependencyRegistrar>();
                registrar.RegisterInstance<IAuthorizationService>(new Administration.AuthorizationService());
                registrar.RegisterInstance<IAuthenticationService>(new Administration.AuthenticationService());
                registrar.RegisterInstance<IPermissionService>(new Administration.PermissionService());
                registrar.RegisterInstance<IUserRetrieveService>(new Administration.UserRetrieveService());

                if (!ConfigurationManager.AppSettings["LDAP"].IsTrimmedEmpty())
                    registrar.RegisterInstance<IDirectoryService>(new LdapDirectoryService());

                if (!ConfigurationManager.AppSettings["ActiveDirectory"].IsTrimmedEmpty())
                    registrar.RegisterInstance<IDirectoryService>(new ActiveDirectoryService());
            }
            catch (Exception ex)
            {
                ex.Log();
                throw;
            }
            EnsureDatabase(databaseDefaltKey);
            RunMigrations(databaseDefaltKey);
            var db = new Administration.Repositories.DataBaseRepository();
            var connect = SqlConnections.NewFor<DataBaseRow>();
            var databaseKeys = db.List(connect, new Serenity.Services.ListRequest());

            databaseKeys.Entities.ForEach((i) =>
            {
                SqlConnections.SetConnection(i.Name, @i.ConnectionString, i.ProviderName);
                EnsureDatabase(i.Name);
                RunMigrations(i.Name);
            });
        }

        public static void ApplicationEnd()
        {
        }
    }
}