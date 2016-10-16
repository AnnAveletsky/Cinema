
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServiceDialog extends Serenity.EntityDialog<ServiceRow, any> {
        protected getFormKey() { return ServiceForm.formKey; }
        protected getIdProperty() { return ServiceRow.idProperty; }
        protected getLocalTextPrefix() { return ServiceRow.localTextPrefix; }
        protected getNameProperty() { return ServiceRow.nameProperty; }
        protected getService() { return ServiceService.baseUrl; }

        protected form = new ServiceForm(this.idPrefix);

    }
}