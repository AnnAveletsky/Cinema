namespace Cinema.Movie.Movie {
    export interface ServicePathRow {
        ServicePathId?: number;
        Path?: string;
        ServiceId?: number;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceMaxRating?: number;
    }

    export namespace ServicePathRow {
        export const idProperty = 'ServicePathId';
        export const nameProperty = 'Path';
        export const localTextPrefix = 'Movie.ServicePath';
        export const lookupKey = 'Movie.ServicePath';

        export function getLookup(): Q.Lookup<ServicePathRow> {
            return Q.getLookup<ServicePathRow>('Movie.ServicePath');
        }

        export namespace Fields {
            export declare const ServicePathId: string;
            export declare const Path: string;
            export declare const ServiceId: string;
            export declare const ServiceName: string;
            export declare const ServiceApi: string;
            export declare const ServiceMaxRating: string;
        }

        ['ServicePathId', 'Path', 'ServiceId', 'ServiceName', 'ServiceApi', 'ServiceMaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

