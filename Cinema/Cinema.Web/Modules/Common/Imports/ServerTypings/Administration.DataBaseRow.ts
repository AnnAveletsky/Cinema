
namespace Cinema.Administration {
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
            export declare const DataBaseId;
            export declare const Name;
            export declare const ConnectionString;
            export declare const ProviderName;
            export declare const Active;
            export declare const TagDataBaseMovie;
            export declare const Type;
        }

        ['DataBaseId', 'Name', 'ConnectionString', 'ProviderName', 'Active', 'TagDataBaseMovie', 'Type'].forEach(x => (<any>Fields)[x] = x);
    }
}

