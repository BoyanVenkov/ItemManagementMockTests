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
            // Arrange: Create a mock instance of IItemRepository
            _mockRepository = new Mock<IItemRepository>();
            _itemService = new ItemService(_mockRepository.Object);
            // Instantiate ItemService with the mocked repository

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

        //[Test]
        //public void UpdateItem_ShouldCallUpdateItemOnRepository()
        //{
        //    //Continue
        //}

        ////Continue
        ///
        [Test]
        public void ValidateName_WhenNameIsValid_ShouldReturnTrue()
        {
            var result = _itemService.ValidateItemName("Valid Name");

            Assert.That(result, Is.True);
        
        }

    }
    
}