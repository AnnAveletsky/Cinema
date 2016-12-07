namespace Cinema.Movie.Movie {
    export interface CastRow {
        CastId?: number;
        Character?: string;
    }

    export namespace CastRow {
        export const idProperty = 'CastId';
        export const nameProperty = 'Character';
        export const localTextPrefix = 'Movie.Cast';
        export const lookupKey = 'Movie.Cast';

        export function getLookup(): Q.Lookup<CastRow> {
            return Q.getLookup<CastRow>('Movie.Cast');
        }

        export namespace Fields {
            export declare const CastId: string;
            export declare const Character: string;
        }

        ['CastId', 'Character'].forEach(x => (<any>Fields)[x] = x);
    }
}

