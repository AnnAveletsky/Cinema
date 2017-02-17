namespace Cinema.Movie {
    export interface ServiceRatingRow {
        ServiceRatingId?: number;
        Rating?: number;
        Id?: number;
        MovieId?: number;
        ServiceId?: number;
        MovieTitleOriginal?: string;
        MovieTitleTranslation?: string;
        MovieUrl?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: string;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieTagline?: string;
        MovieBudget?: number;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceUrl?: string;
        ServiceActive?: boolean;
        ServiceIntervalRequest?: number;
        ServiceMaxRating?: number;
    }

    export namespace ServiceRatingRow {
        export const idProperty = 'ServiceRatingId';
        export const localTextPrefix = 'Movie.ServiceRating';

        export namespace Fields {
            export declare const ServiceRatingId: string;
            export declare const Rating: string;
            export declare const Id: string;
            export declare const MovieId: string;
            export declare const ServiceId: string;
            export declare const MovieTitleOriginal: string;
            export declare const MovieTitleTranslation: string;
            export declare const MovieUrl: string;
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
            export declare const MovieNice: string;
            export declare const MovieContSeason: string;
            export declare const MovieTagline: string;
            export declare const MovieBudget: string;
            export declare const ServiceName: string;
            export declare const ServiceApi: string;
            export declare const ServiceUrl: string;
            export declare const ServiceActive: string;
            export declare const ServiceIntervalRequest: string;
            export declare const ServiceMaxRating: string;
        }

        ['ServiceRatingId', 'Rating', 'Id', 'MovieId', 'ServiceId', 'MovieTitleOriginal', 'MovieTitleTranslation', 'MovieUrl', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieTagline', 'MovieBudget', 'ServiceName', 'ServiceApi', 'ServiceUrl', 'ServiceActive', 'ServiceIntervalRequest', 'ServiceMaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

