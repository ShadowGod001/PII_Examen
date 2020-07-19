![UCU](https://github.com/ucudal/PII_Conceptos_De_POO/raw/master/Assets/logo-ucu.png)

### FIT - Universidad Católica del Uruguay

<br>

# Examen Extraordinario - Julio 2020.1

![Banner](https://azure.wgp-cdn.co.uk/app-table-top-gaming/posts/all-72050.jpg?&width=1200&height=630&mode=crop)

«La ruta de _Tokaido_, que data del siglo XI, conecta las dos cuidades más importantes de Japón: Edo (hoy llamada Tokio) y Kyoto. [...] Tiene 500km de largo y sigue la costa sur de la isla más grande del archipiélago Japonés: Honshu.»

_Tokaido_ es, además de una ruta en Japón, un juego de mesa muy popular creado por Antoine Bauza. En el juego, viajeros de distintos orígenes atravisan el camino de Edo a Kyoto participando de diversas experiencias en el afán de enriqueser su viaje lo más posible.

## Desafío

El desafío de este ejercicio es modelar una versión simplificada del juego _Tokaido_ en C# aplicando los principios y patrones vistos en el curso y presentados en la bibliografía.

### Objetivo del juego original

El objetivo del juego es realizar la mayor cantidad de experiencias posibles, consiguiendo así la mayor cantidad de puntos. El juego termina cuando todos los viajeros se encuentran en la última experiencia. El viajero con más puntos es el ganador.

### Viajeros

Los viajeros son los personajes del juego, que recorrerán el camino deteniendose en las distintas experiencias.

Cada viajero acumula _puntos_ y _monedas_. Al final del juego, el viajero con más puntos es el ganador.

### El camino

_Tokaido_ presenta a lo largo de su recorrido diferentes "estaciones" que permiten realizar experiencias diversas. Cada experiencia le dará al viajero que la realice una determinada cantidad de puntos que se irán acumulando hasta el final del juego. 

Los viajeros siempre deben moverse hacia adelante en el camino. Es decir, no se pueden visitar experiencias que estén _antes_ de la posición actual del viajero.

A continuación se presentan las experiencias (en versión simplificada) que un viajero puede realizar en _Tokaido_.

#### Granja

Un viajero puede visitar una granja, donde trabajará y obtendrá 3 monedas.

#### Aguas termales

Un viajero puede detenerse en una estación de aguas termales para obtener 2 puntos.

#### Paisajes

Existen 2 tipos de paisajes que un viajero puede visitar: montaña y océano. Cuando un viajero visita un paisaje de tipo montaña, el viajero obtiene 1 punto. La siguiente vez que visita un paisaje de Motaña, el viajero obtendrá 2 puntos. Cada vez que visite un nuevo paisaje de montaña obtendrá 1 punto más que la vez anterior. 

Por ejemplo, si un viajero visita 4 paisajes de montaña obtendrá 10 puntos (1 + 2 + 3 + 4).

Con los océanos ocurre algo similar, sólo que los puntos ascienden de 2 en 2. Si un viajero visita 3 paisajes de océano, obtendrá 9 puntos (1 + 3 + 5).

### Disponibilidad

Cada experiencia tiene una cantidad máxima de viajeros que pueden visitarlas. Por ejemplo, un sitio de aguas termales podría tener una restricción de 2 viajeros como máximo. Si 2 viajeros estan presentes en dicho sitio, no es posible que otro viajero realice dicha experiencia.

## Referencia gráfica

La siguiente imágen ilustra la versión simplificada del juego descrito.

![Referencia](./Reference.png)

## Extensibilidad

Se ha presentado una versión simplificada del juego. En el futuro, debe ser posible incorportar los elementos restantes que han sido dejados fuera del alcance. Se destaca en particular nuevos sitios (con formulas de puntos y monedas diferentes) y viajeros que obtienen puntos o monedas extras por visitar determinados lugares (bonos).

# Entregables

## Parte 1: Diagrama de clases

Construír el diagrama de clases que permita representar los objetos del modelo del juego descrito.

## Parte 2: Proyecto C# del modelo del juego

Construir en un proyecto de C# el modelo del juego diagramado en la parte anterior. Debe implementarse la lógica que permita corroborar que el modelo se comporta acorde a las reglas del juego descritas.

**No es necesario implementar un juego funcional, jugable por consola u otra interfaz de usuario.**. 

Sí es necesario representar todos los elementos del juego con sus restricciones y lógica de puntos, monedas, movimiento, condición de finalización y cálculo del ganador.

**Tampoco es necesario implementar un proyecto Program que simule el juego**.

Recuerda justificar mediante comentarios en el código los principios y patrones que utilizas y las desiciones de diseño que has tomado durante el proceso.

## Parte 3: Pruebas del modelo

Construír un proyecto de test que permite verificar que el modelo implementado cumple con las reglas del juego descritas.

## Entrega

La entrega se hará por WebAsignatura en la siguiente tarea: https://webasignatura.ucu.edu.uy/mod/assign/view.php?id=261785.

Fecha límite: Domingo 19 de Julio a las 23:59. No se aceptarán entregas fuera de fecha.

Se deberá entrega un link a un repositorio con la solución, incluyendo todos los entregables mencionados. El repositorio debe tener acceso público.

## Defensa

Se tomará una defensa oral de las entregas el día 20 de Julio a las 18.00 por el canal de Zoom de la asignatura.
