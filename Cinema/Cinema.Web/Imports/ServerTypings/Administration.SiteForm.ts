namespace Cinema.Administration {
    export class SiteForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.Site';

    }

    export interface SiteForm {
        Name: Serenity.StringEditor;
        Url: Serenity.StringEditor;
        Title: Serenity.StringEditor;
        Background: Serenity.StringEditor;
        Logo: Serenity.StringEditor;
        Color: Serenity.StringEditor;
        DataBaseId: Serenity.IntegerEditor;
    }

    [['Name', () => Serenity.StringEditor], ['Url', () => Serenity.StringEditor], ['Title', () => Serenity.StringEditor], ['Background', () => Serenity.StringEditor], ['Logo', () => Serenity.StringEditor], ['Color', () => Serenity.StringEditor], ['DataBaseId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(SiteForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

