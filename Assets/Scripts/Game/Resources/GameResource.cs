using Newtonsoft.Json;
using UnityEngine;
using System.Collections;

public abstract class GameResource : MonoBehaviour
{
    public enum ResourceType
    {
        Gem
    }

    /// <summary>
    /// Идентификатор ресурса
    /// Генерация: выбрать игровой объект, с компонентом, содержащим это поле, активировать пункт меню
    /// Custom -> Guids -> Set GUID from meta
    /// </summary>
    public SerializableGuid Guid;

    /// <summary>
    /// Тип ресурса. Необходим для отправки типа ресурса на сервер вместе с Guid и однозначной идентификации ресурса
    /// </summary>
    public abstract ResourceType Type { get; }

    /// <summary>
    /// Метод для инициализации поля 
    /// </summary>
    /// <param name="fieldName">Имя поля, которое будет проинициализровано с помощью json-данных</param>
    /// <param name="jsonData">Данные в json формате</param>
    protected void SetFieldWithJson(string fieldName, string jsonData)
    {
        foreach (System.Reflection.FieldInfo field in this.GetType().GetFields())
        {
            if (field.Name.Equals(fieldName))
            {
                Debug.Log(fieldName + " field in " + GetType() + " was initialized with jsonData");
                try
                {
                    field.SetValue(this, JsonConvert.DeserializeObject(jsonData, field.GetType()));
                }
                catch
                {
                    Debug.LogError("Не удалось задать поле " + fieldName + " в классе " + GetType());
                }
            }
        }
    }
}
