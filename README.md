

#    -- 📖✏️ incidencias campuslands✏️📖--

Esta api fue desarrollada por motivo de llevar a cabo conocimientos previos y ser ejecutados de manera que el proceso de construccion del mismo sea mas veloz y al mismo tiempo eficiente y correcto. Una practica por el simple hecho de superar las habilidades actuales llevandolas a un nivel superior y presentandolas como proyecto final del mes presente.


#  Acompañamiento para la ejecución del proyecto


#### Como primer paso para probar el proyecto. Es necesario que se reemplacen las credenciales ya existentes por sus credenciales instaladas en su ordenador para efectuar la conexión a la base de datos. Ya sea virtual o local.


## ubicación del archivo en el proyecto


el archivo estara dentro de : InsidenceAPI/appsettings.Development.json

![ubicacion del archivo](/Media/Credenciales.PNG)


### Seguidamente, habiendo reemplazado las credenciales, es hora de generar las migraciones que brevemente nos permitirán poder iniciar nuestro servidor local y poder iniciar la API que es el eje focal del proyecto (en este caso ya tenemos la carpeta de migraciones alojada dentro el proyecto) para poder ejecutar las migraciones usar el siguiente comando




```c#
dotnet ef database update --project ./Persistencia/ --startup-project ./InsidenceAPI/
```






#### Ya habiendo realizado los pasos anteriores, la base de datos debería observarse de la siguiente manera. 




![base de datos](/Media/db%20.png)

#### En caso de que base de datos no se pueda visualizar en su entorno, cabe resaltar que necesita tener en su sistema la librería de herramientas de .net-ef la cual se instala con el siguiente comando (asegúrese de salir del proyecto y ejecutarlo de manera global en su ordenador)


```c#
dotnet tool install --global dotnet-ef
```

En caso de tener una versión anterior de la misma. Por favor realizar la respectiva actualización haciendo uso del siguiente comando:


```c#
dotnet tool update --global dotnet-ef
```

## Realizar peticiones a la api

Una vez iniciado el servidor se puede testear la api con los 4 metodos (get, post, update, delete) el endpoint se encontrara en /InsidenceAPI/Controllers en el archivo BaseApiController.cs


![ubicacion endpoint](/Media/EndpointUBC.PNG)



### luego puede ejecutar todas las acciones con un limite de 2 peticiones cada 10 segundos esto debido al rate limiter que fue configurado e instalado en las dependencias del proyecto


##### ejemplo peticion 

luego de todo lo anterior visto es libre de ya sea consumir la api desde otro proyecto o realizar peticiones como la siguiente


![peticion muestra](/Media/peticionNrm.PNG)

en este ejemplo se resalta que los endpoints tiene inyeccion y flujo de data completamente funcional y logica. Debido a los dto configurados dentro del proyecto permitiendo que nuestra DATA tenga un flujo coherente y limpio añadiendo versionado de apis que nos facilitan el proceso

#### acontinuacion un ejemplo (endpoint con dto + version api 1.1 )


![peticion muestra](/Media/Peticion.PNG)



## uso de Jwt en el proyecto

jwt tiene un papel vital en el proyecto por lo tanto es necesario para mantener los enstandares de seguridad informatica que se nos son solicidatos a la hora de crear un backend. Acontinuacion se le mostrara un ejemplo de creacion.

#### creacion usuario

podemos crear un usuario mandando un cuerpo con los respectivos campos requeridos.

![crear](/Media/creacionusuario.PNG)


no solo es enviar la peticion sino tambien saber el transfondo que esta genera. Sabremos que la informacion se inserto en la base de datos si en la terminal de VSC se visualiza la siguiente sentencia.

![comando terminal](/Media/consolacreacionusuario.PNG)

seguidamente nuestra base de datos deberia verse de la siguiente manera con el nuevo usuario


![comando terminal](/Media/admintablamjr.PNG)

donde podemos observar la encriptacion de nuestra contraseña.


#### añadir rol al usuario

cuando tengamos creado el usuario podemos asignarle un rol respectivo que este en nuestra base de datos y desde luego en nuestro backend

![peticion muestra](/Media/rolesusuario.PNG)


y consecutivamente se podra observar la relacion en nuestra tabla intermedia de nuestra base de datos

![tabla intermedia](/Media/relacion%20rol.PNG)

# Creacion jwt en el proyecto

El proyecto cuenta con que al momento de ser registrado se genera un token de seguridad 
para  que el usuario tenga un registro unico.

![creacion jwt](/Media/relacion%20rol.PNG)


## autorizacion por usuario

es muy importante identificar el rol que nuestro usuario desempeña en la compañia. Por lo tanto debemos generar una autorizacion por rol y dependiendo del rol se verifique y restringir las acciones a determinados usuarios por medio de su rol.

## gerente vs camper

veremos como el gerente tiene permisos que a diferencia del rol camper. No se le pueden conceder



## gerente 

![creacion jwt](/Media/creacion+token.png)


veremos como puede realizar las peticiones sin ningun tipo de problema

## camper

![creacion jwt](/Media/tokennopermitido+creacion.png)

en este caso el camper no tiene permitido realizar esta peticion por lo tanto la solicitud se cancela e invalida.


Cabe aclarar que el proyecto no está 100% culminado. Estar atento a esta documentación que será paulatinamente actualizada faltando añadir autenticaciones y encriptamiento de validaciones para mayor proteccion del mismo🤗.



## Tecnologias Usadas

<div align="center">
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/mysql/mysql-original.svg" height="40" alt="mysql logo"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dotnetcore/dotnetcore-original.svg" height="40" alt="dotnetcore logo"  />
  <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/csharp/csharp-original.svg" height="40" alt="csharp logo"  />
   <img width="12" />
  <img src="https://cdn.jsdelivr.net/gh/devicons/devicon/icons/dot-net/dot-net-original.svg" height="40" alt="dot-net logo"  />

###
</div>


## Soporte

para soporte y consultar adicionales, email angelgabrielorteg@gmail.com o enviame solicitud por discord🥰!

## Authors

- [@Angel-ISO](https://www.github.com/Angel-ISO)


