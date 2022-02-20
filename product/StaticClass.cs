using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography ;
using System.Windows.Forms;

namespace product
{
    public static class StaticClass
    {
        public static string    Encrypt (this string  StringSet,string Text)
       {
            if (string.IsNullOrEmpty(Text ))
                return string .Empty;


            var TextByte = Encoding.Unicode.GetBytes(Text);
            var protectedText = ProtectedData.Protect(TextByte ,null, DataProtectionScope.CurrentUser );
            return Convert.ToBase64String ( protectedText );
        }
        public static string Decrypt(this string StringSet, string Text)
        {
            if (string.IsNullOrEmpty(Text))
                return string.Empty;

            var TextByte1 = Convert.FromBase64String(Text);
            var protectedText = ProtectedData.Unprotect(TextByte1, null, DataProtectionScope.CurrentUser);
            return Encoding.Unicode.GetString(protectedText);
        }
        public static string FormText(this Form  f1,string Name)
        {
            f1.Text = Name;
            return string.Empty;
        }
        public static string  Execute(this mytexbox  StringSet, string Text)
        {
            
            return "";
        }
        public static string  setai(this int text)
        {
            if (text==null )
                return string .Empty;


            return  text.ToString("n0");
        }

        public static string replaceSetai(this string  text)
        {
            if (text == null)
                return string.Empty;


            return text.Replace(",","");
        }
        public static  string DateToShamsi(this DateTime dateatime)
        {

            string year = DateTime.Now.Date.ToString().Substring(6, 4);
            string month = DateTime.Now.Date.ToString().Substring(3, 2);
            string day = DateTime.Now.Date.ToString().Substring(0, 2);
            string date = year + "/" + month + "/" + day;

            return date;
        }


    }
}
