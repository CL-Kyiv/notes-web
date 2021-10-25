using FluentAssertions;
using Notes.Repository.Entities;
using Notes.Repository.Extensions;
using System;
using Xunit;

namespace Notes.Repository.Tests.Mappings
{
    public class NoteMappingTests
    {
        [Fact]
        public void ToDomainModel_Test()
        {
            var tc = new NoteEntity
            {
               id = 1,
               title = "note1",
               body = "note1",
               created_date = DateTime.Now
            };

            // Act
            var result = tc.ToDomainModel();

            // Assert
            result.Id.Should().Be(tc.id);
            result.Title.Should().Be(tc.title);
            result.Body.Should().Be(tc.body);
            result.CreatedDate.Should().Be(tc.created_date);
        }
    }
}
