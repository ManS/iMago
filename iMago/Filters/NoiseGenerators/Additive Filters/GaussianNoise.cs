using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
   public class GaussianNoise : IAdditiveRandomNoise
    {
       public double Sigma { get; private set; }
       public double Mu { get; private set; }

       public GaussianNoise(double sigma, double mu, double noisePercentage)
           :base(noisePercentage)
       {
           this.Sigma = sigma;
           this.Mu = mu;
           this.CalculateProbablity();
       }


       protected override void CalculateProbablity()
       {
           Probablity = new List<double>();
           for (int i = 0; i < 256; i++)
           {
               Probablity.Add((1 / (Math.Sqrt(2 * Math.PI) * Sigma)) * (Math.Exp(-Math.Pow((i - Mu), 2) / (2 * Sigma * Sigma))));
           }
       }
    }
}
