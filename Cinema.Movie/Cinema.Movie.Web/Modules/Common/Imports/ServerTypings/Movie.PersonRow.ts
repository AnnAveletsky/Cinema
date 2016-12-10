namespace Cinema.Movie.Movie {
    export interface PersonRow {
        PersonId?: number;
        NameEn?: string;
        FullNameEn?: string;
        NameOther?: string;
        FullNameOther?: string;
        BirthDate?: string;
        DeathDate?: string;
        BirthPlace?: string;
        Gender?: Gender;
        About?: string;
        PathImage?: string;
    }

    export namespace PersonRow {
        export const idProperty = 'PersonId';
        export const nameProperty = 'NameEn';
        export const localTextPrefix = 'Movie.Person';
        export const lookupKey = 'Movie.Person';

        export function getLookup(): Q.Lookup<PersonRow> {
            return Q.getLookup<PersonRow>('Movie.Person');
        }

        export namespace Fields {
            export declare const PersonId: string;
            export declare const NameEn: string;
            export declare const FullNameEn: string;
            export declare const NameOther: string;
            export declare const FullNameOther: string;
            export declare const BirthDate: string;
            export declare const DeathDate: string;
            export declare const BirthPlace: string;
            export declare const Gender: string;
            export declare const About: string;
            export declare const PathImage: string;
        }

        ['PersonId', 'NameEn', 'FullNameEn', 'NameOther', 'FullNameOther', 'BirthDate', 'DeathDate', 'BirthPlace', 'Gender', 'About', 'PathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

