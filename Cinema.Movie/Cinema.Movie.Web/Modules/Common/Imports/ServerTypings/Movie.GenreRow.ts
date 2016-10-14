
namespace Cinema.Movie.Movie {
    export interface GenreRow {
        GenreId?: number;
        Name?: string;
    }

    export namespace GenreRow {
        export const idProperty = 'GenreId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Genre';

        export namespace Fields {
            export declare const GenreId;
            export declare const Name;
        }

        ['GenreId', 'Name'].forEach(x => (<any>Fields)[x] = x);
    }
}

