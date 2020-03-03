using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    public abstract class CollisionSprite : Sprite
    {
        public static CollisionManager collisionManager { get; private set; }
        public static void Init(CollisionManager cm) {
            collisionManager = cm;
        }
        public List<CollisionSprite> CollidingBodies { get; set; } = new List<CollisionSprite>();

        public CollisionSprite()
        {
        }



  
    }
}
