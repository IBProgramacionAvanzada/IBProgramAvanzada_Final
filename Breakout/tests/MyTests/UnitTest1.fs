module MyTests

open NUnit.Framework
open Bolita
open Bloques
open Barrita
open Pared
open Jugador
open Interacciones




[<Test>]
let ``Actualiza Bolita`` () =
    let bolitaInicial = bolita.condicion_inicial_bolita
    let expectedBolita= bolita.actualiza_bolita(bolitaInicial)
    let actualBolita:bolita.Bolita = {x = 1.0 ; y = 1.001; vx = 0; vy = 1.0}
    Assert.AreEqual(expectedBolita, actualBolita)

[<Test>]
let ``Actualizo Barra`` () =
    let barra:Barrita.Barra = {x = 50.; y = 1.; L = 5.}
    let direccion1: Barrita.MovimientoBarra = Barrita.devuelvoMovimiento(-1) //movimiento izquierda
    let direccion2:Barrita.MovimientoBarra = Barrita.devuelvoMovimiento(1) //movimiento derecha
    let direccion3:Barrita.MovimientoBarra = Barrita.devuelvoMovimiento(0) //movimiento nulo
    let movimiento1:Barrita.MovimientoBarra = direccion1
    let movimiento2:Barrita.MovimientoBarra = direccion2
    let movimiento3:Barrita.MovimientoBarra = direccion3
    let dx_barra = 1
    let barra_after1:Barrita.Barra = {x = 49.0; y = 1.; L = 5.}
    let barra_after2:Barrita.Barra =  {x = 51.0; y = 1.; L = 5.}
    let barra_after3:Barrita.Barra = barra
    Assert.AreEqual(barra_after1, (Barrita.actualizo_barra barra movimiento1 dx_barra))
    Assert.AreEqual(barra_after2, (Barrita.actualizo_barra barra movimiento2 dx_barra))
    Assert.AreEqual(barra_after3, (Barrita.actualizo_barra barra movimiento3 dx_barra))


[<Test>]
let ``Interaccion_barra`` () =
    let barra:Barrita.Barra = {x = 50.; y = 1.; L = 5.}

    let bolita1:bolita.Bolita = {x = 50.; y = 50.; vx = 1.; vy = 1.} 
    let bolita2:bolita.Bolita = {x = 10.; y = 0.5; vx = 1.; vy = 1.} 
    let bolita3:bolita.Bolita = {x = 51.; y = 1.1; vx = 1.; vy = 1.} 
    let bolita4:bolita.Bolita = {x = 51.; y = 0.95; vx = 1.; vy = 1.}

    Assert.AreEqual(bolita1, (Interacciones.Interaccion_barra barra {x = 50.; y = 50.; vx = 1.; vy = 1.})) //no hay choque
    Assert.AreEqual(bolita2, (Interacciones.Interaccion_barra barra {x = 10.; y = 0.5; vx = 1.; vy = 1.}) )//bolita con y debajo de la barra pero x lejos
    Assert.AreEqual(bolita3, (Interacciones.Interaccion_barra barra {x = 51.; y = 1.1; vx = 1.; vy = 1.})) //bolita arriba de la barra
    Assert.AreEqual(bolita4, (Interacciones.Interaccion_barra barra {x = 51.; y = 0.95; vx = 1.; vy = -1.})) //choque

[<Test>]
let ``Interaccion_pared`` ()=
    
    let paredes:Pared.Paredes = {Up_y = 100.; Down_y = 0.; Left_x = 0.; Right_x = 100.}
    let jugador1 = Jugador.inicializarJugador
    let nuevo_jugador1 = Jugador.restarVida jugador1

    let bolita1:bolita.Bolita = {x = 50.; y = 50.; vx = 1.; vy = 1.}
    let bolita2:bolita.Bolita = {x=50.; y = 50.; vx = 100.; vy = 100.}
    let bolita3:bolita.Bolita = {x = -1.; y = 50.; vx = 1. ; vy = 10.}
    let bolita4:bolita.Bolita = {x=101; y = 50; vx = -1; vy = 20}
    let bolita5:bolita.Bolita = {x=50; y = -1; vx = 1; vy = -10}
    let bolita6:bolita.Bolita = {x=50; y = 101; vx = 20; vy = -1}



    Assert.AreEqual((bolita1, jugador1), (Interacciones.Interaccion_pared paredes {x = 50.; y = 50.; vx = 1.; vy = 1.} jugador1)) //no hay choque
    Assert.AreEqual((bolita2, jugador1), (Interacciones.Interaccion_pared paredes {x=50.; y = 50.; vx = 100.; vy = 100.} jugador1)) //no hay choque
    Assert.AreEqual((bolita3, jugador1), (Interacciones.Interaccion_pared paredes {x = -1.; y = 50.; vx = -1. ; vy = 10.} jugador1)) //choque con pared izquierda
    Assert.AreEqual((bolita4, jugador1), (Interacciones.Interaccion_pared paredes {x=101; y = 50; vx = 1; vy = 20} jugador1)) //choque con pared derecha
    Assert.AreEqual((bolita5, nuevo_jugador1), (Interacciones.Interaccion_pared paredes {x=50; y = -1; vx = 1; vy = -10} jugador1)) //choque con pared de abajo
    Assert.AreEqual((bolita6, jugador1), (Interacciones.Interaccion_pared paredes {x=50; y = 101; vx = 20; vy = 1} jugador1)) //choque con pared de arriba
    //No se testea la posibilidad de que esté en una esquina porque numéricamente si el dt es suficientemente pequeño nunca debería darse la posibilidad


