
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Administration {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class DataBaseEditorDialog extends Common.GridEditorDialog<DataBaseRow> {
        protected getFormKey() { return DataBaseForm.formKey; }
                protected getLocalTextPrefix() { return DataBaseRow.localTextPrefix; }
        protected getNameProperty() { return DataBaseRow.nameProperty; }
        protected form = new DataBaseForm(this.idPrefix);
    }
}