namespace Cinema.Movie.Movie {
    export interface MovieTagRow {
        MovieTagId?: number;
        TagId?: number;
        MovieId?: number;
        TagName?: string;
    }

    export namespace MovieTagRow {
        export const idProperty = 'MovieTagId';
        export const localTextPrefix = 'Movie.MovieTag';

        export namespace Fields {
            export declare const MovieTagId: string;
            export declare const TagId: string;
            export declare const MovieId: string;
            export declare const TagName: string;
        }

        ['MovieTagId', 'TagId', 'MovieId', 'TagName'].forEach(x => (<any>Fields)[x] = x);
    }
}

