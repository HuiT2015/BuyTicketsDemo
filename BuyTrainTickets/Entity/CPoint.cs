using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyTrainTickets.Entity
{
    class CPoint
    {
        private double x;
        private double y;

        public CPoint()
        {

        }

        public CPoint(double _x, double _y)
        {
            this.x = _x;
            this.y = _y;
        }

        public double X {
            set { this.x = value; }
            get { return x; }
        }

        public double Y
        {
            set { this.y = value; }
            get { return y; }
        }
    }
}
