using System;

namespace MVC
{
    public static class Views
    {
        public static class Administration
        {
            public static class DataBase
            {
                public const string DataBaseIndex = "~/Modules/Administration/DataBase/DataBaseIndex.cshtml";
            }

            public static class Language
            {
                public const string LanguageIndex = "~/Modules/Administration/Language/LanguageIndex.cshtml";
            }

            public static class Role
            {
                public const string RoleIndex = "~/Modules/Administration/Role/RoleIndex.cshtml";
            }

            public static class Translation
            {
                public const string TranslationIndex = "~/Modules/Administration/Translation/TranslationIndex.cshtml";
            }

            public static class User
            {
                public const string UserIndex = "~/Modules/Administration/User/UserIndex.cshtml";
            }

        }

        public static class Common
        {
            public static class Dashboard
            {
                public const string DashboardIndex = "~/Modules/Common/Dashboard/DashboardIndex.cshtml";
            }

        }

        public static class Configuration
        {
            public static class Background
            {
                public const string BackgroundIndex = "~/Modules/Configuration/Background/BackgroundIndex.cshtml";
            }

            public static class Settings
            {
                public const string SettingsIndex = "~/Modules/Configuration/Settings/SettingsIndex.cshtml";
            }
        }

        public static class Errors
        {
            public const string ValidationError = "~/Views/Errors/ValidationError.cshtml";
        }

        public static class Membership
        {
            public static class Account
            {
                public const string AccountLogin = "~/Modules/Membership/Account/AccountLogin.cshtml";
                public static class ChangePassword
                {
                    public const string AccountChangePassword = "~/Modules/Membership/Account/ChangePassword/AccountChangePassword.cshtml";
                }

                public static class ForgotPassword
                {
                    public const string AccountForgotPassword = "~/Modules/Membership/Account/ForgotPassword/AccountForgotPassword.cshtml";
                }

                public static class ResetPassword
                {
                    public const string AccountResetPassword = "~/Modules/Membership/Account/ResetPassword/AccountResetPassword.cshtml";
                    public const string AccountResetPasswordEmail = "~/Modules/Membership/Account/ResetPassword/AccountResetPasswordEmail.cshtml";
                }

                public static class SignUp
                {
                    public const string AccountActivateEmail = "~/Modules/Membership/Account/SignUp/AccountActivateEmail.cshtml";
                    public const string AccountSignUp = "~/Modules/Membership/Account/SignUp/AccountSignUp.cshtml";
                }
            }

        }

        public static class Movie
        {
            public static class Cast
            {
                public const string CastIndex = "~/Modules/Movie/Cast/CastIndex.cshtml";
            }

            public static class Country
            {
                public const string CountryIndex = "~/Modules/Movie/Country/CountryIndex.cshtml";
            }

            public static class Genre
            {
                public const string _Genres = "~/Modules/Movie/Genre/_Genres.cshtml";
                public const string GenreIndex = "~/Modules/Movie/Genre/GenreIndex.cshtml";
            }

            public static class History
            {
                public const string HistoryIndex = "~/Modules/Movie/History/HistoryIndex.cshtml";
            }

            public static class Movie_
            {
                public const string _Movie = "~/Modules/Movie/Movie/_Movie.cshtml";
                public const string _Movies = "~/Modules/Movie/Movie/_Movies.cshtml";
                public const string MovieIndex = "~/Modules/Movie/Movie/MovieIndex.cshtml";
            }

            public static class MovieCountry
            {
                public const string MovieCountryIndex = "~/Modules/Movie/MovieCountry/MovieCountryIndex.cshtml";
            }

            public static class MovieGenre
            {
                public const string MovieGenreIndex = "~/Modules/Movie/MovieGenre/MovieGenreIndex.cshtml";
            }

            public static class Person
            {
                public const string PersonIndex = "~/Modules/Movie/Person/PersonIndex.cshtml";
            }

            public static class Service
            {
                public const string ServiceIndex = "~/Modules/Movie/Service/ServiceIndex.cshtml";
            }

            public static class ServicePath
            {
                public const string ServicePathIndex = "~/Modules/Movie/ServicePath/ServicePathIndex.cshtml";
            }

            public static class ServiceRating
            {
                public const string ServiceRatingIndex = "~/Modules/Movie/ServiceRating/ServiceRatingIndex.cshtml";
            }

            public static class Tag
            {
                public const string TagIndex = "~/Modules/Movie/Tag/TagIndex.cshtml";
            }

            public static class Video
            {
                public const string VideoIndex = "~/Modules/Movie/Video/VideoIndex.cshtml";
            }
        }

        public static class Shared
        {
            public const string _Layout = "~/Views/Shared/_Layout.cshtml";
            public const string _LayoutHead = "~/Views/Shared/_LayoutHead.cshtml";
            public const string _LayoutNoNavigation = "~/Views/Shared/_LayoutNoNavigation.cshtml";
            public const string Error = "~/Views/Shared/Error.cshtml";
            public const string LeftNavigation = "~/Views/Shared/LeftNavigation.cshtml";
        }
    }
}

