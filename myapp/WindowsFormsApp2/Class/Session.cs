using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.ComponentModel;

namespace tnerhbeauty.Class
{
    public static class Session
    {
        public static company_info companyInfo;
        public static company_info CompanyInfo
        {
            get
            {
                if (companyInfo == null)
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        companyInfo = db.company_infos.FirstOrDefault();
                    }
                }
                return companyInfo;
            }
        }
        private static List< amount_client_type> amount_client_type;
        public static List< amount_client_type> Amount_client_type
        {
            get
            {
                if (amount_client_type == null)
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        amount_client_type = db.amount_client_types.ToList();
                    }
                }
                return amount_client_type;
            }
        }
        private static List<product_serch_View> prducts;
        public static List<product_serch_View> getallprodct
        {
            get
            {
                if (prducts == null)
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        prducts = db.product_serch_Views.ToList();
                    }
                }
                return prducts;
            }
        }

        private static List<list_price> _list_price;
        public static List<list_price> list_price
        {
            get
            {
                if (_list_price == null)
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        _list_price = db.list_prices.OrderBy(x =>x.sort).ToList();
                    }
                }
                return _list_price;
            }
        }

        public static int ConvertInt(string p)
        {
            try
            {
                return Convert.ToInt32(p);
            }
            catch
            {
                return 0;
            }
        }
        public static double ConvertDouble(string p)
        {
            try
            {
                return Math.Truncate(Convert.ToDouble(p) * 100) / 100;
            }
            catch
            {
                return 0.00;
            }
        }
        public static decimal Convertdecimal(string p)
        {
            try
            {
                return Math.Truncate(Convert.ToDecimal(p) * 1000) / 1000;
            }
            catch
            {
                return 0.00m ;
            }
        }
        public static string Replace_text(this string p)
        {
            p = Regex.Replace(p, @"(\W|\.|\[|\]|\\|\||\-|\^|\$|\?|\*|\+|\{|\}|\(|\))", @" ").Trim();            
            p = Regex.Replace(p, "عبد ", "عبد");
            p = Regex.Replace(p, "^[ \t\r\n]+|[ \t\r\n]+$", "");
            p = Regex.Replace(p, @"\s+", " ");
            p = Regex.Replace(p, "[أآ]", "ا");
            p = Regex.Replace(p, "ة", "ه");
            p = Regex.Replace(p, "ؤ", "و");
            p = Regex.Replace(p, "ى", "ي");
            return p.ToString();
        }
        public static Byte[] GetByteFromImage(Image image)
        {
            using (MemoryStream stream = new MemoryStream())
            {

                Bitmap bmp = new Bitmap(image);
                bmp.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
        public static Image GetImageFromByteArray(Byte[] ByteArray)
        {
            Image img;
            try
            {
                Byte[] imgbyte = ByteArray;
                using (MemoryStream stream = new MemoryStream(imgbyte, false))
                {
                    img = Image.FromStream(stream);
                }

            }
            catch { img = null; }
            return img;
        }

        public static string quarygetallprodcutsale(string from,string to,string serch)
        {
string s= string.Format(@"
SELECT product.code, product.name AS product_name,
SUM(CASE WHEN prodcut_get_View.DateAdd BETWEEN CONVERT(DATETIME, '{0}  00:00:00', 102) AND CONVERT(DATETIME, '{1} 23:59:59',102) THEN prodcut_get_View.ItemQty ELSE 0 END) AS ItemQty, 
SUM(CASE WHEN prodcut_get_View.DateAdd BETWEEN CONVERT(DATETIME, '{0}  00:00:00', 102) AND CONVERT(DATETIME, '{1} 23:59:59',102) THEN prodcut_get_View.Total ELSE 0 END) AS Total
FROM product LEFT OUTER JOIN prodcut_get_View  ON product.id = prodcut_get_View.ItemID
GROUP BY product.id, product.name, product.code 
HAVING  (product.id LIKE N'{2}')   ORDER BY ItemQty DESC, Total DESC", from, to, serch);

return s;
        }

        public static string get_all_blance_prodcut(string from, string to)
        {
            string s = string.Format(@"
SELECT product.code, product.name AS product_name,
SUM(CASE WHEN store_log.DateAdd < CONVERT(DATETIME, '{1} 23:59:59',102) THEN store_log.ItemQty_in-store_log.ItemQty_out ELSE 0 END) AS Balance_sabk, 
SUM(CASE WHEN store_log.DateAdd BETWEEN CONVERT(DATETIME, '{0}  00:00:00', 102) AND CONVERT(DATETIME, '{1} 23:59:59',102) THEN store_log.ItemQty_in ELSE 0 END) AS ItemQty_in, 
SUM(CASE WHEN store_log.DateAdd BETWEEN CONVERT(DATETIME, '{0}  00:00:00', 102) AND CONVERT(DATETIME, '{1} 23:59:59',102) THEN store_log.ItemQty_out ELSE 0 END) AS ItemQty_out
FROM dbo.store_log RIGHT OUTER JOIN dbo.product ON dbo.store_log.ItemID = dbo.product.id
GROUP BY dbo.product.name, dbo.product.code", from, to);

            return s;
        }

        public static void IntializeData(this ComboBox lkp, object dataSource)
        {
            lkp.IntializeData(dataSource, "name", "id");
        }
        public static void IntializeData(this ComboBox lkp, object dataSource, string displayMember, string valueMember)
        {
            lkp.DataSource = dataSource;
            lkp.DisplayMember = displayMember;
            lkp.ValueMember = valueMember;
        }
        public static user_View User_login;
        public static bool  _User_login(string tel,string pass) 
        {
            using (var db = new DataClasses1DataContext())
            {
                User_login = db.user_Views.Where(x => x.tel == tel&&x.password==pass ).FirstOrDefault();
            }
            if (User_login != null)
                return true;
            else return false;
        }
        public static setting _setting;
        public static setting User_setting()
        {
            if (_setting == null)
            {
                using (var db = new DataClasses1DataContext())
                {
                    _setting = db.settings.Where(x => x.id == User_login.id_setting).FirstOrDefault();
                }
            }
             return _setting;
        }
        public static DateTime GetDate()
        {
            using (var db = new DataClasses1DataContext())
                return db.ExecuteQuery<DateTime>("SELECT GETDATE()").First();
        }

           

    }
}
