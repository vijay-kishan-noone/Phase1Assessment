using NUnit.Framework;
using Phase4Assessment.Models;
using System.Collections.Generic;

namespace UnitTestingProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            PizzaBO context = new PizzaBO();
            int expectedValue = 6;
            List<PizzaModel> pizzas = context.GetAllPizzas();
            int actualValue = 0;
            foreach(var p in pizzas)
                actualValue++;
            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void Test2()
        {
            PizzaBO context = new PizzaBO();
            string expectedValue = "Indi Tandoori Paneer";
            var pizza = context.GetPizzaById(5);
            var actualValue = pizza.Name;
            Assert.AreEqual(expectedValue, actualValue);
        }
        [Test]
        public void Test3()
        {
            PizzaBO context = new PizzaBO();
            string expectedValue = "Margherita";
            string actualValue = context.GetPizzaByName(1);
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}