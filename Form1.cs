using System;
using System.IO;
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
        private const String RfidDtFileName = "RFID_v2.dtf";

        private List<PhysicalDomino> _dominos;
        private List<PhysicalSlot> _slots;
        private FileSystemWatcher _watcher;
        private LogParser _logPaser;

        public Form1()
        {
            InitializeComponent();
            Reset();

            string path = Directory.GetCurrentDirectory();
            _watcher = new FileSystemWatcher(path)
            {
                NotifyFilter = NotifyFilters.LastWrite, 
                Filter = "dominoLog.txt",
                IncludeSubdirectories = false,
                EnableRaisingEvents = true,
            };

            _logPaser = new LogParser(path + "/dominoLog.txt");
            _logPaser.RfidDetected += OnRfidDetected;
            _logPaser.GameRestarted += OnGameRestarted;
            _watcher.Changed += this.OnLogChanged;

        }

        ~Form1()
        {
            _watcher.Changed -= this.OnLogChanged;
            _watcher.EnableRaisingEvents = false;
        }

        private void OnLogChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }
            _logPaser.Parse();
        }

        private void OnGameRestarted(object sender, EventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate
            {
                Reset();
            }));
        }

        private void OnRfidDetected(object sender, RfidDetectedEventArgs e)
        {

            foreach (PhysicalDomino d in _dominos)
            {
                d.IsPlaced = false;
                for (int i = 0; i < e.Rfids.Count(); i++)
                {
                    if (d.HasRfid(e.Rfids[i]) == false)
                        continue;
                            
                    d.IsPlaced = true;
                    d.IsFound = true;
                    d.CurrentSlot = i;

                    d.IsInverted = true;
                    if (d.HasRfidAt(e.Rfids[i], _slots[i].Side))
                    {
                        d.IsInverted = false;
                    }
                    break;
                }
            }
            OnDataUpdate();
        }

        private void Reset()
        {
            _slots = PopulateSlots();
            _dominos = PopulateDominos();
            InitBoardControls();
        }

        private void OnDataUpdate()
        {
            foreach (PhysicalSlot s in _slots)
            {
                bool slotFound = false;
                foreach (PhysicalDomino d in _dominos)
                {
                    if (d.CurrentSlot == s.Id && d.IsPlaced)
                    {
                        slotFound = true;
                        if (d.IsInverted)
                        {
                            s.Control.TextA = d.TextB;
                            s.Control.TextB = d.TextA;
                        } 
                        else
                        {
                            s.Control.TextA = d.TextA;
                            s.Control.TextB = d.TextB;
                        }
                        if (d.IsAtCorrectPosAndOrient())
                        {
                            s.Control.Status = DominoStatus.Correct;
                            s.Control.ShowCorrect = false;
                        } 
                        else
                        {
                            s.Control.ShowCorrect = true;
                            if (d.IsAtCorrectPos())
                            {
                                s.Control.Status = DominoStatus.Inverted;
                            } 
                            else
                            {
                                s.Control.Status = DominoStatus.Wrong;
                            }
                        }

                    }

                }
                if (slotFound)
                    s.Control.Invoke(new MethodInvoker(delegate
                    {
                        s.Control.Visible = true;
                    }));
                else
                    s.Control.Invoke(new MethodInvoker(delegate
                    {
                        s.Control.Visible = false;
                    }));
            }

            if (_dominos[1].IsFound)
            {
                Domino1_found.Invoke(new MethodInvoker(delegate
                {
                    Domino1_found.Visible = true;
                }));
            }

            if (_dominos[2].IsFound)
            {
                Domino2_found.Invoke(new MethodInvoker(delegate
                {
                    Domino2_found.Visible = true;
                }));
            }
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
            Domino1_found.Visible = false;
            Domino2_found.Visible = false;
        }


        private List<PhysicalDomino> PopulateDominos()
        {
            /* old dominos
            return new List<PhysicalDomino> {
                new PhysicalDomino( "1", "0", "", "801514C4008100A8", "",  0 ),
                new PhysicalDomino( "0", "4", "", "804B7CC400810045", "",  1 ),
                new PhysicalDomino( "0", "5", "", "804836C4008100D4", "",  2 ),
                new PhysicalDomino( "0", "3", "80B4651C0081008B", "", "",  3 ),
                new PhysicalDomino( "2", "3", "", "", "",  4 ), // 8045251C00810039
                new PhysicalDomino( "6", "2", "", "809ABD1C00810099", "",  5 ), // to check
                new PhysicalDomino( "6", "6", "", "", "80A99D1C00810026",  6 ),
                new PhysicalDomino( "5", "6", "802472C4008100F0", "", "",  7 ),
                new PhysicalDomino( "5", "1", "", "804660C4008100F8", "",  8 ),
                new PhysicalDomino( "1", "1", "", "", "80A74AC40081005F",  9 )
            };
            */

            return RfidDtsParser.Parse(Directory.GetCurrentDirectory() + "/" + RfidDtFileName, _slots);

            /*
            return new List<PhysicalDomino> {
                new PhysicalDomino( "1", "0", "80B1DD1900B8005C", "80AF69E900B800B1", "",  0 ),
                new PhysicalDomino( "0", "4", "80103DE900B8000F", "803E271900B800A1", "",  1 ),
                new PhysicalDomino( "0", "5", "80055C1900B80003", "804836C4008100D4", "",  2 ),
                new PhysicalDomino( "0", "3", "80B4651C0081008B", "80F04E1900B800F6", "",  3 ),
                new PhysicalDomino( "2", "3", "808EFFE900B8009A", "806B4BE900B80029", "",  4 ),
                new PhysicalDomino( "6", "2", "80228DC1006600ED", "8053B7C10066005F", "",  5 ),
                new PhysicalDomino( "6", "6", "", "", "806795E900B80026",  6 ),
                new PhysicalDomino( "5", "6", "8049542100660001", "8084D2A1006600B1", "",  7 ),
                new PhysicalDomino( "5", "1", "80BED0210066001D", "806351CA002600EA", "",  8 ),
                new PhysicalDomino( "1", "1", "", "", "805919E900B80013",  9 )
            };
            */

        }

        private List<PhysicalSlot> PopulateSlots()
        {
            return new List<PhysicalSlot> {
                new PhysicalSlot( 0, SensorSide.B, slot0 ),
                new PhysicalSlot( 1, SensorSide.B, slot1 ),
                new PhysicalSlot( 2, SensorSide.B, slot2 ),
                new PhysicalSlot( 3, SensorSide.A, slot3 ),
                new PhysicalSlot( 4, SensorSide.B, slot4 ), // Sensor side unknown
                new PhysicalSlot( 5, SensorSide.B, slot5 ),
                new PhysicalSlot( 6, SensorSide.C, slot6 ),
                new PhysicalSlot( 7, SensorSide.A, slot7 ),
                new PhysicalSlot( 8, SensorSide.B, slot8 ),
                new PhysicalSlot( 9, SensorSide.C, slot9 ),
            };
        }

        private void restartBtn_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
