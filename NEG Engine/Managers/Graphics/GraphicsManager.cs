using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NEG_Engine.Factories.Sprite;
using NEG_Engine.Loader.Sprite;
using NEG_Engine.Managers.Graphics.Camera;
using NEG_Engine.Managers.ManagerAdmin;
using NEG_Engine.Render;
using NEG_Engine.Sprites;

namespace NEG_Engine.Managers.Graphics
{
    class GraphicsManager : IGraphicsManager, IManager, IDisposable
    {
        // 
        public static readonly  string           MANAGER_TAG     = ClassTags.MANAGER_GRAPHICS;
        public static           ISpriteFactory   SPRITE_FACTORY  = null;

        // Internal variables        
        protected   List<ISprite>       _renderList         = null;         // The list of sprites to be rendered
        protected   IRender             _videoRender        = null;         // The actual video renderer
        protected   ISpriteLoader       _spriteLoader       = null;         // The sprite loader
        protected   ICamera             _camera             = null;         // The game camera

        protected   Point               _resolution;                        // The render resolution


        // Constructor
        public GraphicsManager(Form Form, Point Resolution)
        {
            _resolution     = Resolution;                           // Save the resolution
            _videoRender    = new BasicRender  (Form, Resolution);  // Initialize the Video Renderer

            SPRITE_FACTORY = new SpriteFactory(this);                 // Register the manager to the sprite factory
        }

        
        // Interface Methods
        public IRender VideoRender
        {
            get { return _videoRender;      }
            set { _videoRender = value;     }
        }

        public ISpriteLoader SpriteLoader
        {
            get { return _spriteLoader;     }
            set { _spriteLoader = value;    }
        }

        public Point RenderResolution
        {
            get { return _resolution;   }
            set { _resolution = value;  }
        }

        public bool AddSpriteToRenderList(ISprite Sprite)
        {
            int initialCount = _renderList.Count;       // Check the size of the render list 

            _renderList.Add(Sprite);                    // Add the Sprite to the render list


            // Returns true if the sprite was added to the render list
            return ( (_renderList.Count - initialCount) != 0);
        }

        public void Dispose()
        {
            // Empty the variables
            _renderList     = null;
            _videoRender    = null;
        }

        public void End()
        {
            Dispose();
        }

        public string GetManagerTag()
        {
            return "";
        }

        public bool removeSpriteFromRenderList(ISprite Sprite)
        {
            int initialCount = _renderList.Count;       // Check the size of the render list 

            _renderList.Remove(Sprite);                 // Remove the sprite from the list


            // Returns true if the sprite was removed to the render list
            return ((_renderList.Count - initialCount) == 0);
        }

        public bool removeSpriteFromRenderList(int Index)
        {
            int initialCount = _renderList.Count;       // Check the size of the render list 

            _renderList.RemoveAt(Index);                // Remove the sprite from the list


            // Returns true if the sprite was removed to the render list
            return ((_renderList.Count - initialCount) == 0);
        }

        public void Start(IManagerAdmin ManagerAdmin)
        {
            // Initialize the list
            _renderList     = new List<ISprite>();
            _spriteLoader   = new SpriteLoader();
            _camera         = new BasicCamera(this);
        }

        public void Tick(long Ticks)
        {
            _videoRender.NextFrame();       // Start the next frame            

            foreach (ISprite sprite in _renderList) // Loop every Sprite
            {
                if (_camera.SpriteIsInFrame(sprite))    // if the sprite is inside the camera frame, render it
                    _videoRender.DrawBitmap
                        (
                            _spriteLoader.GetBitmap(sprite.Sprite), 
                            _camera.GetCameraRelativeCoords(sprite),
                            sprite.Scale,
                            sprite.Flipped
                        );                                              // Draw the sprite on screen
            }
        }

        // Internal Methods
    }
}

