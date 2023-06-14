namespace Barrita

open System

module Barrita =
    
    type Barrita =
        {
            x: float //x position of lower left corner
            y: float //y position of lower left corner
            length_x: float
            length_y: float
        }

    // let presiona =
    //     let mutable run = true

    //     while run do
    //         if Console.KeyAvailable then
    //             let key = Console.ReadKey(true).Key
    //             match key with
    //             | ConsoleKey.Q -> run <- false // Presionar Q para detener el loop
    //             | _ -> printfn "Has presionado %A" key
    //         System.Threading.Thread.Sleep(1000) // espera un segundo
        