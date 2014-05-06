using System.Collections.Generic;
using Assets.Scripts.Resource;
using UnityEngine;
using System.Collections;

public class GemResourceManager : ResourceManager<GemResource>
{
    public override Dictionary<SerializableGuid, GemResource> Resources { get; set; }

    public GemResourceManager() : base(GameResource.ResourceType.Gem)
    {
    }

    public override void LoadAllResources()
    {
        Resources = new Dictionary<SerializableGuid, GemResource>();

        var gemResources = UnityEngine.Resources.LoadAll<GemResource>("_GameResources/Gems");

        Debug.Log("Загружены ресурсы для " + gemResources.Length + " ед. кристаллов");

        foreach (var gem in gemResources)
        {
            Resources.Add(gem.Guid, gem);
        }
    }
}
