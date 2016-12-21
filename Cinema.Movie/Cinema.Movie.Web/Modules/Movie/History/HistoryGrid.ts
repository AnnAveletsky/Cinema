
namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class HistoryGrid extends Serenity.EntityGrid<HistoryRow, any> {
        protected getColumnsKey() { return 'Movie.History'; }
        protected getDialogType() { return HistoryDialog; }
        protected getIdProperty() { return HistoryRow.idProperty; }
        protected getLocalTextPrefix() { return HistoryRow.localTextPrefix; }
        protected getService() { return HistoryService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}