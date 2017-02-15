
/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Cinema.Movie {
    
    @Serenity.Decorators.registerClass()
    export class ServiceRatingEditor extends Common.GridEditorBase<ServiceRatingRow> {
        protected getColumnsKey() { return 'Movie.ServiceRating'; }
        protected getDialogType() { return ServiceRatingEditorDialog; }
                protected getLocalTextPrefix() { return ServiceRatingRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }
    }
}