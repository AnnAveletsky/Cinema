using FluentMigrator;

namespace Cinema.Migrations.DefaultDB
{
    [Migration(20161030130000)]
    public class DefaultDB_20161030_130000_HistoryLog : AutoReversingMigration
    {
        public override void Up()
        {
            this.CreateTableWithId64("Histories", "Id", s => s
                .WithColumn("GUID").AsGuid().NotNullable()
                .WithColumn("ApplicationName").AsString(50).NotNullable()
                .WithColumn("Type").AsString(100).NotNullable()
                .WithColumn("Url").AsString(500).Nullable()
                .WithColumn("HTTPMethod").AsString(10).Nullable()
                .WithColumn("IPAddress").AsString(40).Nullable()
                .WithColumn("Source").AsString(100).Nullable()
                .WithColumn("Message").AsString(1000).Nullable()
                .WithColumn("StatusCode").AsInt32().Nullable()
                .WithColumn("Username").AsString(100).NotNullable()
                .WithColumn("CreationDate").AsDateTime().NotNullable());
        }
    }
}