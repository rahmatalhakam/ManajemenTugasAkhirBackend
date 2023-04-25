using System;
using System.Data.Common;
using System.Linq;
using ManajemenTugasAkhirGeologi.Service.Commons.Models;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Users.Services.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class SqliteInMemoryDbTestFixture : IDisposable
{
    private readonly DbConnection _connection;
    private readonly DbContextOptions<AppDbContext> _contextOptions;
    private readonly Mock<IUserService> _userServiceMock;

    #region ConstructorAndDispose
    public SqliteInMemoryDbTestFixture()
    {
        // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
        // at the end of the test (see Dispose below).
        _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();

        // These options will be used by the context instances in this test suite, including the connection opened above.
        _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(_connection)
            .Options;

        // Create the schema and seed some data
        _userServiceMock = new Mock<IUserService>();
        using var context = new AppDbContext(_userServiceMock.Object, _contextOptions);
        context.Database.EnsureCreated();
    }

    protected AppDbContext CreateContext() => new AppDbContext(_userServiceMock.Object, _contextOptions);

    public void Dispose() => _connection.Dispose();
    #endregion

}