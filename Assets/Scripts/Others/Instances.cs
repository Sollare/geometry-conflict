using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Класс хранитель инстансов по типу (аля Dependency Injection)
/// </summary>
public class Instances : MonoBehaviour
{
    private static GameObject _instanceHolder;

    public static GameObject InstancesRootObject
    {
        get
        {
            if (_instanceHolder == null)
            {
                _instanceHolder = GameObject.Find("_InstanceHolder");

                if (_instanceHolder == null)
                {
                    _instanceHolder = new GameObject("_InstanceHolder");
                    _instanceHolder.AddComponent<DontDestroyThisOnLoad>();
                }
            }

            return _instanceHolder;
        }
    }

    private static readonly Dictionary<Type, object> instances = new Dictionary<Type, object>();

    /// <summary>
    /// Возвращает экземпляр компонента по его типу. Если такой объект отсутствует, 
    /// то будет создан дочерний объект для объекта сцены _InstanceHolder, содержащий этот компонент
    /// </summary>
    public static T Get<T>() where T : MonoBehaviour
    {
        object result = null;
        instances.TryGetValue(typeof(T), out result);

        if (result == null)
        {
            result = InstancesRootObject.gameObject.GetComponentInChildren<T>();

            if (result != null)
            {
                instances.Add(typeof(T), result);
            }
            else
            {
                var go = new GameObject(typeof (T).Name);
                go.transform.parent = InstancesRootObject.transform;

                result = go.AddComponent<T>();
                instances.Add(typeof(T), result);
            }
        }

        return (T)result;
    }

    public static void InitializeRequiredInstances()
    {

    }
}
