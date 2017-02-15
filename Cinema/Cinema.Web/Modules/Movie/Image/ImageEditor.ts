
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ImageEditor extends Common.GridEditorBase<ImageRow> {
        protected getColumnsKey() { return 'Movie.Image'; }
        protected getDialogType() { return ImageEditorDialog; }
                protected getLocalTextPrefix() { return ImageRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}