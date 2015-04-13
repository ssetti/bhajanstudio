using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bhajans
{
    class SoundEx
    {
        public static int MIN_SOUNDEX_LENGTH = 4;
        public static int MAX_SOUNDEX_LENGTH = 10;

        public static string Soundex(string strName) {
            string strCode;
            string strCodeN;

            int intLength;
            string strLastCode;
            int intI;

            if (strName == null)
                return null;
            else if (strName.Equals(""))
                return "";
            else if (strName.Length < MIN_SOUNDEX_LENGTH)
                return strName;

            strName = strName.ToUpper();

            //Modifying from (1, 1) to (0, 1)
            //strCode = strName.Substring(1, 1).ToUpper();
            //Modifying further, removing ToUpper()
            strCode = strName.Substring(0, 1);
            strLastCode = GetSoundexCode(strCode);
            intLength = strName.Length;

            for (intI = 1; intI < intLength - 1; intI++) {
                strCodeN = GetSoundexCode(strName.Substring(intI, 1));
                if (strCodeN.CompareTo("0") > 0 && !strLastCode.Equals(strCodeN))
                    strCode = strCode + strCodeN;
                if (!strCodeN.Equals("0"))
                    strLastCode = strCodeN;
            }

            if (strCode.Length < 4)
                strCode = strCode + new string('0', 4 - strCode.Length);
            else
                //Modifying from (1, 4) to (0, 4)
                strCode = strCode.Substring(0, 4);

            return strCode;
        }

        public static string GetAmericanSoundexCode(String str) {
            int firstChar = str.ToCharArray()[0];

            if (firstChar == 'B' || firstChar == 'F' || firstChar == 'P' || firstChar == 'V')
                return "1";
            else if (firstChar == 'C' || firstChar == 'G' || firstChar == 'J' || firstChar == 'K' ||
                     firstChar == 'Q' || firstChar == 'S' || firstChar == 'X' || firstChar == 'Z')
                return "2";
            else if (firstChar == 'D' || firstChar == 'T')
                return "3";
            else if (firstChar == 'L')
                return "4";
            else if (firstChar == 'M' || firstChar == 'N')
                return "5";
            else if (firstChar == 'R')
                return "6";
            else if (firstChar == 'H' || firstChar == 'W')
                return "0";

            return "0";
        }

        public static string GetSoundexCode(String str)
        {
            int firstChar = str.ToCharArray()[0];

            if (firstChar == 'B' || firstChar == 'F' || firstChar == 'P')
                return "1";
            else if (firstChar == 'C' || firstChar == 'K' || firstChar == 'Q')
                return "2";
            else if (firstChar == 'G' || firstChar == 'J' || 
                     firstChar == 'S' || firstChar == 'X' || firstChar == 'Z')
                return "3";
            else if (firstChar == 'D' || firstChar == 'T')
                return "4";
            else if (firstChar == 'L')
                return "5";
            else if (firstChar == 'M')
                return "6";
            else if (firstChar == 'N')
                return "7";
            else if (firstChar == 'R')
                return "8";
            else if (firstChar == 'W' || firstChar == 'V')
                return "9";
            else if (firstChar == 'H')
                return "0";

            return "0";
        }

        // Starts function with soundex
        public static bool StartsWithSoundingString(String str1, String str2)
        {
            String soundex1 = GetSoundexCode(str1);
            String soundex2 = GetSoundexCode(str2);

            return soundex1.Equals(soundex2);
        }

        // Like function with soundex
        public static bool ContainsSoundingString(String str1, String str2)
        {
            String soundex2 = GetSoundexCode(str2);

            int rest = 0;
            for (int i = 0; i < str1.Length; i++)
            {
                rest = str1.Length - i;
                String soundex1 = GetSoundexCode(str1.Substring(i, rest < MAX_SOUNDEX_LENGTH ? rest : MAX_SOUNDEX_LENGTH));

                if (soundex1.Equals(soundex2))
                    return true;
            }

            return false;
        }
    }
}
