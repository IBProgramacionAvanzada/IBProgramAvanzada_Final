namespace Bloques

module Bloques =

    // anchura de cada bloque: 700/14 = 50, los 14 bloques ocupan todo el ancho de la arena
    let LX = 50.0
    // altura de cada bloque: (1200/8)/6 = 25, los 8 bloques ocupan una sexta parte de la altura de la arena
    let LY = 25.0
    let anchoArena = 700.0
    // los bloques estan entre la altura 800 y la altura 1000; limite inferior inclusivo, limite superior exclusivo [800, 1000)
    let yInicial = 800.0
    let yFinal = 1000.0

    type Bloques =
        {
            Estado: Map<int*int, bool>
        }
    // se almacena el estado de los bloques en un mapa cuyas claves son los indices (fila, columna) de cada bloque
    // y cuyos valores son un booleano que indica si el bloque esta activo o no
    let inicializarBloques (filas: int) (columnas: int) : Bloques =
        let indices = [for x in 0 .. filas - 1 do for y in 0 .. columnas - 1 -> (x, y)]
        let estado = indices |> List.map (fun (x, y) -> ((x, y), true)) |> Map.ofList
        { Estado = estado }

    // obtiene las coordenadas de la esquina inferior izquierda del bloque a partir de sus indices
    let obtenerCoordenadas (fila: int) (columna: int): float*float =
        let x = (float columna) * LX
        let y = yInicial + (float fila) * LY
        (x, y)

    // cambia el estado de un bloque a false
    let desactivarBloque (fila: int) (columna: int) (bloques: Bloques) : Bloques=
        let nuevoEstado = bloques.Estado |> Map.add (fila, columna) false
        { bloques with Estado = nuevoEstado}

    let condicion_inicial_bloques = inicializarBloques 8 14

