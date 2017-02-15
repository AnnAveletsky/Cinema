

namespace Cinema.Movie {
    export class ImageForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Image';
    }

    export interface ImageForm {
        Path: Serenity.StringEditor;
        MovieId: Serenity.IntegerEditor;
        PersonId: Serenity.IntegerEditor;
    }

    [['Path', () => Serenity.StringEditor], ['MovieId', () => Serenity.IntegerEditor], ['PersonId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ImageForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}