using System;
using System.Linq;
using NorthwindKataRepository.Extensions;
using NorthwindKataRepository.Models;
using Xunit;

namespace NorthwindKataRepository.Tests
{
    public class CalculatorHelperTests
    {
        [Theory]
        [InlineData(-1, 1, 1)]
        [InlineData(0, 1, 2)]
        [InlineData(1, 3, 5)]
        public void Test1(params int[] values)
        {
            // Arrange
            var expected = default(int);
            foreach (var value in values)
            {
                expected = expected + value;
            }

            // Action
            var calcHelper = new CalculatorHelper();
            var actual = calcHelper.Add(values);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestSql()
        {
            using (var db = new NorthwindContext())
            {
                var categories = db.Categories
                    .Where(category => category.Products.Any())
                    .OrderByDescending(blog => blog.CategoryId)
                    .Take(5)
                    .Select(blog => blog.CategoryName);

                var sql = categories.ToSql();

                Console.WriteLine(sql);
                Console.WriteLine();

                var categoryNames = categories
                    .AsEnumerable()
                    .Select(name => $"Category Name: {name}");

                foreach (var categoryName in categoryNames)
                {
                    Console.WriteLine(categoryName);
                }
            }
        }
    }
}