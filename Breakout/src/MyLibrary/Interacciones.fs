namespace Interacciones

open Bolita
open Bloques
open Barrita
open Pared

module Interacciones =
    let Interaccion_pared (paredes:Pared.Paredes) (bolita:bolita.Bolita) =
        match bolita with
        | bolita when bolita.x <= paredes.Left_x -> {bolita with vx = -bolita.vx}
        | bolita when bolita.x >= paredes.Right_x -> {bolita with vx = -bolita.vx}
        | bolita when bolita.y >= paredes.Up_y -> {bolita with vy = -bolita.vy}
        | bolita when bolita.y <= paredes.Down_y -> bolita
        | _ -> bolita

    let Interaccion_barra (barra:Barrita.Barra) (bolita:bolita.Bolita) =
        if bolita.y <= barra.y && bolita.x >= barra.x && bolita.x <= barra.x + barra.L then
            {bolita with vy = -bolita.vy}
        else 
            bolita

    

    // verifica que las coordenadas de la bolita esten dentro de la región donde existen bloques
    let validarCoordenadas (x: float) (y: float): bool =
        x >= 0.0 && x < 700.0 && y >= Bloques.yInicial && y < Bloques.yFinal

    // A partir de las coordenadas (x,y) de la bolita, devuelve los indices del unico bloque con el cual la bolita podria colisionar
    let obtenerIdxBloque (x: float) (y: float): int*int =
        let indiceFila = int ((y - Bloques.yInicial) / Bloques.LY)
        let indiceColumna = int (x / Bloques.LX)
        (indiceFila, indiceColumna)

    // verifica si hay un bloque activo en las coordenadas (x,y)
    let hayBloque (x: float) (y: float) (bloques: Bloques.Bloques) : bool =
        match validarCoordenadas x y with
        | false -> false
        | true ->
            let (indiceFila, indiceColumna) = obtenerIdxBloque x y
            let estado = bloques.Estado |> Map.find (indiceFila, indiceColumna)
            estado
    
    type Choque_con_bloque = 
        | Vertical
        | Horizontal


    let Tipo_choque (bolita:bolita.Bolita) (fila: int) (columna: int) =
        let bloque_x, bloque_y = Bloques.obtenerCoordenadas fila columna
        let distancias_a_bloque = [bolita.y - bloque_y; bloque_y + Bloques.LY - bolita.y; bolita.x - bloque_x; bloque_x + Bloques.LX - bolita.x]
        let minimo = List.min distancias_a_bloque
        if minimo = bolita.y - bloque_y || minimo = bloque_y + Bloques.LY - bolita.y then
            Vertical
        else
            Horizontal
            
    let Interaccion_bloques (estado_bloques: Bloques.Bloques) (bolita: bolita.Bolita) =
        match hayBloque bolita.x bolita.y estado_bloques with
        | false -> 
            (bolita, estado_bloques)
        | true ->
            let fila, columna = obtenerIdxBloque bolita.x bolita.y
            let nuevosBloques = Bloques.desactivarBloque fila columna estado_bloques
            let tipo_choque = Tipo_choque bolita fila columna
            match tipo_choque with
            | Vertical -> ({ bolita with vy = -bolita.vy }, nuevosBloques)
            | Horizontal -> ({ bolita with vx = -bolita.vx }, nuevosBloques)

    //End

    let Bolita_escapa (bolita:bolita.Bolita) (pared:Pared.Paredes) : bool = 
        bolita.y <= pared.Down_y

    let no_hay_bloques (bloques: Bloques.Bloques): bool =
        let lista = bloques.Estado |> Map.values
        List.forall (fun x -> x = false) lista

    // let termina_juego (bolita:bolita.Bolita) (pared:Pared.Paredes) (bloques: Bloques.Bloques) :bool =
    //     Bolita_escapa bolita pared || no_hay_bloques bloques
