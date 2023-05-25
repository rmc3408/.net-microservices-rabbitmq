
Install dependencies
Microsoft.EntityFrameworkCore" Version="7.0.5"
Microsoft.EntityFrameworkCore.Design" Version="7.0.5"
Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.5"
Microsoft.EntityFrameworkCore.Tools" Version="7.0.5"


add-migration initCreation -Context Contexto
update-database -Context Contexto