using System;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEditor;
using UnityEngine;
using System.Collections;

/// <summary>
/// Класс для генерации GUID полей (SerializableGUID) компонентов
/// </summary>
public class GuidEditor : EditorWindow 
{
    
    [MenuItem("Custom/Guids/Set GUID from meta %E")]
    public static void AssignGUIDFromMeta()
    {
        foreach (GameObject obj in UnityEditor.Selection.gameObjects)
        {
            SerializableGuid oldValue = GetGuid(obj);
            if (oldValue != null)
            {
                string meta = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(obj)) + obj.name;
                meta = meta.GetMd5Hash();

                byte[] src = new byte[16];
                for (int i = 0; i < 16; i++)
                {
                    src[i] = Convert.ToByte("" + meta[i * 2] + meta[i * 2 + 1], 16);
                }
                oldValue.m_GuidBytes = src;

                EditorUtility.SetDirty(obj);

                Debug.Log("GUID assigned to " + obj.name + " from meta (" + meta + ")");
            }
        }

        AssetDatabase.SaveAssets();
    }

    public static SerializableGuid GetGuid(GameObject obj)
    {
        if (!string.IsNullOrEmpty(AssetDatabase.GetAssetPath(obj)))
        {
            MonoBehaviour mb = obj.GetComponent<MonoBehaviour>();
            foreach (System.Reflection.FieldInfo fi in mb.GetType().GetFields())
            {
                if (fi.FieldType == typeof(SerializableGuid))
                {
                    SerializableGuid oldValue = fi.GetValue(mb) as SerializableGuid;
                    return oldValue;
                }
            }
        }
        return null;
    }

    [MenuItem("Custom/Guids/Report GUIDs")]
    public static void ReportGuids()
    {
        if (UnityEditor.Selection.gameObjects.Length <= 0)
            return;

        foreach (GameObject go in UnityEditor.Selection.gameObjects)
        {
            SerializableGuid guid = GetGuid(go);
            if (guid == null)
                continue;

            Debug.Log("Item: " + go.name + " GUID: " + guid.GetString());
        }
    }
}
