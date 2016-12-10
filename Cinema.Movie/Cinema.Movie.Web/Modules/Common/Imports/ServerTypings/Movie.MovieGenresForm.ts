namespace Cinema.Movie.Movie {
    export class MovieGenresForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.MovieGenres';

    }

    export interface MovieGenresForm {
        MovieId: Serenity.StringEditor;
        GenreId: Serenity.IntegerEditor;
    }

    [['MovieId', () => Serenity.StringEditor], ['GenreId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MovieGenresForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

