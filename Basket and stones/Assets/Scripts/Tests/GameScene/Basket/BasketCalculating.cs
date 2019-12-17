using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests.GameScene.Basket
{
    public class BasketCalculating
    {
        private global::GameScene.Basket _basket;

        // A Test behaves as an ordinary method
        [SetUp]
        public void Setup()
        {
            _basket = new global::GameScene.Basket();
        }

        [TearDown]
        public void Teardown()
        {
            Object.Destroy(_basket);
        }

        [UnityTest]
        public IEnumerator BasketCalculateSum()
        {
            const int value = 10;
            const char action = '+';
            const int stonesBeforeTest = 5;
            _basket.CurrentAmountOfStones = stonesBeforeTest;
            var stonesAfterTest = _basket.Calculate(action, value);
            Assert.AreEqual(stonesBeforeTest + 10, stonesAfterTest);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BasketCalculateProd()
        {
            const int value = 10;
            const char action = '*';
            const int stonesBeforeTest = 5;
            _basket.CurrentAmountOfStones = stonesBeforeTest;
            var stonesAfterTest = _basket.Calculate(action, value);
            Assert.AreEqual(stonesBeforeTest * 10, stonesAfterTest);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BasketCalculateDiff()
        {
            const int value = 10;
            const char action = '-';
            const int stonesBeforeTest = 5;
            _basket.CurrentAmountOfStones = stonesBeforeTest;
            var stonesAfterTest = _basket.Calculate(action, value);
            Assert.AreEqual(stonesBeforeTest - 10, stonesAfterTest);
            yield return null;
        }

        [UnityTest]
        public IEnumerator BasketCalculateDiv()
        {
            const int value = 10;
            const char action = '/';
            const int stonesBeforeTest = 5;
            _basket.CurrentAmountOfStones = stonesBeforeTest;
            var stonesAfterTest = _basket.Calculate(action, value);
            Assert.AreEqual(stonesBeforeTest / 10, stonesAfterTest);
            yield return null;
        }
    }
}