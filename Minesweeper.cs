using Raylib_cs;

class Game {

    static void Main(string[] args) {
        Board board = new Board();
        board.SetTileList();

        Mouse mouse = new Mouse();

        Tile tile = new Tile();

        var ScreenHeight = Constants.MAX_Y;
        var ScreenWidth = Constants.MAX_X;

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Minesweeper");
        Raylib.SetTargetFPS(60);

        
        while (!Raylib.WindowShouldClose()) {
            board.DrawBoard();
            if (mouse.MousePress()) {
                var MouseXY = mouse.MousePos();
            }
            if (mouse.MineFound(tile)) {
                
            }
            Raylib.EndDrawing();
            
        }
        
    Raylib.CloseWindow();
}
}
