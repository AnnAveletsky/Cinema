
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class MovieEditorDialog extends Common.GridEditorDialog<MovieRow> {
        protected getFormKey() { return MovieForm.formKey; }
                protected getLocalTextPrefix() { return MovieRow.localTextPrefix; }
        protected getNameProperty() { return MovieRow.nameProperty; }
        protected form = new MovieForm(this.idPrefix);
    }
}