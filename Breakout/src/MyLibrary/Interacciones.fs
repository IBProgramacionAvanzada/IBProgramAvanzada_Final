namespace Interacciones


open Barrita
open Bloques
open Bolita

module Interacciones =

    //Creo tentativamente para poder definir las funciones de debajo
    type Bolita = 
        {
            x:float
            y:float
            vx:float
            vy:float

        }

    let wall_left = 0.
    let wall_right = 100.
    let wall_top = 100.

    let wall_bellow = 0.

    let colision_wall (bolita:Bolita) =
        match bolita with
        | {x = x; y = y; vx = vx; vy = vy} when x <= wall_left -> {bolita with vx = -vx}
        | {x = x; y = y; vx = vx; vy = vy} when x >= wall_right -> {bolita with vx = -vx}
        | {x = x; y = y; vx = vx; vy = vy} when y >= wall_top -> {bolita with vy = -vy}
        | _ -> bolita

    let colision_wall_bellow (bolita:Bolita) = 
        match bolita with
        | {x = x; y = y; vx = vx; vy = vy} when y <= wall_bellow -> true
        | _ -> false

    let colision_barrita (bolita:Bolita) (barrita:Barrita.Barrita) =
        match bolita with
        | {x = x; y = y; vx = vx; vy = vy} when y <= barrita.y + barrita.length_y && y >= barrita.y && x >= barrita.x && x <= barrita.x + barrita.length_x -> {bolita with vy = -vy}
        | _ -> bolita

    let colision_blocks (bolita:Bolita) (blocks:Bloques.Block list) = 
        //TODO: Implementar. Depende de cómo se definan los bloques
        bolita