namespace Cinema.Movie.Movie {
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
        ServiceName?: string;
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
            export declare const Player: string;
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
            export declare const ServiceName: string;
        }

        ['VideoId', 'Path', 'Player', 'PathTorrent', 'Name', 'Translation', 'Season', 'Serie', 'Storyline', 'PlannePublishDate', 'ActualPublishDateTime', 'MovieId', 'ServiceId', 'ServiceName'].forEach(x => (<any>Fields)[x] = x);
    }
}

