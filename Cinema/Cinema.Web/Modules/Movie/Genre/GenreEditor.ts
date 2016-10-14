
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class GenreEditor extends Common.GridEditorBase<GenreRow> {
        protected getColumnsKey() { return 'Movie.Genre'; }
        protected getDialogType() { return GenreEditorDialog; }
                protected getLocalTextPrefix() { return GenreRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}