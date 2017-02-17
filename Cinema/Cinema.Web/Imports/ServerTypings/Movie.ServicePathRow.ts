namespace Cinema.Movie {
    export interface ServicePathRow {
        ServicePathId?: number;
        Kind?: MovieKind;
        Path?: string;
        ServiceId?: number;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceUrl?: string;
        ServiceActive?: boolean;
        ServiceIntervalRequest?: number;
        ServiceMaxRating?: number;
    }

    export namespace ServicePathRow {
        export const idProperty = 'ServicePathId';
        export const nameProperty = 'Path';
        export const localTextPrefix = 'Movie.ServicePath';

        export namespace Fields {
            export declare const ServicePathId: string;
            export declare const Kind: string;
            export declare const Path: string;
            export declare const ServiceId: string;
            export declare const ServiceName: string;
            export declare const ServiceApi: string;
            export declare const ServiceUrl: string;
            export declare const ServiceActive: string;
            export declare const ServiceIntervalRequest: string;
            export declare const ServiceMaxRating: string;
        }

        ['ServicePathId', 'Kind', 'Path', 'ServiceId', 'ServiceName', 'ServiceApi', 'ServiceUrl', 'ServiceActive', 'ServiceIntervalRequest', 'ServiceMaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

