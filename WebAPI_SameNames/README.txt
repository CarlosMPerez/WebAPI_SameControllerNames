*********************************************************************************************************
*                                      WebAPI_SameNames                                                 *
*********************************************************************************************************
* Prueba de concepto para poder usar controladores y modelos con los mismos nombres, permitiendo que    * 
* la documentación autogenerada y el routing de WebAPI los pueda usar sin colisiones gracias a los      *
* namespaces diferentes.                                                                                *
*********************************************************************************************************
*                                        10-2017 CMPF                                                   * 
*********************************************************************************************************

Aplicación creada para demostrar la posibilidad de utilizar nombres repetidos en Controllers y Models
y aún así poder seguir viendo documentación completa de los mismos en una librería WebAPI (y poder
llamarlos y usarlos, por supuesto)

Se han seguido los siguientes pasos:

1) Creación de una aplicación WebAPI estándar, sin autenticación.
2) Creación de carpetas Internal y External dentro de Controllers. (Internal y External no significa nada 
en este contexto, es simplemente para distinguir los controllers)
3) Creación de controladores SaludoController en ambas carpetas. Son casi idénticos (reciben un modelo
de entrada y devuelven un modelo de salida) excepto en su ubicación y el NAMESPACE.
4) Creación de carpetas Internal y External dentro de Models.
5) Creación de los modelos de entrada y salida para Internal y External. Igual que con los controladores
son iguales entre sí y sólo difieren en los textos devueltos y los namespaces. 
5a) Si en este paso ejecutamos el proyecto e intentamos acceder a la documentación online de la API,
veremos que nuestros controladores y nuestros métodos no aparecen, sencillamente. Esto es así porque 
ahora mismo existe un conflicto de nombres. 
6) Añadida clase privada NamespaceHttpControllerSelector a WebApiConfig.cs. Ésta es la clase que nos 
permitirá usar mismos nombres de controladores y modelos, ya que hacemos que reemplace al selector de 
controladores por defecto. 
7) En WebApiConfig.cs, cambiado el routing habitual por "{namespace}/{controller}/{id}"
8) En WebApiConfig.cs, añadida la línea 
					            config.Services.Replace(typeof(IHttpControllerSelector), 
									new NamespaceHttpControllerSelector(config));
para reemplazar el selector de controllers estándar por el nuestro customizado.
9) En este paso ya podemos ejecutar la aplicación y ver la documentación de nuestros controladores y 
métodos. Sin embargo, si entramos al detalle de cualquiera de los métodos tendremos un error porque 
aún hay un conflicto de nombres con los modelos. Podríamos resolverlo añadiendo un atributo [ModelName("")]
a cada modelo, pero hay una solución más elegante.
10) Modificamos Areas\HelpPage\ModelNameHelper.cs y cambiamos cada referencia al atributo "Name" 
de los objetos type y genericType por "FullName" para que tenga en cuenta los namespaces y 
eliminar conflictos. 
11) Los mismo para el fichero Areas\HelpPage\SampleGeneration\HelpPageSampleGenerator. Hacemos el 
mismo cambio para los objetos formatter y type, en el método WriteSampleObjectUsingFormatter.
12) Cambiamos el HelpPageConfig.cs para descomentar la línea config.SetDocumentationProvider...
Además, cambiamos el nombre y ruta del fichero XML de documentación por el adecuado. NOTA: tenemos 
que asegurarnos que nuestro proyecto genera documentación XML en las propiedades, solapa Compilar, 
Salida, Documentación XML
12a) La documentación online funciona. Vamos a probar que los controllers funcionan llamando 
a las APIs mediante js.
13) Añadido /Scripts/app/home.js para hacer llamadas a APIs.