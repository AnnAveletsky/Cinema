

namespace Cinema.Movie.Movie {
    export class HistoryForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.History';
    }

    export interface HistoryForm {
        UserName: Serenity.StringEditor;
        Message: Serenity.StringEditor;
        Status: Serenity.BooleanEditor;
        CastId: Serenity.IntegerEditor;
        CountryId: Serenity.IntegerEditor;
        GenreId: Serenity.IntegerEditor;
        ServiceId: Serenity.IntegerEditor;
        MovieId: Serenity.IntegerEditor;
        PersonId: Serenity.IntegerEditor;
        ImageId: Serenity.IntegerEditor;
        MovieCountryId: Serenity.IntegerEditor;
        ServicePathId: Serenity.IntegerEditor;
        ServiceRatingId: Serenity.IntegerEditor;
        MovieTagId: Serenity.IntegerEditor;
        TagId: Serenity.IntegerEditor;
        VideoId: Serenity.IntegerEditor;
        MovieGenreId: Serenity.IntegerEditor;
    }

    [['UserName', () => Serenity.StringEditor], ['Message', () => Serenity.StringEditor], ['Status', () => Serenity.BooleanEditor], ['CastId', () => Serenity.IntegerEditor], ['CountryId', () => Serenity.IntegerEditor], ['GenreId', () => Serenity.IntegerEditor], ['ServiceId', () => Serenity.IntegerEditor], ['MovieId', () => Serenity.IntegerEditor], ['PersonId', () => Serenity.IntegerEditor], ['ImageId', () => Serenity.IntegerEditor], ['MovieCountryId', () => Serenity.IntegerEditor], ['ServicePathId', () => Serenity.IntegerEditor], ['ServiceRatingId', () => Serenity.IntegerEditor], ['MovieTagId', () => Serenity.IntegerEditor], ['TagId', () => Serenity.IntegerEditor], ['VideoId', () => Serenity.IntegerEditor], ['MovieGenreId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(HistoryForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}