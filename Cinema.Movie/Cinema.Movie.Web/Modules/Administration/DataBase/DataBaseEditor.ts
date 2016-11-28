
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Administration {
    
    @Serenity.Decorators.registerClass()
    export class DataBaseEditor extends Common.GridEditorBase<DataBaseRow> {
        protected getColumnsKey() { return 'Administration.DataBase'; }
        protected getDialogType() { return DataBaseEditorDialog; }
                protected getLocalTextPrefix() { return DataBaseRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}