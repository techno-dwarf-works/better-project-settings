using System;
using System.Linq;
using System.Reflection;
using Better.Commons.Runtime.Extensions;
using UnityEditor;

namespace Better.ProjectSettings.EditorAddons
{
    public static class ProjectSettingsRegisterer
    {
        [SettingsProviderGroup]
        internal static SettingsProvider[] CreateSettingsProvider()
        {
            var types = typeof(ProjectSettingsProvider<>).GetAllInheritedTypesOfRawGeneric().Where(ValidateInternal);
            var instances = types.Select(Activator.CreateInstance).Cast<SettingsProvider>();
            return instances.ToArray();
        }

        private static bool ValidateInternal(Type type)
        {
            if (type.IsValueType)
            {
                return true;
            }

            var constructor = type.GetConstructor(
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, Type.EmptyTypes, null);

            return constructor != null;
        }
    }
}