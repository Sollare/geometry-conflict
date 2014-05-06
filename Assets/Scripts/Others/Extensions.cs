using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using System.Collections;

public static class Extensions
{
    public static string GetMd5Hash(this string value)
    {
        MD5 md5Hasher = MD5.Create();
 
        // Преобразуем входную строку в массив байт и вычисляем хэш
        byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(value));
 
        // Создаем новый Stringbuilder (Изменяемую строку) для набора байт
        StringBuilder sBuilder = new StringBuilder();
 
        // Преобразуем каждый байт хэша в шестнадцатеричную строку
        for (int i = 0; i < data.Length; i++)
        {
            //указывает, что нужно преобразовать элемент в шестнадцатиричную строку длиной в два символа
            sBuilder.Append(data[i].ToString("x2"));
        }

        return sBuilder.ToString();
    }

    public static Transform FindChildInHierarchy(this Transform target, string name)
    {
        if (target.name == name) return target;

        for (int i = 0; i < target.childCount; ++i)
        {
            var result = FindChildInHierarchy(target.GetChild(i), name);

            if (result != null) return result;
        }

        return null;
    }

    /// <summary>
    /// Метод для инициализации поля 
    /// </summary>
    /// <param name="obj">Объект, которому необходимо задать поле с помощью json-данных</param>
    /// <param name="fieldName">Имя поля, которое будет проинициализровано с помощью json-данных</param>
    /// <param name="jsonData">Данные в json формате</param>
    public static void SetFieldWithJson(this object obj, string fieldName, string jsonData)
    {
        foreach (System.Reflection.FieldInfo field in obj.GetType().GetFields())
        {
            if (field.Name.Equals(fieldName))
            {
                Debug.Log(fieldName + " field in " + obj.GetType() + " was initialized with jsonData");
                try
                {
                    field.SetValue(obj, JsonConvert.DeserializeObject(jsonData, field.GetType()));
                }
                catch
                {
                    Debug.LogError("Не удалось задать поле " + fieldName + " в классе " + obj.GetType());
                }
            }
        }
    }
}