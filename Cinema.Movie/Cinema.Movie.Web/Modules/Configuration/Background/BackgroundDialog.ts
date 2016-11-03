
namespace Cinema.Movie.Configuration {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class BackgroundDialog extends Serenity.EntityDialog<BackgroundRow, any> {
        protected getFormKey() { return BackgroundForm.formKey; }
        protected getIdProperty() { return BackgroundRow.idProperty; }
        protected getLocalTextPrefix() { return BackgroundRow.localTextPrefix; }
        protected getNameProperty() { return BackgroundRow.nameProperty; }
        protected getService() { return BackgroundService.baseUrl; }

        protected form = new BackgroundForm(this.idPrefix);

    }
}