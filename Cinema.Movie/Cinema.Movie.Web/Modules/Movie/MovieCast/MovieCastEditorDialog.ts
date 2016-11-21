
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class MovieCastEditorDialog extends Common.GridEditorDialog<MovieCastRow> {
        protected getFormKey() { return MovieCastForm.formKey; }
                protected getLocalTextPrefix() { return MovieCastRow.localTextPrefix; }
        protected getNameProperty() { return MovieCastRow.nameProperty; }
        protected form = new MovieCastForm(this.idPrefix);
    }
}