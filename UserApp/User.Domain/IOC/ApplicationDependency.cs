namespace User.Domain.IOC
{
    using Contracts;

    using Service;

    public class ApplicationDependency
    {
        public static Dictionary<Type, Type> GetScopedTypes()
        {
            Dictionary<Type, Type> types = new Dictionary<Type, Type>();
            types.Add(typeof(IUserService), typeof(UserService));
            return types;
        }
    }
}