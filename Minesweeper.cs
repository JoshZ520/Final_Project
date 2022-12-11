using Raylib_cs;

class Game {

    static void Main(string[] args) {
        Board board = new Board();
        board.SetTileList();

        Mouse mouse = new Mouse();

        var ScreenHeight = Constants.MAX_Y;
        var ScreenWidth = Constants.MAX_X;

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Minesweeper");
        Raylib.SetTargetFPS(60);

        Color tileColor = Color.BLACK;
        
        while (!Raylib.WindowShouldClose()) {
            board.DrawBoard(mouse);


            Raylib.EndDrawing();
            
        }
        
    Raylib.CloseWindow();
    }
}
