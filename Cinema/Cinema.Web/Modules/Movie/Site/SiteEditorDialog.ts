
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class SiteEditorDialog extends Common.GridEditorDialog<SiteRow> {
        protected getFormKey() { return SiteForm.formKey; }
                protected getLocalTextPrefix() { return SiteRow.localTextPrefix; }
        protected getNameProperty() { return SiteRow.nameProperty; }
        protected form = new SiteForm(this.idPrefix);
    }
}