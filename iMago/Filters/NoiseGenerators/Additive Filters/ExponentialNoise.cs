using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Utilities;

namespace Filters.NoiseGenerators
{
    public class ExponentialNoise : IAdditiveRandomNoise
    {
        public double a { get; private set; }

        public ExponentialNoise(double p_a, double noisePercentage)
            : base(noisePercentage)
        {
            this.a = p_a;
            this.CalculateProbablity();
        }

        protected override void CalculateProbablity()
        {
            Probablity = new List<double>();
            for (int i = 0; i < 256; i++)
            {
                Probablity.Add(a * Math.Exp(-(a) * i));
            }
        }
    }
}
