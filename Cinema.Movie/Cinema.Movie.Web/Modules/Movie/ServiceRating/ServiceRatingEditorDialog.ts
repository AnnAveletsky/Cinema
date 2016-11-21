
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServiceRatingEditorDialog extends Common.GridEditorDialog<ServiceRatingRow> {
        protected getFormKey() { return ServiceRatingForm.formKey; }
                protected getLocalTextPrefix() { return ServiceRatingRow.localTextPrefix; }
        protected form = new ServiceRatingForm(this.idPrefix);
    }
}