using _KotletaGames.ArchitectureCore_M.Extessions;
using UnityEngine;
using Zenject;

namespace _KotletaGames.ArchitectureCore_M.Configs
{
    public class TypeInstaller<T> : MonoInstaller where T : Component
    {
        [SerializeField] private T _objectPrefab;

        public override void InstallBindings()
        {
            var instance = Instantiate(_objectPrefab);
            Container.BindAllInterfacesAndSelfFromInstance(instance);
        }
    }
}