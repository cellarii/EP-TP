using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Objects
{
    internal class BaseObject
    {
        public float X;
        public float Y;
        public float Angle;
        public Action<BaseObject, BaseObject> OnOverlap;

        public BaseObject(float x, float y, float angle)
        {
            this.X = x;
            this.Y = y;
            this.Angle = angle;
        }

        public Matrix getTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);
            return matrix;
        }

        public virtual void Render(Graphics g)
        {
        }

        public virtual GraphicsPath getGraphicsPath()
        {
            return new GraphicsPath();
        }

        public virtual bool overlaps(BaseObject obj, Graphics g)
        {
            var path1 = this.getGraphicsPath();
            var path2 = obj.getGraphicsPath();

            path1.Transform(this.getTransform());
            path2.Transform(obj.getTransform());

            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }

        public virtual void OverLap(BaseObject obj)
        {
            if (this.OnOverlap != null)
            {
                this.OnOverlap(this, obj);
            }
        }
    }
}