
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CountryEditorDialog extends Common.GridEditorDialog<CountryRow> {
        protected getFormKey() { return CountryForm.formKey; }
                protected getLocalTextPrefix() { return CountryRow.localTextPrefix; }
        protected getNameProperty() { return CountryRow.nameProperty; }
        protected form = new CountryForm(this.idPrefix);
    }
}