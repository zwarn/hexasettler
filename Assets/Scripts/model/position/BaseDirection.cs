using System.Collections.Generic;

namespace model.position
{
    public class BaseDirection : TilePosition
    {
        public static readonly BaseDirection West = new BaseDirection(-1, 0);
        public static readonly BaseDirection SouthWest = new BaseDirection(0,-1);
        public static readonly BaseDirection SouthEast = new BaseDirection(1,-1);
        public static readonly BaseDirection East = new BaseDirection(1,0);
        public static readonly BaseDirection NorthEast = new BaseDirection(0,1);
        public static readonly BaseDirection NorthWest = new BaseDirection(-1,1);
        private static List<BaseDirection> _baseDirections = new List<BaseDirection> { West, SouthWest, SouthEast, East, NorthEast, NorthWest};
            
        public int X;
        public int Y;
        

        public BaseDirection(int x, int y) : base(x,y)
        {
        }

        public static List<BaseDirection> BaseDirections
        {
            get { return _baseDirections; }
        }
    }
    
}