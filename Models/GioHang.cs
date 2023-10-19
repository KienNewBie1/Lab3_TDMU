using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SachOnline.Models
{
	public class GioHang
	{
		dbSachOnlineDataContext db = new dbSachOnlineDataContext();
		public int iMaSach { get; set; }
		public string sTenSach { get; set; }
		public string sAnhBia { get; set; }
		public string dDonGia { get; set; }
		public int iSoLuong { get; set; }
		public double dThanhTien
		{
			get { return iSoLuong * int.Parse(dDonGia); }
		}

		// Khởi tạo giỏ hàng theo MaSach được truyền vào với SoLuong Mặc định là 1
		public GioHang(int ms)
		{
			iMaSach = ms;
			Book s = db.Books.Single(n => n.BookID == iMaSach);
			sTenSach = s.NameBook;
			sAnhBia = s.AnhBia;
			dDonGia = s.GiaBan.ToString();
			iSoLuong = 1;
		}
	}
}