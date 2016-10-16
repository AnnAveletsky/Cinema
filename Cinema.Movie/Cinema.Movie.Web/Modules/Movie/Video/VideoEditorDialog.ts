
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class VideoEditorDialog extends Common.GridEditorDialog<VideoRow> {
        protected getFormKey() { return VideoForm.formKey; }
                protected getLocalTextPrefix() { return VideoRow.localTextPrefix; }
        protected getNameProperty() { return VideoRow.nameProperty; }
        protected form = new VideoForm(this.idPrefix);
    }
}