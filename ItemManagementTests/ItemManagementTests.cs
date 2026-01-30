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
            // Arrange: Setup mock repository to return a list of items


            // Act: Call GetAllItems on the service


            // Assert: Check that the result matches the mock data

        }

        [Test]
        public void UpdateItem_ShouldCallUpdateItemOnRepository()
        {
            //Continue
        }

        //Continue
    }
}