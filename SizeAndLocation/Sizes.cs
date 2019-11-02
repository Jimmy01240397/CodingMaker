using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace SizeAndLocation
{
    public class Sizes
    {
        Size _size;
        public Size _OdjectSize;
        public Sizes(Size FormSize, Size OdjectSize)
        {
            _size = new Size(FormSize.Width, FormSize.Height);
            _OdjectSize = OdjectSize;
        }

        public void SetSize(Size FormSize, double XNum, double YNum)
        {
            double x = FormSize.Width - _size.Width;
            double y = FormSize.Height - _size.Height;
            if (XNum != 0)
            {
                _OdjectSize.Width = Convert.ToInt32((double)_OdjectSize.Width + (x / XNum));
            }
            if (YNum != 0)
            {
                _OdjectSize.Height = Convert.ToInt32((double)_OdjectSize.Height + (y / YNum));
            }
            _size = new Size(FormSize.Width, FormSize.Height);
        }
    }
}
