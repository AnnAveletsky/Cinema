
namespace Cinema.Movie {
    export interface MovieRow {
        MovieId?: number;
        TitleOriginal?: string;
        TitleTranslation?: string;
        Url?: string;
        Description?: string;
        YearStart?: number;
        YearEnd?: number;
        ReleaseWorldDate?: string;
        ReleaseOtherDate?: string;
        ReleaseDvd?: string;
        Runtime?: string;
        CreateDateTime?: string;
        UpdateDateTime?: string;
        PublishDateTime?: string;
        Kind?: number;
        Rating?: number;
        Mpaa?: string;
        PathImage?: string;
        Nice?: boolean;
        ContSeason?: number;
        Tagline?: string;
        Budget?: number;
    }

    export namespace MovieRow {
        export const idProperty = 'MovieId';
        export const nameProperty = 'TitleOriginal';
        export const localTextPrefix = 'Movie.Movie';

        export namespace Fields {
            export declare const MovieId;
            export declare const TitleOriginal;
            export declare const TitleTranslation;
            export declare const Url;
            export declare const Description;
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
            export declare const PathImage;
            export declare const Nice;
            export declare const ContSeason;
            export declare const Tagline;
            export declare const Budget;
        }

        ['MovieId', 'TitleOriginal', 'TitleTranslation', 'Url', 'Description', 'YearStart', 'YearEnd', 'ReleaseWorldDate', 'ReleaseOtherDate', 'ReleaseDvd', 'Runtime', 'CreateDateTime', 'UpdateDateTime', 'PublishDateTime', 'Kind', 'Rating', 'Mpaa', 'PathImage', 'Nice', 'ContSeason', 'Tagline', 'Budget'].forEach(x => (<any>Fields)[x] = x);
    }
}

