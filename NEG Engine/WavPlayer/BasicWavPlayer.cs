using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace NEG_Engine.WavPlayer
{
    class BasicWavPlayer : IWavPlayer
    {
        // Internal Variables
        // Constructor
        public BasicWavPlayer ()
        {

        }
        // Methods
        // Interface methods
        public void PlaySound(SoundPlayer Sound)
        {
            Sound.Play();
        }
    }
}
