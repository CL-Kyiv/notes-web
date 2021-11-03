cd ..
cd backend\Notes.WepAPI.Tests
dotnet test --collect:"XPlat Code Coverage"
cd ..
cd Notes.Domain.Services.Tests
dotnet test --collect:"XPlat Code Coverage"
cd ..
cd Notes.Repository.Tests
dotnet test --collect:"XPlat Code Coverage"
pause