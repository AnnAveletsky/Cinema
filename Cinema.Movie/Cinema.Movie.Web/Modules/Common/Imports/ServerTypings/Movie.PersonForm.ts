namespace Cinema.Movie.Movie {
    export class PersonForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Person';

    }

    export interface PersonForm {
        Firstname: Serenity.StringEditor;
        Lastname: Serenity.StringEditor;
        BirthDate: Serenity.DateEditor;
        BirthPlace: Serenity.StringEditor;
        Gender: Serenity.IntegerEditor;
        Height: Serenity.IntegerEditor;
        PathImage: Serenity.StringEditor;
        PathImageMini: Serenity.StringEditor;
    }

    [['Firstname', () => Serenity.StringEditor], ['Lastname', () => Serenity.StringEditor], ['BirthDate', () => Serenity.DateEditor], ['BirthPlace', () => Serenity.StringEditor], ['Gender', () => Serenity.IntegerEditor], ['Height', () => Serenity.IntegerEditor], ['PathImage', () => Serenity.StringEditor], ['PathImageMini', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(PersonForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

