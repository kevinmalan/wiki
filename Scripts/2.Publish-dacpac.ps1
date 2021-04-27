$SourceFile = "../Wiki.SQL/bin/Debug/Wiki.SQL.dacpac"
$Database = "wikiDb"
$SourceServer = "localhost"
$UserId = "sa"
$Password = 'DevDbP@ssword'

sqlpackage /action:Publish /SourceFile:$SourceFile /TargetConnectionString:"data source=$SourceServer;initial catalog=$Database;User ID=$UserId;Password=$Password"