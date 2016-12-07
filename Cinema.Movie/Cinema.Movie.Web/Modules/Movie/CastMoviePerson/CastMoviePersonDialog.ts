
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CastMoviePersonDialog extends Serenity.EntityDialog<CastMoviePersonRow, any> {
        protected getFormKey() { return CastMoviePersonForm.formKey; }
        protected getIdProperty() { return CastMoviePersonRow.idProperty; }
        protected getLocalTextPrefix() { return CastMoviePersonRow.localTextPrefix; }
        protected getService() { return CastMoviePersonService.baseUrl; }

        protected form = new CastMoviePersonForm(this.idPrefix);

    }
}