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

        bool gameOver = false;
        bool isWinner = false;
        
        while (!Raylib.WindowShouldClose()) {
            int numShowing = 0;
            int maxX = Constants.CELL_SIZE;
            int maxY = Constants.CELL_SIZE;
            int minX = 0;
            int minY = 0;
            int intervalX = 0;
            int intervalY = 0;
            int index = 0;
            foreach (Tile tile in tiles) {
                if (tile.isShowing) {
                    numShowing += 1;
                }

                if (numShowing >= 84) {
                    isWinner = true;
                }

                maxX = Constants.CELL_SIZE * (intervalX + 1);
                minX = Constants.CELL_SIZE * intervalX;
                maxY = Constants.CELL_SIZE * (intervalY + 1);
                minY = Constants.CELL_SIZE * intervalY;
                bool isClicked = board.Check4Click(mouse, maxX, maxY, minX, minY);

                if (tile.isShowing && tile is Blank) {
                    List<int> surroundingMines = tile.SetSurroundingMines(index, tiles);
                        for (int i = 0; i < surroundingMines.Count(); i ++) {
                            Tile mine = tiles[surroundingMines[i]];
                            if ((i <= 3) && ((mine is Blank) || (mine is Number))) {
                                tiles[surroundingMines[i]].color = Raylib_cs.Color.RED;
                                tiles[surroundingMines[i]].isShowing = true;
                            }
                        }
                }

                if (isClicked) {
                    tile.color = Raylib_cs.Color.RED;
                    tile.isShowing = true;
                    if (tile is Mine) {
                        gameOver = true;
                    }
                }

                index += 1;

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

            if (!gameOver) {
                if (!isWinner) {
                    board.DrawBoard(mouse, tiles);
                }

                else {
                    Raylib.DrawText("You Win", 100, (ScreenHeight / 2) - 100, 150, Raylib_cs.Color.GRAY);
                }
            }
            else {
                Raylib.DrawText("Game Over", 100, (ScreenHeight / 2) - 100, 150, Raylib_cs.Color.GRAY);
            }
            

            Raylib.EndDrawing();
            
            
        }
        
    Raylib.CloseWindow();
    }
}
