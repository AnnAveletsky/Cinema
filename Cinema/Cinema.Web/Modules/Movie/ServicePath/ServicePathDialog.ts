
namespace Cinema.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServicePathDialog extends Serenity.EntityDialog<ServicePathRow, any> {
        protected getFormKey() { return ServicePathForm.formKey; }
        protected getIdProperty() { return ServicePathRow.idProperty; }
        protected getLocalTextPrefix() { return ServicePathRow.localTextPrefix; }
        protected getNameProperty() { return ServicePathRow.nameProperty; }
        protected getService() { return ServicePathService.baseUrl; }

        protected form = new ServicePathForm(this.idPrefix);

    }
}