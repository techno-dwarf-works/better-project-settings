using System.IO;
using Better.Internal.Core.Runtime;
using Better.ProjectSettings.Runtime;
using Better.Singletons.Runtime;
using UnityEditor;
using UnityEngine;

namespace Better.ProjectSettings.EditorAddons
{
    public abstract class ProjectSettingsProvider<T> : SettingsProvider where T : ScriptableSettings<T>
    {
        protected readonly T _settings;
        protected readonly SerializedObject _settingsObject;
        private GUIStyle _style;
        private const int Space = 8;
        public const string ProjectPath = PrefixConstants.ProjectPrefix + "/";

        protected ProjectSettingsProvider(string path, SettingsScope scope = SettingsScope.Project)
            : base(ProjectPath + path, scope)
        {
            _settings = ScriptableSingletonObject<T>.Instance;
            _settingsObject = new SerializedObject(_settings);
            label = Path.GetFileName(path);
        }

        public override void OnGUI(string searchContext)
        {
            var style = CreateOrGetStyle();
            using (new EditorGUILayout.VerticalScope(style))
            {
                DrawGUI();
            }

            _settingsObject.ApplyModifiedPropertiesWithoutUndo();
        }

        private GUIStyle CreateOrGetStyle()
        {
            if (_style != null)
            {
                return _style;
            }

            _style = new GUIStyle();
            _style.margin = new RectOffset(Space, Space, Space, Space);
            return _style;
        }

        protected abstract void DrawGUI();
    }
}