[<Test>]
let ``Ubicar bloque`` () =
    let estado_bloques = Bloques.inicializarBloques 8 14   
    
    // las coordenadas donde comienza la región son incluyentes
    // y las coordenadas donde termina la región son excluyentes
    Assert.AreEqual(true, (Interacciones.hayBloque 0.0 800.0 estado_bloques))   
    Assert.AreEqual(false, (Interacciones.hayBloque 0.0 1000. estado_bloques))
    Assert.AreEqual(true, (Interacciones.hayBloque 0.0 999.999 estado_bloques))
    Assert.AreEqual(false, (Interacciones.hayBloque 700.0 999.999 estado_bloques))
    Assert.AreEqual(true, (Interacciones.hayBloque 699.999 800.0 estado_bloques))
    Assert.AreEqual(false, (Interacciones.hayBloque 699.999 1000.0 estado_bloques))
    Assert.AreEqual(true, (Interacciones.hayBloque 699.999 999.999 estado_bloques))


[<Test>]
let ``Tipo de choque`` () =
    // bloque con esquina inferior en (x=100, y=800)
    let filaTest = 0
    let columnaTest = 2

    // choque vertical
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 149.0; y = 800; vx = -1.; vy = -1.} filaTest columnaTest))
    // choque horizontal
    Assert.AreEqual(Interacciones.Choque_con_bloque.Horizontal, (Interacciones.Tipo_choque {x = 100.0; y = 812.5; vx = 1.; vy = -1.} filaTest columnaTest))
    //   con distinta velocidad
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 120.0; y = 824.0; vx = 1.; vy = -1.} filaTest columnaTest))    
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 120.0; y = 824.0; vx = 10.; vy = -48.} filaTest columnaTest))
    // los choques con esquina siempre son verticales
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 100.0; y = 800.0; vx = 1.; vy = 1.} filaTest columnaTest))
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 100.0; y = 825.0; vx = 1.; vy = 1.} filaTest columnaTest))
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 150.0; y = 800.0; vx = 1.; vy = 1.} filaTest columnaTest))
    Assert.AreEqual(Interacciones.Choque_con_bloque.Vertical, (Interacciones.Tipo_choque {x = 150.0; y = 825.0; vx = 1.; vy = 1.} filaTest columnaTest))
    

[<Test>]
let ``Interaccion bloques`` () =
    // bloque con esquina inferior en (x=100, y=800)
    let filaTest = 0
    let columnaTest = 2
    let estado_bloques = Bloques.inicializarBloques 8 14
    let estado_final = Bloques.desactivarBloque filaTest columnaTest estado_bloques
    let jugador1 = Jugador.inicializarJugador
    let jugador1_final = Jugador.sumarPuntos jugador1

    let bolita1:bolita.Bolita = {x = 100.; y = 799.; vx = 1.; vy = 1.}
    
    let bolita2:bolita.Bolita = {x = 100.0; y = 812.5; vx = 1.; vy = 1.}
    let bolita2_final:bolita.Bolita = {x = 100.0; y = 812.5; vx = -1.; vy = 1.}
    
    let bolita3:bolita.Bolita = {x = 120.; y = 824.0; vx = 1.; vy = -1.} 
    let bolita3_final:bolita.Bolita = {x = 120.; y = 824.0; vx = 1.; vy = 1.}

    let bolita4:bolita.Bolita = {x = 100.0; y = 800.0; vx = 1.; vy = 1.}
    let bolita4_final:bolita.Bolita = {x = 100.0; y = 800.0; vx = 1.; vy = -1.}
    
    // no hubo choque
    Assert.AreEqual( (bolita1, estado_bloques, jugador1), (Interacciones.Interaccion_bloques estado_bloques bolita1 jugador1))
    // hubo choque horizontal
    Assert.AreEqual( (bolita2_final, estado_final, jugador1_final), (Interacciones.Interaccion_bloques estado_bloques bolita2 jugador1))
    // hubo choque vertical
    Assert.AreEqual( (bolita3_final, estado_final, jugador1_final), (Interacciones.Interaccion_bloques estado_bloques bolita3 jugador1))
    // hubo choque con esquina
    Assert.AreEqual( (bolita4_final, estado_final, jugador1_final), (Interacciones.Interaccion_bloques estado_bloques bolita4 jugador1))


[<Test>]
let ``No hay bloques`` () =
    let estado_bloques = Bloques.inicializarBloques 1 1
    let apagado = [(0, 0), false] |> Map.ofList
    let estado_apagados:Bloques.Bloques = { Estado = apagado }

    Assert.AreEqual(false, (Interacciones.no_hay_bloques estado_bloques))
    Assert.AreEqual(true, (Interacciones.no_hay_bloques estado_apagados))
