using Lap;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<infomationDbContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("DBconnet")));
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var context = services.GetRequiredService<infomationDbContext>();

        // Tạo một đối tượng Infomation và thêm vào context
        var info = new Lap.Information()
        {
            Name = "San",
            Licener = "SanNHT",
            Datetime = "7/10/2024",
            Revennue = "1000"
        };

        context.Infomations.Add(info);

        // Lưu thay đổi vào cơ sở dữ liệu
        context.SaveChanges();
    }
    catch (Exception ex)
    {
        // Xử lý ngoại lệ nếu có
        Console.WriteLine($"Lỗi xảy ra: {ex.Message}");
    }
}
app.MapGet("/", () => "Đã thêm!");

app.Run();
