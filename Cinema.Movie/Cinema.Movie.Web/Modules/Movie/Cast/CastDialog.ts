
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CastDialog extends Serenity.EntityDialog<CastRow, any> {
        protected getFormKey() { return CastForm.formKey; }
        protected getIdProperty() { return CastRow.idProperty; }
        protected getLocalTextPrefix() { return CastRow.localTextPrefix; }
        protected getNameProperty() { return CastRow.nameProperty; }
        protected getService() { return CastService.baseUrl; }

        protected form = new CastForm(this.idPrefix);

    }
}