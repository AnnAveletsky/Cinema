
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class DataBaseEditor extends Common.GridEditorBase<DataBaseRow> {
        protected getColumnsKey() { return 'Movie.DataBase'; }
        protected getDialogType() { return DataBaseEditorDialog; }
                protected getLocalTextPrefix() { return DataBaseRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}