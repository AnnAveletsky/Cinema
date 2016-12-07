
namespace Cinema.Movie.Movie {
    export interface CastMovieRow {
        CastMovieId?: number;
        CastId?: number;
        MovieId?: number;
        CastCharacter?: string;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        MovieTagline?: string;
        MovieBudget?: number;
    }

    export namespace CastMovieRow {
        export const idProperty = 'CastMovieId';
        export const localTextPrefix = 'Movie.CastMovie';

        export namespace Fields {
            export declare const CastMovieId;
            export declare const CastId;
            export declare const MovieId;
            export declare const CastCharacter: string;
            export declare const MovieTitleEn: string;
            export declare const MovieTitleOther: string;
            export declare const MovieDescription: string;
            export declare const MovieYearStart: string;
            export declare const MovieYearEnd: string;
            export declare const MovieReleaseWorldDate: string;
            export declare const MovieReleaseOtherDate: string;
            export declare const MovieReleaseDvd: string;
            export declare const MovieRuntime: string;
            export declare const MovieCreateDateTime: string;
            export declare const MovieUpdateDateTime: string;
            export declare const MoviePublishDateTime: string;
            export declare const MovieKind: string;
            export declare const MovieRating: string;
            export declare const MovieMpaa: string;
            export declare const MoviePathImage: string;
            export declare const MoviePathMiniImage: string;
            export declare const MovieNice: string;
            export declare const MovieContSeason: string;
            export declare const MovieLastEvent: string;
            export declare const MovieLastEventPublishDateTime: string;
            export declare const MovieTagline: string;
            export declare const MovieBudget: string;
        }

        ['CastMovieId', 'CastId', 'MovieId', 'CastCharacter', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MoviePathMiniImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget'].forEach(x => (<any>Fields)[x] = x);
    }
}

