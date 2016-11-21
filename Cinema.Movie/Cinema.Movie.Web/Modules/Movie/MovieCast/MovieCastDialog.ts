
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class MovieCastDialog extends Serenity.EntityDialog<MovieCastRow, any> {
        protected getFormKey() { return MovieCastForm.formKey; }
        protected getIdProperty() { return MovieCastRow.idProperty; }
        protected getLocalTextPrefix() { return MovieCastRow.localTextPrefix; }
        protected getNameProperty() { return MovieCastRow.nameProperty; }
        protected getService() { return MovieCastService.baseUrl; }

        protected form = new MovieCastForm(this.idPrefix);

    }
}