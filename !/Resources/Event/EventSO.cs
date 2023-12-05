using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "Event/Event")]
public class EventSO : ScriptableObject
{
    [CustomEditor(typeof(EventSO), editorForChildClasses: true)]
    private class EventEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;
            EventSO eventSO = target as EventSO;
            if (GUILayout.Button("Raise")) eventSO.Raise();
        }
    }

    #if UNITY_EDITOR
    [TextArea(), SerializeField] private string DeverloperDescription = "";
    #endif

    private event System.Action _listeners;

    private void OnEnable() => _listeners = null;
    public void Raise() => _listeners?.Invoke();

    public void Subscribe(System.Action callBack) => _listeners += callBack;
    public void UnSubscribe(System.Action callBack) => _listeners -= callBack;
}
