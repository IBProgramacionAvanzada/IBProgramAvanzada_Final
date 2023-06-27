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

    type Bloque_eliminado =
        | Eliminado of Bloques.Bloque
        | NoEliminado

    type Choque_con_bloque = 
        | Vertical
        | Horizontal

    let choca_bloque (bolita:bolita.Bolita)  (bloque:Bloques.Bloque) = 
        bolita.y <= bloque.y + bloque.Ly && bolita.y >= bloque.y && bolita.x >= bloque.x && bolita.x <= bloque.x + bloque.Lx

    let Tipo_choque (bolita:bolita.Bolita) (bloque:Bloques.Bloque) =
        let distancias_a_bloque = [bolita.y - bloque.y; bloque.y + bloque.Ly - bolita.y; bolita.x - bloque.x; bloque.x + bloque.Lx - bolita.x]
        let minimo = List.min distancias_a_bloque
        if minimo = bolita.y - bloque.y || minimo = bloque.y + bloque.Ly - bolita.y then
            Vertical
        else
            Horizontal
            
    let Interaccion_bloques (bloques: Bloques.Bloque List) (bolita: bolita.Bolita) =

        let rec Iteracion_sobre_bloques (bloques: Bloques.Bloque List) (bolita: bolita.Bolita) =
            match bloques with
            | [] -> (bolita, Bloque_eliminado.NoEliminado)
            | bloque::bloques -> 
                if choca_bloque bolita bloque then
                    let tipo_choque = Tipo_choque bolita bloque
                    match tipo_choque with
                        | Vertical -> ({bolita with vy = -bolita.vy}, Bloque_eliminado.Eliminado bloque)
                        | Horizontal -> ({bolita with vx = -bolita.vx}, Bloque_eliminado.Eliminado bloque)
                else
                    Iteracion_sobre_bloques bloques bolita

        Iteracion_sobre_bloques bloques bolita

    //End

    let Bolita_escapa (bolita:bolita.Bolita) (pared:Pared.Paredes) : bool = 
        bolita.y < pared.Down_y

    let Bloques_vacios (bloques:Bloques.Bloque List) : bool =
        bloques = []

    let termina_juego (bolita:bolita.Bolita) (pared:Pared.Paredes) (bloques:Bloques.Bloque List) :bool =
        Bolita_escapa bolita pared || Bloques_vacios bloques



//     //Creo tentativamente para poder definir las funciones de debajo
//     type Bolita = 
//         {
//             x:float
//             y:float
//             vx:float
//             vy:float

//         }


//     let colision_wall (bolita:Bolita) (pared:Pared) =
//         match bolita with
//         | {x = x; y = y; vx = vx; vy = vy} when x <= pared.left -> {bolita with vx = -vx}
//         | {x = x; y = y; vx = vx; vy = vy} when x >= pared.right -> {bolita with vx = -vx}
//         | {x = x; y = y; vx = vx; vy = vy} when y >= pared.top -> {bolita with vy = -vy}
//         | _ -> bolita

//     let colision_wall_bellow (bolita:Bolita) (pared:Pared)= 
//         match bolita with
//         | {x = x; y = y; vx = vx; vy = vy} when y <= pared.down -> true
//         | _ -> false

//     let colision_barrita (bolita:Bolita) (barrita:Barrita.Barrita) =
//         match bolita with
//         | {x = x; y = y; vx = vx; vy = vy} when y <= barrita.y + barrita.length_y && y >= barrita.y && x >= barrita.x && x <= barrita.x + barrita.length_x -> {bolita with vy = -vy}
//         | _ -> bolita

//     let colision_blocks (bolita:Bolita) (blocks:Bloques.Block list) = 
//         //TODO: Implementar. Depende de cómo se definan los bloques
        
        
        
//         bolita
