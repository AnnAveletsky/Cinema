
namespace Cinema.Movie.Movie {
    export interface MovieRow {
        MovieId?: number;
        TitleEn?: string;
        TitleOther?: string;
        Description?: string;
        Storyline?: string;
        YearStart?: number;
        YearEnd?: number;
        ReleaseWorldDate?: string;
        ReleaseOtherDate?: string;
        ReleaseDvd?: string;
        Runtime?: number;
        CreateDateTime?: string;
        UpdateDateTime?: string;
        PublishDateTime?: string;
        Kind?: number;
        Rating?: number;
        Mpaa?: string;
        ContSuffrage?: number;
        PathImage?: string;
        PathMiniImage?: string;
        Nice?: boolean;
        ContSeason?: number;
        LastEvent?: string;
        LastEventPublishDateTime?: string;
    }

    export namespace MovieRow {
        export const idProperty = 'MovieId';
        export const nameProperty = 'TitleEn';
        export const localTextPrefix = 'Movie.Movie';

        export namespace Fields {
            export declare const MovieId;
            export declare const TitleEn;
            export declare const TitleOther;
            export declare const Description;
            export declare const Storyline;
            export declare const YearStart;
            export declare const YearEnd;
            export declare const ReleaseWorldDate;
            export declare const ReleaseOtherDate;
            export declare const ReleaseDvd;
            export declare const Runtime;
            export declare const CreateDateTime;
            export declare const UpdateDateTime;
            export declare const PublishDateTime;
            export declare const Kind;
            export declare const Rating;
            export declare const Mpaa;
            export declare const ContSuffrage;
            export declare const PathImage;
            export declare const PathMiniImage;
            export declare const Nice;
            export declare const ContSeason;
            export declare const LastEvent;
            export declare const LastEventPublishDateTime;
        }

        ['MovieId', 'TitleEn', 'TitleOther', 'Description', 'Storyline', 'YearStart', 'YearEnd', 'ReleaseWorldDate', 'ReleaseOtherDate', 'ReleaseDvd', 'Runtime', 'CreateDateTime', 'UpdateDateTime', 'PublishDateTime', 'Kind', 'Rating', 'Mpaa', 'ContSuffrage', 'PathImage', 'PathMiniImage', 'Nice', 'ContSeason', 'LastEvent', 'LastEventPublishDateTime'].forEach(x => (<any>Fields)[x] = x);
    }
}

