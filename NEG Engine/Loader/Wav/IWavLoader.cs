using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;

namespace NEG_Engine.Loader.Wav
{
    interface IWavLoader
    {
        SoundPlayer GetWav (int Index);
    }
}
