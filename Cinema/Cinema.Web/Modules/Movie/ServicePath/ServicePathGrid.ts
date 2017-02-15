
namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServicePathGrid extends Serenity.EntityGrid<ServicePathRow, any> {
        protected getColumnsKey() { return 'Movie.ServicePath'; }
        protected getDialogType() { return ServicePathDialog; }
        protected getIdProperty() { return ServicePathRow.idProperty; }
        protected getLocalTextPrefix() { return ServicePathRow.localTextPrefix; }
        protected getService() { return ServicePathService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}