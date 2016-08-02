using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace NamesGenerator.Test {
    [TestClass]
    public class NamesGeneratorTest {
        [TestMethod]
        public void Generate_RandomName() {
            // arrange
            System.Text.NamesGenerator namesGen = new System.Text.NamesGenerator();

            // act
            string generatedName = namesGen.GetRandomName();

            // assert
            Console.WriteLine("Generated Name: {0}", generatedName);
            Assert.IsFalse(String.IsNullOrWhiteSpace(generatedName));
            Assert.IsTrue(Regex.IsMatch(generatedName,
                "(?<left>[a-zA-Z]+)_(?<right>[a-zA-Z]+)",
                RegexOptions.Compiled | RegexOptions.IgnoreCase));
        }

        [TestMethod]
        public void Generate_RandomName_WithRetry() {
            // arrange
            System.Text.NamesGenerator namesGen = new System.Text.NamesGenerator();
            bool retry = true;

            // act
            string generatedName = namesGen.GetRandomName(retry);

            // assert
            Console.WriteLine("Generated Name: {0}", generatedName);
            Assert.IsFalse(String.IsNullOrWhiteSpace(generatedName));
            Assert.IsTrue(Regex.IsMatch(generatedName,
                "(?<left>[a-zA-Z]+)_(?<right>[a-zA-Z]+)(?<retryCount>[0-9]{1,2})",
                RegexOptions.Compiled | RegexOptions.IgnoreCase));
        }

        [TestMethod]
        public void Generate_100_RandomNames() {
            // arrange
            System.Text.NamesGenerator namesGen = new System.Text.NamesGenerator();
            Dictionary<string, string> generatedNames = new Dictionary<string, string>();
            int collisionCount = 0;

            // act
            for (int i = 0; i < 100; i++) {
                string generatedName = namesGen.GetRandomName();
                if (generatedNames.ContainsKey(generatedName)) {
                    collisionCount++;
                    continue;
                }
                generatedNames.Add(generatedName, generatedName);
            }

            // assert
            Console.WriteLine("Generated Names (Total {0} names): {1}",
                generatedNames.Count, String.Join(", ", generatedNames.Keys));
            Console.WriteLine("Collision Count: {0}", collisionCount);
            Assert.IsTrue(collisionCount < 5);
        }
    }
}
