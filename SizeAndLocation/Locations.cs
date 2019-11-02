using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SizeAndLocation
{
    public class Locations
    {
        Size _size;
        public Point _OdjectLocation;
        public Locations(Size FormSize, Point OdjectLocation)
        {
            _size = new Size(FormSize.Width, FormSize.Height);
            _OdjectLocation = OdjectLocation;
        }

        public void SetLocation(Size FormSize, double XNum, double YNum)
        {
            double x = FormSize.Width - _size.Width;
            double y = FormSize.Height - _size.Height;
            if (XNum != 0)
            {
                _OdjectLocation.X = Convert.ToInt32((double)_OdjectLocation.X + (x / XNum));
            }
            if (YNum != 0)
            {
                _OdjectLocation.Y = Convert.ToInt32((double)_OdjectLocation.Y + (y / YNum));
            }
            _size = new Size(FormSize.Width, FormSize.Height);
        }
    }
}
