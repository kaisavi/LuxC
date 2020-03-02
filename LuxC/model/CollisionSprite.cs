using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxC.model
{
    public abstract class CollisionSprite : Sprite
    {
        protected readonly CollisionManager collisionManager;

        public List<CollisionSprite> CollidingBodies { get; set; } = new List<CollisionSprite>();

        public CollisionSprite(CollisionManager collisionManager)
        {
            this.collisionManager = collisionManager;
        }



  
    }
}
