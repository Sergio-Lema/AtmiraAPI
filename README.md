# AtmiraAPI

A. API: 
  1. Objetivo: 
  Exponer un endpoint que reciba un planeta como parámetro y que devuelva un listado en
  formato json con el top 3 de asteroides más grandes con potencial riesgo de impacto en dicho
  planeta en los próximos 7 días. En caso de que no haya 3 o más planetas bajo estas
  condiciones, devolver los que sea que apliquen.

  2.Estructura: 
  Desarrollada en C# bajo Framework Asp NET Core

  3. Packages instalados: 
  Microsoft.AspNet.WebApi.Client (5.2.9).
  
B. TEST
  1. Objetivo: 
  Probar los distintos posibles resultados que podrá devolver la función GetListAsteroid existente en el controlador RootController.
  
  2. Estructura: 
  Framework de pruebas Tests xUnit.
  Utilizados para las asserciones librearía OpenSource, Fluent Assertions.
  
  3. Tipos:
  Dada la carencia de complegidad en los resultados de la función GetListAsteroid, se ha optado por crear hechos (Fact) para realizar los diferentes test. 
  
  4. Mejoras: 
    4.1 Teorías: 
    Se podría barajar la posibilidad unificar los tests GetListAsteroid_ShouldReturnNotFoundObject_IfPlanetNameIsEmpty y GetListAsteroid_ShouldReturnOKObject_IfPlanetNameIsEarth en uno, utilizando los InlineData() como atributos del método.
    
    4.2 Objetos simulados (Mocks): 
    Podríamos crear un fichero json guardado en local con los resultado de la llamada al webservice de la NASA y que fuese procesado por una función GetListAsteroidMock, que a diferencia de la existente, no haría ninguna llamada http sino que trabajaría en local con el archivo json (streams). 
