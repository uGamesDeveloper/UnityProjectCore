using System;
using UnityEngine;

namespace uGames
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static bool isApplicationDestroy { get; private set; }
        private static T _instance;
        
        //Для проверки на заблокированность потока 
        private static System.Object _lock = new System.Object();

        public static T Instance
        {
            get
            {
                if (isApplicationDestroy)
                    return null;
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = FindObjectOfType<T>();
                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject("[" + typeof(T).ToString() + "]");
                            _instance = singleton.AddComponent<T>();
                            DontDestroyOnLoad(singleton);
                        }
                    }

                    return _instance;
                }
            }
        }

        public virtual void OnDestroy()
        {
            isApplicationDestroy = true;
        }
    }
}
