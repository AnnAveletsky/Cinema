
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class TagEditor extends Common.GridEditorBase<TagRow> {
        protected getColumnsKey() { return 'Movie.Tag'; }
        protected getDialogType() { return TagEditorDialog; }
                protected getLocalTextPrefix() { return TagRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}