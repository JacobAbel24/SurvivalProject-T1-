using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class inventoryEditor : EditorWindow
{
    [MenuItem("Window/Inventory Editor")]
    public static void showWindow()
    {
        GetWindow<inventoryEditor>();
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Inventory Menu");
    }


}
