
namespace Cinema.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class VideoDialog extends Serenity.EntityDialog<VideoRow, any> {
        protected getFormKey() { return VideoForm.formKey; }
        protected getIdProperty() { return VideoRow.idProperty; }
        protected getLocalTextPrefix() { return VideoRow.localTextPrefix; }
        protected getNameProperty() { return VideoRow.nameProperty; }
        protected getService() { return VideoService.baseUrl; }

        protected form = new VideoForm(this.idPrefix);

    }
}