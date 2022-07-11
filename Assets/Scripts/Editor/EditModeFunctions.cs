using UnityEngine;
using UnityEditor;

public class EditModeFunctions : EditorWindow
{
    [MenuItem("Window/Edit Mode Functions")]
    public static void ShowWindow()
    {
        GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Set movable objects' IDs"))
        {
            SetIDs();
        }

        if (GUILayout.Button(""))
        {
        }

        if (GUILayout.Button(""))
        {
        }

        if (GUILayout.Button("!REMOVE SAVES!"))
        {
            RemoveSaves();
        }
    }

    private void SetIDs()
    {
        var pickableObjects = FindObjectsOfType<Pickable>();

        for (int i = 0; i < pickableObjects.Length; i++)
        {
            pickableObjects[i].GenerateID();
        }
    }

    private void RemoveSaves()
    {
        FindObjectOfType<DataPersistanceManager>().RemoveSaves();
    }
}
