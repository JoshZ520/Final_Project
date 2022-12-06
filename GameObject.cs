

class GameObject {
    // An attribute "posision" will be used to show where on t he grid the tiles and other objects will appear
}


class Tile : GameObject {
    int mineCount = 0;
    List<Tile> surroundingMines;

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
}

class Mine : Tile {
    
}

class Number : Tile {


}

class Blank : Tile{

}