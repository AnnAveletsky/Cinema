
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Configuration {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class SettingsEditorDialog extends Common.GridEditorDialog<SettingsRow> {
        protected getFormKey() { return SettingsForm.formKey; }
                protected getLocalTextPrefix() { return SettingsRow.localTextPrefix; }
        protected getNameProperty() { return SettingsRow.nameProperty; }
        protected form = new SettingsForm(this.idPrefix);
    }
}