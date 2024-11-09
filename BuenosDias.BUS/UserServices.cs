using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using System.Security;
using System.Security.Permissions;


namespace BuenosDias.BUS
{
    public class UserServices
    {
        private readonly BuenosDiasModelDB context = new BuenosDiasModelDB();
        public List<User_> getAllUser()
        {
            return context.User_.ToList();
        }
        public User_ checkLogin(string username, string password)
        {
            var user = context.User_.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user;
        }
        public List<KhoaHoc> GetKhoaHocsByUserId(string userId)
        {
            var khoahocs = context.KhoaHocs
                .Where(kh => kh.UserID == userId)
                .Include(kh => kh.User_) // Nếu cần bao gồm cả thực thể `User_`
                .ToList();
            return khoahocs;
        }
        public bool checkExist(string userId)
        {
            if (context.User_.Where(user => user.UserID == userId).Any())
            {
                return true;
            }
            return false;
        }
        public void createNewUser(User_ userr)
        {
            var user = new User_
            {
                UserID = userr.UserID,
                TenUser = userr.TenUser,
                Username = userr.UserID,
                Password = userr.Password,
            };
            context.User_.Add(user);
            context.SaveChanges();
        }
        public void DeleteUser(User_ userr)
        {
            var find = context.User_.Find(userr.UserID);

            try
            {
                RemovePermission("2", find);
            }
            catch (Exception ex) { };

            try
            {
                RemovePermission("3", find);
            }
            catch (Exception ex) { };

            context.User_.Remove(find);

            context.SaveChanges();
        }
        public void createNewUser2(string maloaiQuyen ,User_ userr)
        {
            var user = new User_
            {
                UserID = userr.UserID,
                TenUser = userr.TenUser,
                Username = userr.UserID,
                Password = userr.Password,
            };
            context.User_.Add(user);
            giveUserStudentPermissions(maloaiQuyen, user);
            context.SaveChanges();
        }
        public void RegisterStudentToCourse(KhoaHoc course, User_ student)
        {
            var findStundent = context.User_.Find(student.UserID);
            var Course = context.KhoaHocs.Find(course.MaKhoaHoc);

            findStundent.KhoaHocs1.Add(Course);
            context.SaveChanges();

        }

        public void RemoveStudentFromCourse(KhoaHoc course, User_ student)
        {
            var findStundent = context.User_.Find(student.UserID);
            var Course = context.KhoaHocs.Find(course.MaKhoaHoc);

            findStundent.KhoaHocs1.Remove(Course);
            context.SaveChanges();

        }
        public string GetQuyenUser(User_ user)
        {
            var findStundent = context.User_.Find(user.UserID);
            return findStundent.CacLoaiQuyens.ToList()[0].TenQuyen;
        }
        public bool checkValidDeleteStudent(User_ user)
        {
            var findStundent = context.User_.Find(user.UserID);

            if (context.BaiViets.Where(x => x.UserID == user.UserID).Any())
            {
                return false;
            }
            else return true;
        }
        public bool checkValidDeleteNhanVien(User_ user)
        {
            var findStundent = context.User_.Find(user.UserID);

            if (context.BaiViets.Where(x => x.UserID == user.UserID).Any()
                && context.KhoaHocs.Where(x => x.UserID == user.UserID).Any())
            {
                return false;
            }
            else return true;
        }
        public void giveUserStudentPermissions(string permission ,User_ student)
        {
            var findStundent = context.User_.Find(student.UserID);
            var permis = context.CacLoaiQuyens.Find(permission);

            findStundent.CacLoaiQuyens.Add(permis);
            context.SaveChanges();

        }
        public void RemovePermission(string permission, User_ student)
        {
            try
            {
            User_ findStundent = context.User_.Find(student.UserID);
            var permis = context.CacLoaiQuyens.Find(permission);

            findStundent.CacLoaiQuyens.Remove(permis);
            context.SaveChanges();
            } catch (Exception ex) { }
        }
    }
  }
