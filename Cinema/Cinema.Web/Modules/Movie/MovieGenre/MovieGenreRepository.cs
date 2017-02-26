

namespace Cinema.Movie.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.MovieGenreRow;

    public class MovieGenreRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }


        public SaveResponse ExistCreate(IUnitOfWork uow, SaveRequest<MyRow> saveRequest)
        {
            ListRequest listRequest = new ListRequest() { Criteria = Criteria(saveRequest.Entity) };
            var entity = Exist(uow.Connection, listRequest);
            if (entity >= 0)
            {
                return new SaveResponse() { EntityId = entity };
            }
            else
            {
                return Create(uow, saveRequest);
            }
        }
        public RetrieveResponse<MyRow> Find(IDbConnection connection, ListRequest request)
        {
            return new RetrieveResponse<MyRow>()
            {
                Entity = List(connection, request).Entities.First()
            };
        }
        public Int32 Exist(IDbConnection connection, ListRequest request)
        {
            var list = List(connection, request).Entities;
            var id = list!=null&& list.Count > 0 ? list.First().GenreId : -1;
            return id != null ? (Int32)id : -1;
        }
        public BaseCriteria Criteria(MyRow request)
        {
            return new Criteria("MovieId") == (Int64)request.MovieId && new Criteria("GenreId") == (Int32)request.GenreId;
        }
    }
}