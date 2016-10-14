
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TagDialog extends Serenity.EntityDialog<TagRow, any> {
        protected getFormKey() { return TagForm.formKey; }
        protected getIdProperty() { return TagRow.idProperty; }
        protected getLocalTextPrefix() { return TagRow.localTextPrefix; }
        protected getNameProperty() { return TagRow.nameProperty; }
        protected getService() { return TagService.baseUrl; }

        protected form = new TagForm(this.idPrefix);

    }
}