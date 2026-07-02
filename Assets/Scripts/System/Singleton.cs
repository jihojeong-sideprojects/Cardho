using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            // Cast to object to bypass Unity's == operator with generics
            if ( _instance == null)
            {
                _instance = FindAnyObjectByType<T>();

                // Ensure DontDestroyOnLoad is called even if accessed before Awake
                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance.gameObject);
                }
                else
                {
                    Debug.LogError($"{typeof(T).Name} Singleton not found.");
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        // Cast to object first to check actual null, then Unity's null for destroyed objects 
        if ( _instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }
}