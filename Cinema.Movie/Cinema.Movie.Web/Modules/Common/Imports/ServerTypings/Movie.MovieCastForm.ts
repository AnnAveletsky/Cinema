

namespace Cinema.Movie.Movie {
    export class MovieCastForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.MovieCast';
    }

    export interface MovieCastForm {
        Character: Serenity.StringEditor;
        MovieId: Serenity.IntegerEditor;
        PersonId: Serenity.IntegerEditor;
    }

    [['Character', () => Serenity.StringEditor], ['MovieId', () => Serenity.IntegerEditor], ['PersonId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MovieCastForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}