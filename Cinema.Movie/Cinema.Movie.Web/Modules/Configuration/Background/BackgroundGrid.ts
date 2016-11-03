
namespace Cinema.Movie.Configuration {
    
    @Serenity.Decorators.registerClass()
    export class BackgroundGrid extends Serenity.EntityGrid<BackgroundRow, any> {
        protected getColumnsKey() { return 'Configuration.Background'; }
        protected getDialogType() { return BackgroundDialog; }
        protected getIdProperty() { return BackgroundRow.idProperty; }
        protected getLocalTextPrefix() { return BackgroundRow.localTextPrefix; }
        protected getService() { return BackgroundService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}