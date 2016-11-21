
namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class CastGrid extends Serenity.EntityGrid<CastRow, any> {
        protected getColumnsKey() { return 'Movie.Cast'; }
        protected getDialogType() { return CastDialog; }
        protected getIdProperty() { return CastRow.idProperty; }
        protected getLocalTextPrefix() { return CastRow.localTextPrefix; }
        protected getService() { return CastService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}