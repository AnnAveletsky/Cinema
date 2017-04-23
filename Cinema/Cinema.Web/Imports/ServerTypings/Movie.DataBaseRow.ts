namespace Cinema.Movie {
    export interface DataBaseRow {
        DataBaseId?: number;
        Name?: string;
        ConnectionString?: string;
        ProviderName?: string;
        Active?: boolean;
        TagDataBaseMovie?: string;
        Type?: string;
    }

    export namespace DataBaseRow {
        export const idProperty = 'DataBaseId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Administration.DataBase';

        export namespace Fields {
            export declare const DataBaseId: string;
            export declare const Name: string;
            export declare const ConnectionString: string;
            export declare const ProviderName: string;
            export declare const Active: string;
            export declare const TagDataBaseMovie: string;
            export declare const Type: string;
        }

        ['DataBaseId', 'Name', 'ConnectionString', 'ProviderName', 'Active', 'TagDataBaseMovie', 'Type'].forEach(x => (<any>Fields)[x] = x);
    }
}

