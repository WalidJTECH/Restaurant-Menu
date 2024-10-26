
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace RestaurantTests
{
    [TestFixture]
    public class MenuTests
    {
        private Menu _menu;
        private MenuItem _item1;
        private MenuItem _item2;
        private MenuItem _item3;

        [SetUp]
        public void Setup()
        {
            
            _menu = new Menu();
            _item1 = new MenuItem("Parisien Cheese", "Warm ricotta cheese, olives, tomato confit, crostini", 13.00m, "Appetizer", false);
            _item2 = new MenuItem("Salmon", "Potato-crusted salmon with lemon beurre blanc", 28.00m, "Main Course", true);
            _item3 = new MenuItem("Chocolate Mousse Cake", "It's just cake, man", 10.00m, "Dessert", false);
        }

        [Test]
        public void AddItem_ShouldAddMenuItemToMenu()
        {
            
            _menu.AddItem(_item1);

            
            Assert.AreEqual(1, _menu.Items.Count);
            Assert.AreEqual(_item1, _menu.Items[0]);
        }

        [Test]
        public void LastUpdated_ShouldUpdateWhenItemAdded()
        {
            
            DateTime beforeAdding = DateTime.Now;
            _menu.AddItem(_item1);
            DateTime afterAdding = _menu.LastUpdated;

            Assert.IsTrue(afterAdding > beforeAdding);
        }

        [Test]
        public void DisplayMenu_ShouldContainAllMenuItems()
        {
            
            _menu.AddItem(_item1);
            _menu.AddItem(_item2);
            _menu.AddItem(_item3);

            
            Assert.AreEqual(3, _menu.Items.Count);
        }

        [Test]
        public void AddItem_ShouldSetIsNewFlagCorrectly()
        {
            
            _menu.AddItem(_item2);

            
            Assert.IsTrue(_menu.Items[0].IsNew);
        }

        [Test]
        public void AddItem_ShouldNotAllowDuplicateItems()
        {
           
            _menu.AddItem(_item1);
            _menu.AddItem(_item1);

           
            Assert.AreEqual(1, _menu.Items.Count);
        }

        [Test]
        public void RemoveItem_ShouldRemoveMenuItemFromMenu()
        {
            
            _menu.AddItem(_item1);
            _menu.RemoveItem(_item1);

            
            Assert.AreEqual(0, _menu.Items.Count);
        }

        [Test]
        public void UpdateItem_ShouldModifyMenuItemDetails()
        {
            
            _menu.AddItem(_item1);
            var updatedItem = new MenuItem("Parisien Cheese", "Updated description", 15.00m, "Appetizer", false);

           
            _menu.UpdateItem(updatedItem);

           
            Assert.AreEqual("Updated description", _menu.Items[0].Description);
            Assert.AreEqual(15.00m, _menu.Items[0].Price);
        }

        [Test]
        public void DisplayMenu_ShouldHandleEmptyMenu()
        {
            
            Assert.DoesNotThrow(() => _menu.DisplayMenu());
        }

        [Test]
        public void AddItem_ShouldNotAcceptInvalidPrice()
        {
           
            var invalidItem = new MenuItem("Invalid Item", "Invalid price", -5.00m, "Appetizer", false);

           
            Assert.Throws<ArgumentException>(() => _menu.AddItem(invalidItem));
        }
    }
}
