using UnityEngine;

public class SingletonMonoBehavior<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance
    {
        get {
            if (_instance == null)
            {
                // find gameobject that matches type of T in current scene.
                _instance = (T)FindObjectOfType(typeof(T));
                
                // if it is null, that singleton is not exist in current scene.
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();

                    // to distinguish singleton object in scene,
                    // set its name to type name.
                    singletonObject.name = typeof(T).ToString();
                }
            }
            return _instance;
        }
    }
}