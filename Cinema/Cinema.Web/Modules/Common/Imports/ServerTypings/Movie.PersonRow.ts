
namespace Cinema.Movie {
    export interface PersonRow {
        PersonId?: number;
        Name?: string;
        Url?: string;
        FullName?: string;
        NameOther?: string;
        FullNameOther?: string;
        BirthDate?: string;
        DeathDate?: string;
        Gender?: number;
        About?: string;
        PathImage?: string;
    }

    export namespace PersonRow {
        export const idProperty = 'PersonId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Person';

        export namespace Fields {
            export declare const PersonId;
            export declare const Name;
            export declare const Url;
            export declare const FullName;
            export declare const NameOther;
            export declare const FullNameOther;
            export declare const BirthDate;
            export declare const DeathDate;
            export declare const Gender;
            export declare const About;
            export declare const PathImage;
        }

        ['PersonId', 'Name', 'Url', 'FullName', 'NameOther', 'FullNameOther', 'BirthDate', 'DeathDate', 'Gender', 'About', 'PathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

