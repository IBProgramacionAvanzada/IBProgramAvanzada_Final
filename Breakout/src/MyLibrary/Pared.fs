namespace Pared

module Pared =

    
    type Paredes =
        {
            Left_x: float
            Down_y: float
            Right_x: float
            Up_y: float
        }

    let paredes_inicial:Paredes =
        {   
            Left_x = 0.
            Down_y = 0.
            Right_x = 700.0
            Up_y = 1200.0
        }

    let condicion_inicial_paredes = 
        paredes_inicial