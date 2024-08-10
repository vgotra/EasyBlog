﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace EasyBlog.DataAccess.Compiledmodels
{
    public partial class EasyBlogDbContextModel
    {
        partial void Initialize()
        {
            var postEntity = PostEntityEntityType.Create(this);

            PostEntityEntityType.CreateAnnotations(postEntity);

            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "8.0.7");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
            AddRuntimeAnnotation("Relational:RelationalModel", CreateRelationalModel());
        }

        private IRelationalModel CreateRelationalModel()
        {
            var relationalModel = new RelationalModel(this);

            var postEntity = FindEntityType("EasyBlog.DataAccess.Entities.PostEntity")!;

            var defaultTableMappings = new List<TableMappingBase<ColumnMappingBase>>();
            postEntity.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings);
            var easyBlogDataAccessEntitiesPostEntityTableBase = new TableBase("EasyBlog.DataAccess.Entities.PostEntity", null, relationalModel);
            var contentColumnBase = new ColumnBase<ColumnMappingBase>("Content", "text", easyBlogDataAccessEntitiesPostEntityTableBase);
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("Content", contentColumnBase);
            var createdDateColumnBase = new ColumnBase<ColumnMappingBase>("CreatedDate", "timestamp with time zone", easyBlogDataAccessEntitiesPostEntityTableBase);
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("CreatedDate", createdDateColumnBase);
            var idColumnBase = new ColumnBase<ColumnMappingBase>("Id", "uuid", easyBlogDataAccessEntitiesPostEntityTableBase);
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("Id", idColumnBase);
            var isPublishedColumnBase = new ColumnBase<ColumnMappingBase>("IsPublished", "boolean", easyBlogDataAccessEntitiesPostEntityTableBase);
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("IsPublished", isPublishedColumnBase);
            var publishOnDateColumnBase = new ColumnBase<ColumnMappingBase>("PublishOnDate", "timestamp with time zone", easyBlogDataAccessEntitiesPostEntityTableBase)
            {
                IsNullable = true
            };
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("PublishOnDate", publishOnDateColumnBase);
            var readableUrlColumnBase = new ColumnBase<ColumnMappingBase>("ReadableUrl", "character varying(2048)", easyBlogDataAccessEntitiesPostEntityTableBase);
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("ReadableUrl", readableUrlColumnBase);
            var titleColumnBase = new ColumnBase<ColumnMappingBase>("Title", "character varying(1000)", easyBlogDataAccessEntitiesPostEntityTableBase);
            easyBlogDataAccessEntitiesPostEntityTableBase.Columns.Add("Title", titleColumnBase);
            relationalModel.DefaultTables.Add("EasyBlog.DataAccess.Entities.PostEntity", easyBlogDataAccessEntitiesPostEntityTableBase);
            var easyBlogDataAccessEntitiesPostEntityMappingBase = new TableMappingBase<ColumnMappingBase>(postEntity, easyBlogDataAccessEntitiesPostEntityTableBase, true);
            easyBlogDataAccessEntitiesPostEntityTableBase.AddTypeMapping(easyBlogDataAccessEntitiesPostEntityMappingBase, false);
            defaultTableMappings.Add(easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase, postEntity.FindProperty("Id")!, easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)contentColumnBase, postEntity.FindProperty("Content")!, easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)createdDateColumnBase, postEntity.FindProperty("CreatedDate")!, easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)isPublishedColumnBase, postEntity.FindProperty("IsPublished")!, easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)publishOnDateColumnBase, postEntity.FindProperty("PublishOnDate")!, easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)readableUrlColumnBase, postEntity.FindProperty("ReadableUrl")!, easyBlogDataAccessEntitiesPostEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)titleColumnBase, postEntity.FindProperty("Title")!, easyBlogDataAccessEntitiesPostEntityMappingBase);

            var tableMappings = new List<TableMapping>();
            postEntity.SetRuntimeAnnotation("Relational:TableMappings", tableMappings);
            var postsTable = new Table("Posts", "EasyBlog", relationalModel);
            var idColumn = new Column("Id", "uuid", postsTable);
            postsTable.Columns.Add("Id", idColumn);
            var contentColumn = new Column("Content", "text", postsTable);
            postsTable.Columns.Add("Content", contentColumn);
            var createdDateColumn = new Column("CreatedDate", "timestamp with time zone", postsTable);
            postsTable.Columns.Add("CreatedDate", createdDateColumn);
            var isPublishedColumn = new Column("IsPublished", "boolean", postsTable);
            postsTable.Columns.Add("IsPublished", isPublishedColumn);
            var publishOnDateColumn = new Column("PublishOnDate", "timestamp with time zone", postsTable)
            {
                IsNullable = true
            };
            postsTable.Columns.Add("PublishOnDate", publishOnDateColumn);
            var readableUrlColumn = new Column("ReadableUrl", "character varying(2048)", postsTable);
            postsTable.Columns.Add("ReadableUrl", readableUrlColumn);
            var titleColumn = new Column("Title", "character varying(1000)", postsTable);
            postsTable.Columns.Add("Title", titleColumn);
            var pK_Posts = new UniqueConstraint("PK_Posts", postsTable, new[] { idColumn });
            postsTable.PrimaryKey = pK_Posts;
            var pK_PostsUc = RelationalModel.GetKey(this,
                "EasyBlog.DataAccess.Entities.PostEntity",
                new[] { "Id" });
            pK_Posts.MappedKeys.Add(pK_PostsUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_PostsUc).Add(pK_Posts);
            postsTable.UniqueConstraints.Add("PK_Posts", pK_Posts);
            relationalModel.Tables.Add(("Posts", "EasyBlog"), postsTable);
            var postsTableMapping = new TableMapping(postEntity, postsTable, true);
            postsTable.AddTypeMapping(postsTableMapping, false);
            tableMappings.Add(postsTableMapping);
            RelationalModel.CreateColumnMapping(idColumn, postEntity.FindProperty("Id")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(contentColumn, postEntity.FindProperty("Content")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(createdDateColumn, postEntity.FindProperty("CreatedDate")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(isPublishedColumn, postEntity.FindProperty("IsPublished")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(publishOnDateColumn, postEntity.FindProperty("PublishOnDate")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(readableUrlColumn, postEntity.FindProperty("ReadableUrl")!, postsTableMapping);
            RelationalModel.CreateColumnMapping(titleColumn, postEntity.FindProperty("Title")!, postsTableMapping);
            return relationalModel.MakeReadOnly();
        }
    }
}
