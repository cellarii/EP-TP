using EP.Objects;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Objects
{
    internal class Enemy : BaseObject
    {
        public float currentRadius;
        public float speed = 0.2f;
        Random random = new Random();
        public Action<Enemy> EnemyDisappeared;

        public Enemy(float x, float y, float angle) : base(x, y, angle)
        {
            currentRadius = random.Next(10, 23);
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Pink), -currentRadius, -currentRadius, currentRadius*2, currentRadius*2);
        }

        public override GraphicsPath getGraphicsPath()
        {
            var path = base.getGraphicsPath();
            path.AddEllipse(-currentRadius, -currentRadius, currentRadius * 2, currentRadius * 2);
            return path;
        }

        public void ReduceSize()
        {
            currentRadius -= speed;
            if (currentRadius <= 0)
            {
                EnemyDisappeared(this);
            }
        }

        public void respawn(int x, int y)
        {
            this.X = x;
            this.Y = y;
            currentRadius = random.Next(10, 23);
        }
    }
}