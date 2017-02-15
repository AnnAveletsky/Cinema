
namespace Cinema.Movie {
    export interface TagRow {
        TagId?: number;
        Name?: string;
    }

    export namespace TagRow {
        export const idProperty = 'TagId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Tag';

        export namespace Fields {
            export declare const TagId;
            export declare const Name;
        }

        ['TagId', 'Name'].forEach(x => (<any>Fields)[x] = x);
    }
}

