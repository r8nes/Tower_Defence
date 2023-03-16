namespace Defender.Service
{
    /// <summary>
    /// Singleton for implementing services via injection into a container.
    /// </summary>
    public class AllServices
    {
        private static AllServices _instance;

        public static AllServices Container => _instance ?? (_instance = new AllServices());

        public void RegisterSingle<TService>(TService service) where TService : IService => Impleamentation<TService>.ServiceInstance = service;

        public TService Single<TService>() where TService : IService => Impleamentation<TService>.ServiceInstance;

        private static class Impleamentation<TService> where TService : IService
        {
            public static TService ServiceInstance;
        }
    }
}