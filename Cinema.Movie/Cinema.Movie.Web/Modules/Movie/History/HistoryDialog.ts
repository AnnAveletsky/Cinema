
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class HistoryDialog extends Serenity.EntityDialog<HistoryRow, any> {
        protected getFormKey() { return HistoryForm.formKey; }
        protected getIdProperty() { return HistoryRow.idProperty; }
        protected getLocalTextPrefix() { return HistoryRow.localTextPrefix; }
        protected getNameProperty() { return HistoryRow.nameProperty; }
        protected getService() { return HistoryService.baseUrl; }

        protected form = new HistoryForm(this.idPrefix);

    }
}