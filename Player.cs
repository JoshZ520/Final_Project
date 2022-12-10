using Raylib_cs;
using System.Numerics;

class Mouse {
    public bool MousePress() {
    return Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON); 
    
 }
 public Vector2 MousePos() {
    return Raylib.GetMousePosition();
        
 }

public bool MineFound(Tile tile) {
   if (MousePress() && tile is Mine) {
         return true;
      }
   else if (MousePress() && tile is Blank) {
      return false;
   }
   else if (MousePress() && tile is Number) {
      return false;
   }
return false;
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