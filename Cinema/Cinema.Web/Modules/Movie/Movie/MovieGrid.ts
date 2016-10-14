
namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class MovieGrid extends Serenity.EntityGrid<MovieRow, any> {
        protected getColumnsKey() { return 'Movie.Movie'; }
        protected getDialogType() { return MovieDialog; }
        protected getIdProperty() { return MovieRow.idProperty; }
        protected getLocalTextPrefix() { return MovieRow.localTextPrefix; }
        protected getService() { return MovieService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}