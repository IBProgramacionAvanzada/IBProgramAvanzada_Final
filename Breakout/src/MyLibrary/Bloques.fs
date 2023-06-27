namespace Bloques

module Bloques =
    type Bloque = 
        {
            x: float // Posición x de esquina inferior izquierda
            y: float // Posición y de esquina inferior izquierda
            Lx: float
            Ly: float
        }


    let condicion_inicial_bloques =
        let bloque:Bloque = {
            x = 0.
            y = 0.
            Lx = 10.
            Ly = 10.
        }
        [bloque;bloque] 

    let eliminar_bloque (bloques:Bloque list) (bloque:Bloque) =
        bloques
