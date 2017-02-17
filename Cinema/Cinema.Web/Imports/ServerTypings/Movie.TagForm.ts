namespace Cinema.Movie {
    export class TagForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Tag';

    }

    export interface TagForm {
        Name: Serenity.StringEditor;
    }

    [['Name', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(TagForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

