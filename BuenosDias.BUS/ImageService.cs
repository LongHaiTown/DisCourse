using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuenosDias.BUS
{
    public class ImageService
    {
        private readonly BuenosDiasModelDB context = new BuenosDiasModelDB();
        public HinhAnh GetCourseCoverbyCourseID(string id)
        {
            return context.HinhAnhs.Where(x => x.IDBaiViet == id).First();
        }
        public void insertPostImages(HinhAnh img)
        {
            var imgpost = new HinhAnh
            {
                MaHinhAnh = "P_"+img.MaHinhAnh,
                TenHinhAnh = img.TenHinhAnh,
                LoaiHinhAnh = img.LoaiHinhAnh,
                IDBaiViet = img.IDBaiViet,
                UserID = img.UserID,
                MaKhoaHoc = img.MaKhoaHoc 
            };
            context.HinhAnhs.Add(imgpost);
            context.SaveChanges();
        }
        public void insertCourseCover(HinhAnh img)
        {
            try
            {
                var imgpost = new HinhAnh
                {
                    MaHinhAnh = "C_" + img.MaHinhAnh,
                    TenHinhAnh = img.TenHinhAnh,
                    LoaiHinhAnh = img.LoaiHinhAnh,
                    IDBaiViet = img.IDBaiViet,
                    UserID = img.UserID,
                    MaKhoaHoc = img.MaKhoaHoc
                };

                context.HinhAnhs.Add(imgpost);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw; 
            }
        }
        public string GetTenHinhAnhBaibyID(string id)
        {
            var hinh = context.HinhAnhs.Find("P_" + id);
            if (hinh != null)
                return hinh.TenHinhAnh;
            else return "";
        }
        public string GetCourseCover(string id)
        {
            var hinh = context.HinhAnhs.Find("C_" + id);
            if (hinh != null)
                return hinh.TenHinhAnh;
            else return "";
        }
        public string GetAvt(string id)
        {
            var hinh = context.HinhAnhs.Find("PA_" + id);
            if (hinh != null)
                return hinh.TenHinhAnh;
            else return "";
        }
        public void DeleteImagesByCourseID(string courseId)
        {
            try
            {
                var images = context.HinhAnhs.Where(x => x.MaKhoaHoc == courseId).ToList();

                if (images.Any())
                {
                    context.HinhAnhs.RemoveRange(images);
                    context.SaveChanges();
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw; 
            }
        }
        public void DeleteImagesByPostID(BaiViet b)
        {
            try
            {
                var images = context.HinhAnhs.Where(x => x.IDBaiViet == b.IDBaiViet).ToList();

                if (images.Any())
                {
                    context.HinhAnhs.RemoveRange(images);
                    context.SaveChanges();
                }
                context.SaveChanges();

            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        MessageBox.Show($"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage}");
                    }
                }
                throw;
            }
        }


    }
}
