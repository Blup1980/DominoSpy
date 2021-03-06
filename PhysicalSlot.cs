
namespace DominoSpy
{
    public enum SensorSide
    {
        A,
        B
    }

    class PhysicalSlot
    {
        private int _id;
        private SensorSide _sensorSide;
        private DominoControl _control;

        public int Id
        {
            get { return _id; }
        }

        public DominoControl Control
        {
            get { return _control; }
        }

        public SensorSide Side
        {
            get { return _sensorSide;  }
        }


        public PhysicalSlot(int id, SensorSide side, DominoControl control)
        {
            _id = id;
            _sensorSide = side;
            _control = control;
        }
    }
}
