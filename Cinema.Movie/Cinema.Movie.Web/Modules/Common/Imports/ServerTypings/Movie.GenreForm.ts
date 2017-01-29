namespace Cinema.Movie.Movie {
    export class GenreForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Genre';

    }

    export interface GenreForm {
        Name: Serenity.StringEditor;
        Icon: Serenity.StringEditor;
        WidthPercent: Serenity.IntegerEditor;
    }

    [['Name', () => Serenity.StringEditor], ['Icon', () => Serenity.StringEditor], ['WidthPercent', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(GenreForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

