using Zenject;

namespace _KotletaGames.ArchitectureCore_M.Extessions
{
    public static class DiContainerExtensions
    {
        public static T BindAllInterfacesAndSelfFromInstance<T>(this DiContainer container, T instance) where T : class
        {
            var type = typeof(T);
            var interfaces = type.GetInterfaces(); // Получаем все интерфейсы, включая унаследованные

            // Привязываем каждый интерфейс к инстансу
            foreach (var iface in interfaces) 
                container.Bind(iface).FromInstance(instance).AsSingle().NonLazy();

            // Привязываем сам тип
            container.Bind<T>().FromInstance(instance).AsSingle().NonLazy();

            return instance;
        }
        
        public static T BindAllInterfacesAndSelf<T>(this DiContainer container) where T : class, new()
        {
            var type = typeof(T);
            var interfaces = type.GetInterfaces(); // Получаем все интерфейсы, включая унаследованные

            var instance = new T();
            
            // Привязываем каждый интерфейс к инстансу
            foreach (var iface in interfaces) 
                container.Bind(iface).FromInstance(instance).AsSingle().NonLazy();

            // Привязываем сам тип
            container.Bind<T>().FromInstance(instance).AsSingle().NonLazy();

            return instance;
        }
    }
}