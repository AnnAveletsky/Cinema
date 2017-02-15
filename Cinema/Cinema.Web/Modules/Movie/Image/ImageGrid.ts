
namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ImageGrid extends Serenity.EntityGrid<ImageRow, any> {
        protected getColumnsKey() { return 'Movie.Image'; }
        protected getDialogType() { return ImageDialog; }
        protected getIdProperty() { return ImageRow.idProperty; }
        protected getLocalTextPrefix() { return ImageRow.localTextPrefix; }
        protected getService() { return ImageService.baseUrl; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}