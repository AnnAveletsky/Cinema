
namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServiceRatingGrid extends Serenity.EntityGrid<ServiceRatingRow, any> {
        protected getColumnsKey() { return 'Movie.ServiceRating'; }
        protected getDialogType() { return ServiceRatingDialog; }
        protected getIdProperty() { return ServiceRatingRow.idProperty; }
        protected getLocalTextPrefix() { return ServiceRatingRow.localTextPrefix; }
        protected getService() { return ServiceRatingService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}