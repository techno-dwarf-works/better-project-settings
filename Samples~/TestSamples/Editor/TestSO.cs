using Better.ProjectSettings.Runtime;
using Better.Singletons.Runtime.Attributes;
using UnityEditor;
using UnityEngine;

namespace Test
{
    [ScriptableCreate(nameof(Better) + "/" + nameof(Editor) + "/" + nameof(Test), "Test1")]
    public class TestSO : ScriptableSettings<TestSO>
    {
        [Header("Test")] [SerializeField] private bool _testBool;
    }
}