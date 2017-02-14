namespace Cinema.ScriptInitialization {
    Q.Config.responsiveDialogs = true;
    Q.Config.rootNamespaces.push('Cinema');
    Serenity.EntityDialog.defaultLanguageList = LanguageList.getValue;
}