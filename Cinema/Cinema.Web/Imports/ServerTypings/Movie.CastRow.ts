namespace Cinema.Movie {
    export interface CastRow {
        CastId?: number;
        CharacterEn?: string;
        CharacterOther?: string;
        MovieId?: number;
        PersonId?: number;
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
        PersonName?: string;
        PersonUrl?: string;
        PersonFullName?: string;
        PersonNameOther?: string;
        PersonFullNameOther?: string;
        PersonBirthDate?: string;
        PersonDeathDate?: string;
        PersonGender?: number;
        PersonAbout?: string;
        PersonPathImage?: string;
    }

    export namespace CastRow {
        export const idProperty = 'CastId';
        export const nameProperty = 'CharacterEn';
        export const localTextPrefix = 'Movie.Cast';
        export const lookupKey = 'Movie.Cast';

        export function getLookup(): Q.Lookup<CastRow> {
            return Q.getLookup<CastRow>('Movie.Cast');
        }

        export namespace Fields {
            export declare const CastId: string;
            export declare const CharacterEn: string;
            export declare const CharacterOther: string;
            export declare const MovieId: string;
            export declare const PersonId: string;
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
            export declare const PersonName: string;
            export declare const PersonUrl: string;
            export declare const PersonFullName: string;
            export declare const PersonNameOther: string;
            export declare const PersonFullNameOther: string;
            export declare const PersonBirthDate: string;
            export declare const PersonDeathDate: string;
            export declare const PersonGender: string;
            export declare const PersonAbout: string;
            export declare const PersonPathImage: string;
        }

        ['CastId', 'CharacterEn', 'CharacterOther', 'MovieId', 'PersonId', 'MovieTitleOriginal', 'MovieTitleTranslation', 'MovieUrl', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieTagline', 'MovieBudget', 'PersonName', 'PersonUrl', 'PersonFullName', 'PersonNameOther', 'PersonFullNameOther', 'PersonBirthDate', 'PersonDeathDate', 'PersonGender', 'PersonAbout', 'PersonPathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

