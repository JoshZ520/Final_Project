using Raylib_cs;

class Board {

    List<Tile> tiles = new List<Tile> {};
    public void DrawBoard()
    {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            DrawGrid();
            DrawTile();
            
            
            
    }

    private void DrawGrid()
    {
        for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
        {
            Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.GRAY);
        }
        for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
        {
            Raylib.DrawLine(0, y, Constants.MAX_X, y, Raylib_cs.Color.GRAY);
        }
    }

    public void DrawTile() {
          for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
        {
            Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.RED);
        }
        for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
        {
            Raylib.DrawLine(0, y, Constants.MAX_X, y,  Raylib_cs.Color.RED);
        }
        for (int y = Constants.CELL_SIZE / 2; y < Constants.MAX_Y;) {
            for (int x = Constants.CELL_SIZE / 2; x < Constants.MAX_X;) {
                Raylib.DrawText("1", x, y, 24, Raylib_cs.Color.RED);
                x += Constants.CELL_SIZE;
            }
            y += Constants.CELL_SIZE;
        }
        
    }
    public List<Tile> SetTileList() {
        for (int i = 0; i < 96; i++) {
            Tile tile = new Tile();
            tiles.Add(tile);
        }
        SetMines();
        for (int i = 0; i < tiles.Count(); i++) {
            var tile = tiles[i];
            tile.SetSurroundingMines(i, tiles);
            tile.SetMineCount();
            if ((tile.GetMineCount() > 0)) {
                tiles[i] = new Number();
            }
            if ((tile.GetMineCount() == 0)) {
                tiles[i] = new Blank();
            }
        }
        return tiles;
    }  

    private List<Tile> SetMines() {
        Random random = new Random();
        for (int m = 0; m < 12; m++) {
        var index = random.Next(tiles.Count);
        tiles[index] = new Mine();
        }
        return tiles;
    } 
    }

class Constants {
    public static int CELL_SIZE = 75;
    public static int MAX_X = 900;
    public static int MAX_Y = 600;
}

class GameOver {
    public void CheckGameOver() {
        Raylib.CloseWindow();
    }

}

