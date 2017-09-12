using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeadAnts
{
    [TestClass]
    public class DeadAntsTest
    {
        [TestMethod]
        public void Input_Null_Should_Be_Zero()
        {
            AssertShouldBeAverageString(null, 0);
        }

        [TestMethod]
        public void Input_Ant_Should_Be_Zero()
        {
            AssertShouldBeAverageString("ant", 0);
        }

        [TestMethod]
        public void Input_Ant_Ant_Should_Be_Zero()
        {
            AssertShouldBeAverageString("ant ant", 0);
        }

        [TestMethod]
        public void Input_Ant_Aant_Should_Be_One()
        {
            AssertShouldBeAverageString("ant aant", 1);
        }

        [TestMethod]
        public void Input_Ant_Aant_t_Should_Be_One()
        {
            AssertShouldBeAverageString("ant aant t", 1);
        }

        [TestMethod]
        public void Input_Ant_Anantt_Aantnt_Should_Be_Two()
        {
            AssertShouldBeAverageString("ant anantt aantnt", 2);
        }

        [TestMethod]
        public void Input_Ant_Ant_A_nt_Should_Be_One()
        {
            AssertShouldBeAverageString("ant ant .... a nt", 1);
        }

        private void AssertShouldBeAverageString(string input, int expect)
        {
            var kata = new Kata();
            Assert.AreEqual(expect, kata.DeadAntCount(input));
        }
    }

    public class Kata
    {
        public int DeadAntCount(string antstring)
        {
            if (string.IsNullOrEmpty(antstring)) return 0;
            var ants = antstring.Split(' ');

            var deadantsQuery = from ant in ants
                where ant.ToLower().Replace("ant", "") != ""
                select ant.ToLower().Replace("ant", "").TakeWhile(x => x == 'a').Count();

            return deadantsQuery.Sum();
        }
    }
}