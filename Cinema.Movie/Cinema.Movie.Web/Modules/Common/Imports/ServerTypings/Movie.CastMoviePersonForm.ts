

namespace Cinema.Movie.Movie {
    export class CastMoviePersonForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.CastMoviePerson';
    }

    export interface CastMoviePersonForm {
        CastId: Serenity.IntegerEditor;
        MovieId: Serenity.IntegerEditor;
        PersonId: Serenity.IntegerEditor;
    }

    [['CastId', () => Serenity.IntegerEditor], ['MovieId', () => Serenity.IntegerEditor], ['PersonId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(CastMoviePersonForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}