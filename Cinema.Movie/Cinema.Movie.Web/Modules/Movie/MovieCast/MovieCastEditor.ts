
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class MovieCastEditor extends Common.GridEditorBase<MovieCastRow> {
        protected getColumnsKey() { return 'Movie.MovieCast'; }
        protected getDialogType() { return MovieCastEditorDialog; }
                protected getLocalTextPrefix() { return MovieCastRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}