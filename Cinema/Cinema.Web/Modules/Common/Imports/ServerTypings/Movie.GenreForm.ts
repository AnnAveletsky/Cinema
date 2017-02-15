

namespace Cinema.Movie {
    export class GenreForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Genre';
    }

    export interface GenreForm {
        Name: Serenity.StringEditor;
        Icon: Serenity.StringEditor;
        Style: Serenity.StringEditor;
    }

    [['Name', () => Serenity.StringEditor], ['Icon', () => Serenity.StringEditor], ['Style', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(GenreForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}