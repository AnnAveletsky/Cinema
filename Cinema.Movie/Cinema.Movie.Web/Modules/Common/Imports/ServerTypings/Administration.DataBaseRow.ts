
namespace Cinema.Movie.Administration {
    export interface DataBaseRow {
        DbId?: number;
        Name?: string;
        ConnectionString?: string;
        ProviderName?: string;
        Active?: boolean;
        TagDataBaseMovie?: string;
    }

    export namespace DataBaseRow {
        export const idProperty = 'DbId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Administration.DataBase';

        export namespace Fields {
            export declare const DbId;
            export declare const Name;
            export declare const ConnectionString;
            export declare const ProviderName;
            export declare const Active;
            export declare const TagDataBaseMovie;
        }

        ['DbId', 'Name', 'ConnectionString', 'ProviderName', 'Active', 'TagDataBaseMovie'].forEach(x => (<any>Fields)[x] = x);
    }
}

