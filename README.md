# Roll a Ball

## Descripción
"Roll a Ball" es un juego en Unity donde el jugador controla una esfera y debe recolectar objetos mientras evita enemigos. El juego incluye múltiples niveles y diferentes perspectivas de cámara.

## Instalación y Configuración
1. Abre Unity y carga el proyecto.
2. Asegúrate de que todos los scripts están en la carpeta `Assets/Scripts`.
3. Asigna los scripts a los objetos correspondientes en la escena.
4. Configura las cámaras y el sistema de navegación del enemigo.
5. Ejecuta el juego y disfruta.

## Scripts y Funcionalidad
### 1. **PlayerController.cs**
   - Controla el movimiento del jugador.
   - Permite el salto y la aceleración.
   - Gestiona la interacción con pickups, niveles y enemigos.
   - Controla las cámaras activas según el nivel.
   - Función especial `ApplyKnockback()`, aplicada cuando el jugador choca con un enemigo.

### 2. **enemyController.cs**
   - Utiliza `NavMeshAgent` para perseguir al jugador.
   - Detecta colisiones con el jugador y aplica `knockback`.

### 3. **Rotator.cs**
   - Se usa para rotar objetos (como pickups) en los ejes X, Y y Z.

### 4. **CameraController1st.cs**
   - Maneja la cámara en primera persona.
   - Permite al jugador rotar la cámara con las teclas del teclado numérico.

### 5. **cameraLevel3.cs**
   - Mantiene una cámara fija con una distancia predefinida respecto al jugador.

### 6. **camera.cs**
   - Similar a `cameraLevel3.cs`, sigue al jugador con un offset constante.

## Controles del Juego
- **Movimiento:** Teclas de dirección o wasd
- **Salto:** `Espacio`.
- **Cambio de cámara:** `F` (Solo en niveles aplicables).
- **Rotación de cámara:** `Teclado numérico (4, 6, 8, 2)` (Solo en modo primera persona).

## Objetivos del Juego
- Recoge todos los pickups para ganar.
- Evita a los enemigos y obstáculos.
- Completa los niveles y alcanza la meta final.


