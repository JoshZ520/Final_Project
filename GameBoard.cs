using Raylib_cs;

class Board {
    public void DrawBoard()
    {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            DrawGrid();
            
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
}

class Constants {
    public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 50;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;
}

class Score {

}
