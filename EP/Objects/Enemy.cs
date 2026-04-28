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
        public Enemy(float x, float y, float angle) : base(x, y, angle) { }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Pink), -15, -15, 30, 30);
        }

        public override GraphicsPath getGraphicsPath()
        {
            var path = base.getGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }
    }
}