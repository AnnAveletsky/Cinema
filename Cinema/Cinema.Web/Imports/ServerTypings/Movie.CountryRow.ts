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
            export declare const CountryId: string;
            export declare const Name: string;
            export declare const NameOther: string;
            export declare const Code: string;
            export declare const Icon: string;
        }

        ['CountryId', 'Name', 'NameOther', 'Code', 'Icon'].forEach(x => (<any>Fields)[x] = x);
    }
}

