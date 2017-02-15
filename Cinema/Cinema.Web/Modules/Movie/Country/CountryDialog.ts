
namespace Cinema.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CountryDialog extends Serenity.EntityDialog<CountryRow, any> {
        protected getFormKey() { return CountryForm.formKey; }
        protected getIdProperty() { return CountryRow.idProperty; }
        protected getLocalTextPrefix() { return CountryRow.localTextPrefix; }
        protected getNameProperty() { return CountryRow.nameProperty; }
        protected getService() { return CountryService.baseUrl; }

        protected form = new CountryForm(this.idPrefix);

    }
}