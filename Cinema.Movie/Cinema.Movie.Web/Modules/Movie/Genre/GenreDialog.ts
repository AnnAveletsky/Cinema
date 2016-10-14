
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class GenreDialog extends Serenity.EntityDialog<GenreRow, any> {
        protected getFormKey() { return GenreForm.formKey; }
        protected getIdProperty() { return GenreRow.idProperty; }
        protected getLocalTextPrefix() { return GenreRow.localTextPrefix; }
        protected getNameProperty() { return GenreRow.nameProperty; }
        protected getService() { return GenreService.baseUrl; }

        protected form = new GenreForm(this.idPrefix);

    }
}