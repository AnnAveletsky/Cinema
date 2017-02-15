
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class MovieEditor extends Common.GridEditorBase<MovieRow> {
        protected getColumnsKey() { return 'Movie.Movie'; }
        protected getDialogType() { return MovieEditorDialog; }
                protected getLocalTextPrefix() { return MovieRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}