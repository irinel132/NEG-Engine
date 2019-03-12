using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NEG_Engine.Loader.Sprite;
using NEG_Engine.Managers.ManagerAdmin;
using NEG_Engine.Render;
using NEG_Engine.Sprites;

namespace NEG_Engine.Managers.Graphics
{
    class GraphicsManager : IGraphicsManager, IManager, IDisposable
    {
        // 
        public static readonly string   MANAGER_TAG = "GraphicsManager";

        // Internal variables        
        protected   List<ISprite>       _renderList         = null;         // The list of sprites to be rendered
        protected   IRender             _videoRender        = null;         // The actual video renderer
        protected   ISpriteLoader       _spriteLoader       = null;         // The sprite loader
        
        // Constructor
        public GraphicsManager(Form Form, Point Resolution)
        {
            _videoRender = new BasicRender  (Form, Resolution);
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
        }

        public void Tick(long Ticks)
        {
            throw new NotImplementedException();
        }

        // Internal Methods
    }
}
