using Raylib_cs;


class Tile {

    // public Tile(Raylib_cs.Color color) {

    // }s
    
    public bool isShowing = false;
    
    // {maxX, maxY, minX, minY}
    public Raylib_cs.Color color = Raylib_cs.Color.GRAY;

    // public List<int> SetPosValues() {

    // }
    

    private bool CheckForMine(Tile tile) {
        if (tile is Mine) {
            return true;
        }

        return false;
    }

    public int CreateMineCount(int tileIndex, List<Tile> tiles) {
        int mineCount = 0;
        List<Tile> surroundingMines = SetSurroundingMines(tileIndex, tiles);
        for (int i = 0; i < surroundingMines.Count(); i++) {
            bool isMine = this.CheckForMine(surroundingMines[i]);
            if (isMine) {
                mineCount += 1;

            }
        }
        return mineCount;
    }


    // This creates a list of the tiles surrounding each tile to be used to check how many mines are next to the tile in question.
    // The format of the tiles in the list are as shown below:
    // 6  4  8 
    // 2  x  1
    // 7  3  5
    public List<Tile> SetSurroundingMines(int tileIndex, List<Tile> tiles) {
        List<Tile> surroundingMines = new List<Tile> {};
        int rowLength = 12;
        int? tile1 = null;
        int? tile2 = null;
        int? tile3 = null;
        int? tile4 = null;
        int? tile5 = null;
        int? tile6 = null;
        int? tile7 = null;
        int? tile8 = null;
        

        // Console.Write($"{tiles[tileIndex]} {tileIndex} ");
        if (tileIndex % 12 == 0) {
            // Console.WriteLine("1");
            tile1 = tileIndex + 1;
            tile3 = tileIndex + rowLength;
            tile4 = tileIndex - rowLength;
            tile8 = tileIndex - rowLength + 1;
            tile5 = tileIndex + rowLength + 1;
            // Console.WriteLine($"{tileIndex} top right corner is {tile8}");
        }

        else if ((tileIndex + 1) % 12 == 0) {
            // Console.WriteLine("2");
            tile2 = tileIndex - 1;
            tile3 = tileIndex + rowLength;
            tile4 = tileIndex - rowLength;
            tile6 = tileIndex - rowLength - 1;
            tile7 = tileIndex + rowLength - 1; 
        }

        else {
            // Console.WriteLine("3");
            tile1 = tileIndex + 1;
            tile2 = tileIndex - 1;
            tile3 = tileIndex + rowLength;
            tile4 = tileIndex - rowLength;
            tile5 = tileIndex + rowLength + 1;
            tile6 = tileIndex - rowLength - 1;
            tile7 = tileIndex + rowLength - 1;
            tile8 = tileIndex - rowLength + 1;
        }

        List<int?> indexes = new List<int?> {tile1, tile2, tile3, tile4, tile5, tile6, tile7, tile8};
        foreach (int? i in indexes) {
            if (i != null) {
                if (i >= 0) {
                    if (i <= tiles.Count() - 1) {
                        surroundingMines.Add(tiles[(int)i]);
                    }
                }
            }
        }

        return surroundingMines;
    }
}

class Mine : Tile {
//     // Texture2D texture;
//     // public Mine() {
//     //     var image = Raylib.LoadImage("Subject.png");
//     //     Raylib.ImageResize(ref image, 40, 40);
//     //     this.texture = Raylib.LoadTextureFromImage(image);
//     //     Raylib.UnloadImage(image);
        
//     // }

}

class Number : Tile {


}

class Blank : Tile{

}