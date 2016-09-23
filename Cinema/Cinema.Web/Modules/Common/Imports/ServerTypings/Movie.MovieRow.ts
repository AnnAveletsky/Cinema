
namespace Cinema.Movie {
    export interface MovieRow {
        MovieId?: number;
        Title?: string;
        Description?: string;
        Storyline?: string;
        Year?: number;
        ReleaseDate?: string;
        Runtime?: number;
    }

    export namespace MovieRow {
        export const idProperty = 'MovieId';
        export const nameProperty = 'Title';
        export const localTextPrefix = 'Movie.Movie';

        export namespace Fields {
            export declare const MovieId;
            export declare const Title;
            export declare const Description;
            export declare const Storyline;
            export declare const Year;
            export declare const ReleaseDate;
            export declare const Runtime;
        }

        ['MovieId', 'Title', 'Description', 'Storyline', 'Year', 'ReleaseDate', 'Runtime'].forEach(x => (<any>Fields)[x] = x);
    }
}

