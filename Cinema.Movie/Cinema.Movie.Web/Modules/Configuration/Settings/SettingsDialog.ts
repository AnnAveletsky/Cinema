
namespace Cinema.Movie.Configuration {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class SettingsDialog extends Serenity.EntityDialog<SettingsRow, any> {
        protected getFormKey() { return SettingsForm.formKey; }
        protected getIdProperty() { return SettingsRow.idProperty; }
        protected getLocalTextPrefix() { return SettingsRow.localTextPrefix; }
        protected getNameProperty() { return SettingsRow.nameProperty; }
        protected getService() { return SettingsService.baseUrl; }

        protected form = new SettingsForm(this.idPrefix);

    }
}