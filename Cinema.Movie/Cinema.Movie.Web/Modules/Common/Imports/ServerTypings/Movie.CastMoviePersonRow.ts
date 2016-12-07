
namespace Cinema.Movie.Movie {
    export interface CastMoviePersonRow {
        CastMoviePersonId?: number;
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
        PersonFirstNameEn?: string;
        PersonMiddleNameEn?: string;
        PersonLastNameEn?: string;
        PersonFirstNameOther?: string;
        PersonMiddleNameOther?: string;
        PersonLastNameOther?: string;
        PersonBirthDate?: string;
        PersonDeathDate?: string;
        PersonBirthPlace?: string;
        PersonGender?: number;
        PersonAbout?: string;
        PersonPathImage?: string;
    }

    export namespace CastMoviePersonRow {
        export const idProperty = 'CastMoviePersonId';
        export const localTextPrefix = 'Movie.CastMoviePerson';

        export namespace Fields {
            export declare const CastMoviePersonId;
            export declare const CastId;
            export declare const MovieId;
            export declare const PersonId;
            export declare const CastCharacter: string;
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
            export declare const PersonFirstNameEn: string;
            export declare const PersonMiddleNameEn: string;
            export declare const PersonLastNameEn: string;
            export declare const PersonFirstNameOther: string;
            export declare const PersonMiddleNameOther: string;
            export declare const PersonLastNameOther: string;
            export declare const PersonBirthDate: string;
            export declare const PersonDeathDate: string;
            export declare const PersonBirthPlace: string;
            export declare const PersonGender: string;
            export declare const PersonAbout: string;
            export declare const PersonPathImage: string;
        }

        ['CastMoviePersonId', 'CastId', 'MovieId', 'PersonId', 'CastCharacter', 'MovieTitleEn', 'MovieTitleOther', 'MovieDescription', 'MovieYearStart', 'MovieYearEnd', 'MovieReleaseWorldDate', 'MovieReleaseOtherDate', 'MovieReleaseDvd', 'MovieRuntime', 'MovieCreateDateTime', 'MovieUpdateDateTime', 'MoviePublishDateTime', 'MovieKind', 'MovieRating', 'MovieMpaa', 'MoviePathImage', 'MoviePathMiniImage', 'MovieNice', 'MovieContSeason', 'MovieLastEvent', 'MovieLastEventPublishDateTime', 'MovieTagline', 'MovieBudget', 'PersonFirstNameEn', 'PersonMiddleNameEn', 'PersonLastNameEn', 'PersonFirstNameOther', 'PersonMiddleNameOther', 'PersonLastNameOther', 'PersonBirthDate', 'PersonDeathDate', 'PersonBirthPlace', 'PersonGender', 'PersonAbout', 'PersonPathImage'].forEach(x => (<any>Fields)[x] = x);
    }
}

