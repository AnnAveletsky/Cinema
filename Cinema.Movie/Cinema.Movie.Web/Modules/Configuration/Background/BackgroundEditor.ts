
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Configuration {
    
    @Serenity.Decorators.registerClass()
    export class BackgroundEditor extends Common.GridEditorBase<BackgroundRow> {
        protected getColumnsKey() { return 'Configuration.Background'; }
        protected getDialogType() { return BackgroundEditorDialog; }
                protected getLocalTextPrefix() { return BackgroundRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}