namespace Cinema.Movie.Movie {
    export interface VideoRow {
        VideoId?: number;
        Path?: string;
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
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieStoryline?: string;
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
        MovieContSuffrage?: number;
        MoviePathImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceMaxRating?: number;
    }

    export namespace VideoRow {
        export const idProperty = 'VideoId';
        export const nameProperty = 'Path';
        export const localTextPrefix = 'Movie.Video';
        export const lookupKey = 'Movie.Video';

        export function getLookup(): Q.Lookup<VideoRow> {
            return Q.getLookup<VideoRow>('Movie.Video');
        }

        export namespace Fields {
            export declare const VideoId: string;
            export declare const Path: string;
            export declare const PathTorrent: string;
            export declare const Name: string;
            export declare const Translation: string;
            export declare const Season: string;
            export declare const Serie: string;
            export declare const Storyline: string;
            export declare const PlannePublishDate: string;
            export declare const ActualPublishDateTime: string;
            export declare const MovieId: string;
            export declare const ServiceId: string;
            export declare const MovieTitleEn: string;
            export declare const MovieTitleOther: string;
            export declare const MovieDescription: string;
            export declare const MovieStoryline: string;
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
            export declare const MovieContSuffrage: string;
            export declare const MoviePathImage: string;
            export declare const MovieNice: string;
            export declare const MovieContSeason: string;
            export declare const MovieLastEvent: string;
            export declare const MovieLastEventPublishDateTime: string;
            export declare const ServiceName: string;
            export declare const ServiceApi: string;
            export declare const ServiceMaxRating: string;
        }

        ['VideoId', 'Path', 'PathTorrent', 'Name', 'Translation', 'Season', 'Serie', 'Storyline', 'PlannePublishDate', 'ActualPublishDateTime', 'MovieId', 'ServiceId', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieStoryline', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MovieContSuffrage', 'MoviePathImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'ServiceName', 'ServiceApi', 'ServiceMaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

