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
                                                                                    new Point(1, 1),
                                                                                    false,
                                                                                    0
                                                                                    ));
            _hitbox = Factories.Hitbox.HitboxFactory.GetHitbox(() => new TestTrigger(
                                                                                    _location,
                                                                                    new Point (256, 256)
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
            switch (e.KeyCode)
            {
                case Keys.W:
                    _location.Y -= _speed.Y;
                    break;
                case Keys.S:
                    _location.Y += _speed.Y;
                    break;
                case Keys.A:
                    _location.X -= _speed.X;
                    break;
                case Keys.D:
                    _location.X += _speed.X;
                    break;
            }
        }

        #endregion
    }
}
