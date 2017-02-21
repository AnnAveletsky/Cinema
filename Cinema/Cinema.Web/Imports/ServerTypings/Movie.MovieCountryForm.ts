namespace Cinema.Movie {
    export class MovieCountryForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.MovieCountry';

    }

    export interface MovieCountryForm {
        MovieId: Serenity.StringEditor;
        CountryId: Serenity.IntegerEditor;
    }

    [['MovieId', () => Serenity.StringEditor], ['CountryId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(MovieCountryForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

