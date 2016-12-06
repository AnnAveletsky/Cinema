namespace Cinema.Admin.BasicSamples {
    export class FilteredLookupInDetailForm extends Serenity.PrefixedContext {
        static formKey = 'BasicSamples.FilteredLookupInDetail';

    }

    export interface FilteredLookupInDetailForm {
        CustomerID: Admin.Northwind.CustomerEditor;
        OrderDate: Serenity.DateEditor;
        CategoryID: Serenity.LookupEditor;
        DetailList: FilteredLookupDetailEditor;
    }

    [['CustomerID', () => Admin.Northwind.CustomerEditor], ['OrderDate', () => Serenity.DateEditor], ['CategoryID', () => Serenity.LookupEditor], ['DetailList', () => FilteredLookupDetailEditor]].forEach(x => Object.defineProperty(FilteredLookupInDetailForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

