
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class CastEditor extends Common.GridEditorBase<CastRow> {
        protected getColumnsKey() { return 'Movie.Cast'; }
        protected getDialogType() { return CastEditorDialog; }
                protected getLocalTextPrefix() { return CastRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}