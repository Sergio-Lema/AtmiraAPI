# AtmiraAPI

A. API: 
  - Objetivo: Exponer un endpoint que reciba un planeta como parámetro y que devuelva un listado en formato json con el top 3 de asteroides más grandes con potencial riesgo de impacto en dicho planeta en los próximos 7 días. En caso de que no haya 3 o más planetas bajo estas condiciones, devolver los que sea que apliquen.

  - Estructura: Desarrollada en C# bajo Framework Asp NET Core

  - Packages instalados: Microsoft.AspNet.WebApi.Client (5.2.9).
  
B. TEST
  - Objetivo: Probar los distintos posibles resultados que podrá devolver la función GetListAsteroid existente en el controlador RootController.
  
  - Estructura: Framework de pruebas Tests xUnit. Utilizados para las asserciones librería OpenSource, Fluent Assertions.
  
  - Tipos: Dada la carencia de complegidad en los resultados de la función GetListAsteroid, se ha optado por crear hechos (Fact) para realizar los diferentes test. 
  
  - Mejoras:
    a. Teorías: Se podría barajar la posibilidad unificar los tests GetListAsteroid_ShouldReturnNotFoundObject_IfPlanetNameIsEmpty y  GetListAsteroid_ShouldReturnOKObject_IfPlanetNameIsEarth en uno, utilizando los InlineData() como atributos del método.
    
    b. Objetos simulados (Mocks): Podríamos crear un fichero json guardado en local con los resultado de la llamada al webservice de la NASA. 
    Y que posteriormente fuese procesado por una función GetListAsteroidMock, que a diferencia de la existente, no habría ninguna llamada http sino que trabajaría en local con el archivo json (streams). 
