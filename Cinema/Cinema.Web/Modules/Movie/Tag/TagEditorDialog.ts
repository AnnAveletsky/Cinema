
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class TagEditorDialog extends Common.GridEditorDialog<TagRow> {
        protected getFormKey() { return TagForm.formKey; }
                protected getLocalTextPrefix() { return TagRow.localTextPrefix; }
        protected getNameProperty() { return TagRow.nameProperty; }
        protected form = new TagForm(this.idPrefix);
    }
}