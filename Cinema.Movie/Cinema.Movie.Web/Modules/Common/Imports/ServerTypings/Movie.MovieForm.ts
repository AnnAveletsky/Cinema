namespace Cinema.Movie.Movie {
    export class MovieForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Movie';

    }

    export interface MovieForm {
        TitleEn: Serenity.StringEditor;
        TitleOther: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        YearStart: Serenity.IntegerEditor;
        YearEnd: Serenity.IntegerEditor;
        ReleaseWorldDate: Serenity.DateEditor;
        ReleaseOtherDate: Serenity.DateEditor;
        ReleaseDvd: Serenity.DateEditor;
        Runtime: Serenity.IntegerEditor;
        CreateDateTime: Serenity.DateEditor;
        UpdateDateTime: Serenity.DateEditor;
        PublishDateTime: Serenity.DateEditor;
        Kind: Serenity.EnumEditor;
        Rating: Serenity.IntegerEditor;
        Mpaa: Serenity.StringEditor;
        PathImage: Serenity.StringEditor;
        PathMiniImage: Serenity.StringEditor;
        Nice: Serenity.BooleanEditor;
        ContSeason: Serenity.IntegerEditor;
        LastEvent: Serenity.StringEditor;
        LastEventPublishDateTime: Serenity.DateEditor;
        Tagline: Serenity.StringEditor;
        Budget: Serenity.IntegerEditor;
        GenreList: Serenity.LookupEditor;
    }

    [['TitleEn', () => Serenity.StringEditor], ['TitleOther', () => Serenity.StringEditor], ['Description', () => Serenity.StringEditor], ['YearStart', () => Serenity.IntegerEditor], ['YearEnd', () => Serenity.IntegerEditor], ['ReleaseWorldDate', () => Serenity.DateEditor], ['ReleaseOtherDate', () => Serenity.DateEditor], ['ReleaseDvd', () => Serenity.DateEditor], ['Runtime', () => Serenity.IntegerEditor], ['CreateDateTime', () => Serenity.DateEditor], ['UpdateDateTime', () => Serenity.DateEditor], ['PublishDateTime', () => Serenity.DateEditor], ['Kind', () => Serenity.EnumEditor], ['Rating', () => Serenity.IntegerEditor], ['Mpaa', () => Serenity.StringEditor], ['PathImage', () => Serenity.StringEditor], ['PathMiniImage', () => Serenity.StringEditor], ['Nice', () => Serenity.BooleanEditor], ['ContSeason', () => Serenity.IntegerEditor], ['LastEvent', () => Serenity.StringEditor], ['LastEventPublishDateTime', () => Serenity.DateEditor], ['Tagline', () => Serenity.StringEditor], ['Budget', () => Serenity.IntegerEditor], ['GenreList', () => Serenity.LookupEditor]].forEach(x => Object.defineProperty(MovieForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

