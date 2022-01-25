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
        public event EventHandler GameRestarted;
        private Regex _Regexp = new Regex(@"^(\d)\s(\w+)\s*$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private string _firstLogLine = "";

        public LogParser(String fileName)
        {
            _fileName = fileName;
        }

        public void Parse()
        {
            List<String> Rfids = Enumerable.Repeat("None", 10).ToList();
            String line;
            bool firstLineProcessed = false;
            try
            {
                using (FileStream inStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var sr = new StreamReader(inStream))
                    {
                        while ((line = sr.ReadLine()) != null)
                        {
                            if (firstLineProcessed == false)
                            {
                                firstLineProcessed = true;
                                if (_firstLogLine != line)
                                {
                                    if (_firstLogLine != "")
                                    {
                                        OnGameRestarted();
                                    }
                                    _firstLogLine = line;
                                }
                            }
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
            } catch (Exception e)
            {
                
            }
        }

        protected virtual void OnGameRestarted()
        {
            EventHandler handler = GameRestarted;
            handler?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnRfidDetected(RfidDetectedEventArgs e)
        {
            EventHandler<RfidDetectedEventArgs> handler = RfidDetected;
            handler?.Invoke(this, e);
        }

        

    }

    public class RfidDetectedEventArgs : EventArgs
    {
        public List<String> Rfids { get; set; }
    }
}

