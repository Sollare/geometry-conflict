using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Resource
{
    /// <summary>
    /// Абстрактный класс менеджера ресурсов для определенной модели
    /// </summary>
    /// <typeparam name="T">Модель, которую хранит менеджер ресурсов</typeparam>
    public abstract class ResourceManager<T> where T: GameResource
    {
        public abstract Dictionary<SerializableGuid, T> Resources { get; set; }

        public readonly GameResource.ResourceType ManagerResourceType; 
         
        /// <summary>
        /// Конструктор для менеджера ресурсов
        /// </summary>
        /// <param name="resourceType">Тип ресурса, с которым работает данный обработчик</param>
        protected ResourceManager(GameResource.ResourceType resourceType)
        {
            ManagerResourceType = resourceType;

            LoadAllResources();
        }

        /// <summary>
        /// Абстрактный метод для определения - загрузка всех ресурсов в Dictionary
        /// </summary>
        public abstract void LoadAllResources();

        /// <summary>
        /// Возвращает ресурсы с guid, который находится в переданном массиве guid'ов
        /// </summary>
        public T[] GetByGuids(params SerializableGuid[] guids)
        {
            if (Resources == null)
            {
                Debug.LogWarning("Ресурсы не загружены, невозможно обновить модель");
                return null;
            }

            return Resources.Where(kvp => guids.Contains(kvp.Key)).Select(kvp => kvp.Value).ToArray();
        }

        /// <summary>
        /// Возвращает ресурс по идентификатору Guid
        /// </summary>
        public T GetByGuid(SerializableGuid guid)
        {
            if (Resources == null)
            {
                Debug.LogWarning("Ресурсы не загружены, невозможно обновить модель");
                return null;
            }

            T value;
            if (Resources.TryGetValue(guid, out value))
                return value;
            else
            {
                Debug.LogError("Не удалось найти ресурс с Guid:" + guid);
                return null;
            }
        }

        /// <summary>
        /// Возвращает ресурс по типу ресурса
        /// </summary>
        public TRes GetByType<TRes>() where TRes : T
        {
            if (Resources == null)
            {
                Debug.LogWarning("Ресурсы не загружены, невозможно обновить модель");
                return null;
            }

            foreach (var resource in Resources)
            {
                if (resource.Value.GetType() == typeof(TRes))
                    return (TRes)resource.Value;
            }

            Debug.LogError("Не удалось найти ресурс с типом " + typeof(TRes).Name);
            return null;
        }
    }
}
