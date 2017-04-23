
namespace Cinema.Administration {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class SiteDialog extends Serenity.EntityDialog<SiteRow, any> {
        protected getFormKey() { return SiteForm.formKey; }
        protected getIdProperty() { return SiteRow.idProperty; }
        protected getLocalTextPrefix() { return SiteRow.localTextPrefix; }
        protected getNameProperty() { return SiteRow.nameProperty; }
        protected getService() { return SiteService.baseUrl; }

        protected form = new SiteForm(this.idPrefix);

    }
}