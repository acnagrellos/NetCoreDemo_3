1. Crea un proyecto .Net Core con la plantilla de vacío que se llame ApiStructure, dentro de una solución SLN llamada MyProject
2. Cambia el puerto del perfil ApiStructure al 9449. Ejécuta la solución con ese perfil.
3. Ataca a tu API con la url: https://localhost:9449/. ¿Que te devuelve? (usa postman)
5. Añade en el appsettings.json un parametro "ProjectSettings" y dentro de este otro con "ProjectName" cuyo valor será "ApiStructure". Saca ese valor en las requests como "Hello {nombredelproyecto}".
6. Añade un fichero appsettings.staging.json donde el nombre del proyecto sea ApiStructureStaging. Ejecuta el proyecto en modo Staging y comprueba que ese es el nombre que usa ahora.
7. Añade una clase a tu proyecto que se llame, Contact que tendrá tres propiedades: Id (int), Name (string), TelephoneNumber (string). Crea una lista dentro del proyecto de contactos y añade a tu API los endpoints de:
* Obtener todos los contactos.
* Obtener un contacto pasando el Id
* Actualizar un contacto pasando el Id
* Crear un Nuevo Contacto
* Borrar un contacto pasando un Id
* Buscar un contacto pasando un patrón por el que buscar (por ejemplo si pasas "Ang" se buscarán todos los contactos que contengan en su nombre la cadena "ang")
8. Crea para tu API anterior un fichero json con Postman con todas las peticiones de tu API.
