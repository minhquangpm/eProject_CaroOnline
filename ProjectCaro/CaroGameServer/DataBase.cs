using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CaroGameServer
{
    class DataBase
    {
        public static string[] roomName = { "Lets Play", "Play Now", "Play With Me", "Terminator" };

        //Tạo phòng
        public static void TaoRoom(string host_id, string room_no)
        {
            Random random = new Random();
            int start = random.Next(0, roomName.Length);
            string roomname = roomName[start];
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "INSERT INTO room (host_id, roomname, room_no)  VALUES (@host_id, @roomname, @room_no) ";
                MyCommand.Parameters.AddWithValue("@host_id", host_id);
                MyCommand.Parameters.AddWithValue("@room_no", room_no);
                MyCommand.Parameters.AddWithValue("@roomname", roomname);
                //MyCommand.Parameters.AddWithValue("@join_id", join_id);
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
        public static void UpdateRoom(string host_id, string join_id, string room_no)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {

                MyCommand.CommandText = "UPDATE room SET host_id = @host_id, join_id = @join_id WHERE room_no = '" + room_no + "';";
                MyCommand.Parameters.AddWithValue("@host_id", host_id);
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
        public static void XoaRoom(string host_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "DELETE FROM room WHERE host_id = @host_id;";
                MyCommand.Parameters.AddWithValue("@host_id", host_id);
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

        //Clear Room

        public static void ClearRoom()
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "TRUNCATE TABLE room;";
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

        //Reset
        #region Reset
        
        public static void ResetUser()
        {
            int status = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "UPDATE user SET status = @status;";
                MyCommand.Parameters.AddWithValue("@status", status);
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

        public static void ResetFriendList()
        {
            int status = 0;
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = "UPDATE friendlist SET status = @status;";
                MyCommand.Parameters.AddWithValue("@status", status);
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

        public static void Reset()
        {
            ResetUser();
            ResetFriendList();
        }

        #endregion


        public static void ChangeStatusUser(string user_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = $"UPDATE user SET status = @status WHERE userName = '" + user_id + "';";
                MyCommand.Parameters.AddWithValue("@status", SqlDbType.Int).Value = 0;
                MyCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                conn.Dispose();
                conn.Close();
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }
        }



        public static void ChangeStatusFriendList(string user_id)
        {
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand MyCommand;
            MyCommand = conn.CreateCommand();
            conn.Open();
            try
            {
                MyCommand.CommandText = $"UPDATE friendlist SET status = @status WHERE name = '" + user_id + "';";
                MyCommand.Parameters.AddWithValue("@status", SqlDbType.Int).Value = 0;
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
