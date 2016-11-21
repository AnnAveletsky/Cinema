
namespace Cinema.Movie.Movie {

    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServiceRatingDialog extends Serenity.EntityDialog<ServiceRatingRow, any> {
        protected getFormKey() { return ServiceRatingForm.formKey; }
        protected getIdProperty() { return ServiceRatingRow.idProperty; }
        protected getLocalTextPrefix() { return ServiceRatingRow.localTextPrefix; }
        protected getService() { return ServiceRatingService.baseUrl; }

        protected form = new ServiceRatingForm(this.idPrefix);

    }
}