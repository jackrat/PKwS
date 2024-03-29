using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02
{
  class Pierwiastki
  {
    public double a;
    public double b;
    public double c;
    public double delta;
    public double[] wyniki;
    public void Oblicz()
    {
      double delta = Math.Pow(b, 2) - 4 * a * c;
      if (delta < 0)
        wyniki = new double[0];
      else if (delta == 0)
      {
        wyniki = new double[1];
        double x0 = -b / (2 * a);
        wyniki[0] = x0;
        //wyniki = new double[] { -b / (2 * a) };
      }
      else
      {
        wyniki = new double[2];
        double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
        double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
        wyniki[0] = x1;
        wyniki[1] = x2;
      }
    }

  }
}
