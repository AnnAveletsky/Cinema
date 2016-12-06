namespace Cinema.Movie.Movie {
    export interface PersonRow {
        PersonId?: number;
        FirstNameEn?: string;
        MiddleNameEn?: string;
        LastNameEn?: string;
        FirstNameOther?: string;
        MiddleNameOther?: string;
        LastNameOther?: string;
        BirthDate?: string;
        DeathDate?: string;
        BirthPlace?: string;
        Gender?: Gender;
        About?: string;
        PathImage?: string;
    }

    export namespace PersonRow {
        export const idProperty = 'PersonId';
        export const nameProperty = 'FirstNameOther';
        export const localTextPrefix = 'Movie.Person';

        export namespace Fields {
            export declare const PersonId: string;
            export declare const FirstNameEn: string;
            export declare const MiddleNameEn: string;
            export declare const LastNameEn: string;
            export declare const FirstNameOther: string;
            export declare const MiddleNameOther: string;
            export declare const LastNameOther: string;
            export declare const BirthDate: string;
            export declare const DeathDate: string;
            export declare const BirthPlace: string;
            export declare const Gender: string;
            export declare const About: string;
            export declare const PathImage: string;
        }

        ['PersonId', 'FirstNameEn', 'MiddleNameEn', 'LastNameEn', 'FirstNameOther', 'MiddleNameOther', 'LastNameOther', 'BirthDate', 'DeathDate', 'BirthPlace', 'Gender', 'About', 'PathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

