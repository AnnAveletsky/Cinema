
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class GenreEditorDialog extends Common.GridEditorDialog<GenreRow> {
        protected getFormKey() { return GenreForm.formKey; }
                protected getLocalTextPrefix() { return GenreRow.localTextPrefix; }
        protected getNameProperty() { return GenreRow.nameProperty; }
        protected form = new GenreForm(this.idPrefix);
    }
}