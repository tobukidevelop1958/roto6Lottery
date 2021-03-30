// 使い方 : main()関数のコメントを見て下さい
using System;

namespace miniroto6
{
    class Program
    {
        static int[] src = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
                        16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
                        29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43};

        static void genrotnum(Random rnd1, ref int[] roto)
        {
            int inum, i, ifnd;
            int icnt = 0;
            for(i=0; i<roto.Length; i++)
            {
                roto[i] = 0;
            }
            while (icnt < roto.Length)
            {
                int num = rnd1.Next(0, src.Length);
                inum = src[num];
                ifnd = 0;
                // 同じ番号を弾く
                for (i=0; i<icnt; i++)
                {
                    if (inum == roto[i])
                    {
                        ifnd = 1;
                        break;
                    }
                }
                if (ifnd == 1) continue;
                roto[icnt] = src[num];
                icnt++;
            }
        }

        static string getrotostring(int[] roto)
        {
            string strroto = new string("");
            for (int i = 0; i < roto.Length; i++)
            {
                strroto = strroto + roto[i].ToString() + " ";
            }
            return strroto;
        }

        static void Main(string[] args)
        {
            // 使用方法 : date1, atari1, date2を毎回設定します。
            // roto6の抽選時刻、当り番号を指定する
            // 前回抽選時刻（予想）
            DateTime date1 = new DateTime(2021, 3, 29, 19, 0, 0);
            // 前回当り番号
            int[] atari1 = { 4, 6, 10, 19, 28, 38 };
            // 今回抽選時刻（予想）
            DateTime date2 = new DateTime(2021, 4, 2, 19, 0, 0);
            // 乱数初期化
            string datestr1 = date1.ToString("MMddHHmmss");
            int random1 = int.Parse(datestr1);
            Random rnd1;
            rnd1 = new System.Random(random1);
            string datestr2 = date2.ToString("MMddHHmmss");
            int random2 = int.Parse(datestr2);
            Random rnd2;
            rnd2 = new System.Random(random2);
            // 変数初期化
            // 6個の乱数を取り出す
            int[] roto = { 0, 0, 0, 0, 0, 0};
            int i, j;
            int num = 0;
            int ifind = 0;
            while (ifind == 0)
            {
                // 前回の当りが出るまで
                genrotnum(rnd1, ref roto);
                for (i = 0; i < atari1.Length; i++)
                {
                    for (j = 0; j < roto.Length; j++)
                    {
                        if (atari1[i] == roto[j])
                        {
                            ifind += 1;
                            break;
                        }
                    }
                }
                if (ifind == atari1.Length)
                {
                    Console.WriteLine("前当たりくじ試行回数 = {0}", num);
                    // 3/25 19時 抽選試行回数   2024555回
                    // 3/29 19時 抽選試行回数   1635213回  4等当り
                    // 4/02 19時 抽選試行回数   4139645回
                    int num1 = num;
                    string rotostr;
                    // くじ計算
                    Console.WriteLine("ロト６　当たりくじ番号表示");
                    for (i = 0; i < num1; i++)
                    {
                        genrotnum(rnd2, ref roto);
                    }
                    for (j = 0; j < 3; j++)
                    {
                        genrotnum(rnd2, ref roto);
                        rotostr = getrotostring(roto);
                        Console.WriteLine("ロト６ = {0}", rotostr);
                    }
                    break;
                }
                ifind = 0;
                num += 1;
                if (num % 10000 == 0)
                {
                    Console.WriteLine("前回あたり回数計算・途中経過回数 = {0}", num);
                }
            }
        }
    }
}
