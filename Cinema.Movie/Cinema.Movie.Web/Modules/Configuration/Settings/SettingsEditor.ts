
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie.Configuration {
    
    @Serenity.Decorators.registerClass()
    export class SettingsEditor extends Common.GridEditorBase<SettingsRow> {
        protected getColumnsKey() { return 'Configuration.Settings'; }
        protected getDialogType() { return SettingsEditorDialog; }
                protected getLocalTextPrefix() { return SettingsRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}