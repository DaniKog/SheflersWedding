using UnityEngine;
using System.Collections;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected static T instance;
	public static T Instance {
		get {
			if(instance == null)
			{
				instance = FindObjectOfType(typeof(T)) as T;

				if(instance == null)
				{
					Debug.LogWarning("There is no singleton of type " + typeof(T).ToString() + 
					               	" in the scene! Please ensure there's always one before playing.");

					Debug.LogWarning("Creating provisory " + typeof(T).ToString()+ "...");
					instance = new GameObject(typeof(T).ToString()).AddComponent<T>();
				}
			}

			return instance;
		}
		private set { instance = value;	}
	}	
}
