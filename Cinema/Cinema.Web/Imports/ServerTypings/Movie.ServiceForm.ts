namespace Cinema.Movie {
    export class ServiceForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Service';

    }

    export interface ServiceForm {
        Name: Serenity.StringEditor;
        Api: Serenity.StringEditor;
        Url: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
        IntervalRequest: Serenity.IntegerEditor;
        MaxRating: Serenity.IntegerEditor;
    }

    [['Name', () => Serenity.StringEditor], ['Api', () => Serenity.StringEditor], ['Url', () => Serenity.StringEditor], ['Active', () => Serenity.BooleanEditor], ['IntervalRequest', () => Serenity.IntegerEditor], ['MaxRating', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ServiceForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

