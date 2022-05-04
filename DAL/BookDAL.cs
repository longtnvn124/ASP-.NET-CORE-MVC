using baithi1.Models;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace baithi1.DAL
{
    public class BookDAL
    
    {
        public SqlConnection Ketnoi()
        {
            SqlConnection con;
            string st = "Data Source=DESKTOP-9OKF8A2\\SQLEXPRESS;Initial Catalog=test1;Integrated Security=True";
            con = new SqlConnection(st);
            return con;
        }

        public List<Book> ListBook()
        {
            List<Book> li = new List<Book>();
            SqlConnection con = Ketnoi();
            con.Open();
            string sql = "SELECT *FROM Book";
            SqlCommand cm  = new SqlCommand(sql, con);
            SqlDataReader Dareader = cm.ExecuteReader();
            

            while (Dareader.Read())
            {
                Book bk = new Book();
                bk.ID = int.Parse(Dareader["ID"].ToString());
                bk.TenSach = Dareader["TenSach"].ToString();
                bk.TacGia = Dareader["TacGia"].ToString();
                bk.TheLoai = Dareader["TheLoai"].ToString();
                li.Add(bk);

            }
            con.Close();
            return li;
        }
        public void addBook(Book b)
        {
            SqlConnection con = Ketnoi();
            con.Open();
            string sql = "INSERT INTO Book VALUES(@ID, @TenSach,@TacGia,@TheLoai)";
            SqlCommand cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("ID", b.ID);
            cm.Parameters.AddWithValue("TenSach", b.TenSach);
            cm.Parameters.AddWithValue("TacGia", b.TacGia);
            cm.Parameters.AddWithValue("TheLoai", b.TheLoai);
            cm.ExecuteNonQuery();
            con.Close();
        }
        public void EditBook(Book b)
        {
            SqlConnection con = Ketnoi();
            con.Open();
            string sql = "UPDATE Book set TenSach=@TenSach,TacGia=@TacGia,TheLoai=@TheLoai where ID=@ID";
            SqlCommand cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("ID", b.ID);
            cm.Parameters.AddWithValue("TenSach", b.TenSach);
            cm.Parameters.AddWithValue("TacGia", b.TacGia);
            cm.Parameters.AddWithValue("TheLoai", b.TheLoai);
            cm.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteBook(int ID)
        {
            SqlConnection con =Ketnoi();
            con.Open();
            string sql = "DELETE FROM Book where ID=@ID";
          
            SqlCommand cm = new SqlCommand(sql, con);
            cm.Parameters.AddWithValue("ID",ID);
            cm.ExecuteNonQuery();
            con.Close();
        }
    }
}
