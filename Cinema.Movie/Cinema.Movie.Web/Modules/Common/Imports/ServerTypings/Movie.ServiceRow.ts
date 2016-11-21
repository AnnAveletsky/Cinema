
namespace Cinema.Movie.Movie {
    export interface ServiceRow {
        ServiceId?: number;
        Name?: string;
        Api?: string;
        Active?: boolean;
        IntervalRequest?: number;
        LastEvent?: string;
        LastEventPublishDateTime?: string;
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
            export declare const Active;
            export declare const IntervalRequest;
            export declare const LastEvent;
            export declare const LastEventPublishDateTime;
            export declare const MaxRating;
        }

        ['ServiceId', 'Name', 'Api', 'Active', 'IntervalRequest', 'LastEvent', 'LastEventPublishDateTime', 'MaxRating'].forEach(x => (<any>Fields)[x] = x);
    }
}

