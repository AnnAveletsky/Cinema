
namespace Cinema.Movie.Movie {
    export interface PersonRow {
        PersonId?: number;
        Firstname?: string;
        Lastname?: string;
        BirthDate?: string;
        BirthPlace?: string;
        Gender?: number;
        Height?: number;
        PathImage?: string;
        PathImageMini?: string;
    }

    export namespace PersonRow {
        export const idProperty = 'PersonId';
        export const nameProperty = 'Firstname';
        export const localTextPrefix = 'Movie.Person';

        export namespace Fields {
            export declare const PersonId;
            export declare const Firstname;
            export declare const Lastname;
            export declare const BirthDate;
            export declare const BirthPlace;
            export declare const Gender;
            export declare const Height;
            export declare const PathImage;
            export declare const PathImageMini;
        }

        ['PersonId', 'Firstname', 'Lastname', 'BirthDate', 'BirthPlace', 'Gender', 'Height', 'PathImage', 'PathImageMini'].forEach(x => (<any>Fields)[x] = x);
    }
}

