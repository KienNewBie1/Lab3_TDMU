using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SachOnline.Models;
using PagedList;
using PagedList.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        dbSachOnlineDataContext data = new dbSachOnlineDataContext();
        private List<Book> LaySachMoi(int count)
        {
            return data.Books.OrderByDescending(a =>
            a.NgayCapNhat).Take(count).ToList();
        }
        // GET: SachOnline
        public ActionResult Index(int? page)
        {
            var listSachMoi = LaySachMoi(20);
            int iSize = 3;
            int iPageNum = (page ?? 1);
            return View(listSachMoi.ToPagedList(iPageNum, iSize));
        }
        // GET: SachOnline
        public ActionResult SachBanNhieuPartial()
        {
            var listSachBanNhieu = from cd in data.SachBanNhieus select cd;
            return PartialView(listSachBanNhieu);
        }
        public ActionResult ChuDePartial() {
            var listChuDe = from cd in data.ChuDes select cd;
            return PartialView(listChuDe);
        }
        public ActionResult NhaXuatBanPartial()
        {
            var listNhaXuatBan = from cd in data.Publishers select cd;
            return PartialView(listNhaXuatBan);
        }
        public ActionResult ChiTietSach(int id)
        {
            var sach = from s in data.Books
                       where s.BookID == id
                       select s;
            return View(sach.Single());
        }
        public ActionResult SachTheoChuDe(int id, int? page)
        {
            ViewBag.MaCD = id;
            int iSize = 3;
            int iPageNum = (page ?? 1);

            var sach = from s in data.Books where s.MaChuDe == id select s;
            return View(sach.ToPagedList(iPageNum, iSize));
        }
        public ActionResult SachTheoNhaXuatBan(int id, int? page)
        {
            ViewBag.MaChuDe = id;
            int iSize = 3;
            int iPageNum = (page ?? 1);
            var sach = from s in data.Books where s.Publisher_id == id select s;
            return View(sach.ToPagedList(iPageNum, iSize));
        }
    }
}