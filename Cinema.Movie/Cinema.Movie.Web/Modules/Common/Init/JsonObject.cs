using Cinema.Movie.Movie;
using Cinema.Movie.Movie.Entities;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Cinema.Movie.Common.Init
{
    public class JsonObject
    {
        public string name;
    }
    public class MovieJson:JsonObject
    {
        public string name_eng;
        public string year;
        public string url;
        public string sub_type;
        public string kinopoisk_id;
        public string player;
        public string trailer;
        public string poster_big;
        public string poster_small;
        public string title_ru;
        public string title_en;
        public string description;
        public string actors;
        public string country;
        public string director;
        public string screenwriter;
        public string producer;
        public string Operator;
        public string design;
        public string editor;
        public string composer;
        public string genre;
        public string time;
        public MovieRow ToMovie(MovieKind movieKind)
        {
            try
            {
                MovieRow Movie = new MovieRow();
                Movie.Kind = movieKind;
                if (year != "" && (title_en != null || name_eng != null || title_ru != null || name != null))
                {
                    Movie.YearEnd = Int16.Parse(year);
                    Movie.YearStart = Int16.Parse(year);

                    if (title_en != null)
                    {
                        name_eng = title_en;
                    }
                    if (title_ru != null)
                    {
                        name = title_ru;
                    }

                    if (name_eng == null || name_eng == "" || name_eng == name)
                    {
                        Movie.TitleOriginal = name;
                        Movie.Url = Translit.GetTranslit(name);
                    }
                    else
                    {
                        Movie.TitleOriginal = name_eng;
                        Movie.TitleTranslation = name;
                        if (name == null || name == "")
                        {
                            Movie.Url = Translit.GetUrl(name_eng);
                        }
                        else
                        {
                            Movie.Url = Translit.GetTranslit(name);
                        }
                    }
                    if (String.IsNullOrWhiteSpace(Movie.Url))
                    {
                        Movie.Url = kinopoisk_id;
                    }
                    Movie.Url += '-' + year;
                    Movie.PathImage = String.IsNullOrWhiteSpace(poster_big) ? poster_small : poster_big;
                    Movie.Description =new string[] { description };
                    Movie.Runtime = time;
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
            return result;
        }
        public List<CountryRow> ToCountries()
        {
            List<CountryRow> result = new List<CountryRow>();
            foreach (var i in country.Split(new[] { ", " }, StringSplitOptions.None))
            {
                if (!String.IsNullOrWhiteSpace(i) && i != "-")
                {
                    result.Add(new CountryRow()
                    {
                        Name = String.Concat(i)
                    });
                }
            }
            return result;
        }
        public List<CastRow> ToCast(SaveResponse movie, PersonRow person)
        {
            List<CastRow> casts = new List<CastRow>(); 
            if (actors.Contains(person.Name)|| !String.IsNullOrWhiteSpace(person.NameOther) && actors.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Actors",
                    CharacterOther = "Актёры",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (director.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther)&& director.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Director",
                    CharacterOther = "Режисёры",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (screenwriter.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && screenwriter.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Screenwriter",
                    CharacterOther = "Сценаристы",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (producer.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && producer.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Producer",
                    CharacterOther = "Продюсеры",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (Operator.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && Operator.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Operator",
                    CharacterOther = "Орераторы",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (design.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && design.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Design",
                    CharacterOther = "Дизайнеры",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (editor.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && editor.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Editor",
                    CharacterOther = "Редакторы",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            if (composer.Contains(person.Name) || !String.IsNullOrWhiteSpace(person.NameOther) && composer.Contains(person.NameOther))
            {
                casts.Add(new CastRow()
                {
                    CharacterEn = "Composer",
                    CharacterOther = "Композиторы",
                    MovieId = Int64.Parse(movie.EntityId.ToString()),
                    PersonId = person.PersonId
                });
            }
            return casts;
        }
        public List<PersonRow> ToPersons()
        {
            List<PersonRow> result = new List<PersonRow>();
            string persons = actors+", "+ director+ ", "+ screenwriter+ ", "+ producer+ ", "+ Operator+ ", "+ design+ ", " + editor+ ", " + composer;
            foreach (var i in persons.Split(new[] { ", " }, StringSplitOptions.None))
            {
                if (!String.IsNullOrWhiteSpace(i) && i != "-")
                {
                        result.Add(new PersonRow()
                        {
                            Name = i
                        });
                    
                }
            }
            return result;
        }
        public VideoRow ToVideo()
        {
            try
            {
                VideoRow Video = new VideoRow();
                if (player != null)
                {
                    url = player;
                }
                Video.Path = url;
                Video.Translation = sub_type != null&&sub_type!="" ? Int16.Parse(sub_type) : (Int16)0;
                return Video;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public ServicePathRow ToServicePath(ServiceRow service)
        {
            return new ServicePathRow() { };
        }
        public ServiceRatingRow ToServiceRating(ServiceRow service)
        {
            try
            {
                return new ServiceRatingRow() { Id = Int64.Parse(kinopoisk_id) };
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
    public class XmlObject
    {
        public Content content;
    }
    public class Content
    {
        public MovieJson[] Movie;
        public MovieJson[] Serial;
    }
    public class StatusTask
    {
        public static List<HistoryRow> tasks = new List<HistoryRow>();
        public static int Count = 0;
        public static DateTime TimeStart;
        public static DateTime TimeEnd;
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
        public static string GetTranslit(string sourceText)
        {
            string ans = "";
            for (int i = 0; i < sourceText.Length; i++)
            {
                if (transliter.ContainsKey(sourceText[i].ToString()))
                {
                    ans = ans + transliter[sourceText[i].ToString()];
                }
                else if (char.IsNumber(sourceText[i]))
                {
                    ans = ans + sourceText[i].ToString();
                }
                else if (char.IsWhiteSpace(sourceText[i]))
                {
                    ans = ans + '-';
                }
            }
            return ans.ToString();
        }
        public static string GetUrl(string sourceText)
        {
            string ans = "";
            for (int i = 0; i < sourceText.Length; i++)
            {
                if (char.IsWhiteSpace(sourceText[i]))
                {
                    ans = ans + '-';
                }
                else if (char.IsSymbol(sourceText[i]))
                {
                    ans = ans + sourceText[i].ToString();
                }
                else if (char.IsNumber(sourceText[i]))
                {
                    ans = ans + sourceText[i].ToString();
                }
            }
            return ans;
        }
    }
}