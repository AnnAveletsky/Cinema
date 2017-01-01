namespace Cinema.Movie.Movie {
    export class HistoryForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.History';

    }

    export interface HistoryForm {
        UserName: Serenity.StringEditor;
        EventDataTime: Serenity.DateEditor;
        Message: Serenity.StringEditor;
        Status: Serenity.BooleanEditor;
        CastId: Serenity.StringEditor;
        CountryId: Serenity.IntegerEditor;
        GenreId: Serenity.IntegerEditor;
        ServiceId: Serenity.IntegerEditor;
        MovieId: Serenity.StringEditor;
        PersonId: Serenity.StringEditor;
        ImageId: Serenity.StringEditor;
        MovieCountryId: Serenity.StringEditor;
        ServicePathId: Serenity.IntegerEditor;
        ServiceRatingId: Serenity.StringEditor;
        MovieTagId: Serenity.StringEditor;
        TagId: Serenity.StringEditor;
        VideoId: Serenity.StringEditor;
        MovieGenreId: Serenity.StringEditor;
    }

    [['UserName', () => Serenity.StringEditor], ['EventDataTime', () => Serenity.DateEditor], ['Message', () => Serenity.StringEditor], ['Status', () => Serenity.BooleanEditor], ['CastId', () => Serenity.StringEditor], ['CountryId', () => Serenity.IntegerEditor], ['GenreId', () => Serenity.IntegerEditor], ['ServiceId', () => Serenity.IntegerEditor], ['MovieId', () => Serenity.StringEditor], ['PersonId', () => Serenity.StringEditor], ['ImageId', () => Serenity.StringEditor], ['MovieCountryId', () => Serenity.StringEditor], ['ServicePathId', () => Serenity.IntegerEditor], ['ServiceRatingId', () => Serenity.StringEditor], ['MovieTagId', () => Serenity.StringEditor], ['TagId', () => Serenity.StringEditor], ['VideoId', () => Serenity.StringEditor], ['MovieGenreId', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(HistoryForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

