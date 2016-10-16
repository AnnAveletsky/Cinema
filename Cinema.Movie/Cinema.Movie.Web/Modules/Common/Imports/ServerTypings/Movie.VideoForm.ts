

namespace Cinema.Movie.Movie {
    export class VideoForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.Video';
    }

    export interface VideoForm {
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

    [['Path', () => Serenity.StringEditor], ['Name', () => Serenity.StringEditor], ['Translation', () => Serenity.IntegerEditor], ['Season', () => Serenity.IntegerEditor], ['Serie', () => Serenity.IntegerEditor], ['PlannePublishDate', () => Serenity.DateEditor], ['ActualPublishDateTime', () => Serenity.DateEditor], ['MovieId', () => Serenity.IntegerEditor], ['ServiceId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(VideoForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}