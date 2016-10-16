
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServiceEditor extends Common.GridEditorBase<ServiceRow> {
        protected getColumnsKey() { return 'Movie.Service'; }
        protected getDialogType() { return ServiceEditorDialog; }
                protected getLocalTextPrefix() { return ServiceRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}