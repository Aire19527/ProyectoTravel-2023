# ProyectoTravel-2023
Proyecto para enseñar a programar
"ConnectionStrings": {
    "ConnectionStringSQLServer": "Server=.;Database=BdGAS;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  
  
#region Context SQL 
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlServer(this.Configuration.GetConnectionString("ConnectionStringSQLServer"));
            });
#endregion
  
** Pluguins a Instalar en los Proyectos ** 
  
1. App
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools 

3. Infraestructure
- Microsoft.EntityFrameworkCore.Relational
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer


** comandos codeFirts **

- add-migration  _mensaje_
- update-databse
