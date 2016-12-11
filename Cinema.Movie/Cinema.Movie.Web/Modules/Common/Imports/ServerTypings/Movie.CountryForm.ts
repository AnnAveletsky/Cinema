﻿namespace Cinema.Movie.Movie {
    export class CountryForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Country';

    }

    export interface CountryForm {
        Name: Serenity.StringEditor;
    }

    [['Name', () => Serenity.StringEditor]].forEach(x => Object.defineProperty(CountryForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

