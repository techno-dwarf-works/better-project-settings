using System.IO;
using Better.Commons.Runtime.Extensions;
using Better.Internal.Core.Runtime;
using Better.ProjectSettings.Runtime;
using Better.Singletons.Runtime;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Better.ProjectSettings.EditorAddons
{
    public abstract class ProjectSettingsProvider<T> : SettingsProvider where T : ScriptableSettings<T>
    {
        protected readonly T _settings;
        protected readonly SerializedObject _settingsObject;
        public const string ProjectPath = PrefixConstants.ProjectPrefix + "/";

        protected ProjectSettingsProvider(string path, SettingsScope scope = SettingsScope.Project)
            : base(ProjectPath + path, scope)
        {
            _settings = ScriptableSingletonObject<T>.Instance;
            _settingsObject = new SerializedObject(_settings);
            label = Path.GetFileName(path);
        }

        public override void OnActivate(string searchContext, VisualElement rootElement)
        {
            CreateVisualElements(rootElement);
            rootElement.Bind(_settingsObject);
            rootElement.RegisterCallback<SerializedObjectChangeEvent>(OnObjectChanged);
        }

        protected virtual void OnObjectChanged(SerializedObjectChangeEvent changeEvent)
        {
            changeEvent.changedObject.ApplyModifiedPropertiesWithoutUndo();
        }

        public override void OnDeactivate()
        {
        }

        protected abstract void CreateVisualElements(VisualElement rootElement);
    }
}