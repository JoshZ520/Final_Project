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

    public List<Tile> SetSurroundingMines(int tileIndex, List<Tile> tiles) {
        int rowLength = 12;
        if ((tileIndex % 12 != 0) || ((tileIndex + 1) % 12 != 0)) {
            int tile1 = tileIndex + 1;
            int tile2 = tileIndex - 1;
            int tile3 = tileIndex + rowLength;
            int tile4 = tileIndex - rowLength;
            int tile5 = tileIndex + rowLength + 1;
            int tile6 = tileIndex - rowLength - 1;
            int tile7 = tileIndex + rowLength - 1;
            int tile8 = tileIndex - rowLength + 1;
        }

        else if (tileIndex % 12 == 0) {
            int tile1 = tileIndex + 1;
            int tile2 = tileIndex + rowLength;
            int tile3 = tileIndex - rowLength;
            int tile4 = tileIndex - rowLength+ 1;
            int tile5 = tileIndex + 1;
        }

        else if ((tileIndex + 1) % 12 == 0) {
            
        }

        return surroundingMines;
    }
}

class Mine : Tile {
    Texture2D texture;
    public Mine() {
        var image = Raylib.LoadImage("Subject.png");
        Raylib.ImageResize(ref image, 40, 40);
        this.texture = Raylib.LoadTextureFromImage(image);
        Raylib.UnloadImage(image);
        
    }

}

class Number : Tile {


}

class Blank : Tile{

}