

class GameObject {
    // An attribute "posision" will be used to show where on t he grid the tiles and other objects will appear
}


class Tile : GameObject {
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
        if ((tileIndex % 12 != 0) || ((tileIndex + 1) % 12 != 1)) {
            int tile1 = tileIndex + 1;
            int tile2 = tileIndex - 1;
            int tile3 = tileIndex + 12;
            int tile4 = tileIndex - 12;
            int tile5 = tileIndex + 13;
            int tile6 = tileIndex - 13;
            int tile7 = tileIndex + 11;
            int tile8 = tileIndex - 11;
        }


        return surroundingMines;
    }
}

class Mine : Tile {
    
}

class Number : Tile {


}

class Blank : Tile{

}