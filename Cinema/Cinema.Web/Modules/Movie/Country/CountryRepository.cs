

namespace Cinema.Movie.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Linq;
    using MyRow = Entities.CountryRow;

    public class CountryRepository
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


        public SaveResponse FindUpdate(IUnitOfWork uow, SaveRequest<MyRow> newRow, ListRequest request)
        {
            SaveRequest<MyRow> oldRow = new SaveRequest<MyRow>() { Entity = List(uow.Connection, request).Entities.First() };
            
            if (String.IsNullOrWhiteSpace(oldRow.Entity.Name) &&
                !String.IsNullOrWhiteSpace(newRow.Entity.Name))
            {
                oldRow.Entity.Name = newRow.Entity.Name;
            }
            if (String.IsNullOrWhiteSpace(oldRow.Entity.NameOther) &&
               !String.IsNullOrWhiteSpace(newRow.Entity.NameOther))
            {
                oldRow.Entity.NameOther = newRow.Entity.NameOther;
            }
            return new MySaveHandler().Process(uow, oldRow, SaveRequestType.Update);
        }
        public SaveResponse UpdateCreate(IUnitOfWork uow, SaveRequest<MyRow> saveRequest)
        {
            ListRequest listRequest = new ListRequest() { Criteria = Criteria(saveRequest.Entity) };
            if (Exist(uow.Connection, listRequest))
            {
                return FindUpdate(uow, saveRequest, listRequest);
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
        public bool Exist(IDbConnection connection, ListRequest request)
        {
            return List(connection, request).TotalCount > 0;
        }
        public BaseCriteria Criteria(MyRow request)
        {
            return new Criteria("Code") == request.Code;
        }
    }
}