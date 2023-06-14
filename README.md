# IBProgramAvanzada_Final
 Repo del final de la materia "Programación Avanzada". Grupo: Pablo Chehade, Andrés Dosil, Zoe Prieto



## Módulos a implementar

### Dinámica de la bolita: Zoe
- [ ] Creación de la bolita: su estado está definido por (x,y,vx,vy)
- [ ] Movimiento de la bolita (Dado por una función que integre su posición usando Euler Explícito y considerando velocidad constante)

### Dinámica de los bloques: Zoe
- [ ] Creación de los bloques
- [ ] Los bloques se representan como una lista de tuplas de pares (x,y) de la esquina inferior. Tienen ancho y altura consta e igual a 1 (por simplicidad)

### Paleta (barrita): Pablo
- [x] Creación de la barrita. Está representada por la posición (x,y) de la esquina inferior. Ancho 3 y altura 1 (por simplicidad)
- [ ] Investigar cómo es la interactividad barrita-usuario en F# (¿Cómo se lee el teclado?)
- [ ] 

### Interacciones: Pablo
- [x] Colisión de la bolita con los bordes de la pantalla (Rebote tipo 1)
- [ ] Colisión de la bolita con los bordes de los bloques (Rebote tipo 2)
- [x] Colisión de la bolita con la paleta (Rebote tipo 3)
- [x] Colisión de la bolita con la pared inferior (perdiste)
- [ ] Si se eliminaron todos los bloques, se gana el juego

### Interfaz gráfica: Andrés
Léase, printfn complejo
- [ ] Determinar cómo dibujar la bolita dado su estado
- [ ] Determinar cómo dibujar los bloques dado su estado
- [ ] Determinar cómo dibujar la paleta dado su estado
- [ ] Definir la tasa de refresco, ej 0.5 s. Investigar cómo hacerlo en F# (¿Cómo se hace un sleep?)

### Evolución
- [ ] Se integra todo lo anterior en un único loop

### Extras
- [ ] Poder cambiar la velocidad de la bolita
- [ ] Definir distintos tipos de bloques
- [ ] Graficar puntaje
- [ ] Si perdés, que salte un aviso "Game Over"
- [ ] Si ganás, que salte un aviso "Ganaste"
- [ ] Unit tests de cada función





