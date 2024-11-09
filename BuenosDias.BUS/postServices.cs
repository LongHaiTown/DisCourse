using BuenosDias.DALL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuenosDias.BUS
{
    public class postServices
    {
        public readonly BuenosDiasModelDB context = new BuenosDiasModelDB();
        public readonly ImageService imageService = new ImageService();
        public void SendPost(BaiViet post)
        {
            var Post = new BaiViet
            {
                IDBaiViet = post.IDBaiViet,
                TIeuDe = post.TIeuDe,
                NoiDung = post.NoiDung,
                UserID = post.UserID,
                MaKhoaHoc = post.MaKhoaHoc
            };
            context.BaiViets.Add(Post);
            context.SaveChanges();
        }
        public void DeletePost(BaiViet post)
        {
            var find = context.BaiViets.Find(post.IDBaiViet);

            imageService.DeleteImagesByPostID(find);

            context.BaiViets.Remove(find);

            context.SaveChanges();
        }
        public List<BaiViet> GetBaiViets()
        {
            return context.BaiViets.ToList();
        }
        public List<BaiViet> GetBaiVietbyCourseID(string id)
        {
            return context.BaiViets.Where(x => x.MaKhoaHoc == id).ToList();
        }
        public List<BaiViet> GetBaiVietbyUserID(string id)
        {
            return context.BaiViets.Where(x => x.UserID == id).ToList();
        }
        public string GenerateFileName()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            return $"{"Post"}_{timestamp}.rtf";
        }
        public string GenerateFileID()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmss");
        }
        public User_ GetUserbyByID(string id)
        {
            return context.User_.Find(id);
        }
        public DateTime DecodeTimestamp(string timestamp)
        {
            try
            {
                return DateTime.ParseExact(timestamp, "yyyyMMdd_HHmmss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (FormatException)
            {
                throw new ArgumentException("Timestamp format is invalid. Expected format: yyyyMMdd_HHmmss.");
            }
        }

    }
}
