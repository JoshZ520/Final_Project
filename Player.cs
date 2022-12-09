using Raylib_cs;
using System.Numerics;

class Mouse {
    public bool MousePress() {
    return Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON); 
    
 }
 public Vector2 MousePos() {
    return Raylib.GetMousePosition();
        
 }
}


class Player {

}

// if  (tile is Mine) {
            
//         }
//         if (tile is Blank) {

//         }
//         if (Tile tile = Number) {

//         }