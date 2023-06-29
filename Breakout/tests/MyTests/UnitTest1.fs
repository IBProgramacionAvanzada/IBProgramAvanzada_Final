module MyTests

open NUnit.Framework
open Bolita
open Bloques
open Barrita
open Pared
open Interacciones
open Interfaz_grafica



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
    Assert.AreEqual(barra_after3, (Barrita.actualizo_barra barra movimiento1 dx_barra))
    Assert.AreEqual(barra_after3, (Barrita.actualizo_barra barra movimiento1 dx_barra))


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

