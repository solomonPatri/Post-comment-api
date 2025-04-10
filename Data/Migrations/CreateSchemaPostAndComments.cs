﻿using FluentMigrator;
using System.ComponentModel.DataAnnotations.Schema;

namespace Post_Coments_Api.Data.Migrations
{
    [Migration(190320251)]
    public class CreateSchemaPostAndComments:Migration
    {

        public override void Up()
        {

            Create.Table("posts")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("title").AsString(120).NotNullable()
                .WithColumn("content").AsString(120).NotNullable()
                .WithColumn("created_post").AsDateTime().NotNullable()
                .WithColumn("update_post").AsDateTime().NotNullable();

            Create.Table("comments")
                .WithColumn("id").AsInt32().PrimaryKey().Identity()
                .WithColumn("name_autor").AsString(120).NotNullable()
                .WithColumn("created").AsDateTime().NotNullable()
                .WithColumn("content").AsString(120).NotNullable()
                .WithColumn("PostId").AsInt32().ForeignKey("posts", "id").OnDelete(System.Data.Rule.Cascade);

        }

        public override void Down()
        {
            Delete.Table("comments");
            Delete.Table("posts");



        }












    }
}
