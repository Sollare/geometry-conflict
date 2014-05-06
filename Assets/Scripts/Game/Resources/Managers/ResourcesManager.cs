using UnityEngine;

namespace Assets.Scripts.Resource
{
    public class ResourcesManager : MonoBehaviour
    {
        /// <summary>
        /// Менеджер ресурсов экзоботов
        /// </summary>
        public GemResourceManager Gems;

        public void Awake()
        {
            Gems = new GemResourceManager();

            Debug.Log("Менеджер ресурсов инициализирован");
        }
    }
}
