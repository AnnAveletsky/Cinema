declare namespace Admin.MovieDB {
    enum Gender {
        Male = 1,
        Female = 2,
    }
}
declare namespace Admin.MovieDB {
}
declare namespace Admin.MovieDB {
    class GenreForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface GenreForm {
        Name: Serenity.StringEditor;
    }
}
declare namespace Admin.MovieDB {
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
declare namespace Admin.MovieDB {
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
declare namespace Admin.MovieDB {
}
declare namespace Admin.MovieDB {
    class MovieCastForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface MovieCastForm {
        PersonId: Serenity.LookupEditor;
        Character: Serenity.StringEditor;
    }
}
declare namespace Admin.MovieDB {
    interface MovieCastRow {
        MovieCastId?: number;
        MovieId?: number;
        PersonId?: number;
        Character?: string;
        MovieTitle?: string;
        MovieDescription?: string;
        MovieStoryline?: string;
        MovieYear?: number;
        MovieReleaseDate?: string;
        MovieRuntime?: number;
        MovieKind?: number;
        PersonFirstname?: string;
        PersonLastname?: string;
        PersonFullname?: string;
        PersonBirthDate?: string;
        PersonBirthPlace?: string;
        PersonGender?: number;
        PersonHeight?: number;
    }
    namespace MovieCastRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieCastId: string;
            const MovieId: string;
            const PersonId: string;
            const Character: string;
            const MovieTitle: string;
            const MovieDescription: string;
            const MovieStoryline: string;
            const MovieYear: string;
            const MovieReleaseDate: string;
            const MovieRuntime: string;
            const MovieKind: string;
            const PersonFirstname: string;
            const PersonLastname: string;
            const PersonFullname: string;
            const PersonBirthDate: string;
            const PersonBirthPlace: string;
            const PersonGender: string;
            const PersonHeight: string;
        }
    }
}
declare namespace Admin.MovieDB {
    namespace MovieCastService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MovieCastRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MovieCastRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MovieCastRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: Serenity.ListRequest, onSuccess?: (response: Serenity.ListResponse<MovieCastRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Admin.MovieDB {
}

declare namespace Admin.MovieDB {
    interface MovieGenresRow {
        MovieGenreId?: number;
        MovieId?: number;
        GenreId?: number;
        MovieTitle?: string;
        MovieDescription?: string;
        MovieStoryline?: string;
        MovieYear?: number;
        MovieReleaseDate?: string;
        MovieRuntime?: number;
        MovieKind?: number;
        GenreName?: string;
    }
    namespace MovieGenresRow {
        const idProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieGenreId: string;
            const MovieId: string;
            const GenreId: string;
            const MovieTitle: string;
            const MovieDescription: string;
            const MovieStoryline: string;
            const MovieYear: string;
            const MovieReleaseDate: string;
            const MovieRuntime: string;
            const MovieKind: string;
            const GenreName: string;
        }
    }
}
declare namespace Admin.MovieDB {
    enum MovieKind {
        Film = 1,
        TvSeries = 2,
        MiniSeries = 3,
    }
}
declare namespace Admin.MovieDB {
    interface MovieListRequest extends Serenity.ListRequest {
        Genres?: number[];
    }
}
declare namespace Admin.MovieDB {
    interface MovieRow {
        MovieId?: number;
        Title?: string;
        Description?: string;
        Storyline?: string;
        Year?: number;
        ReleaseDate?: string;
        Runtime?: number;
        Kind?: MovieKind;
        GenreList?: number[];
        CastList?: MovieCastRow[];
        PrimaryImage?: string;
        GalleryImages?: string;
    }
    namespace MovieRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        namespace Fields {
            const MovieId: string;
            const Title: string;
            const Description: string;
            const Storyline: string;
            const Year: string;
            const ReleaseDate: string;
            const Runtime: string;
            const Kind: string;
            const GenreList: string;
            const CastList: string;
            const PrimaryImage: string;
            const GalleryImages: string;
        }
    }
}
declare namespace Admin.MovieDB {
    namespace MovieService {
        const baseUrl: string;
        function Create(request: Serenity.SaveRequest<MovieRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Update(request: Serenity.SaveRequest<MovieRow>, onSuccess?: (response: Serenity.SaveResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Delete(request: Serenity.DeleteRequest, onSuccess?: (response: Serenity.DeleteResponse) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function Retrieve(request: Serenity.RetrieveRequest, onSuccess?: (response: Serenity.RetrieveResponse<MovieRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        function List(request: MovieListRequest, onSuccess?: (response: Serenity.ListResponse<MovieRow>) => void, opt?: Q.ServiceOptions<any>): JQueryXHR;
        namespace Methods {
            const Create: string;
            const Update: string;
            const Delete: string;
            const Retrieve: string;
            const List: string;
        }
    }
}
declare namespace Admin.MovieDB {
}
declare namespace Admin.MovieDB {
    class PersonForm extends Serenity.PrefixedContext {
        static formKey: string;
    }
    interface PersonForm {
        Firstname: Serenity.StringEditor;
        Lastname: Serenity.StringEditor;
        PrimaryImage: Serenity.ImageUploadEditor;
        GalleryImages: Serenity.MultipleImageUploadEditor;
        BirthDate: Serenity.DateEditor;
        BirthPlace: Serenity.StringEditor;
        Gender: Serenity.EnumEditor;
        Height: Serenity.IntegerEditor;
    }
}
declare namespace Admin.MovieDB {
}
declare namespace Admin.MovieDB {
    interface PersonRow {
        PersonId?: number;
        Firstname?: string;
        Lastname?: string;
        Fullname?: string;
        BirthDate?: string;
        BirthPlace?: string;
        Gender?: Gender;
        Height?: number;
        PrimaryImage?: string;
        GalleryImages?: string;
    }
    namespace PersonRow {
        const idProperty: string;
        const nameProperty: string;
        const localTextPrefix: string;
        const lookupKey: string;
        function getLookup(): Q.Lookup<PersonRow>;
        namespace Fields {
            const PersonId: string;
            const Firstname: string;
            const Lastname: string;
            const Fullname: string;
            const BirthDate: string;
            const BirthPlace: string;
            const Gender: string;
            const Height: string;
            const PrimaryImage: string;
            const GalleryImages: string;
        }
    }
}
declare namespace Admin.MovieDB {
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