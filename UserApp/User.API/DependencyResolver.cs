namespace User.API
{
    using Domain.IOC;

    public static class DependencyResolver
    {
        public static void AddApplication(this IServiceCollection service)
        {
            // service.AddHttpClient();
            foreach (KeyValuePair<Type, Type> item in ApplicationDependency.GetScopedTypes())
            {
                service.AddScoped(item.Key, item.Value);
            }
        }
    }
}