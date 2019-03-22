using NEG_Engine.Factories.Mind;
using NEG_Engine.Factories.Sprite;
using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEG_Engine.Game
{
    class Game
    {
        public Kernel _kernel = null;

        public Game(Kernel Kernel)
        {
            _kernel = Kernel;

            SpriteFactory.GetNewSprite(() => new Obstacle(200, 0, true));
            SpriteFactory.GetNewSprite(() => new Obstacle(200, 200, true));
            SpriteFactory.GetNewSprite(() => new Obstacle(200, 400, true));
            SpriteFactory.GetNewSprite(() => new Obstacle(200, 600, true));

            SpriteFactory.GetNewSprite(() => new Obstacle(1500, 0, false));
            SpriteFactory.GetNewSprite(() => new Obstacle(1500, 200, false));
            SpriteFactory.GetNewSprite(() => new Obstacle(1500, 400, false));
            SpriteFactory.GetNewSprite(() => new Obstacle(1500, 600, false));


            MindFactory.GetNewMind(() => new Player
            (                
                650,
                600,
                new Keys[] 
                {   Keys.W,
                    Keys.S,
                    Keys.A,
                    Keys.D  },
                1
            ));

            MindFactory.GetNewMind(() => new Player
            (
                1100,
                600,
                new Keys[]
                {   Keys.Up,
                    Keys.Down,
                    Keys.Left,
                    Keys.Right  },
                2
            ));

        }
    }
}
