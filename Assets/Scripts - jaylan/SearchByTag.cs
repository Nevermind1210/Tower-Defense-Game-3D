using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
public class SelectByTag : EditorWindow
{
    TextAsset txtAsset;
    Vector2 scroll;
    private static string SelectedTag;

    [MenuItem("Search/Select By Tag %g")]
    public static void SelectObjectsWithTag()
    {
        EditorWindow window = GetWindow<SelectByTag>();
        window.position = new Rect(0, 0, 350, 70);
        window.Show();
    }
    void OnGUI()
    {
        SelectedTag = EditorGUI.TextArea(new Rect(3, 3, position.width - 6, position.height - 35), SelectedTag);

        if (GUI.Button(new Rect(0, position.height - 20, position.width, 15), "Confirm"))
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(SelectedTag);
            Selection.objects = objects;
            this.Close();
        }

        if (Event.current.keyCode == KeyCode.Return)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(SelectedTag);
            Selection.objects = objects;
            this.Close();
        }
    }
}