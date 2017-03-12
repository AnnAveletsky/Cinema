namespace Cinema.Movie {
    export interface MovieCountryRow {
        MovieCountryId?: number;
        MovieId?: number;
        CountryId?: number;
        MovieTitleOriginal?: string;
        MovieTitleTranslation?: string;
        MovieUrl?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: string;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieTagline?: string;
        MovieBudget?: number;
        CountryName?: string;
        CountryNameOther?: string;
        CountryCode?: string;
        CountryIcon?: string;
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
            export declare const MovieTitleOriginal: string;
            export declare const MovieTitleTranslation: string;
            export declare const MovieUrl: string;
            export declare const MovieDescription: string;
            export declare const MovieYearStart: string;
            export declare const MovieYearEnd: string;
            export declare const MovieReleaseWorldDate: string;
            export declare const MovieReleaseOtherDate: string;
            export declare const MovieReleaseDvd: string;
            export declare const MovieRuntime: string;
            export declare const MovieCreateDateTime: string;
            export declare const MovieUpdateDateTime: string;
            export declare const MoviePublishDateTime: string;
            export declare const MovieKind: string;
            export declare const MovieRating: string;
            export declare const MovieMpaa: string;
            export declare const MoviePathImage: string;
            export declare const MovieNice: string;
            export declare const MovieContSeason: string;
            export declare const MovieTagline: string;
            export declare const MovieBudget: string;
            export declare const CountryName: string;
            export declare const CountryNameOther: string;
            export declare const CountryCode: string;
            export declare const CountryIcon: string;
        }

        ['MovieCountryId', 'MovieId', 'CountryId', 'MovieTitleOriginal', 'MovieTitleTranslation', 'MovieUrl', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieTagline', 'MovieBudget', 'CountryName', 'CountryNameOther', 'CountryCode', 'CountryIcon'].forEach(x => (<any>Fields)[x] = x);
    }
}

