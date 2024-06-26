using Better.Commons.Runtime.Interfaces;
using Better.Singletons.Runtime;
using UnityEngine;

namespace Better.ProjectSettings.Runtime
{
    public abstract class ScriptableSettings<TScriptable> : ScriptableSingletonObject<TScriptable>
        where TScriptable : ScriptableSettings<TScriptable>
    {
    }

    public abstract class ScriptableSettings<TScriptable, TData> : ScriptableSettings<TScriptable>
        where TScriptable : ScriptableSettings<TScriptable, TData>
        where TData : ICopyable<TData>, new()
    {
        [SerializeField] private TData _persistent = new();
        [SerializeField] private TData _runtime = new();

        public TData Persistent => _persistent;
        public TData Runtime => _runtime;
        public TData Current => Application.isPlaying ? Runtime : Persistent;

        [RuntimeInitializeOnLoadMethod]
        private static void RuntimeInitializeOnLoadMethod()
        {
            Instance.ResetRuntimeToPersistent();
        }

        public void ResetRuntimeToPersistent()
        {
            _runtime ??= new();
            _runtime.Copy(_persistent);
        }
    }
}