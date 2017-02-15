
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class PersonEditorDialog extends Common.GridEditorDialog<PersonRow> {
        protected getFormKey() { return PersonForm.formKey; }
                protected getLocalTextPrefix() { return PersonRow.localTextPrefix; }
        protected getNameProperty() { return PersonRow.nameProperty; }
        protected form = new PersonForm(this.idPrefix);
    }
}