

namespace Cinema.Movie.Movie {
    export class CastForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Cast';
    }

    export interface CastForm {
        Character: Serenity.StringEditor;
    }

    [['Character', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(CastForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}