
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ImageEditorDialog extends Common.GridEditorDialog<ImageRow> {
        protected getFormKey() { return ImageForm.formKey; }
                protected getLocalTextPrefix() { return ImageRow.localTextPrefix; }
        protected getNameProperty() { return ImageRow.nameProperty; }
        protected form = new ImageForm(this.idPrefix);
    }
}