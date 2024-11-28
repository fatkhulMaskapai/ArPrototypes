using UnityEngine;
public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] protected bool useDontDestroy = false;
    private static T instance;
    public static T Instance => instance;

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            if (useDontDestroy)
                DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
