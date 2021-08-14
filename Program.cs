// 使い方 : main()関数のコメントを見て下さい
using System;

namespace miniroto6
{
    class Program
    {
        //static int[] src = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
        //                16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28,
        //                29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43};
        // 2桁目以降下位数字出現予想
        private static readonly int[] src1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        private static readonly int[] src2 = { 3, 12, 8, 5, 11, 7, 13, 10, 1, 14, 15, 16, 17, 18, 19, 2, 18, 4, 6, 15, 21, 9, 22, 10, 23, 24 };
        private static readonly int[] src3 = { 4, 12, 13, 14, 1, 16, 2, 18, 19, 3, 15, 21, 5, 22, 11, 6, 23, 7, 24, 8, 26, 9, 27, 10, 28 };
        private static readonly int[] src4 = { 13, 23, 14, 24, 15, 19, 16, 21, 22, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37 };
        private static readonly int[] src5 = { 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43 };
        private static readonly int[] src6 = { 21, 23, 24, 25, 27, 29, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43 };

        static void genrotnum(Random rnd1, ref int[] roto)
        {
            int inum, i, ifnd;
            int icnt = 0;
            for (i = 0; i < roto.Length; i++)
            {
                roto[i] = 0;
            }

            ifnd = 1;
            while (ifnd == 1)
            {
                int num = rnd1.Next(0, src1.Length);
                inum = src1[num];
                ifnd = findsamenum(inum, icnt, roto);
                if (ifnd == 0)
                {
                    roto[icnt] = inum;
                    icnt++;
                }
            }

            ifnd = 1;
            while (ifnd == 1)
            {
                int num = rnd1.Next(0, src2.Length);
                inum = src2[num];
                ifnd = findsamenum(inum, icnt, roto);
                if (ifnd == 0)
                {
                    roto[icnt] = inum;
                    icnt++;
                }
            }

            ifnd = 1;
            while (ifnd == 1)
            {
                int num = rnd1.Next(0, src3.Length);
                inum = src3[num];
                ifnd = findsamenum(inum, icnt, roto);
                if (ifnd == 0)
                {
                    roto[icnt] = inum;
                    icnt++;
                }
            }

            ifnd = 1;
            while (ifnd == 1)
            {
                int num = rnd1.Next(0, src4.Length);
                inum = src4[num];
                ifnd = findsamenum(inum, icnt, roto);
                if (ifnd == 0)
                {
                    roto[icnt] = inum;
                    icnt++;
                }
            }

            ifnd = 1;
            while (ifnd == 1)
            {
                int num = rnd1.Next(0, src5.Length);
                inum = src5[num];
                ifnd = findsamenum(inum, icnt, roto);
                if (ifnd == 0)
                {
                    roto[icnt] = inum;
                    icnt++;
                }
            }

            ifnd = 1;
            while (ifnd == 1)
            {
                int num = rnd1.Next(0, src6.Length);
                inum = src6[num];
                ifnd = findsamenum(inum, icnt, roto);
                if (ifnd == 0)
                {
                    roto[icnt] = inum;
                    icnt++;
                }
            }

        }

        static int findsamenum(int inum, int icnt, int[] roto)
        {
            int ifnd = 0;
            // 同じ番号を弾く
            for (int i = 0; i < icnt; i++)
            {
                if (inum == roto[i])
                {
                    ifnd = 1;
                    break;
                }
            }
            if (ifnd == 1) return 1;
            else return 0;

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
            DateTime date1 = new DateTime(2021, 8, 12, 19, 0, 0);
            // 前回当り番号
            int[] atari1 = { 03, 14, 16, 24, 32, 36 };
            // 今回抽選時刻（予想）
            DateTime date2 = new DateTime(2021, 8, 16, 19, 0, 0);
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
                    //  03/25 19時 抽選試行回数   2024555回
                    //  03/29 19時 抽選試行回数   1635213回  4等当り
                    //  04/01 19時 抽選試行回数   4139645回  当り番号 2, 10, 16, 38, 39, 43
                    //  04/05 19時 抽選試行回数   4444454回  当り番号 1,  2,  3, 20, 31, 32
                    //  04/08 19時 抽選試行回数   6615469回
                    //  05/31 19時 抽選試行回数   1411654回  当り番号 10, 12, 15, 29, 33, 42
                    //  06/07 19時 抽選試行回数   4726008回
                    //  08/12 19時 抽選試行回数   3276103回  当り番号 03, 14, 16, 24, 32, 36　5等当たり
                    //  08/16 19時 抽選試行回数   2114371回
                    int num1 = num;
                    string rotostr;
                    // くじ計算
                    Console.WriteLine("ロト６　当たりくじ番号表示");
                    for (i = 0; i < num1; i++)
                    {
                        genrotnum(rnd2, ref roto);
                    }
                    for (j = 0; j < 10; j++)
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
