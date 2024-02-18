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
	class Animation
	{
        int currentFrameHeight;
        float scale;

		public int currentFrameWidth;
		public int elapsedTime;
		public int frameTime;
		public int frameCount; //จำนวนภาพ
		Color color;
        public Texture2D spriteStrip;
        Rectangle sourceRect = new Rectangle(); //กรอบสี่เหลี่ยม
		Rectangle destinationRect = new Rectangle(); //ตำแหน่งที่จะวาดบนจอ

		public int FrameWidth;
		public int FrameHeight;

		public bool Active;
		public bool Looping; //เอาไว้บอกว่าทำเป็นลูปหรือทำรอบเดียว
		public bool Photo;

		public Vector2 Position;
		public void Initialize(Texture2D texture, Vector2 position, int frameWidth, int frameHeight,int frameCount, int frameTime, Color color, float scale, bool looping, bool photo)
		{
			this.color = color; //อ้างถึงตัวข้างนอก บอกว่าไม่ใช่ของใน init..
			this.FrameWidth = frameWidth;
			this.FrameHeight = frameHeight;
			this.frameCount = frameCount;
			this.frameTime = frameTime;
			this.scale = scale;

			Photo = photo;
			Looping = looping;
			Position = position;
			spriteStrip = texture;

			elapsedTime = 0;
			currentFrameWidth = (int)Position.X;
			currentFrameHeight = (int)Position.Y;

			Active = true;

		}
		public void Update(GameTime gameTime)
		{
			if (Active == false)
			{ return; } //return คือ ไม่ทำต่อแล้ว หลุดออกจากฟังชั่นนี้เลย

			elapsedTime += (int)gameTime.TotalGameTime.TotalMilliseconds;

			if (elapsedTime % frameTime == 0 && Photo == false)
			{
				currentFrameWidth++; //เปลี่ยนรูปเป็นรูปที่ 1 2 3 4
				if (currentFrameWidth >= frameCount)
				{
					currentFrameWidth = 0;//เปลี่ยนไปใช้รูปแรก
					if (Looping == false)
					{ Active = false; }
				}
			}
			elapsedTime = 0;
			if (Photo)
			{
				sourceRect = new Rectangle(currentFrameWidth, currentFrameHeight, FrameWidth, FrameHeight);
			}
			else if (Photo == false)
			{
				sourceRect = new Rectangle(currentFrameWidth * FrameWidth, currentFrameHeight, FrameWidth, FrameHeight); //เหมือนว่าเลื่อนค่าXไปเลื่อยๆตามรูป
			}
			destinationRect = new Rectangle((int)Position.X - (int)(FrameWidth * scale) / 2, (int)Position.Y - (int)(FrameHeight * scale) / 2, (int)(FrameWidth ), (int)(FrameHeight)); //ตำแหน่งที่จะปรากฎบนจอ
		}

        public void Draw(SpriteBatch spriteBatch)
		{
			if (Active)
			{
				spriteBatch.Draw(spriteStrip, destinationRect, sourceRect, color);
			}
		}
	}
}
