using FluentMigrator;
using System;

namespace Cinema.Migrations.DefaultDB
{
    [Migration(20160718115100)]
    public class DefaultDB_20160718_115100_History : Migration
    {
        public override void Up()
        {
            Create.Schema("hist");

            Create.Table("History").InSchema("hist")
                .WithColumn("HistoryId").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Date").AsDateTime().Nullable()
                .WithColumn("Essence").AsString(200).NotNullable()
                .WithColumn("Event").AsString(200).NotNullable()
                .WithColumn("Description").AsString(1000).Nullable()
                .WithColumn("Result").AsString(200).NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                    .ForeignKey("FK_History_UserId", "dbo", "Users", "UserId");
        }
        public override void Down()
        {
        }
    }
}