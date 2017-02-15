
namespace Cinema.Movie {
    export interface GenreRow {
        GenreId?: number;
        Name?: string;
        Icon?: string;
        Style?: string;
    }

    export namespace GenreRow {
        export const idProperty = 'GenreId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Genre';

        export namespace Fields {
            export declare const GenreId;
            export declare const Name;
            export declare const Icon;
            export declare const Style;
        }

        ['GenreId', 'Name', 'Icon', 'Style'].forEach(x => (<any>Fields)[x] = x);
    }
}

