using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DominoSpy
{
    public class LogParser
    {
        private String _fileName;
        public event EventHandler<RfidDetectedEventArgs> RfidDetected;
        private Regex _Regexp = new Regex(@"^(\d)\s(\w+)\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public LogParser(String fileName)
        {
            _fileName = fileName;
        }

        public void Parse()
        {
            List<String> Rfids = Enumerable.Repeat("None", 10).ToList();
            String line;
            using (FileStream inStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(inStream))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        MatchCollection matches = _Regexp.Matches(line);
                        foreach (Match match in matches)
                        {
                            Rfids[int.Parse(match.Groups[1].Value)] = match.Groups[2].Value;
                        }
                    }
                }
            }
            RfidDetectedEventArgs args = new RfidDetectedEventArgs
            {
                Rfids = Rfids
            };
            OnRfidDetected(args);
        }

        protected virtual void OnRfidDetected(RfidDetectedEventArgs e)
        {
            EventHandler<RfidDetectedEventArgs> handler = RfidDetected;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        

    }

    public class RfidDetectedEventArgs : EventArgs
    {
        public List<String> Rfids { get; set; }
    }
}

