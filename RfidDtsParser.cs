using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DominoSpy
{
    static class RfidDtsParser
    {

        static public List<PhysicalDomino> Parse(String fileName, List<PhysicalSlot> slots)
        {
            List<PhysicalDomino> dominos = new List<PhysicalDomino> {
                new PhysicalDomino( "1", "0", "", "", "",  0 ),
                new PhysicalDomino( "0", "4", "", "", "",  1 ),
                new PhysicalDomino( "0", "5", "", "", "",  2 ),
                new PhysicalDomino( "0", "3", "", "", "",  3 ),
                new PhysicalDomino( "2", "3", "", "", "",  4 ),
                new PhysicalDomino( "6", "2", "", "", "",  5 ),
                new PhysicalDomino( "6", "6", "", "", "",  6 ),
                new PhysicalDomino( "5", "6", "", "", "",  7 ),
                new PhysicalDomino( "5", "1", "", "", "",  8 ),
                new PhysicalDomino( "1", "1", "", "", "",  9 )
            };

            Regex regexA = new Regex(@"^RFTag(\d+)=(\w+)\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex regexB = new Regex(@"^RFTag(\d+)_INV=(\w+)\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            String line;
            using (FileStream inStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(inStream))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        MatchCollection matches = regexA.Matches(line);
                        foreach (Match match in matches)
                        {
                            int dominoNb = int.Parse(match.Groups[1].Value) - 1;

                            switch (slots[dominoNb].Side)
                            {
                                case SensorSide.A:
                                    dominos[dominoNb].RfidA = match.Groups[2].Value;
                                    break;
                                case SensorSide.B:
                                    dominos[dominoNb].RfidB = match.Groups[2].Value;
                                    break;
                                case SensorSide.C:
                                    dominos[dominoNb].RfidC = match.Groups[2].Value;
                                    break;
                            }
                        }

                        matches = regexB.Matches(line);
                        foreach (Match match in matches)
                        {
                            int dominoNb = int.Parse(match.Groups[1].Value) - 1;

                            switch (slots[dominoNb].Side)
                            {
                                case SensorSide.A:
                                    dominos[dominoNb].RfidB = match.Groups[2].Value;
                                    break;
                                case SensorSide.B:
                                    dominos[dominoNb].RfidA = match.Groups[2].Value;
                                    break;
                            }
                        }
                    }
                }
            }
            return dominos;

        }
    }
}
