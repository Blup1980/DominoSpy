using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoSpy
{
    class PhysicalDomino
    {
        private String _textA = "";
        private String _textB = "";
        private String _rfidA = "";
        private String _rfidB = "";
        private String _rfidC = "";
        private bool _isFound = false;
        private bool _isPlaced = false;
        private bool _isInverted = false;
        private int _currentSlot = 0;
        private int _correctSlot = 0;

        public PhysicalDomino(String textA, String textB, String rfidA, String rfidB, String rfidC, int correctSlot)
        {
            _textA = textA;
            _textB = textB;
            _correctSlot = correctSlot;
            _rfidA = rfidA;
            _rfidB = rfidB;
        }

        public bool IsAtCorrectSlot()
        {
            if (_isPlaced == false || _isInverted == false)
                return false;
            return _currentSlot == _correctSlot;
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
            set { _correctSlot = value; }
        }

    }
}
