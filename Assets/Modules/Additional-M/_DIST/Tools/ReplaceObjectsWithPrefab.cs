#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _KotletaGames.ArchitectureCore_M.Tools
{
    public class ReplaceChildObjectsWithPrefab : MonoBehaviour
    {
        // Строка для поиска в названиях объектов
        public string searchString;

        // Префаб для замены
        public GameObject prefab;

        void ReplaceObjectsInChildren()
        {
            if (prefab == null)
            {
                Debug.LogError("Prefab не назначен!");
                return;
            }

            // Создаем список дочерних объектов
            List<Transform> childObjects = new List<Transform>();

            // Наполняем список дочерними объектами
            foreach (Transform child in transform)
            {
                if (child.name.Contains(searchString))
                {
                    childObjects.Add(child);
                }
            }

            // Удаляем старые объекты и создаем новые
            foreach (Transform child in childObjects)
            {
                // Сохраняем параметры Transform
                Vector3 position = child.position;
                Quaternion rotation = child.rotation;
                Vector3 scale = child.localScale;

                // Удаляем старый объект
                DestroyImmediate(child.gameObject);

                // Создаем новый объект как префаб
                GameObject newObject = (GameObject)PrefabUtility.InstantiatePrefab(prefab, transform);
                newObject.transform.position = position;
                newObject.transform.rotation = rotation;
                newObject.transform.localScale = scale;

                // Отметить новый объект и сцену как изменённые
                EditorUtility.SetDirty(newObject);
            }

            // Отметить родительский объект как изменённый
            EditorUtility.SetDirty(gameObject);
        }

        // Вызываем замену через контекстное меню
        public void ReplaceObjectsMenu()
        {
            ReplaceObjectsInChildren();
        }
    }
}
#endif