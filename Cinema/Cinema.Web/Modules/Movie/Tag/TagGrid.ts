
namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class TagGrid extends Serenity.EntityGrid<TagRow, any> {
        protected getColumnsKey() { return 'Movie.Tag'; }
        protected getDialogType() { return TagDialog; }
        protected getIdProperty() { return TagRow.idProperty; }
        protected getLocalTextPrefix() { return TagRow.localTextPrefix; }
        protected getService() { return TagService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}