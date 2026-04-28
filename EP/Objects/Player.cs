using EP.Objects;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Objects
{
    internal class Player : BaseObject
    {
        public Action<Marker> OnMarkerOverlap;
        public Action<Enemy> OnEnemyOverlap;
        public float vX, vY;
        public Player(float x, float y, float angle) : base(x, y, angle)
        {
        }

        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.DeepSkyBlue), -15, -15, 30, 30);
            g.DrawEllipse(new Pen(Color.Black, 2), -15, -15, 30, 30);
            g.DrawLine(new Pen(Color.Black, 2), 0, 0, 25, 0);
        }

        public override GraphicsPath getGraphicsPath()
        {
            var path = base.getGraphicsPath();
            path.AddEllipse(-15, -15, 30, 30);
            return path;
        }

        public override void OverLap(BaseObject obj)
        {
            base.OverLap(obj);

            if (obj is Marker)
            {
                OnMarkerOverlap(obj as Marker);
            }
            if (obj is Enemy)
            {
                OnEnemyOverlap(obj as Enemy);
            }
        }
    }
}