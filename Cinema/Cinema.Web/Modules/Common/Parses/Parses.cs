

namespace Cinema.Common.Init
{
    using Cinema.Movie;
    using Cinema.Movie.Entities;
    using Serenity.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;
    public class JsonObject
    {
        public string name;
    }
    public class MovieJson : JsonObject
    {
        public string name_eng;
        public string year;
        public string year_start;
        public string year_end;
        public string url;
        public string sub_type;
        public string kinopoisk_id;
        public string id;
        public string player;
        public string content;
        public string trailer;
        public string poster_big;
        public string poster_small;
        public string poster_url;
        public string picture;
        public string title_ru;
        public string title_en;
        public string description;
        public string actors;
        public string is_active;
        public string country;
        public List<Element> countries;
        public string director;
        public string screenwriter;
        public string producer;
        public string Operator;
        public string design;
        public string editor;
        public string composer;
        public string genre;
        //public List<Element> genres;
        public string time;
        public string age_restriction;
        public string slogan;
        public MovieKind movieKind;
        public MovieRow ToMovie()
        {
            try
            {
                MovieRow Movie = new MovieRow();
                Movie.Kind = movieKind;
                if ((!String.IsNullOrWhiteSpace(title_en) || !String.IsNullOrWhiteSpace(name_eng) || !String.IsNullOrWhiteSpace(title_ru) || !String.IsNullOrWhiteSpace(name)))
                {
                    if (!String.IsNullOrWhiteSpace(year))
                    {
                        Movie.YearEnd = Int16.Parse(year);
                        Movie.YearStart = Int16.Parse(year);
                    }
                    else if (!String.IsNullOrWhiteSpace(year_start))
                    {
                        Movie.YearEnd = Int16.Parse(year_start);
                    }
                    else if (!String.IsNullOrWhiteSpace(year_end))
                    {
                        Movie.YearEnd = Int16.Parse(year_end);
                    }
                    if (!String.IsNullOrWhiteSpace(title_en))
                    {
                        name_eng = title_en;
                    }
                    if (!String.IsNullOrWhiteSpace(title_ru))
                    {
                        name = title_ru;
                    }
                    if (String.IsNullOrWhiteSpace(name_eng) || name_eng == name)
                    {
                        Movie.TitleOriginal = name;
                    }
                    else
                    {
                        Movie.TitleOriginal = name_eng;
                        Movie.TitleTranslation = name;
                    }
                    Movie.Url = Translit.GetUrl(Movie.TitleDisplay);
                    if (!String.IsNullOrWhiteSpace(poster_big))
                    {
                        Movie.PathImage = poster_big;
                    }
                    else if (!String.IsNullOrWhiteSpace(poster_small))
                    {
                        Movie.PathImage = poster_small;
                    }
                    else if (!String.IsNullOrWhiteSpace(picture))
                    {
                        Movie.PathImage = picture;
                    }
                    else if (!String.IsNullOrWhiteSpace(poster_url))
                    {
                        Movie.PathImage = poster_url;
                    }
                    if (!String.IsNullOrWhiteSpace(description))
                    {
                        Movie.Description = new string[] { description };
                    }
                    if (!String.IsNullOrWhiteSpace(time))
                    {
                        Movie.Runtime = time;
                    }
                    return Movie;
                }
                return null;
            }
            catch
            {
                return null;
            }

        }
        public List<GenreRow> ToGenres()
        {
            List<GenreRow> result = new List<GenreRow>();
            if (!String.IsNullOrWhiteSpace(genre))
            {
                foreach (var i in genre.Split(new[] { ", " }, StringSplitOptions.None))
                {
                    if (!String.IsNullOrWhiteSpace(i) && i != "-")
                    {
                        result.Add(new GenreRow()
                        {
                            Name = String.Concat(i[0].ToString().ToUpper(), i.Substring(1).ToLower())
                        });
                    }
                }
            }
            return result;
        }
        public List<CountryRow> ToCountries()
        {
            List<CountryRow> result = new List<CountryRow>();
            if (!String.IsNullOrWhiteSpace(country))
            {
                foreach (var i in country.Split(new[] { ", " }, StringSplitOptions.None))
                {
                    if (!String.IsNullOrWhiteSpace(i) && i != "-")
                    {
                        result.Add(new CountryRow()
                        {
                            Name = String.Concat(i),
                            NameOther=String.Concat(i),
                            Code= String.Concat(i),
                        });
                    }
                }
            }
            return result;
        }
        public List<CastRow> ToCast(RetrieveResponse<MovieRow> movie, PersonRow person)
        {
            List<CastRow> casts = new List<CastRow>();
            if (!String.IsNullOrWhiteSpace(actors) && actors.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && actors.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Actors",
                    CharacterOther = "Актёры",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(director) && director.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && director.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Director",
                    CharacterOther = "Режисёры",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(screenwriter) && screenwriter.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && screenwriter.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Screenwriter",
                    CharacterOther = "Сценаристы",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(producer) && producer.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && producer.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Producer",
                    CharacterOther = "Продюсеры",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(Operator) && Operator.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && Operator.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Operator",
                    CharacterOther = "Орераторы",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(design) && design.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && design.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Design",
                    CharacterOther = "Дизайнеры",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(editor) && editor.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && editor.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Editor",
                    CharacterOther = "Редакторы",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            if (!String.IsNullOrWhiteSpace(composer) && composer.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && composer.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Composer",
                    CharacterOther = "Композиторы",
                    MovieId = movie.Entity.MovieId,
                    PersonId = person.PersonId
                });
            }
            return casts;
        }
        public List<PersonRow> ToPersons()
        {
            List<PersonRow> result = new List<PersonRow>();
            string persons = actors + ", " + director + ", " + screenwriter + ", " + producer + ", " + Operator + ", " + design + ", " + editor + ", " + composer;
            foreach (var i in persons.Split(new[] { ", " }, StringSplitOptions.None))
            {
                if (!String.IsNullOrWhiteSpace(i) && i != "-")
                {
                    result.Add(new PersonRow()
                    {
                        Name = i,
                        Url = Translit.GetUrl(i)
                    });
                }
            }
            return result;
        }
        public VideoRow ToVideo(RetrieveResponse<MovieRow> movie,RetrieveResponse<ServicePathRow> service)
        {
            VideoRow Video = new VideoRow();
            if (player != null)
            {
                url = player;
            }else
            if (content != null)
            {
                url = content;
            }
            Video.Path = url;
            Video.Translation = sub_type != null && sub_type != "" ? Int16.Parse(sub_type) : (Int16)0;
            Video.MovieId = movie.Entity.MovieId;
            Video.ServiceId = service.Entity.ServiceId;
            return Video;
        }

