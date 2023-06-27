namespace Bolita

// module Say =
//     let hello name =
//         printfn "Hello %s" name


module bolita =

    type Bolita = 
        {
            x: float
            y: float
            vx: float
            vy: float
        }

    let condicion_inicial_bolita = 
        let bolita:Bolita = {
            x = 1.
            y = 1.
            vx = 0.
            vy = 1.
        }
        bolita

    let actualiza_bolita (bolita:Bolita) =
        let dt = 1e-3
        let newBolita:Bolita = {
            x = bolita.x + bolita.vx * dt
            y = bolita.y + bolita.vy * dt
            vx = bolita.vx
            vy = bolita.vy
        }
        newBolita
