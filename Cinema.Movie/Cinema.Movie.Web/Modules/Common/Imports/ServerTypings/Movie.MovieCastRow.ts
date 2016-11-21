
namespace Cinema.Movie.Movie {
    export interface MovieCastRow {
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

    export namespace MovieCastRow {
        export const idProperty = 'MovieCastId';
        export const nameProperty = 'Character';
        export const localTextPrefix = 'Movie.MovieCast';

        export namespace Fields {
            export declare const MovieCastId;
            export declare const Character;
            export declare const MovieId;
            export declare const PersonId;
            export declare const MovieTitleEn: string;
            export declare const MovieTitleOther: string;
            export declare const MovieDescription: string;
            export declare const MovieYearStart: string;
            export declare const MovieYearEnd: string;
            export declare const MovieReleaseWorldDate: string;
            export declare const MovieReleaseOtherDate: string;
            export declare const MovieReleaseDvd: string;
            export declare const MovieRuntime: string;
            export declare const MovieCreateDateTime: string;
            export declare const MovieUpdateDateTime: string;
            export declare const MoviePublishDateTime: string;
            export declare const MovieKind: string;
            export declare const MovieRating: string;
            export declare const MovieMpaa: string;
            export declare const MoviePathImage: string;
            export declare const MoviePathMiniImage: string;
            export declare const MovieNice: string;
            export declare const MovieContSeason: string;
            export declare const MovieLastEvent: string;
            export declare const MovieLastEventPublishDateTime: string;
            export declare const MovieTagline: string;
            export declare const MovieBudget: string;
            export declare const PersonFirstname: string;
            export declare const PersonLastname: string;
            export declare const PersonBirthDate: string;
            export declare const PersonBirthPlace: string;
            export declare const PersonGender: string;
            export declare const PersonHeight: string;
            export declare const PersonPathImage: string;
            export declare const PersonPathImageMini: string;
        }

        ['MovieCastId', 'Character', 'MovieId', 'PersonId', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MoviePathMiniImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget', 'PersonFirstname', 'PersonLastname', 'PersonBirthDate', 'PersonBirthPlace', 'PersonGender', 'PersonHeight', 'PersonPathImage', 'PersonPathImageMini'].forEach(x => (<any>Fields)[x] = x);
    }
}

