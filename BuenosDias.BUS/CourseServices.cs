using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Windows.Forms;

namespace BuenosDias.BUS
{
    public class CourseServices
    {
        private readonly BuenosDiasModelDB context = new BuenosDiasModelDB();
        private readonly postServices postServices = new postServices();
        private readonly ImageService imageService = new ImageService();
        private readonly UserServices userServices = new UserServices();

        public int GetCourseMaxQuantity()
        {
            return context.KhoaHocs.Count()+1;

        }

        public List<KhoaHoc> GetKhoaHocs()
        {
            return context.KhoaHocs.ToList();
        }
        public List<KhoaHoc> GetKhoaHocByUserID(string id)
        {
            return context.KhoaHocs.Where(x => x.User_.UserID == id).ToList();
        }
        public void CreateNewCourse(KhoaHoc k)
        {
            var Course = new KhoaHoc
            {
                MaKhoaHoc = k.MaKhoaHoc,
                TenKhoaHoc = k.TenKhoaHoc,
                UserID = k.UserID,
            };
            context.KhoaHocs.Add(Course);
            context.SaveChanges();
        }
        public void DeleteCourseContent(KhoaHoc courseToDelete)
        {

            var baiViets = postServices.GetBaiVietbyCourseID(courseToDelete.MaKhoaHoc);

            foreach (var baiViet in baiViets)
            {
                postServices.DeletePost(baiViet);

            }
            context.SaveChanges();
        }
        public void DeleteRegisterdStunder(KhoaHoc courseToDelete)
        {

            var users = this.GetUsersByKhoaHocId(courseToDelete.MaKhoaHoc);
            MessageBox.Show(users.Count.ToString());
            foreach (var user in users)
            {
                userServices.RemoveStudentFromCourse(courseToDelete, user);
            }
            context.SaveChanges();
        }
        public void DeleteCourse(KhoaHoc course)
        {
            
            var courseToDelete = context.KhoaHocs.Find(course.MaKhoaHoc);

            imageService.DeleteImagesByCourseID(courseToDelete.MaKhoaHoc);

            context.KhoaHocs.Remove(courseToDelete);

            context.SaveChanges();

        }
        public List<User_> GetUsersByKhoaHocId(string khoaHocId)
        {
            KhoaHoc khoaHoc = context.KhoaHocs.Include(k => k.User_1).FirstOrDefault(k => k.MaKhoaHoc == khoaHocId);
            if (khoaHoc != null)
            {
                return khoaHoc.User_1.ToList();
            }
            return new List<User_>();

        }
        public bool checkExist(string khoahocID)
        {
            return context.KhoaHocs.Any(x => x.MaKhoaHoc == khoahocID);
        }
    }
    }
