
namespace Cinema.Movie.Movie.Pages
{
    using Entities;
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Casts = Repositories.CastRepository;
    using Histories = HistoryController;

    [RoutePrefix("Movie/Cast"), Route("{action=index}")]
    public class CastController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Movie/Cast/CastIndex.cshtml");
        }
        public static ListResponse<CastRow> List(ListRequest listRequest)
        {
            return new Casts().List(listRequest);
        }
        [PageAuthorize("Administration")]
        public static SaveResponse CreateUpdate(SaveRequest<CastRow> request)
        {
            SaveResponse result = null;
            try
            {
                result= new Casts().FindCreate(request);

                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow()
                    {
                        Status = true,
                        Message = "Add or Find Cast",
                        UserName = Authorization.Username,
                        CastId = Int64.Parse(result.EntityId.ToString()),
                    }
                });
            }
            catch (Exception e)
            {
                Histories.Create(new SaveRequest<HistoryRow>()
                {
                    Entity = new HistoryRow()
                    {
                        Status = result == null ? false : true,
                        Message = "Fail add or update cast" + e.Message,
                        UserName = Authorization.Username
                    }
                });
            }
            return result;
        }
    }
}