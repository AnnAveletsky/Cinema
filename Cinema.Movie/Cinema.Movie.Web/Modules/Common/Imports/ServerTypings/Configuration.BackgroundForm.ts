namespace Cinema.Movie.Configuration {
    export class BackgroundForm extends Serenity.PrefixedContext {
        static formKey = 'Configuration.Background';

    }

    export interface BackgroundForm {
        Color: Serenity.StringEditor;
        Path: Serenity.StringEditor;
        Size: Serenity.StringEditor;
    }

    [['Color', () => Serenity.StringEditor], ['Path', () => Serenity.StringEditor], ['Size', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(BackgroundForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

