
namespace ManajemenTugasAkhirGeologi.Tests;


using ManajemenTugasAkhirGeologi.Service.ErrorFilters;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Inputs;
using ManajemenTugasAkhirGeologi.Service.GraphQL.Students.Services.Implementations;

public class StudentServiceTests : SqliteInMemoryDbTestFixture
{

    [Fact]
    public async Task Upsert_Student_Success()
    {
        var context = CreateContext();
        var _studentService = new StudentService(context);
        var student = await _studentService.Upsert(new StudentInput { Name = "Test", Nim = "123" }, CancellationToken.None);
        Assert.NotNull(student);
    }

    [Fact]
    public async Task Upsert_Student_Failed_Nim_Already_Exist()
    {
        var studentInput = new StudentInput { Name = "Test", Nim = "123" };

        var context = CreateContext();
        var _studentService = new StudentService(context);
        await _studentService.Upsert(studentInput, CancellationToken.None);

        var exception = await Assert.ThrowsAsync<BusinessLogicException>(() => _studentService.Upsert(studentInput, CancellationToken.None));
        Assert.Equal($"NIM {studentInput.Nim} sudah terdaftar. Silahkan daftar mahasiswa lainnya!", exception.Message);
    }
}
