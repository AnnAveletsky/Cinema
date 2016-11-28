
namespace Cinema.Movie.DataBase {
    export interface DbRow {
        DbId?: number;
        Name?: string;
        ConnectionString?: string;
        ProviderName?: string;
        Active?: boolean;
        TagDataBaseMovie?: string;
    }

    export namespace DbRow {
        export const idProperty = 'DbId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'DataBase.Db';

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

