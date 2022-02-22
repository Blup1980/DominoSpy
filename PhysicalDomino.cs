using System;

namespace DominoSpy
{
    class PhysicalDomino
    {
        private String _textA = "";
        private String _textB = "";
        private String _rfidA = "";
        private String _rfidB = "";
        private bool _isFound = false;
        private bool _isPlaced = false;
        private bool _isInverted = false;
        private int _currentSlot = 0;
        private int _correctSlot = 0;

        public PhysicalDomino(String textA, String textB, String rfidA, String rfidB, int correctSlot)
        {
            _textA = textA;
            _textB = textB;
            _correctSlot = correctSlot;
            _rfidA = rfidA;
            _rfidB = rfidB;
        }

        public string RfidA
        {
            get { return _rfidA; }
            set { _rfidA = value; }
        }

        public string RfidB
        {
            get { return _rfidB; }
            set { _rfidB = value; }
        }


        public bool IsAtCorrectPosAndOrient()
        {
            if (_isPlaced == false || _isInverted == true)
                return false;
            return _currentSlot == _correctSlot;
        }

        public bool IsAtCorrectPos()
        {
            if (_isPlaced == false )
                return false;
            return _currentSlot == _correctSlot;
        }

        public bool IsInverted
        {
            get { return _isInverted; }
            set { _isInverted = value; } 
        }

        public bool IsPlaced
        {
            get { return _isPlaced; }
            set { _isPlaced = value; }
        }

        public bool IsFound
        {
            get { return _isFound; }
            set { _isFound = value; }
        }

        public String TextA
        {
            get { return _textA; }
        }

        public String TextB
        {
            get { return _textB; }
        }

        public int CurrentSlot
        {
            get { return _currentSlot; }
            set { _currentSlot = value; }
        }

        public int CorrectSlot
        {
            get { return _correctSlot; }
        }

        public bool HasRfid(String rfid)
        {
            return _rfidA.Equals(rfid) || _rfidB.Equals(rfid);
        }

        public bool HasRfidAt(String rfid, SensorSide side )
        {
            switch (side)
            {
                case SensorSide.A:
                    return _rfidA.Equals(rfid);
                case SensorSide.B:
                    return _rfidB.Equals(rfid);
                default:
                    return false;
            }
        }
    }
}
