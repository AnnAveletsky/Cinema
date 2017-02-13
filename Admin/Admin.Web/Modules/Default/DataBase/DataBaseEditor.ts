
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Admin.Default {
    
    @Serenity.Decorators.registerClass()
    export class DataBaseEditor extends Common.GridEditorBase<DataBaseRow> {
        protected getColumnsKey() { return 'Default.DataBase'; }
        protected getDialogType() { return DataBaseEditorDialog; }
                protected getLocalTextPrefix() { return DataBaseRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}