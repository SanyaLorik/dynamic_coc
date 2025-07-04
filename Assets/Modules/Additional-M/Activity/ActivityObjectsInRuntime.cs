using System;
using UnityEngine;

namespace _KotletaGames.Additional_M
{
    public class ActivityObjectsInRuntime : MonoBehaviour
    {
        [Header("Gameobject Enable")]

        [Header("Awake")]
        [SerializeField] private SerializableStructArray<SubContainer<SerializableStructArray<GameObject>>> _awakeGameobjectsEnables;

        [Header("Start")]
        [SerializeField] private SerializableStructArray<SubContainer<SerializableStructArray<GameObject>>> _startGameobjectsEnables;

        [Header("Gameobject Disable")]

        [Header("Awake")]
        [SerializeField] private SerializableStructArray<SubContainer<SerializableStructArray<GameObject>>> _awakeGameobjectsDisables;

        [Header("Start")]
        [SerializeField] private SerializableStructArray<SubContainer<SerializableStructArray<GameObject>>> _startGameobjectsDisables;

        public bool IsCompleted { get; private set; } = false;

        public void Awake()
        {
            foreach (var awakeArray in _awakeGameobjectsEnables.Array)
            {
                foreach (var awake in awakeArray.Value.Array)
                    awake.ActiveSelf();
            }

            foreach (var awakeArray in _awakeGameobjectsDisables.Array)
            {
                foreach (var awake in awakeArray.Value.Array)
                    awake.DisactiveSelf();
            }
        }

        private void Start()
        {
            foreach (var startArray in _startGameobjectsEnables.Array)
            {
                foreach (var start in startArray.Value.Array)
                    start.ActiveSelf();
            }

            foreach (var startArray in _startGameobjectsDisables.Array)
            {
                foreach (var start in startArray.Value.Array)
                    start.DisactiveSelf();
            }

            IsCompleted = true;
        }

        [Serializable]
        internal struct SubContainer<T>
        {
            [field: SerializeField] public T Value; 
        }
    }
}