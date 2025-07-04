using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    [Serializable]
    public class ReplacableGameObject
    {
        [field:SerializeField] public Transform Container { get; private set; }
        public GameObject Instance { get; private set; }
        public GameObject Set(GameObject prefab)
        {
            if (Container == null)
                throw new InvalidOperationException("Container is not assigned.");

            // Удаляем старый объект, если он есть
            if ( Instance != null) 
                GameObject.Destroy(Instance);

            // Создаем новый объект и устанавливаем его в качестве дочернего элемента контейнера
            return Instance = GameObject.Instantiate(prefab, Container);
        }
    }
}