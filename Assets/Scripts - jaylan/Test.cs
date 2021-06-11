using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestTextFieldFocusOnStartup : EditorWindow 
{
    [MenuItem("Test/Text Field Focus On Startup")]
    public static void St()
    {
        var w = GetWindow<TestTextFieldFocusOnStartup>();
        w.Show();
    }
    private bool focused;
    private void OnGUI()
    {
        GUI.SetNextControlName("prpr");
        EditorGUILayout.TextField("");
        if (!focused)
        {
            GUI.FocusControl("prpr");
            var te = (TextEditor)GUIUtility.GetStateObject(typeof(TextEditor), GUIUtility.keyboardControl);
            te.cursorIndex = 1;
            focused = true;
        }
        EditorGUILayout.TextField("");
    }
}

