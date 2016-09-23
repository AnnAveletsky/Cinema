

namespace Cinema.Movie {
    export class MovieForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Movie';
    }

    export interface MovieForm {
        Title: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        Storyline: Serenity.StringEditor;
        Year: Serenity.IntegerEditor;
        ReleaseDate: Serenity.DateEditor;
        Runtime: Serenity.IntegerEditor;
    }

    [['Title', () => Serenity.StringEditor], ['Description', () => Serenity.StringEditor], ['Storyline', () => Serenity.StringEditor], ['Year', () => Serenity.IntegerEditor], ['ReleaseDate', () => Serenity.DateEditor], ['Runtime', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MovieForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}