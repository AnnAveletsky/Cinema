

namespace Cinema.Movie.Administration {
    export class DataBaseForm extends Serenity.PrefixedContext {
        static formKey = 'Administration.DataBase';
    }

    export interface DataBaseForm {
        Name: Serenity.StringEditor;
        ConnectionString: Serenity.StringEditor;
        ProviderName: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
        TagDataBaseMovie: Serenity.StringEditor;
    }

    [['DbId', () => Serenity.IntegerEditor], ['Name', () => Serenity.StringEditor], ['ConnectionString', () => Serenity.StringEditor], ['ProviderName', () => Serenity.StringEditor], ['Active', () => Serenity.BooleanEditor], ['TagDataBaseMovie', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(DataBaseForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}