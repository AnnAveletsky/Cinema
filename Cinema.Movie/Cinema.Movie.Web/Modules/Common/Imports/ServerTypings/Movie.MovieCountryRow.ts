namespace Cinema.Movie.Movie {
    export interface MovieCountryRow {
        MovieCountryId?: number;
        MovieId?: number;
        CountryId?: number;
        CountryName?: string;
    }

    export namespace MovieCountryRow {
        export const idProperty = 'MovieCountryId';
        export const localTextPrefix = 'Movie.MovieCountry';
        export const lookupKey = 'Movie.MovieCountry';

        export function getLookup(): Q.Lookup<MovieCountryRow> {
            return Q.getLookup<MovieCountryRow>('Movie.MovieCountry');
        }

        export namespace Fields {
            export declare const MovieCountryId: string;
            export declare const MovieId: string;
            export declare const CountryId: string;
            export declare const CountryName: string;
        }

        ['MovieCountryId', 'MovieId', 'CountryId', 'CountryName'].forEach(x => (<any>Fields)[x] = x);
    }
}

