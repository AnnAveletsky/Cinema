namespace Cinema.Movie.Movie {
    export class PersonForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Person';

    }

    export interface PersonForm {
        NameEn: Serenity.StringEditor;
        FullNameEn: Serenity.StringEditor;
        NameOther: Serenity.StringEditor;
        FullNameOther: Serenity.StringEditor;
        BirthDate: Serenity.DateEditor;
        DeathDate: Serenity.DateEditor;
        Gender: Serenity.EnumEditor;
        About: Serenity.StringEditor;
        PathImage: Serenity.StringEditor;
    }

    [['NameEn', () => Serenity.StringEditor], ['FullNameEn', () => Serenity.StringEditor], ['NameOther', () => Serenity.StringEditor], ['FullNameOther', () => Serenity.StringEditor], ['BirthDate', () => Serenity.DateEditor], ['DeathDate', () => Serenity.DateEditor], ['Gender', () => Serenity.EnumEditor], ['About', () => Serenity.StringEditor], ['PathImage', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(PersonForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

