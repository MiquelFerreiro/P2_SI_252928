Cosas extras a parte de las partes 1 y 2:

- Solucionado error donde la colision de oveja salvada triggeaba 2 veces por oveja, 
añadiendo atributo booleano a la clase oveja.
- Errores para Game Over = 5

MODO DIFICIL
- Se activa cuando salvas 10 ovejas. Simula que aparece viento, por lo que los molinos
giran más rápido y las ovejas corren más. 
- Cambio de variables públicas usando [SerializeField]:
	+ speed (Ruedas de Molinos)
	- timeBetweenSpawns (Más Ovejas)
	+ speed, - shootInterval (Jugador más rápido, más cadencia)
	+ Cambios en color de background y luz, anaranjado para sensación de puesta de sol

- También he cambiado la runSpeed de las ovejas al doble, pero no he conseguido acceder
a la variable para cambiar la velocidad con que se inicializan, asi que de manera un poco
chapuza actualizo la velocidad de todas cada frame