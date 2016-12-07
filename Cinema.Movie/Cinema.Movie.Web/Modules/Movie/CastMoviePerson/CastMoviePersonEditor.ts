
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class CastMoviePersonEditor extends Common.GridEditorBase<CastMoviePersonRow> {
        protected getColumnsKey() { return 'Movie.CastMoviePerson'; }
        protected getDialogType() { return CastMoviePersonEditorDialog; }
                protected getLocalTextPrefix() { return CastMoviePersonRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}