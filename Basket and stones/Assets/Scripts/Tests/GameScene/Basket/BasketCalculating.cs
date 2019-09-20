using System.Collections;
using GameScene;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class BasketCalculating
    {
        private Basket basket;
        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            basket = new Basket();
        }
        [TearDown]
        public void Teardown()
        {
            Object.Destroy(basket);
        }
        [UnityTest]
        public IEnumerator BasketCalculateSumm()
        {

            int value = 10;
            char action = '+';
            int stonesBeforeTest = 5;
            basket.CurrentAmountOfStones = stonesBeforeTest;
            int stonesAfterTest = basket.Calculate(action, value, true);
            Assert.AreEqual(stonesBeforeTest + 10, stonesAfterTest);
            yield return null;
        }
        [UnityTest]
        public IEnumerator BasketCalculateProd()
        {
            int value = 10;
            char action = '*';
            int stonesBeforeTest = 5;
            basket.CurrentAmountOfStones = stonesBeforeTest;
            int stonesAfterTest = basket.Calculate(action, value, true);
            Assert.AreEqual(stonesBeforeTest * 10, stonesAfterTest);
            yield return null;
        }
        [UnityTest]
        public IEnumerator BasketCalculateDiff()
        {

            int value = 10;
            char action = '-';
            int stonesBeforeTest = 5;
            basket.CurrentAmountOfStones = stonesBeforeTest;
            int stonesAfterTest = basket.Calculate(action, value, true);
            Assert.AreEqual(stonesBeforeTest - 10, stonesAfterTest);
            yield return null;
        }
        [UnityTest]
        public IEnumerator BasketCalculateDiv()
        {

            int value = 10;
            char action = '/';
            int stonesBeforeTest = 5;
            basket.CurrentAmountOfStones = stonesBeforeTest;
            int stonesAfterTest = basket.Calculate(action, value, true);
            Assert.AreEqual(stonesBeforeTest / 10, stonesAfterTest);
            yield return null;
        }
    }
}
