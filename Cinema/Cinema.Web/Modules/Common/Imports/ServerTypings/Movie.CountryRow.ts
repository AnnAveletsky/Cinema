
namespace Cinema.Movie {
    export interface CountryRow {
        CountryId?: number;
        Name?: string;
        NameOther?: string;
        Code?: string;
        Icon?: string;
    }

    export namespace CountryRow {
        export const idProperty = 'CountryId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Country';

        export namespace Fields {
            export declare const CountryId;
            export declare const Name;
            export declare const NameOther;
            export declare const Code;
            export declare const Icon;
        }

        ['CountryId', 'Name', 'NameOther', 'Code', 'Icon'].forEach(x => (<any>Fields)[x] = x);
    }
}

