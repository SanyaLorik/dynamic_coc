using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public static partial class GlobalSpawner
    {
        public static T SpawnPrefabWithPosition<T>(T prefab, Vector2 position)
            where T : UnityEngine.Object
        {
            return UnityEngine.Object.Instantiate(prefab, position, Quaternion.identity);
        }

        public static T SpawnPrefab<T>(T prefab, Transform container)
            where T : UnityEngine.Object
        {
            return UnityEngine.Object.Instantiate(prefab, container);
        }
    }
}