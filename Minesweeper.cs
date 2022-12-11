using Raylib_cs;

class Game {

    static void Main(string[] args) {
        Board board = new Board();
        List<Tile> tiles = new List<Tile> {};
        tiles = board.SetTileList(tiles);

        Mouse mouse = new Mouse();

        var ScreenHeight = Constants.MAX_Y;
        var ScreenWidth = Constants.MAX_X;

        Raylib.InitWindow(ScreenWidth, ScreenHeight, "Minesweeper");
        Raylib.SetTargetFPS(60);

        Color tileColor = Color.BLACK;
        
        while (!Raylib.WindowShouldClose()) {
            int maxX = Constants.CELL_SIZE;
            int maxY = Constants.CELL_SIZE;
            int minX = 0;
            int minY = 0;
            int intervalX = 0;
            int intervalY = 0;
            foreach (Tile tile in tiles) {
                maxX = Constants.CELL_SIZE * (intervalX + 1);
                minX = Constants.CELL_SIZE * intervalX;
                maxY = Constants.CELL_SIZE * (intervalY + 1);
                minY = Constants.CELL_SIZE * intervalY;
                bool isClicked = board.Check4Click(mouse, maxX, maxY, minX, minY);

                if (isClicked) {
                    tile.color = Raylib_cs.Color.RED;
                    Console.WriteLine(intervalX);
                    Console.WriteLine(intervalY);
                    Console.WriteLine($"{maxX}, {maxY}");
                    Console.WriteLine($"{minX}, {minY}");
                    Console.WriteLine(tile);
                }

                if ((intervalX + 1) % 12 == 0) {
                    intervalY += 1;
                }
                if (intervalX == 11) {
                    intervalX = 0;
                }
                else {
                    intervalX += 1;
                }
            }
            board.DrawBoard(mouse, tiles);


            Raylib.EndDrawing();
            
        }
        
    Raylib.CloseWindow();
    }
}
