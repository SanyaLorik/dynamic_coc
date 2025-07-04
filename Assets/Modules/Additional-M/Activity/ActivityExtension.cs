using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public static class ActivityExtension
    {
        public static void ActiveSelf(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void ActiveSelf<T>(this T monoBehaviour) where T : Component
        {
            monoBehaviour.gameObject.SetActive(true);
        }

        public static void DisactiveSelf(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void DisactiveSelf<T>(this T monoBehaviour) where T : Component
        {
            monoBehaviour.gameObject.SetActive(false);
        }

        public static void ActiveSelf(this GameObject[] gameObjects)
        {
            for (int i = 0; i < gameObjects.Length; i++)
                gameObjects[i].SetActive(true);
        }

        public static void ActiveSelfWithNull(this GameObject[] gameObjects)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                if (gameObjects[i] != null)
                    gameObjects[i].SetActive(true);
            }
        }

        public static void DisactiveSelf(this GameObject[] gameObjects)
        {
            for (int i = 0; i < gameObjects.Length; i++)
                gameObjects[i].SetActive(false);
        }

        public static void ActiveSelf<T>(this T[] monoBehaviour) where T : Component
        {
            for (int i = 0; i < monoBehaviour.Length; i++)
                monoBehaviour[i].gameObject.SetActive(true);
        }

        public static void DisactiveSelf<T>(this T[] monoBehaviour) where T : Component
        {
            for (int i = 0; i < monoBehaviour.Length; i++)
                monoBehaviour[i].gameObject.SetActive(false);
        }

        public static void ActiveSelfByFlag<T>(this T monoBehaviour, bool flag) where T : Component
        {
            monoBehaviour.gameObject.SetActive(flag);
        }

        public static void ActiveSelfByFlag(this GameObject gameObject, bool flag)
        {
            gameObject.SetActive(flag);
        }

        public static void ActiveSelf(this ReplacableGameObject replacableGameObject) 
            => replacableGameObject.Instance.SetActive(true);

        public static void DisactiveSelf(this ReplacableGameObject replacableGameObject) 
            => replacableGameObject.Instance.SetActive(false);

        public static bool IsActiveSelf(this GameObject gameObject)
        {
            return gameObject.activeSelf == true && gameObject.activeInHierarchy;
        }

        public static bool IsActiveSelf<T>(this T monoBehaviour) where T : Component
        {
            return monoBehaviour.gameObject.activeSelf == true && monoBehaviour.gameObject.activeInHierarchy;
        }
    }
}