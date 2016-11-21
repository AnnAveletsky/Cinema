
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CastEditorDialog extends Common.GridEditorDialog<CastRow> {
        protected getFormKey() { return CastForm.formKey; }
                protected getLocalTextPrefix() { return CastRow.localTextPrefix; }
        protected getNameProperty() { return CastRow.nameProperty; }
        protected form = new CastForm(this.idPrefix);
    }
}