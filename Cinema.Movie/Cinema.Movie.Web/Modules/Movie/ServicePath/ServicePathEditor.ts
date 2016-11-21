
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServicePathEditor extends Common.GridEditorBase<ServicePathRow> {
        protected getColumnsKey() { return 'Movie.ServicePath'; }
        protected getDialogType() { return ServicePathEditorDialog; }
                protected getLocalTextPrefix() { return ServicePathRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}