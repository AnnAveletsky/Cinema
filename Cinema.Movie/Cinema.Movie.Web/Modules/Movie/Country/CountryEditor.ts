
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class CountryEditor extends Common.GridEditorBase<CountryRow> {
        protected getColumnsKey() { return 'Movie.Country'; }
        protected getDialogType() { return CountryEditorDialog; }
                protected getLocalTextPrefix() { return CountryRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}