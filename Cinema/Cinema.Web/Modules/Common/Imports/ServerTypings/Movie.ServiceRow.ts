
namespace Cinema.Movie {
    export interface ServiceRow {
        ServiceId?: number;
        Name?: string;
        Api?: string;
        Url?: string;
        Active?: boolean;
        IntervalRequest?: number;
        MaxRating?: number;
    }

    export namespace ServiceRow {
        export const idProperty = 'ServiceId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Service';

        export namespace Fields {
            export declare const ServiceId;
            export declare const Name;
            export declare const Api;
            export declare const Url;
            export declare const Active;
            export declare const IntervalRequest;
            export declare const MaxRating;
        }

        ['ServiceId', 'Name', 'Api', 'Url', 'Active', 'IntervalRequest', 'MaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

