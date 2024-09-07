namespace EasyBlog.Common;

public static class DbDefaults
{
    public static class Language
    {
        public const int NameMaxLength = 50;
        public const int CodeMaxLength = 10;
    }

    public static class Post
    {
        public const int ReadableUrlMaxLength = 2048;
    }

    public static class PostContent
    {
        public const int TitleMaxLength = 1000;
        public const int ContentMaxLength = 50000;
    }

    public static class Tag
    {
        public const int NameMaxLength = 20;
    }

    public static class Setting
    {
        public const int NameMaxLength = 40;
        public const int ValueMaxLength = 4000;
    }
}