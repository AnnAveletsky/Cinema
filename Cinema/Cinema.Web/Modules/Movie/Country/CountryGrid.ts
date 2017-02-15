
namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class CountryGrid extends Serenity.EntityGrid<CountryRow, any> {
        protected getColumnsKey() { return 'Movie.Country'; }
        protected getDialogType() { return CountryDialog; }
        protected getIdProperty() { return CountryRow.idProperty; }
        protected getLocalTextPrefix() { return CountryRow.localTextPrefix; }
        protected getService() { return CountryService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}