
namespace Cinema.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ImageDialog extends Serenity.EntityDialog<ImageRow, any> {
        protected getFormKey() { return ImageForm.formKey; }
        protected getIdProperty() { return ImageRow.idProperty; }
        protected getLocalTextPrefix() { return ImageRow.localTextPrefix; }
        protected getNameProperty() { return ImageRow.nameProperty; }
        protected getService() { return ImageService.baseUrl; }

        protected form = new ImageForm(this.idPrefix);

    }
}