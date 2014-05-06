using System.Collections.Generic;
using Assets.Scripts.Resource;
using Sfs2X;
using Sfs2X.Entities;
using UnityEngine;
using System.Collections;

public class GemManager : MonoBehaviour 
{
    private static GemManager _instance;

    public static GemManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<GemManager>();

            return _instance;
        }
    }	

    private Dictionary<SerializableGuid, GemInstance> gems = new Dictionary<SerializableGuid, GemInstance>();

    public void LoadAllGemsOnScene()
    {
        gems.Clear();

        foreach (var gem in FindObjectsOfType<GemInstance>())
            gems.Add(gem.Guid, gem);
    }

    /// <summary>
    /// Создание фигуры на поле по пришедшим с сервера данным 
    /// </summary>
    public void CreateGem(GemSpawnData data)
    {
        // К нам пришел идентификатор - определяем по нему что за фигура
        GemResource resource = Instances.Get<ResourcesManager>().Gems.GetByGuid(data.resourceGuid);

        var gem = GameObject.Instantiate(resource.prefab) as GameObject;

        gem.transform.position = BoardGridManager.instance.GetCellCenter(data.coords);

        var gemInstance = gem.AddComponent<GemInstance>();
        gemInstance.Guid = data.instanceGuid;
        gemInstance.Resource = resource;
        gemInstance.ownerId = data.userId;

        gems.Add(gemInstance.Guid, gemInstance);
    }

    /// <summary>
    /// Удалить кристалл с поля
    /// </summary>
    public void RemoveGem(GemInstance gem)
    {
        gems.Remove(gem.Guid);

        Destroy(gem.gameObject);
    }
}
