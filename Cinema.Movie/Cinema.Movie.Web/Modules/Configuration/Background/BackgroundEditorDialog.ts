
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Configuration {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class BackgroundEditorDialog extends Common.GridEditorDialog<BackgroundRow> {
        protected getFormKey() { return BackgroundForm.formKey; }
                protected getLocalTextPrefix() { return BackgroundRow.localTextPrefix; }
        protected getNameProperty() { return BackgroundRow.nameProperty; }
        protected form = new BackgroundForm(this.idPrefix);
    }
}