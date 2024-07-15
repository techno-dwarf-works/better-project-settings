using Better.ProjectSettings.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace Better.ProjectSettings.EditorAddons
{
    public abstract class DefaultProjectSettingsProvider<T> : ProjectSettingsProvider<T> where T : ScriptableSettings<T>
    {
        private Editor _editor;
        
        protected DefaultProjectSettingsProvider(string path, SettingsScope scopes = SettingsScope.Project) : base(path, scopes)
        {
            _editor = Editor.CreateEditor(_settings);
        }

        protected override void CreateVisualElements(VisualElement rootElement)
        {
            InspectorElement.FillDefaultInspector(rootElement, _settingsObject, _editor);
        }
    }
}