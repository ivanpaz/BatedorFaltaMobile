using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR

[ExecuteInEditMode]
[CustomEditor(typeof(InstanceByArea), true)]
public class InstanceByAreaEditor : Editor
{


    InstanceByArea myObject;
    void OnEnable()
    {
        if(myObject == null){
            myObject = target as InstanceByArea;
        }
    }

    public override void OnInspectorGUI(){

        DrawDefaultInspector();
        if(GUILayout.Button("Create Areas"))
        {
            myObject.CreateAreasAndSave();
        }
    }
    
    void OnSceneGUI()
    {
        Vector3 size = new Vector3(myObject.width, myObject.height, 2f);
        Handles.color = Color.yellow;
        Handles.DrawWireCube(myObject.transform.position, size);

        //Criar quadrado das areas
        if (myObject.itenAreas != null && myObject.itenAreas.Count > 0)
        {
            for(int i = 0; i < myObject.itenAreas.Count; i++)
            {
             
                float xx = myObject.itenAreas[i].x;
                float xx2 = myObject.itenAreas[i].x2;
                float yy = myObject.itenAreas[i].y;
                float yy2 = myObject.itenAreas[i].y2;
                float margin = myObject.margin;
                DrawCube(xx, yy, xx2, yy2, myObject.transform.position.z, 5f);
                Handles.color = Color.red;

                float marginx = margin;
                float marginy = margin;

                if(yy == yy2){
                    marginy = 0;
                }

                if(xx == xx2){
                    marginx = 0;
                }

                float clampx1 = Mathf.Clamp(xx + marginx, xx, (xx + xx2) / 2);
                float clampx2 = Mathf.Clamp(xx2 - marginx, (xx + xx2) / 2, xx2);
                float clampy1 = Mathf.Clamp(yy + marginy, yy, (yy + yy2) / 2);
                float clampy2 = Mathf.Clamp(yy2 - marginy, (yy + yy2) / 2, yy2);
                //Mathf.Clamp(xx2, xx2, xx2 - marginx);

                DrawCube(clampx1, clampy1, clampx2, clampy2, myObject.transform.position.z, 10f);
            }
        }
    }

    void DrawCube (float x, float y, float x2, float y2, float z, float lineSize)
    {
        Handles.DrawDottedLine(new Vector3(x, y, z), new Vector3(x2, y, z), lineSize);
        Handles.DrawDottedLine(new Vector3(x2, y, z), new Vector3(x2, y2, z), lineSize);
        Handles.DrawDottedLine(new Vector3(x2, y2, z), new Vector3(x, y2, z), lineSize);
        Handles.DrawDottedLine(new Vector3(x, y2, z), new Vector3(x, y, z), lineSize);
    }
}
#endif