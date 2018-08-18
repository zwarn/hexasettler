namespace model.map
{
    public class Road
    {
        private TilePosition _position;
        private bool _road = false;
        //TODO: roadview
                
        public Road(TilePosition position)
        {
            _position = position;
        }
    }
}