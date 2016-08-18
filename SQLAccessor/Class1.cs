using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLAccessor
{
    public class Class1
    {
	    public void Test()
	    {
			var s = string.Format("Guid: {o.Guid}");
		}
    }

	public abstract class CTest
	{
		public abstract void Test();
	}

	public class CTestImpl : CTest
	{
		public override void Test()
		{
			RectangleF f = new RectangleF(10, 10, 100, 100);
			PointF p = new PointF(12, 9);
			var listx = new List<float> {10, 110, 110, 10};
			var listy = new List<float> { 10, 10, 110, 110 };
			var tt = Pnpoly(4, listx, listy, p.X, p.Y);
			listx.Find(ff => ff == p.X);
		}

		bool Pnpoly(int nvert, List<float> vertx, List<float> verty, float testx, float testy)
		{
			int i, j = 0;
			bool c = false;
			for (i = 0, j = nvert - 1; i < nvert; j = i++)
			{
				if (((verty[i] > testy) != (verty[j] > testy)) &&
				 (testx < (vertx[j] - vertx[i]) * (testy - verty[i]) / (verty[j] - verty[i]) + vertx[i]))
					c = !c;
			}
			return c;
		}

		
	}
	
}
