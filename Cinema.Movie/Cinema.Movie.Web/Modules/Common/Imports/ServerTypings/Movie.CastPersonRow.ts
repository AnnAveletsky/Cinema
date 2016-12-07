
namespace Cinema.Movie.Movie {
    export interface CastPersonRow {
        CastPersonId?: number;
        CastId?: number;
        PersonId?: number;
        CastCharacter?: string;
        PersonFirstNameEn?: string;
        PersonMiddleNameEn?: string;
        PersonLastNameEn?: string;
        PersonFirstNameOther?: string;
        PersonMiddleNameOther?: string;
        PersonLastNameOther?: string;
        PersonBirthDate?: string;
        PersonDeathDate?: string;
        PersonBirthPlace?: string;
        PersonGender?: number;
        PersonAbout?: string;
        PersonPathImage?: string;
    }

    export namespace CastPersonRow {
        export const idProperty = 'CastPersonId';
        export const localTextPrefix = 'Movie.CastPerson';

        export namespace Fields {
            export declare const CastPersonId;
            export declare const CastId;
            export declare const PersonId;
            export declare const CastCharacter: string;
            export declare const PersonFirstNameEn: string;
            export declare const PersonMiddleNameEn: string;
            export declare const PersonLastNameEn: string;
            export declare const PersonFirstNameOther: string;
            export declare const PersonMiddleNameOther: string;
            export declare const PersonLastNameOther: string;
            export declare const PersonBirthDate: string;
            export declare const PersonDeathDate: string;
            export declare const PersonBirthPlace: string;
            export declare const PersonGender: string;
            export declare const PersonAbout: string;
            export declare const PersonPathImage: string;
        }

        ['CastPersonId', 'CastId', 'PersonId', 'CastCharacter', 'PersonFirstNameEn', 'PersonMiddleNameEn', 'PersonLastNameEn', 'PersonFirstNameOther', 'PersonMiddleNameOther', 'PersonLastNameOther', 'PersonBirthDate', 'PersonDeathDate', 'PersonBirthPlace', 'PersonGender', 'PersonAbout', 'PersonPathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

