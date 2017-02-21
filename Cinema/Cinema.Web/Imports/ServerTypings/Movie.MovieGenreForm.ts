namespace Cinema.Movie {
    export class MovieGenreForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.MovieGenre';

    }

    export interface MovieGenreForm {
        MovieId: Serenity.StringEditor;
        GenreId: Serenity.IntegerEditor;
    }

    [['MovieId', () => Serenity.StringEditor], ['GenreId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MovieGenreForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

