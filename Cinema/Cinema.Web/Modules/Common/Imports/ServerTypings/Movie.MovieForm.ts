

namespace Cinema.Movie {
    export class MovieForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Movie';
    }

    export interface MovieForm {
        TitleOriginal: Serenity.StringEditor;
        TitleTranslation: Serenity.StringEditor;
        Url: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        YearStart: Serenity.IntegerEditor;
        YearEnd: Serenity.IntegerEditor;
        ReleaseWorldDate: Serenity.DateEditor;
        ReleaseOtherDate: Serenity.DateEditor;
        ReleaseDvd: Serenity.DateEditor;
        Runtime: Serenity.StringEditor;
        CreateDateTime: Serenity.DateEditor;
        UpdateDateTime: Serenity.DateEditor;
        PublishDateTime: Serenity.DateEditor;
        Kind: Serenity.IntegerEditor;
        Rating: Serenity.IntegerEditor;
        Mpaa: Serenity.StringEditor;
        PathImage: Serenity.StringEditor;
        Nice: Serenity.BooleanEditor;
        ContSeason: Serenity.IntegerEditor;
        Tagline: Serenity.StringEditor;
        Budget: Serenity.DecimalEditor;
    }

    [['TitleOriginal', () => Serenity.StringEditor], ['TitleTranslation', () => Serenity.StringEditor], ['Url', () => Serenity.StringEditor], ['Description', () => Serenity.StringEditor], ['YearStart', () => Serenity.IntegerEditor], ['YearEnd', () => Serenity.IntegerEditor], ['ReleaseWorldDate', () => Serenity.DateEditor], ['ReleaseOtherDate', () => Serenity.DateEditor], ['ReleaseDvd', () => Serenity.DateEditor], ['Runtime', () => Serenity.StringEditor], ['CreateDateTime', () => Serenity.DateEditor], ['UpdateDateTime', () => Serenity.DateEditor], ['PublishDateTime', () => Serenity.DateEditor], ['Kind', () => Serenity.IntegerEditor], ['Rating', () => Serenity.IntegerEditor], ['Mpaa', () => Serenity.StringEditor], ['PathImage', () => Serenity.StringEditor], ['Nice', () => Serenity.BooleanEditor], ['ContSeason', () => Serenity.IntegerEditor], ['Tagline', () => Serenity.StringEditor], ['Budget', () => Serenity.DecimalEditor]].forEach(x => Object.defineProperty(MovieForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}