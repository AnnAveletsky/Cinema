namespace Cinema.Movie {
    export class MovieTagForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.MovieTag';

    }

    export interface MovieTagForm {
        TagId: Serenity.StringEditor;
        MovieId: Serenity.StringEditor;
    }

    [['TagId', () => Serenity.StringEditor], ['MovieId', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(MovieTagForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

