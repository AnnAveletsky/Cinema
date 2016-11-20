namespace Cinema.Movie.Configuration {
    export interface BackgroundRow {
        BackgroundId?: number;
        Color?: string;
        Path?: string;
        Size?: string;
    }

    export namespace BackgroundRow {
        export const idProperty = 'BackgroundId';
        export const nameProperty = 'Color';
        export const localTextPrefix = 'Configuration.Background';

        export namespace Fields {
            export declare const BackgroundId: string;
            export declare const Color: string;
            export declare const Path: string;
            export declare const Size: string;
        }

        ['BackgroundId', 'Color', 'Path', 'Size'].forEach(x => (<any>Fields)[x] = x);
    }
}

