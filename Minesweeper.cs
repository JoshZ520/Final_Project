using Raylib_cs;

class Game {

    static void Main(string[] args) {
        Board board = new Board();

        var ScreenHeight = Constants.MAX_Y;
        var ScreenWidth = Constants.MAX_X;

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Minesweeper");
        Raylib.SetTargetFPS(60);

        
        while (!Raylib.WindowShouldClose()) {
            board.DrawBoard();
            

            Raylib.EndDrawing();
            
        }
        
    Raylib.CloseWindow();
}
}
