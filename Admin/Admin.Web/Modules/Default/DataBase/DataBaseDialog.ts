
namespace Admin.Default {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class DataBaseDialog extends Serenity.EntityDialog<DataBaseRow, any> {
        protected getFormKey() { return DataBaseForm.formKey; }
        protected getIdProperty() { return DataBaseRow.idProperty; }
        protected getLocalTextPrefix() { return DataBaseRow.localTextPrefix; }
        protected getNameProperty() { return DataBaseRow.nameProperty; }
        protected getService() { return DataBaseService.baseUrl; }

        protected form = new DataBaseForm(this.idPrefix);

    }
}