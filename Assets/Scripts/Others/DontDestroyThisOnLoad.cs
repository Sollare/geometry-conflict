using UnityEngine;
using System.Collections;


[AddComponentMenu("Scripts/Utils/DontDestroyThisOnLoad")]
public class DontDestroyThisOnLoad : MonoBehaviour
{
	void Awake() 
	{
		DontDestroyOnLoad(this);
	}
}