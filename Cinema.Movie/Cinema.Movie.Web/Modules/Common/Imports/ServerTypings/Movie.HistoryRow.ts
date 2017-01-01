namespace Cinema.Movie.Movie {
    export interface HistoryRow {
        HistoryId?: number;
        UserName?: string;
        EventDataTime?: string;
        Message?: string;
        Status?: boolean;
        CastId?: number;
        CountryId?: number;
        GenreId?: number;
        ServiceId?: number;
        MovieId?: number;
        PersonId?: number;
        ImageId?: number;
        MovieCountryId?: number;
        ServicePathId?: number;
        ServiceRatingId?: number;
        MovieTagId?: number;
        TagId?: number;
        VideoId?: number;
        MovieGenreId?: number;
        CastCharacter?: string;
        CountryName?: string;
        GenreName?: string;
        ServiceName?: string;
        MovieTitleOriginal?: string;
        PersonNameEn?: string;
        ImagePath?: string;
        ServicePathPath?: string;
        TagName?: string;
        VideoPath?: string;
    }

    export namespace HistoryRow {
        export const idProperty = 'HistoryId';
        export const nameProperty = 'Message';
        export const localTextPrefix = 'Movie.History';

        export namespace Fields {
            export declare const HistoryId: string;
            export declare const UserName: string;
            export declare const EventDataTime: string;
            export declare const Message: string;
            export declare const Status: string;
            export declare const CastId: string;
            export declare const CountryId: string;
            export declare const GenreId: string;
            export declare const ServiceId: string;
            export declare const MovieId: string;
            export declare const PersonId: string;
            export declare const ImageId: string;
            export declare const MovieCountryId: string;
            export declare const ServicePathId: string;
            export declare const ServiceRatingId: string;
            export declare const MovieTagId: string;
            export declare const TagId: string;
            export declare const VideoId: string;
            export declare const MovieGenreId: string;
            export declare const CastCharacter: string;
            export declare const CountryName: string;
            export declare const GenreName: string;
            export declare const ServiceName: string;
            export declare const MovieTitleOriginal: string;
            export declare const PersonNameEn: string;
            export declare const ImagePath: string;
            export declare const ServicePathPath: string;
            export declare const TagName: string;
            export declare const VideoPath: string;
        }

        ['HistoryId', 'UserName', 'EventDataTime', 'Message', 'Status', 'CastId', 'CountryId', 'GenreId', 'ServiceId', 'MovieId', 'PersonId', 'ImageId', 'MovieCountryId', 'ServicePathId', 'ServiceRatingId', 'MovieTagId', 'TagId', 'VideoId', 'MovieGenreId', 'CastCharacter', 'CountryName', 'GenreName', 'ServiceName', 'MovieTitleOriginal', 'PersonNameEn', 'ImagePath', 'ServicePathPath', 'TagName', 'VideoPath'].forEach(x => (<any>Fields)[x] = x);
    }
}

