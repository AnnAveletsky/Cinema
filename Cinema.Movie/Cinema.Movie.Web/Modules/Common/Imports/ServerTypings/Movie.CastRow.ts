namespace Cinema.Movie.Movie {
    export interface CastRow {
        CastId?: number;
        CharacterEn?: string;
        CharacterOther?: string;
        MovieId?: number;
        PersonId?: number;
        MovieTitleOriginal?: string;
        MovieTitleTranslation?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MoviePathImage?: string;
        PersonName?: string;
        PersonFullName?: string;
        PersonNameOther?: string;
        PersonFullNameOther?: string;
        PersonUrl?: string;
        PersonBirthDate?: string;
        PersonDeathDate?: string;
        PersonBirthPlace?: string;
        PersonGender?: number;
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
            export declare const MovieYearStart: string;
            export declare const MovieYearEnd: string;
            export declare const MoviePathImage: string;
            export declare const PersonName: string;
            export declare const PersonFullName: string;
            export declare const PersonNameOther: string;
            export declare const PersonFullNameOther: string;
            export declare const PersonUrl: string;
            export declare const PersonBirthDate: string;
            export declare const PersonDeathDate: string;
            export declare const PersonBirthPlace: string;
            export declare const PersonGender: string;
            export declare const PersonPathImage: string;
        }

        ['CastId', 'CharacterEn', 'CharacterOther', 'MovieId', 'PersonId', 'MovieTitleOriginal', 'MovieTitleTranslation', 'MovieYearStart', 'MovieYearEnd', 'MoviePathImage', 'PersonName', 'PersonFullName', 'PersonNameOther', 'PersonFullNameOther', 'PersonUrl', 'PersonBirthDate', 'PersonDeathDate', 'PersonBirthPlace', 'PersonGender', 'PersonPathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

