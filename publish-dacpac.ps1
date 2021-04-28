$SourceFile = "./Wiki.SQL/bin/Debug/Wiki.SQL.dacpac"
$Database = "wikiDb"
$SourceServer = "localhost,5433"
$UserId = "sa"
$Password = "DevDbP@ssword"

# Add Env var if not exists
$path = "C:\Program Files (x86)\Microsoft SQL Server\140\DAC\bin"
if (!(test-path $path))
{
    New-Item -ItemType Directory -Force -Path $path
}


sqlpackage /action:Publish /SourceFile:$SourceFile /TargetConnectionString:"data source=$SourceServer;initial catalog=$Database;User ID=$UserId;Password=$Password"