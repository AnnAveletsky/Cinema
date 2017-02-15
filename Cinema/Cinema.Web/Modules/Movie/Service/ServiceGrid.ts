
namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServiceGrid extends Serenity.EntityGrid<ServiceRow, any> {
        protected getColumnsKey() { return 'Movie.Service'; }
        protected getDialogType() { return ServiceDialog; }
        protected getIdProperty() { return ServiceRow.idProperty; }
        protected getLocalTextPrefix() { return ServiceRow.localTextPrefix; }
        protected getService() { return ServiceService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}