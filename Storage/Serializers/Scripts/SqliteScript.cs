namespace Storage.Serializers.Scripts
{
    internal class SqliteScript
    {
        public const string CREATE_ACTIVITY = 
            @"CREATE TABLE [Activity](
                            [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                            [Date] TEXT NOT NULL, 
                            [Desc] TEXT NOT NULL, 
                            [Days] INTEGER NOT NULL, 
                            [ProjectId] INTEGER NOT NULL REFERENCES Projects([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION, 
                            [UserId] INTEGER NOT NULL REFERENCES Users([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION);";

        public const string CREATE_PROJECT =
            @"CREATE TABLE [Projects] (
                            [Id]	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                            [ProjectType]	INTEGER NOT NULL);";

        public const string CREATE_USERS =
            @"CREATE TABLE [Users] (
	                        [Id]	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	                        [Name]	TEXT NOT NULL);";

        public const string CREATE_DRAFTS =
            @"CREATE TABLE [Drafts](
                            [Id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, 
                            [Desc] TEXT NOT NULL, 
                            [ActivityId] INTEGER NOT NULL REFERENCES Activity([Id]) ON DELETE CASCADE ON UPDATE CASCADE);";
    }
}
