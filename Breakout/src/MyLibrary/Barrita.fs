namespace Barrita

open System

module Barrita =
        

    type Barra = 
        {
            x: float
            y: float
            L: float
        }

    type MovimientoBarra = 
        | Izquierda
        | Derecha
        | Ninguno

    let barra_inicial:Barra = 
        {
            x = 300.0
            y = 50.
            L = 100.
        }

    let condicion_inicial_barra =
        barra_inicial

    let actualizo_barra (barra:Barra) (movimiento:MovimientoBarra) (dx_barra:float) =
        match movimiento with
        | Izquierda -> {barra with x = barra.x - dx_barra}
        | Derecha -> {barra with x = barra.x + dx_barra}
        | Ninguno -> barra
