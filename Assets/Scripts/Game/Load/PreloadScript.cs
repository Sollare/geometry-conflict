using Assets.Scripts.Resource;
using UnityEngine;
using System.Collections;

// Данный скрипт находится в базовой сцене и выполняется самым первым в проекте
public class PreloadScript : MonoBehaviour
{

    public string SceneToLoad;

	void Awake () 
    {
	    // Инициаилизруем базовые компоненты, которые нужны будут в дальнейших сценах. Здесь мы контролируем порядок их загрузки, чтобы что то не вызвалось раньше
	    Instances.Get<ResourcesManager>();

        Application.LoadLevel(SceneToLoad);
	}
}
