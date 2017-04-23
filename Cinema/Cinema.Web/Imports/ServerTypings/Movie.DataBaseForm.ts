namespace Cinema.Movie {
    export class DataBaseForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.DataBase';

    }

    export interface DataBaseForm {
        Name: Serenity.StringEditor;
        ConnectionString: Serenity.StringEditor;
        ProviderName: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
        TagDataBaseMovie: Serenity.StringEditor;
        Type: Serenity.StringEditor;
    }

    [['Name', () => Serenity.StringEditor], ['ConnectionString', () => Serenity.StringEditor], ['ProviderName', () => Serenity.StringEditor], ['Active', () => Serenity.BooleanEditor], ['TagDataBaseMovie', () => Serenity.StringEditor], ['Type', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(DataBaseForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

