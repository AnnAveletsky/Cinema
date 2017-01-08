namespace Cinema.Movie.Movie {
    export interface ServiceRow {
        ServiceId?: number;
        Name?: string;
        Api?: string;
        Active?: boolean;
        IntervalRequest?: number;
        MaxRating?: number;
        PathListPath?: string[];
        PathList?: number[];
    }

    export namespace ServiceRow {
        export const idProperty = 'ServiceId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Service';
        export const lookupKey = 'Movie.Service';

        export function getLookup(): Q.Lookup<ServiceRow> {
            return Q.getLookup<ServiceRow>('Movie.Service');
        }

        export namespace Fields {
            export declare const ServiceId: string;
            export declare const Name: string;
            export declare const Api: string;
            export declare const Active: string;
            export declare const IntervalRequest: string;
            export declare const MaxRating: string;
            export declare const PathListPath: string;
            export declare const PathList: string;
        }

        ['ServiceId', 'Name', 'Api', 'Active', 'IntervalRequest', 'MaxRating', 'PathListPath', 'PathList'].forEach(x => (<any>Fields)[x] = x);
    }
}

