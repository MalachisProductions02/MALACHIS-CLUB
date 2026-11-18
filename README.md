## CLUB DE DESARROLLO DE VIDEOJUEGOS

En este repositorio encontrarán todo lo relacionado con código respecto a los temas que estaremos viendo o trabajando.

![miku](https://cdn.phototourl.com/anon/2026-11-17-18893c1c-2f17-4325-9326-e76a160133b2.jpg)

---

### 18 DE NOVIEMBRE DEL 2026

Se estará trabajando en lo siguiente:

- Interfaz de Unity
- Primer código en C#
- Implementación del código para manipulación de objetos

Además que se estará trabajando por equipos en su primer plataformero 2D para conocer un poco más a profundidad este motor gráfico.

Se proporcionarán los siguientes materiales:

- Assets listos para implementar
- Tilemaps listos para implementar
- Código prefabricado listo para instalar

---

En **PlayerMovement.cs** podrán ver un código básico de movimiento 2D listo para usar, requerirán configurar el _InputSystem_ como se indicó en la sesión o como se muestra en el video, debido a que el script utiliza esa misma librería.
Deberán asignar en **Animator** lso siguiente sparámetros escritos tal cual como aparecen enlistados:

- speed: flaot con valor inicial a 0
- isGrounded: booleano

El Player deberá contar con un hijo **GameObject empty** colocado sobre sus pies llamado **groundCheck** para detectar que está en el suelo y el salto pueda ejecutarse.
