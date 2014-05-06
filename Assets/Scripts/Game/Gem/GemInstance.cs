using Sfs2X.Entities;
using UnityEngine;
using System.Collections;

/// <summary>
/// Обязательный компонент для кристалла, идентифицирует его на поле
/// Не определяет его поведение!
/// </summary>
public class GemInstance : MonoBehaviour 
{
    /// <summary>
    /// Идентификатор кристалла (уникальный, получаем с сервера при начале игровой сессии)
    /// </summary>
    public SerializableGuid Guid { get; set; }

    /// <summary>
    /// Ресурс кристалла. Из него мы можем получить название, иконку и путь к префабу
    /// </summary>
    public GemResource Resource { get; set; }

    /// <summary>
    /// Владелец данной фигуры
    /// </summary>
    public int ownerId;

    /// <summary>
    /// Получение владельца по айди
    /// </summary>
    public GemPlayer Owner
    {
        get { return null; }
    }
}