        public List<ServiceRatingRow> ToServiceRatings(MovieRow movie, ServiceRatingRow id = null)
        {
            var list = new List<ServiceRatingRow>();
            if (!String.IsNullOrWhiteSpace(kinopoisk_id))
            {
                list.Add(new ServiceRatingRow()
                {
                    Id = Int64.Parse(kinopoisk_id),
                    ServiceUrl = "https://www.kinopoisk.ru/film/",
                    ServiceName = "kinopoisk.ru",
                    ServiceApi = "https://www.kinopoisk.ru/film/",
                    MovieId= movie.MovieId,
                });
            }
            if (id != null)
            {
                id.MovieId = movie.MovieId;
                list.Add(id);
            }
            return list;
        }
    }
    [XmlRoot(ElementName = "content")]
    public class Content
    {
        [XmlElement(ElementName = "movie")]
        public List<MovieJson> Movie;
        [XmlElement(ElementName = "serial")]
        public List<MovieJson> Serial;

        public ListResponse<MovieJson> All(MovieKind? movieKind)
        {
            var list = new ListResponse<MovieJson>();
            list.Entities = new List<MovieJson>();
            list.Keys = new List<long>();
            if (Movie != null && Movie.Count > 0)
            {
                Movie.ForEach(i =>
                {
                    try
                    {
                        i.movieKind = (movieKind.HasValue ? (MovieKind)movieKind : MovieKind.Film);
                        list.Entities.Add(i);
                    }
                    catch (Exception e)
                    {
                        SqlExceptionHelper.HandleSavePrimaryKeyException(e);
                    }
                });
            }
            if (Serial != null && Serial.Count > 0)
            {
                Serial.ForEach(i =>
                {
                    try
                    {
                        i.movieKind = (movieKind.HasValue ? (MovieKind)movieKind : MovieKind.TvSeries);
                        list.Entities.Add(i);
                    }
                    catch (Exception e)
                    {
                        SqlExceptionHelper.HandleSavePrimaryKeyException(e);
                    }
                });
            }
            return list;
        }
    }
    public class Root
    {
        public bool Has_next;
        public string Next;
        public List<MovieJson> Results;
    }
    public class StatusTask
    {
        public static int Count = 0;
        public static DateTime TimeStart;
        public static DateTime TimeEnd;
    }
    public class Element
    {
        public string id;
        public string name;
    }
    public class Translit
    {
        private static Dictionary<string, string> transliter = new Dictionary<string, string>();
        private static void prepareTranslit()
        {
            transliter.Add("а", "a");
            transliter.Add("б", "b");
            transliter.Add("в", "v");
            transliter.Add("г", "g");
            transliter.Add("д", "d");
            transliter.Add("е", "e");
            transliter.Add("ё", "yo");
            transliter.Add("ж", "zh");
            transliter.Add("з", "z");
            transliter.Add("и", "i");
            transliter.Add("й", "j");
            transliter.Add("к", "k");
            transliter.Add("л", "l");
            transliter.Add("м", "m");
            transliter.Add("н", "n");
            transliter.Add("о", "o");
            transliter.Add("п", "p");
            transliter.Add("р", "r");
            transliter.Add("с", "s");
            transliter.Add("т", "t");
            transliter.Add("у", "u");
            transliter.Add("ф", "f");
            transliter.Add("х", "h");
            transliter.Add("ц", "c");
            transliter.Add("ч", "ch");
            transliter.Add("ш", "sh");
            transliter.Add("щ", "sch");
            transliter.Add("ъ", "j");
            transliter.Add("ы", "i");
            transliter.Add("ь", "j");
            transliter.Add("э", "e");
            transliter.Add("ю", "yu");
            transliter.Add("я", "ya");
            transliter.Add("А", "A");
            transliter.Add("Б", "B");
            transliter.Add("В", "V");
            transliter.Add("Г", "G");
            transliter.Add("Д", "D");
            transliter.Add("Е", "E");
            transliter.Add("Ё", "Yo");
            transliter.Add("Ж", "Zh");
            transliter.Add("З", "Z");
            transliter.Add("И", "I");
            transliter.Add("Й", "J");
            transliter.Add("К", "K");
            transliter.Add("Л", "L");
            transliter.Add("М", "M");
            transliter.Add("Н", "N");
            transliter.Add("О", "O");
            transliter.Add("П", "P");
            transliter.Add("Р", "R");
            transliter.Add("С", "S");
            transliter.Add("Т", "T");
            transliter.Add("У", "U");
            transliter.Add("Ф", "F");
            transliter.Add("Х", "H");
            transliter.Add("Ц", "C");
            transliter.Add("Ч", "Ch");
            transliter.Add("Ш", "Sh");
            transliter.Add("Щ", "Sch");
            transliter.Add("Ъ", "J");
            transliter.Add("Ы", "I");
            transliter.Add("Ь", "J");
            transliter.Add("Э", "E");
            transliter.Add("Ю", "Yu");
            transliter.Add("Я", "Ya");
        }
        static Translit()
        {
            prepareTranslit();
        }

        public static string GetUrl(string sourceText)
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < sourceText.Length; i++)
            {
                if (char.IsWhiteSpace(sourceText[i]) || char.IsSymbol(sourceText[i]))
                {
                    ans.Append('-');
                }
                else if (char.IsNumber(sourceText[i]) || transliter.ContainsValue(sourceText[i].ToString()))
                {
                    ans.Append(sourceText[i].ToString());
                }
                else if (transliter.ContainsKey(sourceText[i].ToString()))
                {
                    ans.Append(transliter[sourceText[i].ToString()]);
                }

            }
            return ans.ToString();
        }
    }
}