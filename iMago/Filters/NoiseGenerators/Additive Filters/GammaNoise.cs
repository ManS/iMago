using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
   public class GammaNoise : IAdditiveRandomNoise
    {
        public int a { get; private set; }
        public int b { get; private set; }

        public GammaNoise(int p_a, int p_b, double noisePercentage)
            : base(noisePercentage)
        {
            this.a = p_a;
            this.b = p_b;
            this.CalculateProbablity();
        }

        protected override void CalculateProbablity()
        {
            Probablity = new List<double>();
            double fact = 1;
            for (int j = 1; j < b; j++)
                fact *= j;

            for (int i = 0; i < 256; i++)
            {
                Probablity.Add(((Math.Pow(a, b) * Math.Pow(i, (b) - 1)) / fact) * Math.Exp(-(a) * i));
            }
        }
    }
}
