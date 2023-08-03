using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    public static T Instance {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(instance.gameObject);
            instance = null;
        }

        T prevObject = FindObjectOfType<T>();
        if (prevObject != null && prevObject != this)
        {
            DestroyImmediate(prevObject);
            instance = null;
        }

        instance = this as T;
        DontDestroyOnLoad(gameObject);
    }

    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
    }

    protected virtual void OnDestroy()
    {
    }
}
