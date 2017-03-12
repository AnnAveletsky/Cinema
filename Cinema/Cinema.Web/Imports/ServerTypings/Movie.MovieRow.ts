namespace Cinema.Movie {
    export interface MovieRow {
        MovieId?: number;
        TitleOriginal?: string;
        TitleTranslation?: string;
        Url?: string;
        Description?: string;
        YearStart?: number;
        YearEnd?: number;
        ReleaseWorldDate?: string;
        ReleaseOtherDate?: string;
        ReleaseDvd?: string;
        Runtime?: string;
        CreateDateTime?: string;
        UpdateDateTime?: string;
        PublishDateTime?: string;
        Kind?: MovieKind;
        Rating?: number;
        Mpaa?: string;
        PathImage?: string;
        Nice?: boolean;
        ContSeason?: number;
        Tagline?: string;
        Budget?: number;
        Views?: number;
    }

    export namespace MovieRow {
        export const idProperty = 'MovieId';
        export const nameProperty = 'TitleOriginal';
        export const localTextPrefix = 'Movie.Movie';
        export const lookupKey = 'Movie.Movie';

        export function getLookup(): Q.Lookup<MovieRow> {
            return Q.getLookup<MovieRow>('Movie.Movie');
        }

        export namespace Fields {
            export declare const MovieId: string;
            export declare const TitleOriginal: string;
            export declare const TitleTranslation: string;
            export declare const Url: string;
            export declare const Description: string;
            export declare const YearStart: string;
            export declare const YearEnd: string;
            export declare const ReleaseWorldDate: string;
            export declare const ReleaseOtherDate: string;
            export declare const ReleaseDvd: string;
            export declare const Runtime: string;
            export declare const CreateDateTime: string;
            export declare const UpdateDateTime: string;
            export declare const PublishDateTime: string;
            export declare const Kind: string;
            export declare const Rating: string;
            export declare const Mpaa: string;
            export declare const PathImage: string;
            export declare const Nice: string;
            export declare const ContSeason: string;
            export declare const Tagline: string;
            export declare const Budget: string;
            export declare const Views: string;
        }

        ['MovieId', 'TitleOriginal', 'TitleTranslation', 'Url', 'Description', 'YearStart', 'YearEnd', 'ReleaseWorldDate', 'ReleaseOtherDate', 'ReleaseDvd', 'Runtime', 'CreateDateTime', 'UpdateDateTime', 'PublishDateTime', 'Kind', 'Rating', 'Mpaa', 'PathImage', 'Nice', 'ContSeason', 'Tagline', 'Budget', 'Views'].forEach(x => (<any>Fields)[x] = x);
    }
}

