namespace Admin.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('Admin');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;
}