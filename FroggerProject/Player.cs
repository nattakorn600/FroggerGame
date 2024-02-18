
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace FroggerProject
{
	class Player
	{
		public Vector2 Position;
		public bool Active;
		public int Live;
        public int Health;
		public Animation PlayerAnimation;
		public int Width
		 {
			 get { return PlayerAnimation.FrameWidth; }
		 }
		 public int Height
		 {
			 get { return PlayerAnimation.FrameHeight; }
		 }

		public void Initialize(Animation animation, Vector2 position , int live , int health)
		{
			PlayerAnimation = animation;
			Position = position;
			Active = true;
			Live = live;
            Health = health;
		}
		public void Update(GameTime gameTime)
		{
            if (Active)
            {
                PlayerAnimation.Position = Position;
                PlayerAnimation.Update(gameTime);
            }
		}
		public void Draw(SpriteBatch spriteBatch)
		{
            if (Active)
            {
                PlayerAnimation.Draw(spriteBatch);
            }
		}
	}
}
