using System.Linq;
using Assets.Scripts.Resource;
using UnityEngine;

/// <summary>
/// Главный игровой контроллер, управляющей ходом игры.
/// </summary>
public class GameController : MonoBehaviour 
{
    void Awake()
    {
        // Реализовать здесь логику "входа" двух игроков в игру (с помощью PlayerManager)

        // Запуск игры - с помощью 

        GemSpawnData data = new GemSpawnData(); // объект с информацией о создаваемой фигуре (позже будет приходить с сервера)
        data.instanceGuid = new SerializableGuid(); // Генерируем случайный гуид

        // Подробно
        // Все ресурсы хранятся в GemResourceManager в списке Resources

        // Через класс Instances мы получае экземпляр компонента ResourceManager, который загружается в сцене Preload в скрипте PreloadScript
        // У этого экземпляра есть менеджер ресурсов именно для КРИСТАЛЛОВ - переменная Gems (это и есть GemResourceManager)
        // Берем его словарик ресурсов, нам нужен именно ключ ресурса - Keys, для примера берем самый первый ключ (так же можно и другой 1 из 6)
        data.resourceGuid = Instances.Get<ResourcesManager>().Gems.Resources.Keys.ElementAt(0);

        data.userId = -1; // Один из созданных выше игроков
        
        data.coords = new BoardCoord(0, 0); // Случайно или нет выставляем координаты

        Instances.Get<GemManager>().CreateGem(data); // Это создаст КРИСТАЛЛ на доске
    }
}
