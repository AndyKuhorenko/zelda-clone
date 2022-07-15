using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

public class EditModeFunctions : EditorWindow
{
    private Dictionary<string, GameData> profiles;


    [MenuItem("Window/Edit Mode Functions")]
    public static void ShowWindow()
    {
        GetWindow<EditModeFunctions>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        GUILayout.Space(20f);

        if (GUILayout.Button("Set movable objects' IDs"))
        {
            SetIDs();
        }

        GUILayout.Space(20f);

        if (GUILayout.Button("Remove ALL saves"))
        {
            bool decision = EditorUtility.DisplayDialog(
              "Remove all saves", // title
              "Are you sure want to remove all saves?", // description
              "Yes", // OK button
              "No" // Cancel button
            );

            if (decision)
            {
                RemoveSaves();
                GetAllProfileIDs();
            }
            else
            {
                Debug.Log("Remove canceled!");
            }
        }
        
        GUILayout.Space(20f);


        if (GUILayout.Button("Remove save by PROFILE ID"))
        {
            GetAllProfileIDs();
        }

        if (profiles != null)
        {
            if (profiles.Count == 0)
            {
                Debug.Log("Saves in profiles not found!");

                profiles = null;
            }
            else
            {
                foreach (var profile in profiles)
                {
                    if (GUILayout.Button("Remove save in profile: " + profile.Key))
                    {
                        bool decision = EditorUtility.DisplayDialog(
                          "Remove save in profile: " + profile.Key, // title
                          "Are you sure want to remove saves for profile: " + profile.Key + "?", // description
                          "Yes", // OK button
                          "No" // Cancel button
                        );

                        if (decision)
                        {
                            FindObjectOfType<DataPersistanceManager>().RemoveSaveByProfileId(profile.Key);
                            GetAllProfileIDs();
                        }
                        else
                        {
                            Debug.Log("Remove canceled!");
                        }
                    }
                }
            }
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

    private void GetAllProfileIDs()
    {
        profiles = FindObjectOfType<DataPersistanceManager>().GetAllProfilesDataInEditor();
    }
}
