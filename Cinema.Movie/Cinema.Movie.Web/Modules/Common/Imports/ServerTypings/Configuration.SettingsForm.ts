namespace Cinema.Movie.Configuration {
    export class SettingsForm extends Serenity.PrefixedContext {
        static formKey = 'Configuration.Settings';

    }

    export interface SettingsForm {
        Setting: Serenity.StringEditor;
        Value: Serenity.StringEditor;
        Type: Serenity.StringEditor;
    }

    [['Setting', () => Serenity.StringEditor], ['Value', () => Serenity.StringEditor], ['Type', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(SettingsForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

