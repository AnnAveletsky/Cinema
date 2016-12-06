namespace Cinema.Movie.Movie {
    export class PersonForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Person';

    }

    export interface PersonForm {
        FirstNameEn: Serenity.StringEditor;
        MiddleNameEn: Serenity.StringEditor;
        LastNameEn: Serenity.StringEditor;
        FirstNameOther: Serenity.StringEditor;
        MiddleNameOther: Serenity.StringEditor;
        LastNameOther: Serenity.StringEditor;
        BirthDate: Serenity.DateEditor;
        DeathDate: Serenity.DateEditor;
        BirthPlace: Serenity.StringEditor;
        Gender: Serenity.EnumEditor;
        About: Serenity.StringEditor;
        PathImage: Serenity.StringEditor;
    }

    [['FirstNameEn', () => Serenity.StringEditor], ['MiddleNameEn', () => Serenity.StringEditor], ['LastNameEn', () => Serenity.StringEditor], ['FirstNameOther', () => Serenity.StringEditor], ['MiddleNameOther', () => Serenity.StringEditor], ['LastNameOther', () => Serenity.StringEditor], ['BirthDate', () => Serenity.DateEditor], ['DeathDate', () => Serenity.DateEditor], ['BirthPlace', () => Serenity.StringEditor], ['Gender', () => Serenity.EnumEditor], ['About', () => Serenity.StringEditor], ['PathImage', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(PersonForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

