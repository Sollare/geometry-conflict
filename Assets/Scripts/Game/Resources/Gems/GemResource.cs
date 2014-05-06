using UnityEngine;
using System.Collections;

public class GemResource : GameResource
{
    /// <summary>
    /// Индентификатор из словаря локализаций
    /// </summary>
    public string displayName;

    /// <summary>
    /// Иконка ресурса
    /// </summary>
    public Sprite displayIcon;

    /// <summary>
    /// Префаб кристалла
    /// </summary>
    public GameObject prefab;
    
    public override ResourceType Type
    {
        get { return ResourceType.Gem; }
    }
}
