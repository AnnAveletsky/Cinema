
namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    export class VideoGrid extends Serenity.EntityGrid<VideoRow, any> {
        protected getColumnsKey() { return 'Movie.Video'; }
        protected getDialogType() { return VideoDialog; }
        protected getIdProperty() { return VideoRow.idProperty; }
        protected getLocalTextPrefix() { return VideoRow.localTextPrefix; }
        protected getService() { return VideoService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}