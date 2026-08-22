using System;
using System.Globalization;

namespace AppProject.Resources;

public static class StringResources
{
    public static string GetStringByKey(string key, params object?[] args)
    {
        var message = Resource.ResourceManager
            .GetString(key, CultureInfo.CurrentCulture) ?? string.Empty;
        return string.Format(message, args);
    }
}
