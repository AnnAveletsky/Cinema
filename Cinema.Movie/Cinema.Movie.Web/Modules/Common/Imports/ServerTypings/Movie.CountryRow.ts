namespace Cinema.Movie.Movie {
    export interface CountryRow {
        CountryId?: number;
        Name?: string;
    }

    export namespace CountryRow {
        export const idProperty = 'CountryId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Country';

        export namespace Fields {
            export declare const CountryId: string;
            export declare const Name: string;
        }

        ['CountryId', 'Name'].forEach(x => (<any>Fields)[x] = x);
    }
}

