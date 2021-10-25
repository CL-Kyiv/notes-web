using Moq;
using Notes.Domain.Services.Abstractions;
using Notes.Repository.Abstractions.Repositories;
using System;
using Notes.Domain.Services;
using System.Threading.Tasks;
using Xunit;
using Notes.Domain.Models;
using System.Collections.Generic;
using FluentAssertions;

namespace Notes.Domain.Services.Tests
{
    public class NoteServiceTests
    {
        private readonly Mock<INoteRepository> _noteRepositoryMock = new Mock<INoteRepository>();
        private readonly NoteService _service;

        public NoteServiceTests()
        {
            _noteRepositoryMock = new Mock<INoteRepository>();

            _service = new NoteService(_noteRepositoryMock.Object);
        }

        [Fact]
        public async Task GetNotes_ReturnsNotes()
        {
            // Arrange
            var notesFromRepository = new List<Note>
            {
               new Note(1, "note1", "note1", DateTime.Now),
            };

            _noteRepositoryMock.Setup(n => n.GetNotesAsync())
                .ReturnsAsync(notesFromRepository);

            // Act
            var result = await _service.GetNotesAsync();

            // Assert
            result.Should().HaveCount(1);
            _noteRepositoryMock.Verify(_ => _.GetNotesAsync(), Times.Once);
        }
    }
}
