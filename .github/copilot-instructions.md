# Copilot Instructions - Hotelia

## Contexto del proyecto
Este repositorio implementa una API para administración y reserva de hoteles.

El dominio principal está dividido en:
- Hotels: administración de hoteles y habitaciones
- Bookings: búsqueda de disponibilidad y reservas
- Shared: utilidades comunes, resultados, validaciones, excepciones, fechas

## Stack esperado
- C#
- ASP.NET Core Web API
- Clean Architecture
- DDD ligero
- CQRS por casos de uso
- Pruebas unitarias e integración

## Reglas de arquitectura
- Domain no depende de ninguna otra capa.
- Application depende solo de Domain.
- Infrastructure implementa contratos de Application y usa persistencia/servicios externos.
- Api solo orquesta HTTP, DI, middleware y composición.
- No mezclar reglas de negocio con controllers.
- No exponer entidades de dominio directamente en respuestas HTTP.

## Convenciones
- Cada caso de uso debe vivir en su propio vertical slice.
- Nombres claros y explícitos.
- Evitar métodos enormes.
- Preferir objetos inmutables cuando sea razonable.
- Validar comandos/requests antes de ejecutar lógica de negocio.
- No usar comentarios obvios; el código debe ser claro por sí mismo.
- Mantener cambios pequeños y enfocados.

## Estándar de endpoints
- Controllers delgados.
- Request/Response DTOs claros.
- Respuestas consistentes.
- No romper contratos públicos sin avisar.
- Si hay error de validación, devolver respuesta semánticamente correcta.
- Si hay reglas de negocio incumplidas, devolver error controlado.

## Reglas de dominio
- No permitir reservas sobre habitaciones deshabilitadas.
- No permitir reservas en hoteles deshabilitados.
- No permitir solapamiento de reservas para la misma habitación.
- La búsqueda de habitaciones depende de ciudad, fechas y cantidad de personas.
- La reserva debe incluir huéspedes y contacto de emergencia.

## Calidad mínima antes de cerrar una tarea
Siempre:
1. compilar
2. revisar warnings importantes
3. ejecutar pruebas relevantes
4. explicar riesgos o supuestos
5. listar archivos modificados

## Qué no hacer
- No agregar dependencias innecesarias.
- No meter lógica de negocio en Program.cs.
- No modificar varias capas sin justificar el impacto.
- No improvisar contratos sin antes revisar el dominio y el caso de uso.

# Copilot Instructions - Hotelia

## Contexto del proyecto
Este repositorio implementa una API backend en C# con ASP.NET Core.

La solución debe seguir:
- Clean Architecture
- DDD ligero
- CQRS por casos de uso
- Clean Code
- vertical slices por feature

## Reglas de arquitectura
- Domain no depende de ninguna otra capa.
- Application depende solo de Domain.
- Infrastructure implementa contratos de Application y resuelve persistencia y servicios externos.
- Api solo expone endpoints, configura DI y maneja concerns HTTP.
- No colocar lógica de negocio en controllers.
- No exponer entidades de dominio directamente en respuestas HTTP.
- Cada caso de uso debe estar separado en su propio vertical slice.

## Convenciones generales de C#
- Escribir código claro, explícito y consistente.
- Priorizar legibilidad sobre compacidad.
- Evitar métodos largos.
- Evitar clases con múltiples responsabilidades.
- Evitar comentarios obvios.
- No agregar dependencias innecesarias.
- No inventar abstracciones si no aportan valor real.

## Estilo de código C#
### Firmas de métodos y parámetros
- Cuando un método tenga varios parámetros, atributos como `[FromBody]`, o la firma pierda legibilidad en una sola línea, usar formato multilínea.
- Preferir este formato:

  ```csharp
  public async Task<ActionResult<CreateHotelResponse>> CreateHotel([FromBody] CreateHotelRequest request,
                                                                   CancellationToken cancellationToken)
  {
  }