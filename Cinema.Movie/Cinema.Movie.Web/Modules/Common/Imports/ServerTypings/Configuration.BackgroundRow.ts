
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
            export declare const BackgroundId;
            export declare const Color;
            export declare const Path;
            export declare const Size;
        }

        ['BackgroundId', 'Color', 'Path', 'Size'].forEach(x => (<any>Fields)[x] = x);
    }
}

