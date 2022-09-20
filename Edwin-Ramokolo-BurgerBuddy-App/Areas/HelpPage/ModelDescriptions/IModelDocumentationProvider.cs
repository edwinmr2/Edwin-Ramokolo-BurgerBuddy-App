using System;
using System.Reflection;

namespace Edwin_Ramokolo_BurgerBuddy_App.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}