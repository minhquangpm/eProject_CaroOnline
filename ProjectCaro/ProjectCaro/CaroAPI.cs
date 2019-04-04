using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCaro
{
    public class ThongKe
    {
        public int idThongKe { get; set; }
        public int idUser { get; set; }
        public string name { get; set; }
        public int gameCount { get; set; }
        public int win { get; set; }
        public int lose { get; set; }
        public int draw { get; set; }
    }
    public class LichSuDau
    {
        public int idLichSuDau { get; set; }
        public int idUser { get; set; }
        public string name { get; set; }
        public int idUser2 { get; set; }
        public string name2 { get; set; }
        public int status { get; set; }
    }
    public class FriendList
    {
        public string name { get; set; }
        public int status { get; set; }
        public FriendListThongKe thongke { get; set; }
        public FriendListInfo user { get; set; }
    }
    public class FriendListThongKe
    {
        public int win { get; set; }
        public int lose { get; set; }
        public int draw { get; set; }
    }
    public class FriendListInfo
    {
        public string avatar { get; set; }
    }
    public class RoomGame
    {
        public string host_id { get; set; }
        public string room_no { get; set; }
        public string roomname { get; set; }
        public string join_id { get; set; }
        public string room_key { get; set; }
    }
    public class GetRoom
    {
        public List<RoomGame> data = new List<RoomGame>();
    }
    public class GetFriendList
    {
        public List<FriendList> data = new List<FriendList>();
    }
    public class GetRank
    {
        public List<ThongKe> data = new List<ThongKe>();
    }
    public class UserLogin
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
    public class UserSignUp
    {
        public string username { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
    }
    public class UserReturn
    {
        public string statuscode { get; set; }
    }
    public class UserModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }

        public UserModel()
        {
        }
    }
    class CaroAPI
    {

        public static UserModel user;

        public static ThongKe thongke;

        public static GetFriendList getFriendList;

        public static GetRoom getRoom;

        public static GetRank getRank;

        public static UserReturn userReturn;

        public static string[] avatar = { "manh1.jpg", "manh2.jpg", "manh3.jpg"};

        static string baseAddress = "http://127.0.0.1:8000/";

        // Login Bằng UserName và Password
        #region Login
        public static async Task<bool> LoginAsync(UserLogin userLogin, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
       "api/login", userLogin);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<UserModel>();
                return true;
            }
            else
            {
                userReturn = await response.Content.ReadAsAsync<UserReturn>();
                return false;
            }

        }



        protected static void SetupClientDefaults(HttpClient client)
        {
            client.Timeout = TimeSpan.FromSeconds(30); //set your own timeout.
            client.BaseAddress = new Uri(baseAddress);
        }



        public static async Task<bool> Login(string username, string password)
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.Timeout = TimeSpan.FromSeconds(3000);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                UserLogin userlogin = new UserLogin
                {
                    userName = username,
                    password = password,
                };
                bool user = await LoginAsync(userlogin, client);
                if (user)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
            }

        }


        #endregion

        #region friend list

        public static async Task<GetFriendList> FriendListAsync(HttpClient client)
        {
            string url = baseAddress + "api/friendlist/" + user.username;
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                getFriendList = await response.Content.ReadAsAsync<GetFriendList>();
            }
            return getFriendList;

        }


        public static async Task FriendList()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                getFriendList = await FriendListAsync(client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }

        #endregion  

        #region signup

        public static async Task<bool> SignUpAsync(UserSignUp userSignUp, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
       "api/signup", userSignUp);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }

        public static async Task<bool> SignUp(string username, string name, string password, string email)
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Random random = new Random();
                int start = random.Next(0, avatar.Length);
                string getavatar = avatar[start];
                UserSignUp userSignUp = new UserSignUp
                {
                    username = username,
                    name = name,
                    password = password,
                    email = email,
                    avatar = getavatar,
                };
                bool check = await SignUpAsync(userSignUp, client);
                if (check)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
            }

        }
        #endregion

        #region log out

        public static async Task<bool> LogOutAsync(UserModel userLogin, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
       "api/logout", userLogin);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }


        public static async Task LogOut()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.Timeout = TimeSpan.FromSeconds(3000);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                bool logout = await LogOutAsync(user, client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }

        #endregion

        #region get rank

        public static async Task<GetRank> RankAsync(HttpClient client)
        {
            string url = baseAddress + "api/thongke/";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                getRank = await response.Content.ReadAsAsync<GetRank>();
            }
            return getRank;

        }


        public static async Task Rank()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                getRank = await RankAsync(client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }

        #endregion

        #region Thong ke

        public static async Task<ThongKe> ThongKeAsync(HttpClient client)
        {
            string url = baseAddress + "api/thongke/" + user.id.ToString();
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                thongke = await response.Content.ReadAsAsync<ThongKe>();
            }
            return thongke;

        }


        public static async Task ThongKe()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                thongke = await ThongKeAsync(client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }

        #endregion

        #region Win
        public static async Task<bool> WinAsync(UserModel userModel, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
       "api/win", userModel);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }


        public static async Task Win()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                bool check = await WinAsync(user, client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }


        #endregion

        #region Lose
        public static async Task<bool> LoseAsync(UserModel userModel, HttpClient client)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
       "api/lose", userModel);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;

        }


        public static async Task Lose()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                bool check = await LoseAsync(user, client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }


        #endregion

        #region get room

        public static async Task<GetRoom> RoomAsync(HttpClient client)
        {
            string url = baseAddress + "api/room/";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                getRoom = await response.Content.ReadAsAsync<GetRoom>();
            }
            return getRoom;

        }


        public static async Task Room()
        {
            var client = new HttpClient();
            SetupClientDefaults(client);
            client.BaseAddress = new Uri(baseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                getRoom = await RoomAsync(client);
            }
            catch (Exception e)
            {
            }
            finally
            {
            }

        }

        #endregion


    }
}
