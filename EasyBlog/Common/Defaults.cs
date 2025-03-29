namespace EasyBlog.Common;

public static class Defaults
{
    public static class Auth
    {
        public const string DefaultAdminRoleName = "AdminRole";
    }

    public static class Cache
    {
        public const string NoCachePolicy = nameof(NoCachePolicy);
    }
}