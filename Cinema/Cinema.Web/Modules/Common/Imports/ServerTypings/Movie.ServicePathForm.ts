

namespace Cinema.Movie {
    export class ServicePathForm extends Serenity.PrefixedContext {
        static formKey = 'Movie.ServicePath';
    }

    export interface ServicePathForm {
        Path: Serenity.StringEditor;
        ServiceId: Serenity.IntegerEditor;
    }

    [['Path', () => Serenity.StringEditor], ['ServiceId', () => Serenity.IntegerEditor]].forEach(x => Object.defineProperty(ServicePathForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}