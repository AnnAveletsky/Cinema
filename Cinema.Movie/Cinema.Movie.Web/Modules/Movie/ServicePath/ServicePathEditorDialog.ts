
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServicePathEditorDialog extends Common.GridEditorDialog<ServicePathRow> {
        protected getFormKey() { return ServicePathForm.formKey; }
                protected getLocalTextPrefix() { return ServicePathRow.localTextPrefix; }
        protected getNameProperty() { return ServicePathRow.nameProperty; }
        protected form = new ServicePathForm(this.idPrefix);
    }
}