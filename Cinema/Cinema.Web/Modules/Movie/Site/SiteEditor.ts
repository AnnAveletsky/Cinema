
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class SiteEditor extends Common.GridEditorBase<SiteRow> {
        protected getColumnsKey() { return 'Movie.Site'; }
        protected getDialogType() { return SiteEditorDialog; }
                protected getLocalTextPrefix() { return SiteRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}