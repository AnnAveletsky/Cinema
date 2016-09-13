
namespace Admin.MovieDB {
    
    @Serenity.Decorators.registerClass()
    export class GenreGrid extends Serenity.EntityGrid<GenreRow, any> {
        protected getColumnsKey() { return 'MovieDB.Genre'; }
        protected getDialogType() { return GenreDialog; }
        protected getIdProperty() { return GenreRow.idProperty; }
        protected getLocalTextPrefix() { return GenreRow.localTextPrefix; }
        protected getService() { return GenreService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}