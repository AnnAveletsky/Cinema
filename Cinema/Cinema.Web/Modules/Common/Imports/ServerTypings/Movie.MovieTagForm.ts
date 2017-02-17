

namespace Cinema.Movie {
    export class MovieTagForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.MovieTag';
    }

    export interface MovieTagForm {
        TagId: Serenity.IntegerEditor;
        MovieId: Serenity.IntegerEditor;
    }

    [['TagId', () => Serenity.IntegerEditor], ['MovieId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MovieTagForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}