using Raylib_cs;

class GameObject {
    // An attribute "posision" will be used to show where on the grid the tiles and other objects will appear
}


class Tile : GameObject {
    public bool isShowing = false;
    int mineCount = 0;
    List<Tile> surroundingMines = new List<Tile> {};

    private bool CheckForMine(Tile tile) {
        if (tile is Mine) {
            return true;
        }

        return false;
    }

    public int SetMineCount() {
        foreach (Tile tile in surroundingMines) {
            bool isMine = this.CheckForMine(tile);
            if (isMine) {
                mineCount += 1;
            }
        }
        return mineCount;
    }

    public int GetMineCount() {
        return mineCount;
    }

    public List<Tile> SetSurroundingMines(int tileIndex, List<Tile> tiles) {
        int rowLength = 12;
        int? tile1 = null;
        int? tile2 = null;
        int? tile3 = null;
        int? tile4 = null;
        int? tile5 = null;
        int? tile6 = null;
        int? tile7 = null;
        int? tile8 = null;
        
        if ((tileIndex % 12 != 0) || ((tileIndex + 1) % 12 != 0)) {
            tile1 = tileIndex + 1;
            tile2 = tileIndex - 1;
            tile3 = tileIndex + rowLength;
            tile4 = tileIndex - rowLength;
            tile5 = tileIndex + rowLength + 1;
            tile6 = tileIndex - rowLength - 1;
            tile7 = tileIndex + rowLength - 1;
            tile8 = tileIndex - rowLength + 1;
        }

        else if (tileIndex % 12 == 0) {
            tile1 = tileIndex + 1;
            tile3 = tileIndex + rowLength;
            tile4 = tileIndex - rowLength;
            tile8 = tileIndex - rowLength + 1;
            tile5 = tileIndex + rowLength + 1;
        }

        else {
            tile2 = tileIndex - 1;
            tile3 = tileIndex + rowLength;
            tile4 = tileIndex - rowLength;
            tile6 = tileIndex - rowLength - 1;
            tile7 = tileIndex + rowLength - 1; 
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
    // Texture2D texture;
    // public Mine() {
    //     var image = Raylib.LoadImage("Subject.png");
    //     Raylib.ImageResize(ref image, 40, 40);
    //     this.texture = Raylib.LoadTextureFromImage(image);
    //     Raylib.UnloadImage(image);
        
    // }

}

class Number : Tile {


}

class Blank : Tile{

}