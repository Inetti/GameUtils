using GameUtils.Items;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BR.Tests.Utils.Items {
    class ItemStorageTests {
        ItemsStorage<IItem> storage;
        int lowItemsSize;
        Mock<IItem> item;
        Mock<IItem> unexistedItem;
        Mock<IItem> lowItem;
        Mock<IItem> bigItem;
        int numberOfItem;
        int itemInStorageSize;

        [SetUp]
        public void Setup() {
            int storageSize = 10;
            storage = new ItemsStorage<IItem>(storageSize);
            itemInStorageSize = 2;
            numberOfItem = 3;
            lowItemsSize = 1;

            item = new Mock<IItem>();
            item.Setup(x => x.Name).Returns("itemInStorage");
            item.Setup(x => x.Size).Returns(itemInStorageSize);
            item.Setup(x => x.Copy()).Returns(item.Object);
            storage.AddItem(item.Object, numberOfItem);

            lowItem = new Mock<IItem>();
            lowItem.Setup(x => x.Name).Returns("LowItem");
            lowItem.Setup(x => x.Size).Returns(lowItemsSize);

            bigItem = new Mock<IItem>();
            bigItem.Setup(x => x.Name).Returns("BigItem");
            bigItem.Setup(x => x.Size).Returns(storageSize + 1);

            unexistedItem = new Mock<IItem>();
            unexistedItem.Setup(x => x.Name).Returns("UnxestedItem");
            unexistedItem.Setup(x => x.Size).Returns(1);    
        }

        [Test]
        public void AddItem_should_return_true_for_lowItem_and_one() {
            //arrange
            bool expectedValue = true;

            //act
            bool actualValue = storage.AddItem(lowItem.Object, 1);

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddItem_should_decrease_FreeSpace_by_lowItemsSize_for_lowItem_and_one() {
            //arrange
            int expectedValue = storage.FreeSpace - lowItemsSize;

            //act
            storage.AddItem(lowItem.Object, 1);
            int actualValue = storage.FreeSpace;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddItem_should_decrease_FreeSpace_by_two_lowItemsSize_for_lowItem_and_two() {
            //arrange
            int expectedValue = storage.FreeSpace - lowItemsSize * 2;

            //act
            storage.AddItem(lowItem.Object, 2);
            int actualValue = storage.FreeSpace;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void AddItem_should_return_false_for_bigItem_and_one() {
            //arrange
            bool expectedValue = false;

            //act
            bool actualValue = storage.AddItem(bigItem.Object, 1);

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void FreeSpace_should_still_same_after_AddItem_for_bigItem_and_one() {
            //arrange
            int expectedValue = storage.FreeSpace;

            //act
            storage.AddItem(bigItem.Object, 1);
            int actualValue = storage.FreeSpace;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GetItems_should_return_array_with_one_size_for_item_and_one() {
            //arrange
            int expectedValue = 1;            

            //act
            int actualValue = storage.GetItems(item.Object.Name, 1).Length;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }


        [Test]
        public void GetItems_should_return_array_with_numberOfItems_size_for_item_and_numberOfItem() {
            //arrange
            int expectedValue = numberOfItem;

            //act
            int actualValue = storage.GetItems(item.Object.Name, numberOfItem).Length;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GetItems_should_return_array_with_zero_size_for_item_and_numberOfItem_plus_one() {
            //arrange
            int expectedValue = 0;

            //act
            int actualValue = storage.GetItems(item.Object.Name, numberOfItem + 1).Length;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GetItems_should_return_zero_elemens_array_for_unexistedItemName() {
            //arrange
            int expectedValue = 0;

            //act
            int actualValue = storage.GetItems(unexistedItem.Object.Name, 1).Length;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void GetItems_should_increase_FreeSpace_by_mul_of_itemInStorageSize_and_size_of_returned_array() {
            //arrange
            int expectedValue = storage.FreeSpace;

            //act
            expectedValue += itemInStorageSize * storage.GetItems(item.Object.Name, 1).Length;
            int actualValue = storage.FreeSpace;

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Contains_should_return_true_for_itemInStorageName() {
            //arrange
            bool expectedValue = true;

            //act
            bool actualValue = storage.Contains(item.Object.Name);

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void Contains_should_return_false_for_unexistedItemName() {
            //arrange
            bool expectedValue = false;

            //act
            bool actualValue = storage.Contains(unexistedItem.Object.Name);

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ItemCount_should_return_zero_for_unexistedItemName() {
            //arrange
            int expectedValue = 0; 

            //act
            int actualValue = storage.ItemCount(unexistedItem.Object.Name);

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        public void ItemCount_should_return_numberOfItem_for_item() {
            //arrange
            int expectedValue = numberOfItem;

            //act
            int actualValue = storage.ItemCount(item.Object.Name);

            //assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
