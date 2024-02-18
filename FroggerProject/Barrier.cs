using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FroggerProject
{
	class Barrier
	{
		public Animation BarrierAnima;
		public Vector2 Position;
		public bool Active;
        public int Damage;
        public int Way;
		public int Width
		{
			get { return BarrierAnima.FrameWidth; }
		}
		public int Height
		{
			get { return BarrierAnima.FrameHeight; }
		}

		public float BarrierMoveSpeed;

		public void Initialize(Animation animation,Vector2 position,float MoveSpeed, int damage , int way)
		{
			BarrierAnima = animation;
			Position = position;
			Active = true;
			BarrierMoveSpeed = MoveSpeed;
            Damage = damage;
            Way = way;
		}
		public void Update(GameTime gameTime)
		{

            if (Way == 1)
            {
                Position.X += BarrierMoveSpeed;
            }
            else if(Way == 2)
            {
                Position.Y -= BarrierMoveSpeed;
            }

			BarrierAnima.Position = Position;
			BarrierAnima.Update(gameTime);
			if(Position.X < -Width || Position.X > 800 + Width)
			{
				Active = false;
			}
		}
		public void Draw(SpriteBatch spriteBatch)
		{
			BarrierAnima.Draw(spriteBatch);
		}
	}
}
