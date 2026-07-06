## 1 Proyecto
- Pensar en una proyecto chico, para desarrollarlo usando el patron de dise;o "Onion Architecture" en .Net.
Usar el comando 

``` bash
dotnet new webapi -o NombreDeTuProyecto --use-controllers
``` 


## 2 Estructura
- Crear la estructura basica del Proyecto, usando las linealogias del patron Onion Architecture. Hacerlo simple sin implementar ORM, la persistencia se hara "InMemory"

### Capas del Modelo

 - **Dominio**: Es donde se especifican los modelos de negocio. Osea las clases que representa la logica del "negocio" que estamos desarrollando. Y tambien las interfaces de los repositorios como por ejemplo: IRepositorioCuenta (Create, Read, Update, Delete) 

 - **Aplicacion**: Es donde se definen los servicios para cada una de nuestros endpoints por ejemplo los servicios para Cuentas. y todos los Objetos de transferencia de datos conocidos como Dtos.

 - **Infraestructura**:
    * **Persistencia**:
    * **Presentacion**:


