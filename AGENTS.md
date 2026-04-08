# AGENTS.md

## Misión del repositorio
Construir una API backend para administrar hoteles y habitaciones, buscar disponibilidad y registrar reservas.

## Módulos principales
- Hotels
- Bookings
- Shared

## Prioridad funcional
Orden sugerido de implementación:
1. CreateHotel
2. AddRoomToHotel
3. UpdateHotel
4. UpdateRoom
5. EnableDisableHotel
6. EnableDisableRoom
7. SearchAvailableRooms
8. CreateReservation
9. ListReservations
10. GetReservationDetail
11. EmailNotification

## Reglas para agentes
Antes de escribir código:
- entender el objetivo
- identificar capa y módulo afectados
- proponer plan corto
- listar archivos a tocar

Al escribir código:
- mantener cambios pequeños
- respetar Clean Architecture
- no mover reglas de negocio fuera del dominio o aplicación
- preferir vertical slices por caso de uso

Antes de terminar:
- compilar
- validar nombres
- verificar contratos
- proponer pruebas faltantes
- reportar riesgos

## Contexto de negocio
Hotel:
- puede estar habilitado o deshabilitado
- contiene habitaciones

Room:
- pertenece a un hotel
- tiene costo base, impuestos, tipo, ubicación, capacidad y estado

Reservation:
- pertenece a una habitación
- tiene rango de fechas
- incluye huéspedes
- incluye contacto de emergencia

## Filosofía
Primero claridad.
Luego consistencia.
Luego automatización.