using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoSpy
{
    public partial class Form1 : Form
    {

        private List<PhysicalDomino> _dominos;
        private List<PhysicalSlot> _slots;

        public Form1()
        {
            InitializeComponent();
            reset();
        }

        private void reset()
        {
            _slots = PopulateSlots();
            _dominos = PopulateDominos();
            InitBoardControls();
        }

        private void InitBoardControls()
        {
            foreach (PhysicalSlot s in _slots)
            {
                foreach (PhysicalDomino d in _dominos)
                {
                    if (d.CorrectSlot == s.Id)
                    {
                        s.Control.CorrectA = d.TextA;
                        s.Control.CorrectB = d.TextB;
                        s.Control.ShowCorrect = true;
                        s.Control.Visible = false;
                    }
                }
            }
        }


        private List<PhysicalDomino> PopulateDominos()
        {
            return new List<PhysicalDomino> {
                new PhysicalDomino( "1", "0", "", "801514C4008100A8", "",  0 ),
                new PhysicalDomino( "0", "4", "", "804B7CC400810045", "",  1 ),
                new PhysicalDomino( "0", "5", "", "804836C4008100D4", "",  2 ),
                new PhysicalDomino( "0", "3", "80B4651C0081008B", "", "",  3 ),
                new PhysicalDomino( "2", "3", "", "", "",  4 ), // ????
                new PhysicalDomino( "6", "2", "", "809ABD1C00810099", "",  5 ), 
                new PhysicalDomino( "6", "6", "", "", "80A99D1C00810026",  6 ),
                new PhysicalDomino( "5", "6", "802472C4008100F0", "", "",  7 ),
                new PhysicalDomino( "5", "1", "", "804660C4008100F8", "",  8 ),
                new PhysicalDomino( "1", "1", "", "", "80A74AC40081005F",  9 )
            };
        }

        private List<PhysicalSlot> PopulateSlots()
        {
            return new List<PhysicalSlot> {
                new PhysicalSlot( 0, SensorSide.B, slot0 ),
                new PhysicalSlot( 1, SensorSide.B, slot1 ),
                new PhysicalSlot( 2, SensorSide.B, slot2 ),
                new PhysicalSlot( 3, SensorSide.A, slot3 ),
                new PhysicalSlot( 4, SensorSide.A, slot4 ), // ????
                new PhysicalSlot( 5, SensorSide.B, slot5 ),
                new PhysicalSlot( 6, SensorSide.C, slot6 ),
                new PhysicalSlot( 7, SensorSide.A, slot7 ),
                new PhysicalSlot( 8, SensorSide.B, slot8 ),
                new PhysicalSlot( 9, SensorSide.C, slot9 ),
            };
        }




    }
}
