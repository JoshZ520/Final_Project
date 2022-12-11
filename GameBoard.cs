using Raylib_cs;

class Board {

    List<Tile> tiles = new List<Tile> {};
    public void DrawBoard(Mouse mouse)
    {
            Raylib_cs.Color color = Raylib_cs.Color.GRAY;
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            DrawTile(mouse, color);
            DrawGrid();

            int maxX = Constants.CELL_SIZE;
            int maxY = Constants.CELL_SIZE;
            int minX = 0;
            int minY = 0;
            int index = 0;
            foreach (Tile tile in tiles) {
                maxX = Constants.CELL_SIZE * (index + 1);
                minX = Constants.CELL_SIZE * index;
                maxY = Constants.CELL_SIZE * (index + 1);
                minY = Constants.CELL_SIZE * index;
                bool isClicked = Check4Click(mouse, maxX, maxY, minX, minY);

                if (isClicked) {
                    tile.isShowing = true;
                    Console.WriteLine(isClicked);
                }


                if (tile.isShowing) {
                    color = Raylib_cs.Color.RED;
                }
                index += 1;
            }
            
            
    }

    private void DrawGrid()
    {
        for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
        {
            Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.WHITE);
        }
        for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
        {
            Raylib.DrawLine(0, y, Constants.MAX_X, y, Raylib_cs.Color.WHITE);
        }
    }

    public void DrawTile(Mouse mouse, Raylib_cs.Color color) {
        // for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
        // {
        //     Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.RED);
        // }
        // for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
        // {
        //     Raylib.DrawLine(0, y, Constants.MAX_X, y,  Raylib_cs.Color.RED);
        // }
        int index = 0;
        
        for (int y = Constants.CELL_SIZE / 2; y < Constants.MAX_Y;) {
            for (int x = Constants.CELL_SIZE / 2; x < Constants.MAX_X;) {
                var tile = tiles[index];


                if (tile is Number) {
                    int count = tile.CreateMineCount(index, tiles);
                    Raylib.DrawText($"{count}", x, y, 24, color);
                    
                }
                else if (tile is Mine) {
                    
                    // here we would display the image of the mine (Aka the pic of his face)
                    Raylib.DrawText($"M", x, y, 24, color);
                    
                }
                else {
                    Raylib.DrawText("", x, y, 24, color);
                    
                }
                x += Constants.CELL_SIZE;
                index += 1;
            }
            y += Constants.CELL_SIZE;
        }
        
    }
    public List<Tile> SetTileList() {
        for (int i = 0; i < 96; i += 1) {
            Tile tile = new Tile();
            tiles.Add(tile);
            List<Tile> surroundinngMines = tile.SetSurroundingMines(i, tiles);
        }
        
        SetMines();

        for (int i = 0; i < tiles.Count(); i++) {
            var tile = tiles[i];
            var count = tile.CreateMineCount(i, tiles);
            // Console.WriteLine($"{i} {tile} {count}");
            if (tile is Mine) {
                //Just a catch for the mines
                // Console.WriteLine($"{tiles[i]} {i}");
            }
            else if (count > 0) {
                tiles[i] = new Number();
                // Console.WriteLine($"{tiles[i]} {i}");
            }
            else if (count == 0) {
                tiles[i] = new Blank();
                // Console.WriteLine($"{tile} {i}");
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

    private bool Check4Click(Mouse mouse, int maxX, int maxY, int minX, int minY) {
        if (mouse.MousePress()) {
            if ((mouse.MouseX() > minX) && (mouse.MouseY() > minY) && (mouse.MouseX() < maxX) && (mouse.MouseY() < maxY)) {
                return true;
            }
            
        }
        return false;
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

