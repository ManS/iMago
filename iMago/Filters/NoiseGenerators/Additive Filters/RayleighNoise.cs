using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filters.NoiseGenerators
{
    /// <summary>
    /// 
    /// </summary>
   public class RayleighNoise : IAdditiveRandomNoise
    {
        /// <summary>
        /// Gets or sets a.
        /// </summary>
        /// <value>A.</value>
        public int a { get; private set; }
        /// <summary>
        /// Gets or sets the b.
        /// </summary>
        /// <value>The b.</value>
        public int b { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RayleighNoise"/> class.
        /// </summary>
        /// <param name="p_a">The p_a.</param>
        /// <param name="p_b">The P_B.</param>
        /// <param name="noisePercentage">The noise percentage.</param>
        public RayleighNoise(int p_a, int p_b, double noisePercentage)
            : base(noisePercentage)
        {
            this.a = p_a;
            this.b = p_b;
            this.CalculateProbablity();
        }

        /// <summary>
        /// Calculates the probablity.
        /// </summary>
        protected override void CalculateProbablity()
        {
            Probablity = new List<double>();
            for (int i = 0; i < 256; i++)
            {
                Probablity.Add((2.0 / (b)) * (i - (a)) * Math.Exp(-(Math.Pow(i - (a), 2) / b)));
            }
        }

    }
}
