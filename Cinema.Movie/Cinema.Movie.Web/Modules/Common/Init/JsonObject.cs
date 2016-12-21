using Cinema.Movie.Movie;
using Cinema.Movie.Movie.Entities;
using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    if (Movie.Url == null || Movie.Url == "")
                    {
                        Movie.Url = kinopoisk_id;
                    }
                    Movie.Url += '-' + year;
                    Movie.PathImage = poster_big == null ? poster_small : poster_big;
                    Movie.Description = description;
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
                Video.Translation = sub_type != null ? Int16.Parse(sub_type) : (Int16)0;
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
    public class Files
    {
        public string Name { get; set; }
        public MovieKind MovieKind { get; set; }
        public string Service { get; set; }
    }
    public class StatusTask
    {
        public static List<Task> tasks = new List<Task>();
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