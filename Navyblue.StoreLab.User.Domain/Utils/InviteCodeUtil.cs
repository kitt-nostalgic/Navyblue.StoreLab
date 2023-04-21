// ******************************************************************************************************
// Project          : Navyblue.StoreLab.User
// File             : GenerateInviteCode.cs
// Created          : 2023-04-20  11:09
// 
// Last Modified By : Edison Ma (jstsmaxx@163.com)
// Last Modified On : 2023-04-20  11:09
// ******************************************************************************************************
// <copyright file="GenerateInviteCode.cs" company="">
//     Copyright ©  2011-2023. All rights reserved.
// </copyright>
// ******************************************************************************************************


namespace Navyblue.StoreLab.User.Domain.Utils;

public class InviteCodeUtil
{
    private static readonly Dictionary<int, string> DirectBase64Code = new()
    {
        { 0, "z" }, { 1, "1" }, { 2, "2" }, { 3, "3" }, { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" }, { 8, "8" }, { 9, "9" },
        { 10, "a" }, { 11, "b" }, { 12, "c" }, { 13, "d" }, { 14, "e" }, { 15, "f" }, { 16, "g" }, { 17, "h" }, { 18, "i" }, { 19, "j" },
        { 20, "k" }, { 21, "x" }, { 22, "m" }, { 23, "n" }, { 24, "y" }, { 25, "p" }, { 26, "q" }, { 27, "r" }, { 28, "s" }, { 29, "t" },
        { 30, "u" }, { 31, "v" }, { 32, "w" }, { 33, "x" }, { 34, "y" }, { 35, "z" }, { 36, "A" }, { 37, "B" }, { 38, "C" }, { 39, "D" },
        { 40, "E" }, { 41, "F" }, { 42, "G" }, { 43, "H" }, { 44, "I" }, { 45, "J" }, { 46, "K" }, { 47, "L" }, { 48, "M" }, { 49, "N" },
        { 50, "O" }, { 51, "P" }, { 52, "Q" }, { 53, "R" }, { 54, "S" }, { 55, "T" }, { 56, "U" }, { 57, "V" }, { 58, "W" }, { 59, "X" },
        { 60, "Y" }, { 61, "Z" }, { 62, "-" }, { 63, "_" },
    };

    private static Dictionary<string, int> ReverseBase64Code
    {
        get { return Enumerable.Range(0, DirectBase64Code.Count()).ToDictionary(i => DirectBase64Code[i], i => i); }

    }

    public static string ConvertToInviteCode(long phoneNumber)
    {
        string inviteCode = "";
        while (phoneNumber >= 1)
        {
            int index = Convert.ToInt16(phoneNumber - (phoneNumber / 32) * 32);
            inviteCode = DirectBase64Code[index] + inviteCode;
            phoneNumber = phoneNumber / 32;
        }

        return inviteCode;
    }

    public static long ReverseInviteCode(string inviteCode)
    {
        long phoneNumber = 0;
        int power = inviteCode.Length - 1;

        for (int i = 0; i <= power; i++)
        {
            phoneNumber += ReverseBase64Code[inviteCode[power - i].ToString()] * Convert.ToInt64(Math.Pow(32, i));
        }

        return phoneNumber;
    }

}