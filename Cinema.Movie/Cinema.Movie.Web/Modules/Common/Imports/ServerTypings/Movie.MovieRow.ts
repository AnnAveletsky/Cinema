namespace Cinema.Movie.Movie {
    export interface MovieRow {
        MovieId?: number;
        TitleEn?: string;
        TitleOther?: string;
        Description?: string;
        YearStart?: number;
        YearEnd?: number;
        ReleaseWorldDate?: string;
        ReleaseOtherDate?: string;
        ReleaseDvd?: string;
        Runtime?: number;
        CreateDateTime?: string;
        UpdateDateTime?: string;
        PublishDateTime?: string;
        Kind?: MovieKind;
        Rating?: number;
        Mpaa?: string;
        PathImage?: string;
        PathMiniImage?: string;
        Nice?: boolean;
        ContSeason?: number;
        LastEvent?: string;
        LastEventPublishDateTime?: string;
        Tagline?: string;
        Budget?: number;
        GenreList?: number[];
        GenreListName?: string[];
    }

    export namespace MovieRow {
        export const idProperty = 'MovieId';
        export const nameProperty = 'TitleEn';
        export const localTextPrefix = 'Movie.Movie';

        export namespace Fields {
            export declare const MovieId: string;
            export declare const TitleEn: string;
            export declare const TitleOther: string;
            export declare const Description: string;
            export declare const YearStart: string;
            export declare const YearEnd: string;
            export declare const ReleaseWorldDate: string;
            export declare const ReleaseOtherDate: string;
            export declare const ReleaseDvd: string;
            export declare const Runtime: string;
            export declare const CreateDateTime: string;
            export declare const UpdateDateTime: string;
            export declare const PublishDateTime: string;
            export declare const Kind: string;
            export declare const Rating: string;
            export declare const Mpaa: string;
            export declare const PathImage: string;
            export declare const PathMiniImage: string;
            export declare const Nice: string;
            export declare const ContSeason: string;
            export declare const LastEvent: string;
            export declare const LastEventPublishDateTime: string;
            export declare const Tagline: string;
            export declare const Budget: string;
            export declare const GenreList: string;
            export declare const GenreListName: string;
        }

        ['MovieId', 'TitleEn', 'TitleOther', 'Description', 'YearStart', 'YearEnd', 'ReleaseWorldDate', 'ReleaseOtherDate', 'ReleaseDvd', 'Runtime', 'CreateDateTime', 'UpdateDateTime', 'PublishDateTime', 'Kind', 'Rating', 'Mpaa', 'PathImage', 'PathMiniImage', 'Nice', 'ContSeason', 'LastEvent', 'LastEventPublishDateTime', 'Tagline', 'Budget', 'GenreList', 'GenreListName'].forEach(x => (<any>Fields)[x] = x);
    }
}

