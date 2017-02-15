
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class VideoEditor extends Common.GridEditorBase<VideoRow> {
        protected getColumnsKey() { return 'Movie.Video'; }
        protected getDialogType() { return VideoEditorDialog; }
                protected getLocalTextPrefix() { return VideoRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}