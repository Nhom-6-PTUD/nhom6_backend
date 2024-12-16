using CHIC_CHARM2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CHIC_CHARM2.Areas.Admin.Controllers
{
  [Area("Admin")] //*Xác định phân vùng của Admin
    [Route("Admin")]  //*Xác định route chính là "Admin" cho tất cả các action trong controller này
    [Route("Admin/Homeadmin")] //*Bổ sung route cụ thể hơn là "Admin/Homeadmin" để định tuyến đến controller này.
    public class HomeAdminController : Controller
    {
        ChicCharm2Context db = new ChicCharm2Context();  //*Khởi tạo đối tượng "db" của lớp dữ liệu ChicCharm2Context để làm việc với cơ sở dữ liệu.
        [Route("")]
        [Route("Admin")]
        public IActionResult Admin() //* xử lý yêu cầu truy cập vào route trên.
        {
        return View();  //*Trả về view liên kết với action "Admin"
        }

      [Route("TaikhoanAdmin")] // *Định nghĩa route "TaikhoanAdmin" để định tuyến tới action method này.
    public IActionResult TaikhoanAdmin() // *Action method "TaikhoanAdmin" xử lý yêu cầu liên quan đến tài khoản admin.
            {
                return View(); // *Trả về một view mặc định liên kết với action "TaikhoanAdmin".
            }

    [Route("Quanlysanpham")] // *Định nghĩa route "Quanlysanpham" để định tuyến tới action method này.
    public IActionResult Quanlysanpham() // *Action method "Quanlysanpham" xử lý yêu cầu hiển thị danh sách sản phẩm.
            {
                var lstSanpham = db.Sanphams.ToList(); // *Lấy danh sách tất cả các sản phẩm từ bảng "Sanphams" trong cơ sở dữ liệu.
                return View(lstSanpham); // *Trả về view mặc định, đồng thời truyền danh sách sản phẩm vào view để hiển thị.
            }

    [Route("Themsanpham")] // *Định nghĩa route "Themsanpham" để định tuyến tới action method này.
    [HttpGet] // *Chỉ định rằng action này xử lý các yêu cầu HTTP GET (truy vấn dữ liệu).
    public IActionResult Themsanpham() // *Action method "Themsanpham" xử lý yêu cầu hiển thị form thêm sản phẩm.
            {
                // *Gửi danh sách các danh mục sản phẩm tới view dưới dạng SelectList để hiển thị trong dropdown.
            ViewBag.Madm = new SelectList(db.Danhmucsps.ToList(), "Madm", "Tendanhmuc"); 

                return View(); // *Trả về view mặc định hiển thị form thêm sản phẩm.
            }

        [Route("Themsanpham")] // *Định nghĩa route "Themsanpham" để định tuyến tới action method này.
        [HttpPost] // *Xử lý các yêu cầu HTTP POST (gửi dữ liệu).
        [ValidateAntiForgeryToken] // *Bảo vệ chống lại các cuộc tấn công CSRF bằng cách xác thực token khi gửi form.
        public IActionResult Themsanpham(Sanpham Sanpham) // *Xử lý dữ liệu sản phẩm được gửi từ form.
            {
                    if (ModelState.IsValid) // *Kiểm tra nếu dữ liệu được gửi từ form hợp lệ.
                 {
        db.Sanphams.Add(Sanpham); // *Thêm sản phẩm mới vào bảng "Sanphams" trong cơ sở dữ liệu.
        db.SaveChanges(); // *Lưu các thay đổi vào cơ sở dữ liệu.
        return RedirectToAction("Quanlysanpham"); // *Chuyển hướng người dùng đến action "Quanlysanpham" sau khi thêm sản phẩm thành công.
                }
                return View(Sanpham); // *Nếu dữ liệu không hợp lệ, trả về view để người dùng sửa lại, đồng thời truyền đối tượng sản phẩm đã nhập.
            }


        [Route("Suasanpham")] // *Định nghĩa route "Suasanpham" để định tuyến tới action sửa sản phẩm.
        [HttpGet] // *Chỉ định rằng action này xử lý các yêu cầu HTTP GET.
        public IActionResult Suasanpham(string masp) // *Action method hiển thị form sửa sản phẩm, nhận mã sản phẩm làm tham số.
            {        
                var Sanpham = db.Sanphams.Find(masp); // *Tìm kiếm sản phẩm trong bảng "Sanphams" bằng mã sản phẩm (masp).
                ViewBag.Madm = new SelectList(db.Danhmucsps.ToList(), "Madm", "Tendanhmuc"); // *Gửi danh sách danh mục sản phẩm tới view dưới dạng SelectList để hiển thị dropdown.
                return View(Sanpham); // *Trả về view hiển thị form sửa sản phẩm, đồng thời truyền đối tượng sản phẩm cần sửa.
            }

        [Route("Suasanpham")] // *Định nghĩa route "Suasanpham" để định tuyến tới action sửa sản phẩm.
        [HttpPost] // *Chỉ định rằng action này xử lý các yêu cầu HTTP POST.
        [ValidateAntiForgeryToken] // *Bảo vệ chống lại các cuộc tấn công CSRF bằng cách xác thực token khi gửi form.
        public IActionResult Suasanpham(Sanpham Sanpham) // *Action method nhận đối tượng sản phẩm từ form sau khi người dùng sửa.
            {
                if (ModelState.IsValid) // *Kiểm tra nếu dữ liệu từ form hợp lệ.
                    {
                 
                        db.Entry(Sanpham).State = Microsoft.EntityFrameworkCore.EntityState.Modified; //*Đánh dấu đối tượng sản phẩm là đã sửa đổi trong Entity Framework.
                        db.SaveChanges(); // *Lưu các thay đổi vào cơ sở dữ liệu.
                        return RedirectToAction("Quanlysanpham", "HomeAdmin"); // *Chuyển hướng người dùng về trang quản lý sản phẩm sau khi sửa thành công.
                    }
                return View(Sanpham); // *Nếu dữ liệu không hợp lệ, trả về form sửa sản phẩm với thông tin cũ để người dùng sửa lại.
            }

            [Route("Xoasanpham")] // *Định nghĩa route "Xoasanpham" để định tuyến tới action xóa sản phẩm.
            [HttpPost] // *Chỉ định rằng action này xử lý các yêu cầu HTTP POST.
            public IActionResult Xoasanpham(string masp) // *Action method xử lý yêu cầu xóa sản phẩm, nhận mã sản phẩm làm tham số.
                {
                db.Database.ExecuteSqlRaw("delete from Sanpham where Masp = '" + masp + "'");  // *Thực hiện lệnh SQL xóa sản phẩm khỏi bảng "Sanpham" dựa trên mã sản phẩm.
                return RedirectToAction("Quanlysanpham");// *Chuyển hướng người dùng về trang quản lý sản phẩm sau khi xóa thành công.
                }

            [Route("Login")] // *Định nghĩa route "Login" để định tuyến tới action đăng nhập.
            [HttpGet] // *Chỉ định rằng action này xử lý các yêu cầu HTTP GET.
            public IActionResult Login() // *Action method hiển thị form đăng nhập.
                {
                        TempData["Message"] = ""; // *Khởi tạo thông báo rỗng để sử dụng trong view (nếu cần thông báo cho người dùng).
                        return View("~/Areas/Admin/Views/HomeAdmin/Login.cshtml"); // *Trả về view đăng nhập với đường dẫn đầy đủ của view trong phân vùng "Admin".
                }

         [Route("Login")] // *Định nghĩa route "Login" để định tuyến tới action đăng nhập.
         [HttpPost] // *Chỉ định rằng action này xử lý các yêu cầu HTTP POST (gửi dữ liệu từ form).
         public IActionResult Login(string username, string password) // *Action method xử lý đăng nhập, nhận tên đăng nhập và mật khẩu từ form.
                {
                        var account = db.Nguoidungs.SingleOrDefault(x => x.Tendangnhap == username && x.Matkhau == password);// *Tìm kiếm tài khoản trong bảng "Nguoidungs" dựa trên tên đăng nhập và mật khẩu.
                        if (account != null) // *Kiểm tra nếu tài khoản tồn tại.
                {
        if (account.Loainguoidung == "Admin") // *Kiểm tra nếu loại người dùng là "Admin".
        {
            return RedirectToAction("Admin");    // *Nếu là quản trị viên, chuyển hướng tới trang Admin.
        }
        else if (account.Loainguoidung == "Khách hàng") // *Kiểm tra nếu loại người dùng là "Khách hàng".
        {
            TempData["Message"] = "Không phải là quản trị viên"; // *Nếu không phải quản trị viên, gửi thông báo về view để hiển thị.
        }
    }
        else // *Nếu không tìm thấy tài khoản trong cơ sở dữ liệu.
    {
        TempData["Message"] = "Tên đăng nhập hoặc mật khẩu không đúng"; // *Gửi thông báo lỗi về view để hiển thị rằng tên đăng nhập hoặc mật khẩu không đúng.
    }
    return View("~/Areas/Admin/Views/HomeAdmin/Login.cshtml");  // *Trả về view đăng nhập với đường dẫn đầy đủ trong phân vùng "Admin".

        }
    }

}
