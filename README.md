# Bienvenido al Reto Tecnico SoftTek !

Para este reto considere una tienda de autos, los vendedores pueden hacer descuentos siempre y cuando estén dentro del margen permitido, se acepta un descuento mayor al margen pero este tiene que ser autorizado por un Jefe.

Archivos Backend  [SoftTek-Reto](./SoftTek-Reto) 
- Realizado con Visual Studio 
- Net Core 6.0

Archivos Front End [SoftTek-Front](./SoftTek-Front)
- Realizado con Visual Studio Code
- Requiere instalar dependencias (npm install)
-------------------------------
### Correr API en Docker 

Clonamos la Imagen
```
docker pull ylisafne/softtekreto
```
Para Correr (exponemos el puerto 8010)
```
docker run -p 8010:80 -d ylisafne/softtekreto
```

## Uso de las API
- Primero debe ejecutar el endpoint "/login" con el siguiente JSON
```

{
"UserName":  "string",
"Password":  "string"
}
Usuarios Permitidos
|Usuario | password|rol|
|agonzales|agonzales|Vendedor|
|eperez|eperez|Vendedor|
|gsilverio|gsilverio|Administrador|
|aquezada|aquezada|Vendedor|
|mespinoza|mespinoza|Vendedor|


```
- Obtendremos por resultado  la siguiente estructura  donde "result" es el token a usar en las demas EndPoints
```
{
"success":  true,
"message":  "",
"result":  ""
}
```
- Agregar a la Cabecera la Authorization JWT Bearer con la cadena de result
