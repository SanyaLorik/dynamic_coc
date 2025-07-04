using UnityEngine;
using Zenject;

namespace _KotletaGames.Additional_M
{
    public class DebugResolverToolBase<T> : MonoBehaviour
    {
        public T _instance;

        [Inject]
        private void Construct(T instance)
        {
            _instance = instance;
        }
    }
}