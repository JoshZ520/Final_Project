using Raylib_cs;
using System.Numerics;

class Mouse {
    public bool MousePress() {
    return Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON); 
 }

 public Vector2 MousePos() {
    return Raylib.GetMousePosition();
 }

   public int MouseX() {
      return (int)Raylib.GetMousePosition().X;
   }

   // public int MouseX() {
   //    return (int)Raylib.GetMousePosition().X;
   // }

   public int MouseY() {
      return (int)Raylib.GetMousePosition().Y;
   }

   public bool MineFound(Tile tile) {
      if (MousePress() && tile is Blank) {
         return false;
      }
      else if (MousePress() && tile is Number) {
         return false;
      }
      else if (MousePress()) { 
         return true;
      }
      else {
         return false;
      }
   }

}
 



class Player {

}