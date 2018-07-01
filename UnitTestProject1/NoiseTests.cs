using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Noise;

namespace UnitTestProject1
{
    [TestClass]
    public class NoiseTests
    {
        #region Value Noise Tests

        [TestMethod]
        public void ValueNoise_Linear_test()
        {
            float val1 = T1(0.0f, 0.0f, Interp.Linear);
            Assert.AreEqual(-0.06701785f, val1, 0.00000001f);

            float val2 = T2(0.0f, 0.0f, FastNoise.Interp.Linear);
            Assert.AreEqual(-0.06701785f, val2, 0.00000001f);

            Assert.AreEqual(val1, val2, 0.00000001f);
        }

        [TestMethod]
        public void ValueNoise_Quintic_test()
        {
            float val1 = T1(0.0f, 0.0f, Interp.Quintic);
            Assert.AreEqual(-0.06701785f, val1, 0.00000001f);

            float val2 = T2(0.0f, 0.0f, FastNoise.Interp.Quintic);
            Assert.AreEqual(-0.06701785f, val2, 0.00000001f);

            Assert.AreEqual(val1, val2, 0.00000001f);
        }

        [TestMethod]
        public void ValueNoise_Hermite_test()
        {
            float val1 = T1(0.0f, 0.0f, Interp.Hermite);
            Assert.AreEqual(-0.06701785f, val1, 0.00000001f);

            float val2 = T2(0.0f, 0.0f, FastNoise.Interp.Hermite);
            Assert.AreEqual(-0.06701785f, val2, 0.00000001f);

            Assert.AreEqual(val1, val2, 0.00000001f);
        }

        [TestMethod]
        public void Comparison_Value_Linear()
        {
            Comparison(Interp.Linear, FastNoise.Interp.Linear);
        }

        [TestMethod]
        public void Comparison_Value_Quintic()
        {
            Comparison(Interp.Quintic, FastNoise.Interp.Quintic);
        }

        [TestMethod]
        public void Comparison_Value_Hermite()
        {
            Comparison(Interp.Hermite, FastNoise.Interp.Hermite);
        }

        private void Comparison(Interp interp1, FastNoise.Interp interp2)
        {
            for (float y = 0.0f; y < 32.0f; ++y)
            {
                for (float x = 0.0f; x < 32.0f; ++x)
                {
                    float val1 = T1(x, y, interp1);
                    float val2 = T2(x, y, interp2);

                    Assert.AreEqual(val1, val2, 0.00000001f, $"X: {x}, Y: {y} are not equal.");
                }
            }
        }

        private float T1(float x, float y, Interp interp)
        {
            var valueNoise = new ValueNoise();
            float val = valueNoise.GetNoise(x, y, interp);

            Console.WriteLine($"My NoiseValue  : {val} for X:{x},Y:{y}");

            return val;
        }

        private float T2(float x, float y, FastNoise.Interp interp)
        {
            var fastNoise = new FastNoise();
            fastNoise.SetNoiseType(FastNoise.NoiseType.Value);
            fastNoise.SetInterp(interp);
            float val = fastNoise.GetNoise(x, y);

            Console.WriteLine($"Fast NoiseValue: {val} for X:{x},Y:{y}");

            return val;
        }

        [TestMethod]
        public void ValueNoise3d_Linear_test()
        {
            var valueNoise = new ValueNoise();
            float val = valueNoise.GetNoise(0.0f, 0.0f, 0.0f, Interp.Linear);

            Console.WriteLine($"NoiseValue: {val}"); // -0.06701785

            Assert.AreEqual(-0.06701785f, val, 0.00000001f);
        }

        [TestMethod]
        public void ValueNoise3d_Quintic_test()
        {
            var valueNoise = new ValueNoise();
            float val = valueNoise.GetNoise(0.0f, 0.0f, 0.0f, Interp.Quintic);

            Console.WriteLine($"NoiseValue: {val}"); // -0.06701785

            Assert.AreEqual(-0.06701785f, val, 0.00000001f);
        }

        [TestMethod]
        public void ValueNoise3d_Hermite_test()
        {
            var valueNoise = new ValueNoise();
            float val = valueNoise.GetNoise(0.0f, 0.0f, 0.0f, Interp.Hermite);

            Console.WriteLine($"NoiseValue: {val}"); // -0.06701785

            Assert.AreEqual(-0.06701785f, val, 0.00000001f);
        }

        #endregion

        #region Perlin Noise Tests

        [TestMethod]
        public void PerlinNoise_Linear_test()
        {
            var perlinNoise = new PerlinNoise();
            float val = perlinNoise.GetNoise(0.0f, 0.0f, Interp.Linear);

            Console.WriteLine($"NoiseValue: {val}"); // 0.0

            Assert.AreEqual(0.0f, val, 0.00000001f);
        }

        [TestMethod]
        public void PerlinNoise_Quintic_test()
        {
            var perlinNoise = new PerlinNoise();
            float val = perlinNoise.GetNoise(0.0f, 0.0f, Interp.Quintic);

            Console.WriteLine($"NoiseValue: {val}"); // 0.0

            Assert.AreEqual(0.0f, val, 0.00000001f);
        }

        [TestMethod]
        public void PerlinNoise_Hermite_test()
        {
            var perlinNoise = new PerlinNoise();
            float val = perlinNoise.GetNoise(0.0f, 0.0f, Interp.Hermite);

            Console.WriteLine($"NoiseValue: {val}"); // 0.0

            Assert.AreEqual(0.0f, val, 0.00000001f);
        }

        [TestMethod]
        public void PerlinNoise3d_Linear_test()
        {
            var perlinNoise = new PerlinNoise();
            float val = perlinNoise.GetNoise(0.0f, 0.0f, 0.0f, Interp.Linear);

            Console.WriteLine($"NoiseValue: {val}"); // 0.0

            Assert.AreEqual(0.0f, val, 0.00000001f);
        }

        [TestMethod]
        public void PerlinNoise3d_Quintic_test()
        {
            var perlinNoise = new PerlinNoise();
            float val = perlinNoise.GetNoise(0.0f, 0.0f, 0.0f, Interp.Quintic);

            Console.WriteLine($"NoiseValue: {val}"); // 0.0

            Assert.AreEqual(0.0f, val, 0.00000001f);
        }

        [TestMethod]
        public void PerlinNoise3d_Hermite_test()
        {
            var perlinNoise = new PerlinNoise();
            float val = perlinNoise.GetNoise(0.0f, 0.0f, 0.0f, Interp.Hermite);

            Console.WriteLine($"NoiseValue: {val}"); // 0.0

            Assert.AreEqual(0.0f, val, 0.00000001f);
        }

        #endregion

    }
}