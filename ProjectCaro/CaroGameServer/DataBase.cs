using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaroGameServer
{
    class DataBase
    {
        //Tạo phòng
        public static void TaoRoom(string host_id, string room_no, string join_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "INSERT INTO room (host_id, room_no, join_id)  VALUES (@host_id, @room_no, @join_id) ";
                MyCommand.Parameters.AddWithValue("@host_id", host_id);
                MyCommand.Parameters.AddWithValue("@room_no", room_no);
                MyCommand.Parameters.AddWithValue("@join_id", join_id);
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }

        //Update join_id
        public static void UpdateRoom(string room_no, string join_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "UPDATE room SET join_id = @join_id WHERE room_no = '" + room_no + "';";
                MyCommand.Parameters.AddWithValue("@join_id", join_id);
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }

        //Xóa Phòng
        public static void XoaRoom(string room_no)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "DELETE FROM room WHERE room_no = '" + room_no + "';";
                MyCommand.Parameters.AddWithValue("@room_no", room_no);
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }
    }
}
