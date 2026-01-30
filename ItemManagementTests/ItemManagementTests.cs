using NUnit.Framework;
using Moq;
using ItemManagementApp.Services;
using ItemManagementLib.Repositories;
using ItemManagementLib.Models;
using System.Collections.Generic;
using System.Linq;

namespace ItemManagement.Tests
{
    [TestFixture]
    public class ItemServiceTests
    {
        private Mock<IItemRepository> _mockRepository;
        private ItemService _itemService;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IItemRepository>();
            _itemService = new ItemService(_mockRepository.Object);

        }

        [Test]
        public void AddItem_ShouldCallAddItemOnRepository()
        {
            _itemService.AddItem("Test Item");


            _mockRepository.Verify(repo => repo.AddItem(It.IsAny<Item>()), Times.Once);

        }

        [Test]
        public void GetAllItems_ShouldReturnAllItems()
        {
            var items = new List<Item>
            {
                new Item { Id = 1, Name = "Item 1"},
                new Item { Id = 2, Name = "Item 2"}
            };

            _mockRepository.Setup(repo => repo.GetAllItems()).Returns(items);

            var result = _itemService.GetAllItems();

            Assert.That(result.Count(), Is.EqualTo(items.Count()));
            Assert.That(result, Is.EqualTo(items));

        }

        [Test]
        public void UpdateItem_WhenItemNotFound_ShouldNotCallUpdate()
        {
            _mockRepository.Setup(repo => repo.GetItemById(It.IsAny<int>())).Returns((Item)null);
            _itemService.UpdateItem(99, "Updated Name");

            _mockRepository.Verify(repo => repo.UpdateItem(It.IsAny<Item>()), Times.Never);
        }

        [Test]
        public void ValidateName_WhenNameIsValid_ShouldReturnTrue()
        {
            var result = _itemService.ValidateItemName("Valid Name");

            Assert.That(result, Is.True);

        }
        [Test]
        public void ValidateItemName_WhenNameIsTooLong_ShouldReturnFalse()
        {
            var result = _itemService.ValidateItemName("Valid Name Boyan");

            Assert.That(result, Is.False);

        }
        [Test]
        public void ValidateItemName_WhenNameIsEmpty_ShouldReturnFalse()
        {
            var result = _itemService.ValidateItemName("");

            Assert.That(result, Is.False);

        }
        [Test]
        public void GetItemById_ShouldReturnCorrectItem()
        {
            var item = new Item { Id = 8, Name = "Item 8" };
            _mockRepository.Setup(repo => repo.GetItemById(8)).Returns(item);

            var result = _itemService.GetItemById(8);

            Assert.That(result, Is.EqualTo(item));
        }

    }

}