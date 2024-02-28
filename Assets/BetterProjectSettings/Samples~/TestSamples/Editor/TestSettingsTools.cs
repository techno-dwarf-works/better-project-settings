using System;
using Better.Internal.Core.Runtime;
using Better.ProjectSettings.EditorAddons;
using UnityEditor;

namespace Test
{
    public class TestProvider : DefaultProjectSettingsProvider<TestSO>
    {
        public const string Path = PrefixConstants.BetterPrefix + "/" + nameof(Test);

        public TestProvider() : base(Path)
        {
            keywords = new[] { "Test" };
        }

        [MenuItem(Path + "/" + PrefixConstants.HighlightPrefix, false, 999)]
        private static void Highlight()
        {
            SettingsService.OpenProjectSettings(ProjectPath + Path);
        }
    }
}