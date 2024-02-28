using Better.Singletons.Runtime;

namespace Better.ProjectSettings.Runtime
{
    public abstract class ScriptableSettings<T> : ScriptableSingletonObject<T> where T : ScriptableSettings<T>
    {
        
    }
}