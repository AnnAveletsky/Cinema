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
            export declare const PersonId: string;
            export declare const Firstname: string;
            export declare const Lastname: string;
            export declare const BirthDate: string;
            export declare const BirthPlace: string;
            export declare const Gender: string;
            export declare const Height: string;
            export declare const PathImage: string;
            export declare const PathImageMini: string;
        }

        ['PersonId', 'Firstname', 'Lastname', 'BirthDate', 'BirthPlace', 'Gender', 'Height', 'PathImage', 'PathImageMini'].forEach(x => (<any>Fields)[x] = x);
    }
}

