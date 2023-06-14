namespace Interacciones

open Bolita
open Bloques
open Barrita
open Pared

module Interacciones =

    //Creo tentativamente para poder definir las funciones de debajo
    type Bolita = 
        {
            x:float
            y:float
            vx:float
            vy:float

        }


    let colision_wall (bolita:Bolita) (pared:Pared) =
        match bolita with
        | {x = x; y = y; vx = vx; vy = vy} when x <= pared.left -> {bolita with vx = -vx}
        | {x = x; y = y; vx = vx; vy = vy} when x >= pared.right -> {bolita with vx = -vx}
        | {x = x; y = y; vx = vx; vy = vy} when y >= pared.top -> {bolita with vy = -vy}
        | _ -> bolita

    let colision_wall_bellow (bolita:Bolita) (pared:Pared)= 
        match bolita with
        | {x = x; y = y; vx = vx; vy = vy} when y <= pared.down -> true
        | _ -> false

    let colision_barrita (bolita:Bolita) (barrita:Barrita.Barrita) =
        match bolita with
        | {x = x; y = y; vx = vx; vy = vy} when y <= barrita.y + barrita.length_y && y >= barrita.y && x >= barrita.x && x <= barrita.x + barrita.length_x -> {bolita with vy = -vy}
        | _ -> bolita

    let colision_blocks (bolita:Bolita) (blocks:Bloques.Block list) = 
        //TODO: Implementar. Depende de cómo se definan los bloques
        
        
        
        bolita
