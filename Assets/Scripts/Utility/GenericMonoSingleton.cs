using UnityEngine;

namespace TankGame.Utility
{
    public class GenericMonoSingleton<T> : MonoBehaviour where T : GenericMonoSingleton<T>
    {
        private static T instance = null;

        public static T Instance { get { return instance; } }

        virtual protected void Awake()
        {
            if (instance == null)
            {
                instance = (T)this;
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(this);
        }
    }
}