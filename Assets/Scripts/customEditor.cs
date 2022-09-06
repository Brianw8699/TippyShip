using UnityEditor;
using UnityEngine;
 
// provide the component type for which this inspector UI is required
[CustomEditor(typeof(ShadowCaster2DTileMap))]
public class customInspector : Editor
{
    public override void OnInspectorGUI()
    {
        // will enable the default inpector UI 
        base.OnInspectorGUI();
 
        // implement your UI code here
        var style = new GUIStyle(GUI.skin.label);
        style.alignment = TextAnchor.MiddleCenter;
        style.fontStyle = FontStyle.Bold;
        GUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Generate Shadows");
        ShadowCaster2DTileMap ShadowCaster2DTileMap = (ShadowCaster2DTileMap)target;
        GUILayout.EndHorizontal();
        //Button
        if (GUILayout.Button("Generate Shadows"))
        {
            ShadowCaster2DTileMap.Generate();
        }
    }
}

    // Update is called once per frame
