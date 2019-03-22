using NEG_Engine.Hitbox;
using NEG_Engine.Input;
using NEG_Engine.Sprites;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NEG_Engine.Mind
{
    class TestMind : AbstractMind, IDisposable, IInputListener
    {
        #region Variables
        protected           ISprite     _sprite     = null;
        protected           IHitbox     _hitbox     = null;
        protected           Point       _location;

        protected   static  Point       _speed      = new Point(5, 5);   

        #endregion

        public TestMind (int X, int Y )
        {
            MIND_TAG = "TestMind";

            _location = new Point(X, Y);

            _sprite = Factories.Sprite.SpriteFactory.GetNewSprite(() => new TestSprite(
                                                                                    1,
                                                                                    _location,
                                                                                    .25f,
                                                                                    true,
                                                                                    0
                                                                                    ));
            _hitbox = Factories.Hitbox.HitboxFactory.GetHitbox(() => new TestTrigger(
                                                                                    _location,
                                                                                    new Point ((int) (256 * .25f), (int) (256 * .25f))
                                                                                    ));

            InputHandler.Instance.Subscribe(this);
        }

        public void Dispose()
        {
            _sprite = null;          
        }

        #region Inherited methods

        public override void Tick(long Tick)
        {
            _sprite.Position    = _location;
            _hitbox.Origin      = _location;
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.W)) { _location.Y -= _speed.Y; }
            if (e.KeyCode.Equals(Keys.S)) { _location.Y += _speed.Y; }
            if (e.KeyCode.Equals(Keys.A)) { _location.X -= _speed.X; }
            if (e.KeyCode.Equals(Keys.D)) { _location.X += _speed.X; }
        }

        #endregion
    }
}
