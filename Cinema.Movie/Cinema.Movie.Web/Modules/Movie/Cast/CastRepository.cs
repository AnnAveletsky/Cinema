

namespace Cinema.Movie.Movie.Repositories
{
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using MyRow = Entities.CastRow;
    using System.Linq;

    public class CastRepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }
        public RetrieveResponse<MyRow> Create(IUnitOfWork uow, IDbConnection connection, SaveRequest<MyRow> request)
        {
            return Retrieve(connection, new RetrieveRequest() { EntityId = Create(uow, request).EntityId });
        }
        public SaveResponse Create(IDbConnection connection, SaveRequest<MyRow> request)
        {
            SaveResponse result = null;
            using (var uow = new UnitOfWork(connection))
            {
                result = Create(uow, request);
                uow.Commit();
            }
            return result;
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
        public ListResponse<MyRow> List(ListRequest request)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                return List(connection, request);
            }
        }
        public SaveResponse Find(IDbConnection connection, SaveRequest<MyRow> request)
        {
            var list = List(connection, new ListRequest()
            {
                Criteria = new Criteria("CharacterEn") == request.Entity.CharacterEn && new Criteria("PersonId") == request.Entity.PersonId.Value && new Criteria("MovieId") == request.Entity.MovieId.Value
            });
            if (list.Entities != null && list.TotalCount > 0)
            {
                var first = list.Entities.First();
                if (first != null)
                {
                    return new SaveResponse() { EntityId=first.CastId};
                }
            }
            return new SaveResponse() { Error = new ServiceError() { Message = "Error Find Cast", Code = "CastFind" },EntityId=null };
        }
        public SaveResponse FindCreate(SaveRequest<MyRow> request)
        {
            using (var connection = SqlConnections.NewFor<MyRow>())
            {
                var res = Find(connection, request);
                if (res.EntityId == null || res.Error != null)
                {
                    res = Create(connection, request);
                }
                connection.Close();
                return res;
            }
        }
        
        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}