
namespace Admin.MovieDB {
    
    @Serenity.Decorators.registerClass()
    export class PersonGrid extends Serenity.EntityGrid<PersonRow, any> {
        protected getColumnsKey() { return 'MovieDB.Person'; }
        protected getDialogType() { return PersonDialog; }
        protected getIdProperty() { return PersonRow.idProperty; }
        protected getLocalTextPrefix() { return PersonRow.localTextPrefix; }
        protected getService() { return PersonService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}