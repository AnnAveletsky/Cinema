namespace Cinema.Movie.Movie {
    export interface TagRow {
        TagId?: number;
        Name?: string;
    }

    export namespace TagRow {
        export const idProperty = 'TagId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Movie.Tag';
        export const lookupKey = 'Movie.Tag';

        export function getLookup(): Q.Lookup<TagRow> {
            return Q.getLookup<TagRow>('Movie.Tag');
        }

        export namespace Fields {
            export declare const TagId: string;
            export declare const Name: string;
        }

        ['TagId', 'Name'].forEach(x => (<any>Fields)[x] = x);
    }
}

