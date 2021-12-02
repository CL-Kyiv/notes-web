using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using Notes.Domain.Models;
using Notes.Domain.Services.Abstractions;
using Notes.WebAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Notes.WepAPI.Tests
{
    public class NotesControllerTests
    {
        private readonly NotesController _controller;
        private readonly Mock<INoteService> _noteServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<ILogger<NotesController>> _loggerMock;

        public NotesControllerTests()
        {
            _noteServiceMock = new Mock<INoteService>();

            _mapperMock = new Mock<IMapper>();

            _loggerMock = new Mock<ILogger<NotesController>>();

           _controller = new NotesController(_noteServiceMock.Object, _mapperMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetNotes_ReturnsOkStatusCode()
        {
            //Arrange
            var notesFromService = new List<Note>
            {
               new Note(1, "note1", "note1", DateTime.Now),
            };

            _noteServiceMock.Setup(n => n.GetNotesAsync())
                .ReturnsAsync(notesFromService);

            //Act
            var result = await _controller.GetNotes() as OkObjectResult;

            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be((int) HttpStatusCode.OK);
            result.Value.Should().Be(notesFromService);
        }
    }
}
