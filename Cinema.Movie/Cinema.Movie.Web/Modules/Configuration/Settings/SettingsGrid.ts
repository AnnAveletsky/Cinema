
namespace Cinema.Movie.Configuration {
    
    @Serenity.Decorators.registerClass()
    export class SettingsGrid extends Serenity.EntityGrid<SettingsRow, any> {
        protected getColumnsKey() { return 'Configuration.Settings'; }
        protected getDialogType() { return SettingsDialog; }
        protected getIdProperty() { return SettingsRow.idProperty; }
        protected getLocalTextPrefix() { return SettingsRow.localTextPrefix; }
        protected getService() { return SettingsService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}