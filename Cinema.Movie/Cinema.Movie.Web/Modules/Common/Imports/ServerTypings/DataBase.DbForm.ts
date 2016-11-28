

namespace Cinema.Movie.DataBase {
    export class DbForm extends Serenity.PrefixedContext {
        static formKey = 'DataBase.Db';
    }

    export interface DbForm {
        Name: Serenity.StringEditor;
        ConnectionString: Serenity.StringEditor;
        ProviderName: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
        TagDataBaseMovie: Serenity.StringEditor;
    }

    [['DbId', () => Serenity.IntegerEditor], ['Name', () => Serenity.StringEditor], ['ConnectionString', () => Serenity.StringEditor], ['ProviderName', () => Serenity.StringEditor], ['Active', () => Serenity.BooleanEditor], ['TagDataBaseMovie', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(DbForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}