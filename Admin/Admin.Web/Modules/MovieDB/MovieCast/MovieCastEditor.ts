/// <reference path="../../Common/Helpers/GridEditorBase.ts" />

namespace Admin.MovieDB {
    @Serenity.Decorators.registerEditor()
    export class MovieCastEditor extends Common.GridEditorBase<MovieCastRow> {
        protected getColumnsKey() { return "MovieDB.MovieCast"; }
        protected getDialogType() { return MovieCastEditDialog; }
        protected getLocalTextPrefix() { return MovieCastRow.localTextPrefix; }

        constructor(container: JQuery) {
            super(container);
        }

        protected getAddButtonCaption() {
            return "Add";
        }

        protected validateEntity(row: MovieCastRow, id: number) {
            if (!super.validateEntity(row, id))
                return false;

            row.PersonFullname = PersonRow.getLookup()
                .itemById[row.PersonId].Fullname;

            return true;
        }
    }
}