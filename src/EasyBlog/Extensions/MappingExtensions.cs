namespace EasyBlog.Extensions;

[Mapper]
public static partial class EntityToModelMappingExtensions
{
    public static partial PostResponse ToModel(this PostEntity entity);
    //TODO Add mapping for some properties
}