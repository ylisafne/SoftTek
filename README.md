# Bienvenido al Reto Tecnico SoftTek !

Requerimientos Backend 
- Net Core 6.0
Front End
- npm
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
"UserName":  "gsilverio",
"Password":  "gsilverio"
}
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
