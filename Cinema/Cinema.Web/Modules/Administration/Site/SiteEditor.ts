
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Administration {
    
    @Serenity.Decorators.registerClass()
    export class SiteEditor extends Common.GridEditorBase<SiteRow> {
        protected getColumnsKey() { return 'Administration.Site'; }
        protected getDialogType() { return SiteEditorDialog; }
                protected getLocalTextPrefix() { return SiteRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}