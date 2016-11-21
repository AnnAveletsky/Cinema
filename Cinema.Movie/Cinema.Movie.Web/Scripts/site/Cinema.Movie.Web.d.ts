declare namespace Cinema.Movie.Movie {
    class VideoDialog extends Serenity.EntityDialog<VideoRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: VideoForm;
    }
}
declare namespace Cinema.Movie.Common {
    class GridEditorBase<TEntity> extends Serenity.EntityGrid<TEntity, any> implements Serenity.IGetEditValue, Serenity.ISetEditValue {
        protected getIdProperty(): string;
        private nextId;
        constructor(container: JQuery);
        protected id(entity: TEntity): any;
        protected save(opt: Serenity.ServiceOptions<any>, callback: (r: Serenity.ServiceResponse) => void): void;
        protected deleteEntity(id: number): boolean;
        protected validateEntity(row: TEntity, id: number): boolean;
        protected setEntities(items: TEntity[]): void;
        protected getNewEntity(): TEntity;
        protected getButtons(): Serenity.ToolButton[];
        protected editItem(entityOrId: any): void;
        getEditValue(property: any, target: any): void;
        setEditValue(source: any, property: any): void;
        value: TEntity[];
        protected getGridCanLoad(): boolean;
        protected usePager(): boolean;
        protected getInitialTitle(): any;
        protected createQuickSearchInput(): void;
    }
}
declare namespace Cinema.Movie.Movie {
    class VideoEditor extends Common.GridEditorBase<VideoRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VideoEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Common {
    class GridEditorDialog<TEntity> extends Serenity.EntityDialog<TEntity, any> {
        protected getIdProperty(): string;
        onSave: (options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void) => void;
        onDelete: (options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void) => void;
        destroy(): void;
        protected updateInterface(): void;
        protected saveHandler(options: Serenity.ServiceOptions<Serenity.SaveResponse>, callback: (response: Serenity.SaveResponse) => void): void;
        protected deleteHandler(options: Serenity.ServiceOptions<Serenity.DeleteResponse>, callback: (response: Serenity.DeleteResponse) => void): void;
    }
}
declare namespace Cinema.Movie.Movie {
    class VideoEditorDialog extends Common.GridEditorDialog<VideoRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: VideoForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class VideoGrid extends Serenity.EntityGrid<VideoRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof VideoDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class TagDialog extends Serenity.EntityDialog<TagRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: TagForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class TagEditor extends Common.GridEditorBase<TagRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TagEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class TagEditorDialog extends Common.GridEditorDialog<TagRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: TagForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class TagGrid extends Serenity.EntityGrid<TagRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof TagDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceRatingDialog extends Serenity.EntityDialog<ServiceRatingRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        protected form: ServiceRatingForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceRatingEditor extends Common.GridEditorBase<ServiceRatingRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServiceRatingEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceRatingEditorDialog extends Common.GridEditorDialog<ServiceRatingRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected form: ServiceRatingForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceRatingGrid extends Serenity.EntityGrid<ServiceRatingRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServiceRatingDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class ServicePathDialog extends Serenity.EntityDialog<ServicePathRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ServicePathForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class ServicePathEditor extends Common.GridEditorBase<ServicePathRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServicePathEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class ServicePathEditorDialog extends Common.GridEditorDialog<ServicePathRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: ServicePathForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class ServicePathGrid extends Serenity.EntityGrid<ServicePathRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServicePathDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceDialog extends Serenity.EntityDialog<ServiceRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: ServiceForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceEditor extends Common.GridEditorBase<ServiceRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServiceEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceEditorDialog extends Common.GridEditorDialog<ServiceRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: ServiceForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceGrid extends Serenity.EntityGrid<ServiceRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof ServiceDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class PersonDialog extends Serenity.EntityDialog<PersonRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: PersonForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class PersonEditor extends Common.GridEditorBase<PersonRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof PersonEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class PersonEditorDialog extends Common.GridEditorDialog<PersonRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: PersonForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class PersonGrid extends Serenity.EntityGrid<PersonRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof PersonDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class MovieDialog extends Serenity.EntityDialog<MovieRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: MovieForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class MovieEditor extends Common.GridEditorBase<MovieRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MovieEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class MovieEditorDialog extends Common.GridEditorDialog<MovieRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: MovieForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class MovieGrid extends Serenity.EntityGrid<MovieRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof MovieDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class GenreDialog extends Serenity.EntityDialog<GenreRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: GenreForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class GenreEditor extends Common.GridEditorBase<GenreRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof GenreEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class GenreEditorDialog extends Common.GridEditorDialog<GenreRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: GenreForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class GenreGrid extends Serenity.EntityGrid<GenreRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof GenreDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class CastDialog extends Serenity.EntityDialog<CastRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: CastForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class CastEditor extends Common.GridEditorBase<CastRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof CastEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Movie {
    class CastEditorDialog extends Common.GridEditorDialog<CastRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: CastForm;
    }
}
declare namespace Cinema.Movie.Movie {
    class CastGrid extends Serenity.EntityGrid<CastRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof CastDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Membership {
    class LoginPanel extends Serenity.PropertyPanel<LoginRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Membership {
    class SignUpPanel extends Serenity.PropertyPanel<SignUpRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Membership {
    class ResetPasswordPanel extends Serenity.PropertyPanel<ResetPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Membership {
    class ForgotPasswordPanel extends Serenity.PropertyPanel<ForgotPasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Membership {
    class ChangePasswordPanel extends Serenity.PropertyPanel<ChangePasswordRequest, any> {
        protected getFormKey(): string;
        private form;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Configuration {
    class SettingsDialog extends Serenity.EntityDialog<SettingsRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: SettingsForm;
    }
}
declare namespace Cinema.Movie.Configuration {
    class SettingsEditor extends Common.GridEditorBase<SettingsRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof SettingsEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Configuration {
    class SettingsEditorDialog extends Common.GridEditorDialog<SettingsRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: SettingsForm;
    }
}
declare namespace Cinema.Movie.Configuration {
    class SettingsGrid extends Serenity.EntityGrid<SettingsRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof SettingsDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Configuration {
    class BackgroundDialog extends Serenity.EntityDialog<BackgroundRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: BackgroundForm;
    }
}
declare namespace Cinema.Movie.Configuration {
    class BackgroundEditor extends Common.GridEditorBase<BackgroundRow> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BackgroundEditorDialog;
        protected getLocalTextPrefix(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.Configuration {
    class BackgroundEditorDialog extends Common.GridEditorDialog<BackgroundRow> {
        protected getFormKey(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected form: BackgroundForm;
    }
}
declare namespace Cinema.Movie.Configuration {
    class BackgroundGrid extends Serenity.EntityGrid<BackgroundRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof BackgroundDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
    }
}
declare namespace Cinema.Movie.ScriptInitialization {
}
declare namespace Cinema.Movie.Common {
    class UserPreferenceStorage implements Serenity.SettingStorage {
        getItem(key: string): string;
        setItem(key: string, data: string): void;
    }
}
declare namespace Cinema.Movie.Common {
    interface PdfExportOptions {
        grid: Serenity.DataGrid<any, any>;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
        reportTitle?: string;
        titleTop?: number;
        titleFontSize?: number;
        fileName?: string;
        pageNumbers?: boolean;
        columnTitles?: {
            [key: string]: string;
        };
        tableOptions?: jsPDF.AutoTableOptions;
        output?: string;
        autoPrint?: boolean;
    }
    namespace PdfExportHelper {
        function exportToPdf(options: PdfExportOptions): void;
        function createToolButton(options: PdfExportOptions): Serenity.ToolButton;
    }
}
declare namespace Cinema.Movie.Common {
    class LanguageSelection extends Serenity.Widget<any> {
        constructor(select: JQuery, currentLanguage: string);
    }
}
declare namespace Cinema.Movie.Common {
    class SidebarSearch extends Serenity.Widget<any> {
        private menuUL;
        constructor(input: JQuery, menuUL: JQuery);
        protected updateMatchFlags(text: string): void;
    }
}
declare namespace Cinema.Movie.Common {
    class ThemeSelection extends Serenity.Widget<any> {
        constructor(select: JQuery);
        protected getCurrentTheme(): string;
    }
}
declare namespace Cinema.Movie.Administration {
}
declare namespace Cinema.Movie.Administration {
    class LanguageForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LanguageForm {
        LanguageId: Serenity.StringEditor;
        LanguageName: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Administration {
    interface LanguageRow {
        Id?: number;
        LanguageId?: string;
        LanguageName?: string;
    }
    namespace LanguageRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<LanguageRow>;
        namespace Fields {
            const Id: string;
            const LanguageId: string;
            const LanguageName: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    namespace LanguageService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<LanguageRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<LanguageRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
}
declare namespace Cinema.Movie.Administration {
    class RoleForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface RoleForm {
        RoleName: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Administration {
    interface RolePermissionListRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace Cinema.Movie.Administration {
    interface RolePermissionListResponse extends Serenity.ListResponse<string> {
    }
}
declare namespace Cinema.Movie.Administration {
    interface RolePermissionRow {
        RolePermissionId?: number;
        RoleId?: number;
        PermissionKey?: string;
        RoleRoleName?: string;
    }
    namespace RolePermissionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const RolePermissionId: string;
            const RoleId: string;
            const PermissionKey: string;
            const RoleRoleName: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    namespace RolePermissionService {
        const baseUrl: string;
        function Update(request: RolePermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: RolePermissionListRequest, onSuccess?: (response: RolePermissionListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    interface RolePermissionUpdateRequest extends Serenity.ServiceRequest {
        RoleID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: string[];
    }
}
declare namespace Cinema.Movie.Administration {
    interface RoleRow {
        RoleId?: number;
        RoleName?: string;
    }
    namespace RoleRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<RoleRow>;
        namespace Fields {
            const RoleId: string;
            const RoleName: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    namespace RoleService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<RoleRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<RoleRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    interface TranslationItem {
        Key?: string;
        SourceText?: string;
        TargetText?: string;
        CustomText?: string;
    }
}
declare namespace Cinema.Movie.Administration {
    interface TranslationListRequest extends Serenity.ListRequest {
        SourceLanguageID?: string;
        TargetLanguageID?: string;
    }
}
declare namespace Cinema.Movie.Administration {
    namespace TranslationService {
        const baseUrl: string;
        function List(request: TranslationListRequest, onSuccess?: (response: Serenity.ListResponse<TranslationItem>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: TranslationUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const List: string;
            const Update: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    interface TranslationUpdateRequest extends Serenity.ServiceRequest {
        TargetLanguageID?: string;
        Translations?: {
            [key: string]: string;
        };
    }
}
declare namespace Cinema.Movie.Administration {
}
declare namespace Cinema.Movie.Administration {
    class UserForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface UserForm {
        Username: Serenity.StringEditor;
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        UserImage: Serenity.ImageUploadEditor;
        Password: Serenity.PasswordEditor;
        PasswordConfirm: Serenity.PasswordEditor;
        Source: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserPermissionListRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserPermissionRow {
        UserPermissionId?: number;
        UserId?: number;
        PermissionKey?: string;
        Granted?: boolean;
        Username?: string;
        User?: string;
    }
    namespace UserPermissionRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserPermissionId: string;
            const UserId: string;
            const PermissionKey: string;
            const Granted: string;
            const Username: string;
            const User: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    namespace UserPermissionService {
        const baseUrl: string;
        function Update(request: UserPermissionUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<UserPermissionRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListRolePermissions(request: UserPermissionListRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function ListPermissionKeys(request: Serenity.ServiceRequest, onSuccess?: (response: Serenity.ListResponse<string>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const List: string;
            const ListRolePermissions: string;
            const ListPermissionKeys: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserPermissionUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Module?: string;
        Submodule?: string;
        Permissions?: UserPermissionRow[];
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserRoleListRequest extends Serenity.ServiceRequest {
        UserID?: number;
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserRoleListResponse extends Serenity.ListResponse<number> {
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserRoleRow {
        UserRoleId?: number;
        UserId?: number;
        RoleId?: number;
        Username?: string;
        User?: string;
    }
    namespace UserRoleRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserRoleId: string;
            const UserId: string;
            const RoleId: string;
            const Username: string;
            const User: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    namespace UserRoleService {
        const baseUrl: string;
        function Update(request: UserRoleUpdateRequest, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: UserRoleListRequest, onSuccess?: (response: UserRoleListResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserRoleUpdateRequest extends Serenity.ServiceRequest {
        UserID?: number;
        Roles?: number[];
    }
}
declare namespace Cinema.Movie.Administration {
    interface UserRow {
        UserId?: number;
        Username?: string;
        Source?: string;
        PasswordHash?: string;
        PasswordSalt?: string;
        DisplayName?: string;
        Email?: string;
        UserImage?: string;
        LastDirectoryUpdate?: string;
        IsActive?: number;
        Password?: string;
        PasswordConfirm?: string;
        InsertUserId?: number;
        InsertDate?: string;
        UpdateUserId?: number;
        UpdateDate?: string;
    }
    namespace UserRow {
        const idProperty: string;
        const isActiveProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserId: string;
            const Username: string;
            const Source: string;
            const PasswordHash: string;
            const PasswordSalt: string;
            const DisplayName: string;
            const Email: string;
            const UserImage: string;
            const LastDirectoryUpdate: string;
            const IsActive: string;
            const Password: string;
            const PasswordConfirm: string;
            const InsertUserId: string;
            const InsertDate: string;
            const UpdateUserId: string;
            const UpdateDate: string;
        }
    }
}
declare namespace Cinema.Movie.Administration {
    namespace UserService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<UserRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Undelete(request: Serenity.UndeleteRequest, onSuccess?: (response: Serenity.UndeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<UserRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Undelete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Common.Pages {
    interface UploadResponse extends Serenity.ServiceResponse {
        TemporaryFile?: string;
        Size?: number;
        IsImage?: boolean;
        Width?: number;
        Height?: number;
    }
}
declare namespace Cinema.Movie.Common {
    interface UserPreferenceRetrieveRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
    }
}
declare namespace Cinema.Movie.Common {
    interface UserPreferenceRetrieveResponse extends Serenity.ServiceResponse {
        Value?: string;
    }
}
declare namespace Cinema.Movie.Common {
    interface UserPreferenceRow {
        UserPreferenceId?: number;
        UserId?: number;
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
    namespace UserPreferenceRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const UserPreferenceId: string;
            const UserId: string;
            const PreferenceType: string;
            const Name: string;
            const Value: string;
        }
    }
}
declare namespace Cinema.Movie.Common {
    namespace UserPreferenceService {
        const baseUrl: string;
        function Update(request: UserPreferenceUpdateRequest, onSuccess?: (response: Serenity.ServiceResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: UserPreferenceRetrieveRequest, onSuccess?: (response: UserPreferenceRetrieveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Update: string;
            const Retrieve: string;
        }
    }
}
declare namespace Cinema.Movie.Common {
    interface UserPreferenceUpdateRequest extends Serenity.ServiceRequest {
        PreferenceType?: string;
        Name?: string;
        Value?: string;
    }
}
declare namespace Cinema.Movie.Configuration {
}
declare namespace Cinema.Movie.Configuration {
    class BackgroundForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface BackgroundForm {
        Color: Serenity.StringEditor;
        Path: Serenity.StringEditor;
        Size: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Configuration {
    interface BackgroundRow {
        BackgroundId?: number;
        Color?: string;
        Path?: string;
        Size?: string;
    }
    namespace BackgroundRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const BackgroundId: string;
            const Color: string;
            const Path: string;
            const Size: string;
        }
    }
}
declare namespace Cinema.Movie.Configuration {
    namespace BackgroundService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<BackgroundRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<BackgroundRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<BackgroundRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<BackgroundRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Configuration {
}
declare namespace Cinema.Movie.Configuration {
    class SettingsForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface SettingsForm {
        Setting: Serenity.StringEditor;
        Value: Serenity.StringEditor;
        Type: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Configuration {
    interface SettingsRow {
        SettingId?: number;
        Setting?: string;
        Value?: string;
        Type?: string;
    }
    namespace SettingsRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const SettingId: string;
            const Setting: string;
            const Value: string;
            const Type: string;
        }
    }
}
declare namespace Cinema.Movie.Configuration {
    namespace SettingsService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<SettingsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<SettingsRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<SettingsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<SettingsRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie {
    interface ExcelImportRequest extends Serenity.ServiceRequest {
        FileName?: string;
    }
}
declare namespace Cinema.Movie {
    interface ExcelImportResponse extends Serenity.ServiceResponse {
        Inserted?: number;
        Updated?: number;
        ErrorList?: string[];
    }
}
declare namespace Cinema.Movie {
    interface GetNextNumberRequest extends Serenity.ServiceRequest {
        Prefix?: string;
        Length?: number;
    }
}
declare namespace Cinema.Movie {
    interface GetNextNumberResponse extends Serenity.ServiceResponse {
        Number?: number;
        Serial?: string;
    }
}
declare namespace Cinema.Movie.Membership {
    class ChangePasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ChangePasswordForm {
        OldPassword: Serenity.PasswordEditor;
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
}
declare namespace Cinema.Movie.Membership {
    interface ChangePasswordRequest extends Serenity.ServiceRequest {
        OldPassword?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace Cinema.Movie.Membership {
    class ForgotPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ForgotPasswordForm {
        Email: Serenity.EmailEditor;
    }
}
declare namespace Cinema.Movie.Membership {
    interface ForgotPasswordRequest extends Serenity.ServiceRequest {
        Email?: string;
    }
}
declare namespace Cinema.Movie.Membership {
    class LoginForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface LoginForm {
        Username: Serenity.StringEditor;
        Password: Serenity.PasswordEditor;
    }
}
declare namespace Cinema.Movie.Membership {
    interface LoginRequest extends Serenity.ServiceRequest {
        Username?: string;
        Password?: string;
    }
}
declare namespace Cinema.Movie.Membership {
    class ResetPasswordForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ResetPasswordForm {
        NewPassword: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
}
declare namespace Cinema.Movie.Membership {
    interface ResetPasswordRequest extends Serenity.ServiceRequest {
        Token?: string;
        NewPassword?: string;
        ConfirmPassword?: string;
    }
}
declare namespace Cinema.Movie.Membership {
    class SignUpForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface SignUpForm {
        DisplayName: Serenity.StringEditor;
        Email: Serenity.EmailEditor;
        ConfirmEmail: Serenity.EmailEditor;
        Password: Serenity.PasswordEditor;
        ConfirmPassword: Serenity.PasswordEditor;
    }
}
declare namespace Cinema.Movie.Membership {
    interface SignUpRequest extends Serenity.ServiceRequest {
        DisplayName?: string;
        Email?: string;
        Password?: string;
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class CastForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface CastForm {
        Character: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface CastMoviePersonRow {
        MoviePersonCastId?: number;
        CastId?: number;
        MovieId?: number;
        PersonId?: number;
        CastCharacter?: string;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        MovieTagline?: string;
        MovieBudget?: number;
        PersonFirstname?: string;
        PersonLastname?: string;
        PersonBirthDate?: string;
        PersonBirthPlace?: string;
        PersonGender?: number;
        PersonHeight?: number;
        PersonPathImage?: string;
        PersonPathImageMini?: string;
    }
    namespace CastMoviePersonRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MoviePersonCastId: string;
            const CastId: string;
            const MovieId: string;
            const PersonId: string;
            const CastCharacter: string;
            const MovieTitleEn: string;
            const MovieTitleOther: string;
            const MovieDescription: string;
            const MovieYearStart: string;
            const MovieYearEnd: string;
            const MovieReleaseWorldDate: string;
            const MovieReleaseOtherDate: string;
            const MovieReleaseDvd: string;
            const MovieRuntime: string;
            const MovieCreateDateTime: string;
            const MovieUpdateDateTime: string;
            const MoviePublishDateTime: string;
            const MovieKind: string;
            const MovieRating: string;
            const MovieMpaa: string;
            const MoviePathImage: string;
            const MoviePathMiniImage: string;
            const MovieNice: string;
            const MovieContSeason: string;
            const MovieLastEvent: string;
            const MovieLastEventPublishDateTime: string;
            const MovieTagline: string;
            const MovieBudget: string;
            const PersonFirstname: string;
            const PersonLastname: string;
            const PersonBirthDate: string;
            const PersonBirthPlace: string;
            const PersonGender: string;
            const PersonHeight: string;
            const PersonPathImage: string;
            const PersonPathImageMini: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    interface CastRow {
        CastId?: number;
        Character?: string;
    }
    namespace CastRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const CastId: string;
            const Character: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace CastService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<CastRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<CastRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<CastRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<CastRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class GenreForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface GenreForm {
        Name: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface GenreRow {
        GenreId?: number;
        Name?: string;
    }
    namespace GenreRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<GenreRow>;
        namespace Fields {
            const GenreId: string;
            const Name: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace GenreService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<GenreRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<GenreRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<GenreRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<GenreRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    class MovieCastForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MovieCastForm {
        Character: Serenity.StringEditor;
        MovieId: Serenity.IntegerEditor;
        PersonId: Serenity.IntegerEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface MovieCastRow {
        MovieCastId?: number;
        Character?: string;
        MovieId?: number;
        PersonId?: number;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        MovieTagline?: string;
        MovieBudget?: number;
        PersonFirstname?: string;
        PersonLastname?: string;
        PersonBirthDate?: string;
        PersonBirthPlace?: string;
        PersonGender?: number;
        PersonHeight?: number;
        PersonPathImage?: string;
        PersonPathImageMini?: string;
    }
    namespace MovieCastRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieCastId: any;
            const Character: any;
            const MovieId: any;
            const PersonId: any;
            const MovieTitleEn: string;
            const MovieTitleOther: string;
            const MovieDescription: string;
            const MovieYearStart: string;
            const MovieYearEnd: string;
            const MovieReleaseWorldDate: string;
            const MovieReleaseOtherDate: string;
            const MovieReleaseDvd: string;
            const MovieRuntime: string;
            const MovieCreateDateTime: string;
            const MovieUpdateDateTime: string;
            const MoviePublishDateTime: string;
            const MovieKind: string;
            const MovieRating: string;
            const MovieMpaa: string;
            const MoviePathImage: string;
            const MoviePathMiniImage: string;
            const MovieNice: string;
            const MovieContSeason: string;
            const MovieLastEvent: string;
            const MovieLastEventPublishDateTime: string;
            const MovieTagline: string;
            const MovieBudget: string;
            const PersonFirstname: string;
            const PersonLastname: string;
            const PersonBirthDate: string;
            const PersonBirthPlace: string;
            const PersonGender: string;
            const PersonHeight: string;
            const PersonPathImage: string;
            const PersonPathImageMini: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace MovieCastService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MovieCastRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MovieCastRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MovieCastRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MovieCastRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class MovieForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MovieForm {
        TitleEn: Serenity.StringEditor;
        TitleOther: Serenity.StringEditor;
        Description: Serenity.StringEditor;
        YearStart: Serenity.IntegerEditor;
        YearEnd: Serenity.IntegerEditor;
        ReleaseWorldDate: Serenity.DateEditor;
        ReleaseOtherDate: Serenity.DateEditor;
        ReleaseDvd: Serenity.DateEditor;
        Runtime: Serenity.IntegerEditor;
        CreateDateTime: Serenity.DateEditor;
        UpdateDateTime: Serenity.DateEditor;
        PublishDateTime: Serenity.DateEditor;
        Kind: Serenity.EnumEditor;
        Rating: Serenity.IntegerEditor;
        Mpaa: Serenity.StringEditor;
        PathImage: Serenity.StringEditor;
        PathMiniImage: Serenity.StringEditor;
        Nice: Serenity.BooleanEditor;
        ContSeason: Serenity.IntegerEditor;
        LastEvent: Serenity.StringEditor;
        LastEventPublishDateTime: Serenity.DateEditor;
        Tagline: Serenity.StringEditor;
        Budget: Serenity.IntegerEditor;
        GenreList: Serenity.LookupEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface MovieGenresRow {
        MovieGenreId?: number;
        MovieId?: number;
        GenreId?: number;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        MovieTagline?: string;
        MovieBudget?: number;
        GenreName?: string;
    }
    namespace MovieGenresRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieGenreId: string;
            const MovieId: string;
            const GenreId: string;
            const MovieTitleEn: string;
            const MovieTitleOther: string;
            const MovieDescription: string;
            const MovieYearStart: string;
            const MovieYearEnd: string;
            const MovieReleaseWorldDate: string;
            const MovieReleaseOtherDate: string;
            const MovieReleaseDvd: string;
            const MovieRuntime: string;
            const MovieCreateDateTime: string;
            const MovieUpdateDateTime: string;
            const MoviePublishDateTime: string;
            const MovieKind: string;
            const MovieRating: string;
            const MovieMpaa: string;
            const MoviePathImage: string;
            const MoviePathMiniImage: string;
            const MovieNice: string;
            const MovieContSeason: string;
            const MovieLastEvent: string;
            const MovieLastEventPublishDateTime: string;
            const MovieTagline: string;
            const MovieBudget: string;
            const GenreName: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    enum MovieKind {
        Film = 1,
        TvSeries = 2,
        MiniSeries = 3,
    }
}
declare namespace Cinema.Movie.Movie {
    interface MovieRow {
        MovieId?: number;
        TitleEn?: string;
        TitleOther?: string;
        Description?: string;
        YearStart?: number;
        YearEnd?: number;
        ReleaseWorldDate?: string;
        ReleaseOtherDate?: string;
        ReleaseDvd?: string;
        Runtime?: number;
        CreateDateTime?: string;
        UpdateDateTime?: string;
        PublishDateTime?: string;
        Kind?: MovieKind;
        Rating?: number;
        Mpaa?: string;
        PathImage?: string;
        PathMiniImage?: string;
        Nice?: boolean;
        ContSeason?: number;
        LastEvent?: string;
        LastEventPublishDateTime?: string;
        Tagline?: string;
        Budget?: number;
        GenreList?: number[];
        GenreListName?: string[];
    }
    namespace MovieRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieId: string;
            const TitleEn: string;
            const TitleOther: string;
            const Description: string;
            const YearStart: string;
            const YearEnd: string;
            const ReleaseWorldDate: string;
            const ReleaseOtherDate: string;
            const ReleaseDvd: string;
            const Runtime: string;
            const CreateDateTime: string;
            const UpdateDateTime: string;
            const PublishDateTime: string;
            const Kind: string;
            const Rating: string;
            const Mpaa: string;
            const PathImage: string;
            const PathMiniImage: string;
            const Nice: string;
            const ContSeason: string;
            const LastEvent: string;
            const LastEventPublishDateTime: string;
            const Tagline: string;
            const Budget: string;
            const GenreList: string;
            const GenreListName: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace MovieService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MovieRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MovieRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MovieRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MovieRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    interface MovieTagRow {
        MovieTagId?: number;
        TagId?: number;
        MovieId?: number;
        TagName?: string;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        MovieTagline?: string;
        MovieBudget?: number;
    }
    namespace MovieTagRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieTagId: string;
            const TagId: string;
            const MovieId: string;
            const TagName: string;
            const MovieTitleEn: string;
            const MovieTitleOther: string;
            const MovieDescription: string;
            const MovieYearStart: string;
            const MovieYearEnd: string;
            const MovieReleaseWorldDate: string;
            const MovieReleaseOtherDate: string;
            const MovieReleaseDvd: string;
            const MovieRuntime: string;
            const MovieCreateDateTime: string;
            const MovieUpdateDateTime: string;
            const MoviePublishDateTime: string;
            const MovieKind: string;
            const MovieRating: string;
            const MovieMpaa: string;
            const MoviePathImage: string;
            const MoviePathMiniImage: string;
            const MovieNice: string;
            const MovieContSeason: string;
            const MovieLastEvent: string;
            const MovieLastEventPublishDateTime: string;
            const MovieTagline: string;
            const MovieBudget: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class PersonForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface PersonForm {
        Firstname: Serenity.StringEditor;
        Lastname: Serenity.StringEditor;
        BirthDate: Serenity.DateEditor;
        BirthPlace: Serenity.StringEditor;
        Gender: Serenity.IntegerEditor;
        Height: Serenity.IntegerEditor;
        PathImage: Serenity.StringEditor;
        PathImageMini: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface PersonRow {
        PersonId?: number;
        Firstname?: string;
        Lastname?: string;
        BirthDate?: string;
        BirthPlace?: string;
        Gender?: number;
        Height?: number;
        PathImage?: string;
        PathImageMini?: string;
    }
    namespace PersonRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const PersonId: string;
            const Firstname: string;
            const Lastname: string;
            const BirthDate: string;
            const BirthPlace: string;
            const Gender: string;
            const Height: string;
            const PathImage: string;
            const PathImageMini: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace PersonService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<PersonRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<PersonRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<PersonRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<PersonRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    class ServiceForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ServiceForm {
        Name: Serenity.StringEditor;
        Api: Serenity.StringEditor;
        Active: Serenity.BooleanEditor;
        IntervalRequest: Serenity.IntegerEditor;
        LastEvent: Serenity.StringEditor;
        LastEventPublishDateTime: Serenity.DateEditor;
        MaxRating: Serenity.IntegerEditor;
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class ServicePathForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ServicePathForm {
        Path: Serenity.StringEditor;
        ServiceId: Serenity.IntegerEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface ServicePathRow {
        ServicePathId?: number;
        Path?: string;
        ServiceId?: number;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceMaxRating?: number;
    }
    namespace ServicePathRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const ServicePathId: string;
            const Path: string;
            const ServiceId: string;
            const ServiceName: string;
            const ServiceApi: string;
            const ServiceMaxRating: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace ServicePathService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ServicePathRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ServicePathRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ServicePathRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ServicePathRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class ServiceRatingForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface ServiceRatingForm {
        Rating: Serenity.IntegerEditor;
        MovieId: Serenity.StringEditor;
        ServiceId: Serenity.IntegerEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface ServiceRatingRow {
        ServiceRatingId?: number;
        Rating?: number;
        MovieId?: number;
        ServiceId?: number;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        MovieTagline?: string;
        MovieBudget?: number;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceMaxRating?: number;
    }
    namespace ServiceRatingRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const ServiceRatingId: string;
            const Rating: string;
            const MovieId: string;
            const ServiceId: string;
            const MovieTitleEn: string;
            const MovieTitleOther: string;
            const MovieDescription: string;
            const MovieYearStart: string;
            const MovieYearEnd: string;
            const MovieReleaseWorldDate: string;
            const MovieReleaseOtherDate: string;
            const MovieReleaseDvd: string;
            const MovieRuntime: string;
            const MovieCreateDateTime: string;
            const MovieUpdateDateTime: string;
            const MoviePublishDateTime: string;
            const MovieKind: string;
            const MovieRating: string;
            const MovieMpaa: string;
            const MoviePathImage: string;
            const MoviePathMiniImage: string;
            const MovieNice: string;
            const MovieContSeason: string;
            const MovieLastEvent: string;
            const MovieLastEventPublishDateTime: string;
            const MovieTagline: string;
            const MovieBudget: string;
            const ServiceName: string;
            const ServiceApi: string;
            const ServiceMaxRating: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace ServiceRatingService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ServiceRatingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ServiceRatingRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ServiceRatingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ServiceRatingRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    interface ServiceRow {
        ServiceId?: number;
        Name?: string;
        Api?: string;
        Active?: boolean;
        IntervalRequest?: number;
        LastEvent?: string;
        LastEventPublishDateTime?: string;
        MaxRating?: number;
    }
    namespace ServiceRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const ServiceId: any;
            const Name: any;
            const Api: any;
            const Active: any;
            const IntervalRequest: any;
            const LastEvent: any;
            const LastEventPublishDateTime: any;
            const MaxRating: any;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace ServiceService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<ServiceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<ServiceRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<ServiceRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<ServiceRow>) => void, opt?: Serenity.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class TagForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface TagForm {
        Name: Serenity.StringEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface TagRow {
        TagId?: number;
        Name?: string;
    }
    namespace TagRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const TagId: string;
            const Name: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace TagService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<TagRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<TagRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<TagRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<TagRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
}
declare namespace Cinema.Movie.Movie {
    class VideoForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface VideoForm {
        Path: Serenity.StringEditor;
        Name: Serenity.StringEditor;
        Translation: Serenity.IntegerEditor;
        Season: Serenity.IntegerEditor;
        Serie: Serenity.IntegerEditor;
        PlannePublishDate: Serenity.DateEditor;
        ActualPublishDateTime: Serenity.DateEditor;
        MovieId: Serenity.IntegerEditor;
        ServiceId: Serenity.IntegerEditor;
    }
}
declare namespace Cinema.Movie.Movie {
    interface VideoRow {
        VudeoId?: number;
        Path?: string;
        Name?: string;
        Translation?: number;
        Season?: number;
        Serie?: number;
        PlannePublishDate?: string;
        ActualPublishDateTime?: string;
        MovieId?: number;
        ServiceId?: number;
        MovieTitleEn?: string;
        MovieTitleOther?: string;
        MovieDescription?: string;
        MovieStoryline?: string;
        MovieYearStart?: number;
        MovieYearEnd?: number;
        MovieReleaseWorldDate?: string;
        MovieReleaseOtherDate?: string;
        MovieReleaseDvd?: string;
        MovieRuntime?: number;
        MovieCreateDateTime?: string;
        MovieUpdateDateTime?: string;
        MoviePublishDateTime?: string;
        MovieKind?: number;
        MovieRating?: number;
        MovieMpaa?: string;
        MovieContSuffrage?: number;
        MoviePathImage?: string;
        MoviePathMiniImage?: string;
        MovieNice?: boolean;
        MovieContSeason?: number;
        MovieLastEvent?: string;
        MovieLastEventPublishDateTime?: string;
        ServiceName?: string;
        ServiceApi?: string;
        ServiceMaxRating?: number;
    }
    namespace VideoRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const VudeoId: string;
            const Path: string;
            const Name: string;
            const Translation: string;
            const Season: string;
            const Serie: string;
            const PlannePublishDate: string;
            const ActualPublishDateTime: string;
            const MovieId: string;
            const ServiceId: string;
            const MovieTitleEn: string;
            const MovieTitleOther: string;
            const MovieDescription: string;
            const MovieStoryline: string;
            const MovieYearStart: string;
            const MovieYearEnd: string;
            const MovieReleaseWorldDate: string;
            const MovieReleaseOtherDate: string;
            const MovieReleaseDvd: string;
            const MovieRuntime: string;
            const MovieCreateDateTime: string;
            const MovieUpdateDateTime: string;
            const MoviePublishDateTime: string;
            const MovieKind: string;
            const MovieRating: string;
            const MovieMpaa: string;
            const MovieContSuffrage: string;
            const MoviePathImage: string;
            const MoviePathMiniImage: string;
            const MovieNice: string;
            const MovieContSeason: string;
            const MovieLastEvent: string;
            const MovieLastEventPublishDateTime: string;
            const ServiceName: string;
            const ServiceApi: string;
            const ServiceMaxRating: string;
        }
    }
}
declare namespace Cinema.Movie.Movie {
    namespace VideoService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<VideoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<VideoRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<VideoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<VideoRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Cinema.Movie {
    interface ScriptUserDefinition {
        Username?: string;
        DisplayName?: string;
        Permissions?: {
            [key: string]: boolean;
        };
    }
}
declare namespace Cinema.Movie {
    class BasicProgressDialog extends Serenity.TemplatedDialog<any> {
        constructor();
        cancelled: boolean;
        max: number;
        value: number;
        title: string;
        cancelTitle: string;
        getDialogOptions(): JQueryUI.DialogOptions;
        initDialog(): void;
        getTemplate(): string;
    }
}
declare namespace Cinema.Movie.Common {
    class BulkServiceAction {
        protected keys: string[];
        protected queue: string[];
        protected queueIndex: number;
        protected progressDialog: BasicProgressDialog;
        protected pendingRequests: number;
        protected completedRequests: number;
        protected errorByKey: Q.Dictionary<Serenity.ServiceError>;
        private successCount;
        private errorCount;
        done: () => void;
        protected createProgressDialog(): void;
        protected getConfirmationFormat(): string;
        protected getConfirmationMessage(targetCount: any): string;
        protected confirm(targetCount: any, action: any): void;
        protected getNothingToProcessMessage(): string;
        protected nothingToProcess(): void;
        protected getParallelRequests(): number;
        protected getBatchSize(): number;
        protected startParallelExecution(): void;
        protected serviceCallCleanup(): void;
        protected executeForBatch(batch: string[]): void;
        protected executeNextBatch(): void;
        protected getAllHadErrorsFormat(): string;
        protected showAllHadErrors(): void;
        protected getSomeHadErrorsFormat(): string;
        protected showSomeHadErrors(): void;
        protected getAllSuccessFormat(): string;
        protected showAllSuccess(): void;
        protected showResults(): void;
        execute(keys: string[]): void;
        get_successCount(): any;
        set_successCount(value: number): void;
        get_errorCount(): any;
        set_errorCount(value: number): void;
    }
}
declare namespace Cinema.Movie.DialogUtils {
    function pendingChangesConfirmation(element: JQuery, hasPendingChanges: () => boolean): void;
}
declare namespace Cinema.Movie.Common {
    interface ExcelExportOptions {
        grid: Serenity.DataGrid<any, any>;
        service: string;
        onViewSubmit: () => boolean;
        title?: string;
        hint?: string;
        separator?: boolean;
    }
    namespace ExcelExportHelper {
        function createToolButton(options: ExcelExportOptions): Serenity.ToolButton;
    }
}
declare namespace Cinema.Movie.LanguageList {
    function getValue(): string[][];
}
declare namespace Cinema.Movie.Common {
    interface ReportButtonOptions {
        title?: string;
        cssClass?: string;
        icon?: string;
        download?: boolean;
        reportKey: string;
        extension?: string;
        getParams?: () => any;
        target?: string;
    }
    namespace ReportHelper {
        function createToolButton(options: ReportButtonOptions): Serenity.ToolButton;
    }
}
declare namespace Cinema.Movie.Administration {
    class RoleCheckEditor extends Serenity.CheckTreeEditor<Serenity.CheckTreeItem<any>, any> {
        private searchText;
        constructor(div: JQuery);
        protected createToolbarExtensions(): void;
        protected getButtons(): any[];
        protected getTreeItems(): Serenity.CheckTreeItem<any>[];
        protected onViewFilter(item: any): boolean;
    }
}
declare namespace Cinema.Movie.Administration {
    class UserRoleDialog extends Serenity.TemplatedDialog<UserRoleDialogOptions> {
        private permissions;
        constructor(opt: UserRoleDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserRoleDialogOptions {
        userID: number;
        username: string;
    }
}
declare namespace Cinema.Movie.Administration {
    class PermissionCheckEditor extends Serenity.DataGrid<PermissionCheckItem, PermissionCheckEditorOptions> {
        protected getIdProperty(): string;
        private searchText;
        private byParentKey;
        private rolePermissions;
        constructor(container: JQuery, opt: PermissionCheckEditorOptions);
        private getItemGrantRevokeClass(item, grant);
        private getItemEffectiveClass(item);
        protected getColumns(): Slick.Column[];
        setItems(items: PermissionCheckItem[]): void;
        protected onViewSubmit(): boolean;
        protected onViewFilter(item: PermissionCheckItem): boolean;
        private matchContains(item);
        private getDescendants(item, excludeGroups);
        protected onClick(e: any, row: any, cell: any): void;
        private getParentKey(key);
        protected getButtons(): Serenity.ToolButton[];
        protected createToolbarExtensions(): void;
        private getSortedGroupAndPermissionKeys(titleByKey);
        get_value(): UserPermissionRow[];
        set_value(value: UserPermissionRow[]): void;
        get_rolePermissions(): string[];
        set_rolePermissions(value: string[]): void;
    }
    interface PermissionCheckEditorOptions {
        showRevoke?: boolean;
    }
    interface PermissionCheckItem {
        ParentKey?: string;
        Key?: string;
        Title?: string;
        IsGroup?: boolean;
        GrantRevoke?: boolean;
    }
}
declare namespace Cinema.Movie.Administration {
    class UserPermissionDialog extends Serenity.TemplatedDialog<UserPermissionDialogOptions> {
        private permissions;
        constructor(opt: UserPermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface UserPermissionDialogOptions {
        userID?: number;
        username?: string;
    }
}
declare namespace Cinema.Movie.Administration {
    class UserDialog extends Serenity.EntityDialog<UserRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: UserForm;
        constructor();
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
        protected afterLoadEntity(): void;
    }
}
declare namespace Cinema.Movie.Administration {
    class UserGrid extends Serenity.EntityGrid<UserRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof UserDialog;
        protected getIdProperty(): string;
        protected getIsActiveProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
    }
}
declare namespace Cinema.Movie.Authorization {
    let userDefinition: ScriptUserDefinition;
    function hasPermission(permissionKey: string): boolean;
}
declare namespace Cinema.Movie.Administration {
    class TranslationGrid extends Serenity.EntityGrid<TranslationItem, any> {
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        private hasChanges;
        private searchText;
        private sourceLanguage;
        private targetLanguage;
        private targetLanguageKey;
        constructor(container: JQuery);
        protected onClick(e: JQueryEventObject, row: number, cell: number): any;
        protected getColumns(): Slick.Column[];
        protected createToolbarExtensions(): void;
        protected saveChanges(language: string): RSVP.Promise<any>;
        protected onViewSubmit(): boolean;
        protected getButtons(): Serenity.ToolButton[];
        protected createQuickSearchInput(): void;
        protected onViewFilter(item: TranslationItem): boolean;
        protected usePager(): boolean;
    }
}
declare namespace Cinema.Movie.Administration {
    class RolePermissionDialog extends Serenity.TemplatedDialog<RolePermissionDialogOptions> {
        private permissions;
        constructor(opt: RolePermissionDialogOptions);
        protected getDialogOptions(): JQueryUI.DialogOptions;
        protected getTemplate(): string;
    }
    interface RolePermissionDialogOptions {
        roleID?: number;
        title?: string;
    }
}
declare namespace Cinema.Movie.Administration {
    class RoleDialog extends Serenity.EntityDialog<RoleRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: RoleForm;
        protected getToolbarButtons(): Serenity.ToolButton[];
        protected updateInterface(): void;
    }
}
declare namespace Cinema.Movie.Administration {
    class RoleGrid extends Serenity.EntityGrid<RoleRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof RoleDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
    }
}
declare namespace Cinema.Movie.Administration {
    class LanguageDialog extends Serenity.EntityDialog<LanguageRow, any> {
        protected getFormKey(): string;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getNameProperty(): string;
        protected getService(): string;
        protected form: LanguageForm;
    }
}
declare namespace Cinema.Movie.Administration {
    class LanguageGrid extends Serenity.EntityGrid<LanguageRow, any> {
        protected getColumnsKey(): string;
        protected getDialogType(): typeof LanguageDialog;
        protected getIdProperty(): string;
        protected getLocalTextPrefix(): string;
        protected getService(): string;
        constructor(container: JQuery);
        protected getDefaultSortBy(): string[];
    }
}
