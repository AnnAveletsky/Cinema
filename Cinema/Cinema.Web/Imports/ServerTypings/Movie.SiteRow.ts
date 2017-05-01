namespace Cinema.Movie {
    export interface SiteRow {
        SiteId?: number;
        Name?: string;
        Url?: string;
        Title?: string;
        Background?: string;
        Logo?: string;
        BackgroundColor?: string;
        DataBaseId?: number;
        DataBaseName?: string;
        DataBaseConnectionString?: string;
        DataBaseProviderName?: string;
        DataBaseActive?: boolean;
        DataBaseTagDataBaseMovie?: string;
        DataBaseType?: string;
    }

    export namespace SiteRow {
        export const idProperty = 'SiteId';
        export const nameProperty = 'Name';
        export const localTextPrefix = 'Default.Site';
        export const lookupKey = 'Movie.Site';

        export function getLookup(): Q.Lookup<SiteRow> {
            return Q.getLookup<SiteRow>('Movie.Site');
        }

        export namespace Fields {
            export declare const SiteId: string;
            export declare const Name: string;
            export declare const Url: string;
            export declare const Title: string;
            export declare const Background: string;
            export declare const Logo: string;
            export declare const BackgroundColor: string;
            export declare const DataBaseId: string;
            export declare const DataBaseName: string;
            export declare const DataBaseConnectionString: string;
            export declare const DataBaseProviderName: string;
            export declare const DataBaseActive: string;
            export declare const DataBaseTagDataBaseMovie: string;
            export declare const DataBaseType: string;
        }

        ['SiteId', 'Name', 'Url', 'Title', 'Background', 'Logo', 'BackgroundColor', 'DataBaseId', 'DataBaseName', 'DataBaseConnectionString', 'DataBaseProviderName', 'DataBaseActive', 'DataBaseTagDataBaseMovie', 'DataBaseType'].forEach(x => (<any>Fields)[x] = x);
    }
}

