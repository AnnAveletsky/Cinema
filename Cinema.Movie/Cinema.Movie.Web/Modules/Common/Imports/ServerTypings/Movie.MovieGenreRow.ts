namespace Cinema.Movie.Movie {
    export interface MovieGenreRow {
        MovieGenreId?: number;
        MovieId?: number;
        GenreId?: number;
        GenreName?: string;
    }

    export namespace MovieGenreRow {
        export const idProperty = 'MovieGenreId';
        export const localTextPrefix = 'Movie.MovieGenre';

        export namespace Fields {
            export declare const MovieGenreId: string;
            export declare const MovieId: string;
            export declare const GenreId: string;
            export declare const GenreName: string;
        }

        ['MovieGenreId', 'MovieId', 'GenreId', 'GenreName'].forEach(x => (<any>Fields)[x] = x);
    }
}

