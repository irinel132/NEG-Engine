using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace NEG_Engine.Mind
{
    class TestMind : AbstractMind, IDisposable
    {
        #region Variables
        protected ISprite   _testSprite = null;

        #endregion

        public TestMind (int X, int Y )
        {
            MIND_TAG = "TestMind";

            _testSprite = Factories.Sprite.SpriteFactory.GetNewSprite(() => new TestSprite(
                                                                                    1,
                                                                                    new Point(X, Y),
                                                                                    new Point(1, 1),
                                                                                    false,
                                                                                    0
                                                                                    ));
        }

        public void Dispose()
        {
            _testSprite = null;          
        }

        #region Inherited methods

        public override void Tick(long Tick)
        {
            _testSprite.Position = new Point((int) Tick, (int) Tick);
        }

        #endregion
    }
}
