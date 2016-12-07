
namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class CastMoviePersonGrid extends Serenity.EntityGrid<CastMoviePersonRow, any> {
        protected getColumnsKey() { return 'Movie.CastMoviePerson'; }
        protected getDialogType() { return CastMoviePersonDialog; }
        protected getIdProperty() { return CastMoviePersonRow.idProperty; }
        protected getLocalTextPrefix() { return CastMoviePersonRow.localTextPrefix; }
        protected getService() { return CastMoviePersonService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}