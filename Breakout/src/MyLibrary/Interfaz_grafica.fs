namespace Interfaz_grafica


open Bolita
open Bloques
open Barrita
open Pared

module tablero =
    type Tablero = 
        {
            paredes: Pared.Paredes
            barra: Barrita.Barra
            bolita: bolita.Bolita
            bloques: Bloques.Bloque List
        }