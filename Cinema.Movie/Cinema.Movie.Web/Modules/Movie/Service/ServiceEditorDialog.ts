
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class ServiceEditorDialog extends Common.GridEditorDialog<ServiceRow> {
        protected getFormKey() { return ServiceForm.formKey; }
                protected getLocalTextPrefix() { return ServiceRow.localTextPrefix; }
        protected getNameProperty() { return ServiceRow.nameProperty; }
        protected form = new ServiceForm(this.idPrefix);
    }
}