
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class PersonEditor extends Common.GridEditorBase<PersonRow> {
        protected getColumnsKey() { return 'Movie.Person'; }
        protected getDialogType() { return PersonEditorDialog; }
                protected getLocalTextPrefix() { return PersonRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}