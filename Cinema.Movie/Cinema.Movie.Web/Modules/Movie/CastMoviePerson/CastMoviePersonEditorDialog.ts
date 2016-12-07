
/// <reference path="../../Common/Helpers/GridEditorDialog.ts" />

namespace Cinema.Movie.Movie {
    
    @Serenity.Decorators.registerClass()
    @Serenity.Decorators.responsive()
    export class CastMoviePersonEditorDialog extends Common.GridEditorDialog<CastMoviePersonRow> {
        protected getFormKey() { return CastMoviePersonForm.formKey; }
                protected getLocalTextPrefix() { return CastMoviePersonRow.localTextPrefix; }
        protected form = new CastMoviePersonForm(this.idPrefix);
    }
}