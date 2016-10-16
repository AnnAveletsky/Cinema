using Serenity.Navigation;
using Administration = Cinema.Movie.Administration.Pages;
using Movie= Cinema.Movie.Movie.Pages;

[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]
[assembly: NavigationLink(1100, "Dashboard/Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]
[assembly: NavigationLink(1200, "Dashboard/CatalogFilms", url: "~/catalog-films", permission: "", icon: "fa-bars")]
[assembly: NavigationLink(1300, "Dashboard/Top", url: "~/top", permission: "", icon: "fa-list-ol")]
[assembly: NavigationLink(1400, "Dashboard/FAQ", url: "~/faq", permission: "", icon: " fa-question")]
[assembly: NavigationLink(1500, "Dashboard/Contacts", url: "~/contacts", permission: "", icon: "fa-info")]

[assembly: NavigationMenu(9000, "Administration", icon: "fa-gears")]
[assembly: NavigationLink(9100, "Administration/Languages", typeof(Administration.LanguageController), icon: "icon-bubbles")]
[assembly: NavigationLink(9200, "Administration/Translations", typeof(Administration.TranslationController), icon: "icon-speech")]
[assembly: NavigationLink(9300, "Administration/Roles", typeof(Administration.RoleController), icon: "icon-lock")]
[assembly: NavigationLink(9400, "Administration/User Management", typeof(Administration.UserController), icon: "icon-people")]

[assembly: NavigationMenu(10000, "Movie", icon: "fa-tv")]
[assembly: NavigationLink(10100, "Movie/Genre", typeof(Movie.GenreController), icon: "fa-bars")]
[assembly: NavigationLink(10200, "Movie/Movie", typeof(Movie.MovieController), icon: "fa-film")]
[assembly: NavigationLink(10300, "Movie/Person", typeof(Movie.PersonController), icon: "fa-users")]
[assembly: NavigationLink(10400, "Movie/Service", typeof(Movie.ServiceController), icon: "fa-gear")]
[assembly: NavigationLink(10500, "Movie/Tag", typeof(Movie.TagController), icon: "fa-tags")]
[assembly: NavigationLink(10600, "Movie/Video", typeof(Movie.VideoController), icon: "fa-video-camera")]