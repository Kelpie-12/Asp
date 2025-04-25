using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolApplicationHW
{
    class MusicPlayer
    {
        ILogger _logger;
        IMusic _music;
        public MusicPlayer(ILogger log,IMusic mus)
        {
            _logger = log;
            _music = mus;
        }
        public void PlayMusic()
        {
            Console.WriteLine($"{_logger.Log(_music.GetGenge())} playing...");
        }
    }
}
