namespace Cinema.Movie.Configuration {
    export interface SettingsRow {
        SettingId?: number;
        Setting?: string;
        Value?: string;
        Type?: string;
    }

    export namespace SettingsRow {
        export const idProperty = 'SettingId';
        export const nameProperty = 'Setting';
        export const localTextPrefix = 'Configuration.Settings';

        export namespace Fields {
            export declare const SettingId: string;
            export declare const Setting: string;
            export declare const Value: string;
            export declare const Type: string;
        }

        ['SettingId', 'Setting', 'Value', 'Type'].forEach(x => (<any>Fields)[x] = x);
    }
}

