
namespace Admin.MovieDB {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class PersonDialog extends Serenity.EntityDialog<PersonRow, any> {
        protected getFormKey() { return PersonForm.formKey; }
        protected getIdProperty() { return PersonRow.idProperty; }
        protected getLocalTextPrefix() { return PersonRow.localTextPrefix; }
        protected getNameProperty() { return PersonRow.nameProperty; }
        protected getService() { return PersonService.baseUrl; }

        protected form = new PersonForm(this.idPrefix);

        private moviesGrid: PersonMovieGrid;

        constructor() {
            super();

            this.moviesGrid = new PersonMovieGrid(this.byId("MoviesGrid"));
            this.tabs.on('tabsactivate', (e, i) => {
                this.arrange();
            });
        }

        protected afterLoadEntity() {
            super.afterLoadEntity();

            this.moviesGrid.personID = this.entityId;
        }
    }
}