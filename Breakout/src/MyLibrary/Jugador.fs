namespace Jugador

module Jugador =

    type Jugador =
        {
            vidas : int
            puntos: int
        }

    let inicializarJugador: Jugador  = 
        { vidas = 3 ; puntos = 0 }

    let sumarPuntos (jugador: Jugador) =
        { jugador with puntos = jugador.puntos + 10 }

    let restarVida (jugador: Jugador) =
        { jugador with vidas = jugador.vidas - 1 }

