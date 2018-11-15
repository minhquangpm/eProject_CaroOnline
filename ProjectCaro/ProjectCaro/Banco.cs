using System.Collections.Generic;
using System.Drawing;
using ProjectCaro.Properties;
using System.Media;

namespace ProjectCaro
{
    class Banco
    {
        public const int _ChieuRong = 24;
        public const int _ChieuCao = 24;

        private int _SoDong;
        private int _SoCot;

        private static List<int> playerX = new List<int>();
        private static List<int> playerO = new List<int>();
        private static int[,] keHuyDiet;
        private static List<int> checkPlayer = new List<int>();

        public int Dong { set; get; }
        private int Cot { set; get; }

        public Banco(int Socot, int Sodong)
        {
            _SoDong = Sodong;
            _SoCot = Socot;
        }

        public void VeBanCo(Graphics g)
        {
            for (int i = 0; i <= _SoCot; i++)
            {
                g.DrawLine(Program.pen, i * _ChieuRong, 0, i * _ChieuRong, _SoDong * _ChieuCao);
            }
            for (int j = 0; j <= _SoDong; j++)
            {
                g.DrawLine(Program.pen, 0, j * _ChieuCao, _SoCot * _ChieuRong, j * _ChieuCao);
            }
        }

        // gán tất cả các ô số 1 (để kiểm tra ô đã tồn tại quân cờ hay chưa)
        public void check(int soDong, int soCot)
        {
            keHuyDiet = new int[soDong, soCot];
            for (int i = 0; i < soDong; i++)
            {
                for (int j = 0; j < soCot; j++)
                {
                    keHuyDiet[i, j] = 1;
                }
            }
        }

        // thuật toán đánh cờ
        public static int DanhCo(int x, int y, int player, Graphics g)
        {
            // lấy ảnh từ Resources
            Bitmap player_x = Resources.x;
            Bitmap player_o = Resources.o;
            // tính toán vị trí đặt ảnh theo vị trí click chuột
            int new_x = 0;
            int new_y = 0;
            for (int i = 1; i <= _ChieuRong; i++)
            {
                for (int j = 1; j <= _ChieuCao; j++)
                {


                    if ((x <= _ChieuRong * i) && (y <= _ChieuCao * j))
                    {
                        new_x = _ChieuRong * (i - 1);
                        new_y = _ChieuCao * (j - 1);

                        // ô nào được vẽ thì gán số 2 (để kiểm tra ô đã được đánh hay chưa)
                        if (keHuyDiet[i - 1, j - 1] == 1)
                        {
                            keHuyDiet[i - 1, j - 1] = 2;
                            goto Next;
                        }

                        else
                        {
                            return 0;
                        }
                    }
                }
            }

            Next:
            Rectangle rect = new Rectangle
            {
                Height = _ChieuCao,
                Width = _ChieuRong,
                X = new_x,
                Y = new_y,
            };

            if (player == 1)
            {
                g.DrawImage(player_x, rect);
            }
            else if (player == 2)
            {
                g.DrawImage(player_o, rect);
            }

            // lưu vị trí theo thứ tự 1-> 81 vào List
            int vi_tri = (new_x + new_y * _ChieuRong + _ChieuRong) / _ChieuRong;

            // lưu vị trí người đánh vào list của ng đó
            if (player == 1)
            {
                playerX.Add(vi_tri);
            }
            else if (player == 2)
            {
                playerO.Add(vi_tri);
            }

            return vi_tri;
        }

        // check thắng
        public static bool CheckWin(int player, int vi_tri)
        {
            if (player == 1)
            {
                checkPlayer = playerX;
            }
            else if (player == 2)
            {
                checkPlayer = playerO;
            }

            for (int i = -4; i < 1; i++)
            {
                // check hàng checkPlayer
                if (checkPlayer.Contains(vi_tri + i) &&
                checkPlayer.Contains(vi_tri + i + 1) &&
                checkPlayer.Contains(vi_tri + i + 2) &&
                checkPlayer.Contains(vi_tri + i + 3) &&
                checkPlayer.Contains(vi_tri + i + 4))
                {
                    return true;
                }

                // check hàng chéo phải sang trái
                if (checkPlayer.Contains(vi_tri + i * (_ChieuRong - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 1) * (_ChieuRong - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 2) * (_ChieuRong - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 3) * (_ChieuRong - 1)) &&
                checkPlayer.Contains(vi_tri + (i + 4) * (_ChieuRong - 1)))
                {
                    return true;
                }

                // check hàng dọc
                if (checkPlayer.Contains(vi_tri + i * _ChieuRong) &&
                checkPlayer.Contains(vi_tri + (i + 1) * _ChieuRong) &&
                checkPlayer.Contains(vi_tri + (i + 2) * _ChieuRong) &&
                checkPlayer.Contains(vi_tri + (i + 3) * _ChieuRong) &&
                checkPlayer.Contains(vi_tri + (i + 4) * _ChieuRong))
                {
                    return true;
                }

                // check hàng chéo trái sang phải
                if (checkPlayer.Contains(vi_tri + i * (_ChieuRong + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 1) * (_ChieuRong + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 2) * (_ChieuRong + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 3) * (_ChieuRong + 1)) &&
                checkPlayer.Contains(vi_tri + (i + 4) * (_ChieuRong + 1)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
