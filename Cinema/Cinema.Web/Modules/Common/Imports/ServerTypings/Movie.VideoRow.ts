
namespace Cinema.Movie {
    export interface VideoRow {
        VideoId?: number;
        Path?: string;
        Player?: number;
        PathTorrent?: string;
        Name?: string;
        Translation?: number;
        Season?: number;
        Serie?: number;
        Storyline?: string;
        PlannePublishDate?: string;
        ActualPublishDateTime?: string;
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

    export namespace VideoRow {
        export const idProperty = 'VideoId';
        export const nameProperty = 'Path';
        export const localTextPrefix = 'Movie.Video';

        export namespace Fields {
            export declare const VideoId;
            export declare const Path;
            export declare const Player;
            export declare const PathTorrent;
            export declare const Name;
            export declare const Translation;
            export declare const Season;
            export declare const Serie;
            export declare const Storyline;
            export declare const PlannePublishDate;
            export declare const ActualPublishDateTime;
            export declare const MovieId;
            export declare const ServiceId;
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

        ['VideoId', 'Path', 'Player', 'PathTorrent', 'Name', 'Translation', 'Season', 'Serie', 'Storyline', 'PlannePublishDate', 'ActualPublishDateTime', 'MovieId', 'ServiceId', 'MovieTitleOriginal', 'MovieTitleTranslation', 'MovieUrl', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieTagline', 'MovieBudget', 'ServiceName', 'ServiceApi', 'ServiceUrl', 'ServiceActive', 'ServiceIntervalRequest', 'ServiceMaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

