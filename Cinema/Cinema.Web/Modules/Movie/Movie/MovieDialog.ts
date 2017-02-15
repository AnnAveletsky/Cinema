
namespace Cinema.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class MovieDialog extends Serenity.EntityDialog<MovieRow, any> {
        protected getFormKey() { return MovieForm.formKey; }
        protected getIdProperty() { return MovieRow.idProperty; }
        protected getLocalTextPrefix() { return MovieRow.localTextPrefix; }
        protected getNameProperty() { return MovieRow.nameProperty; }
        protected getService() { return MovieService.baseUrl; }

        protected form = new MovieForm(this.idPrefix);

    }
}