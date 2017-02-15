
namespace Cinema.Administration {
    
    @Serenity.Decorators.registerClass()
    export class DataBaseGrid extends Serenity.EntityGrid<DataBaseRow, any> {
        protected getColumnsKey() { return 'Administration.DataBase'; }
        protected getDialogType() { return DataBaseDialog; }
        protected getIdProperty() { return DataBaseRow.idProperty; }
        protected getLocalTextPrefix() { return DataBaseRow.localTextPrefix; }
        protected getService() { return DataBaseService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}