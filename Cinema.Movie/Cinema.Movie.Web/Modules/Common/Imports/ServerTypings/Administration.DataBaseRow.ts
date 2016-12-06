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
            export declare const DbId: string;
            export declare const Name: string;
            export declare const ConnectionString: string;
            export declare const ProviderName: string;
            export declare const Active: string;
            export declare const TagDataBaseMovie: string;
        }

        ['DbId', 'Name', 'ConnectionString', 'ProviderName', 'Active', 'TagDataBaseMovie'].forEach(x => (<any>Fields)[x] = x);
    }
}

