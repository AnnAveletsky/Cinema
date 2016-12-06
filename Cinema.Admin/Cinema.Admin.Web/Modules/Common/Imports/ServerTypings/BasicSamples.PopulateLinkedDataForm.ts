namespace Cinema.Admin.BasicSamples {
    export class PopulateLinkedDataForm extends Serenity.PrefixedContext {
        static formKey = 'BasicSamples.PopulateLinkedData';

    }

    export interface PopulateLinkedDataForm {
        CustomerID: Admin.Northwind.CustomerEditor;
        CustomerContactName: Serenity.StringEditor;
        CustomerContactTitle: Serenity.StringEditor;
        CustomerCity: Serenity.StringEditor;
        CustomerRegion: Serenity.StringEditor;
        CustomerCountry: Serenity.StringEditor;
        CustomerPhone: Serenity.StringEditor;
        CustomerFax: Serenity.StringEditor;
        OrderDate: Serenity.DateEditor;
        RequiredDate: Serenity.DateEditor;
        EmployeeID: Serenity.LookupEditor;
        DetailList: Admin.Northwind.OrderDetailsEditor;
    }

    [['CustomerID', () => Admin.Northwind.CustomerEditor], ['CustomerContactName', () => Serenity.StringEditor], ['CustomerContactTitle', () => Serenity.StringEditor], ['CustomerCity', () => Serenity.StringEditor], ['CustomerRegion', () => Serenity.StringEditor], ['CustomerCountry', () => Serenity.StringEditor], ['CustomerPhone', () => Serenity.StringEditor], ['CustomerFax', () => Serenity.StringEditor], ['OrderDate', () => Serenity.DateEditor], ['RequiredDate', () => Serenity.DateEditor], ['EmployeeID', () => Serenity.LookupEditor], ['DetailList', () => Admin.Northwind.OrderDetailsEditor]].forEach(x => Object.defineProperty(PopulateLinkedDataForm.prototype, <string>x[0], { get: function () { return this.w(x[0], (x[1] as any)()); }, enumerable: true, configurable: true }));
}

