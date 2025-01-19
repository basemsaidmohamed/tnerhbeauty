using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using tnerhbeauty.Class;
using tnerhbeauty.Properties;

namespace tnerhbeauty
{
    public partial class frm_Connection : Form
    {
        private SqlConnection cnn;

        private string ConnectionString;

        private SqlConnection cn;

        public frm_Connection()
        {
            InitializeComponent();
        }
        private void btn_new_Click(object sender, EventArgs e)
        {
            panel1.Enabled = true;
            tx_ip_adress.Enabled = true;
            btn_save.Visible = false;
            btn_new.Visible = false;
            btn_test.Visible = true;
            pictureBox1.Image = null;
            label1.Text = string.Empty;
            ConnectionString = "";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)configuration.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["tnerhbeauty.Properties.Settings.DBBETTERLIFE_MDF"].ConnectionString = ConnectionString;
            configuration.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
            Settings.Default.server = (rd_local.Checked ? rd_local.Text : rd_server.Text);
            Settings.Default.Save();
            Settings.Default.Reload();
            home home2 = Application.OpenForms.OfType<home>().SingleOrDefault();
            if (home2 != null)
            {
                home2.ts_server.Text = Settings.Default.server;
            }
            Close();
        }

        private void rd_local_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = string.Empty;
            if (rd_local.Checked)
            {
                tx_ip_adress.Visible = false;
                return;
            }
            tx_ip_adress.Visible = true;
            tx_ip_adress.Focus();
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            ConnectionString = "";
            if (rd_server.Checked)
            {
                Match match = Regex.Match(tx_ip_adress.Text, "\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}\\.\\d{1,3}");
                if (!match.Success)
                {
                    label1.Text = "ÌÃ» ﬂ «»… ⁄‰Ê«‰ ip »‘ﬂ· ’ÕÌÕ";
                    tx_ip_adress.Focus();
                    tx_ip_adress.SelectAll();
                    return;
                }
                ConnectionString = $"Data Source={tx_ip_adress.Text};Initial Catalog=DBBETTERLIFESERVER;User ID=ba;Password=ba;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False";
            }
            else
            {
                ConnectionString = "Data Source=.\\sqlexpress;AttachDbFilename=|DataDirectory|\\dbbetterlife.mdf;Integrated Security=True;Connect Timeout=20; Encrypt = False; TrustServerCertificate = False";
            }
            cnn = new SqlConnection(ConnectionString);
            try
            {
                cnn.Open();
                OkConnection();
            }
            catch (SqlException ex)
            {
                pictureBox1.Image = Resources.mark;
                if (ex.Number == -1)
                {
                    label1.Text = "·„ Ì „ «·⁄ÀÊ— ⁄·Ì «·”Ì—›— «·„Õ·Ì »—Ã«¡ «÷«›… sqlserver «·Ì «·ÃÂ«“";
                    if (MyMessageBox.showMessage(" «ﬂÌœ", "Â·  —Ìœ «‰‘«¡ ﬁ«⁄œ… »Ì«‰«  „Õ·Ì… ⁄·Ì Â–« «·ÃÂ«“ ", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        setupSqlServer();
                    }
                }
                else if (ex.Number == 15350)
                {
                    label1.Text = "·„ Ì „ «·⁄ÀÊ— ⁄·Ì ﬁ«⁄œ… «·»Ì«‰«  «·„Õ·Ì… ";
                    if (MyMessageBox.showMessage(" «ﬂÌœ", "Â·  —Ìœ «‰‘«¡ ﬁ«⁄œ… »Ì«‰«  „Õ·Ì… ⁄·Ì Â–« «·ÃÂ«“ ", "", MessageBoxButtons.YesNo) == DialogResult.Yes && ChekDataBase())
                    {
                        label1.Text = " „ «‰‘«¡ ﬁ«⁄œ… »Ì«‰«  „Õ·Ì… ⁄·Ì Â–« «·ÃÂ«“ »—Ã«¡ ⁄„· «Œ »«— «Œ—";
                        OkConnection();
                    }
                }
                else if (ex.Number == 53)
                {
                    label1.Text = "⁄‰Ê«‰ ip  €Ì— ’«·Õ";
                }
                else if (ex.Number == 4060)
                {
                    label1.Text = " ·„ Ì „ «·⁄ÀÊ— ⁄·Ì ﬁ«⁄œ… «·»Ì«‰«  »«·”Ì—›—";
                }
                else if (ex.Number == 5120)
                {
                    label1.Text = "’·«ÕÌ«  «·Ê’Ê· ·œÌﬂ ";
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cnn.Close();
            }
        }

        private void OkConnection()
        {
            label1.Text = " „ «·« ’«· »‰Ã«Õ ... !";
            btn_save.Visible = true;
            btn_new.Visible = true;
            pictureBox1.Visible = true;
            pictureBox1.Image = Resources.check;
            panel1.Enabled = false;
            tx_ip_adress.Enabled = false;
            btn_test.Visible = false;
        }

        private void setupSqlServer()
        {
            Process process = null;
            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                process = Process.Start(directoryName + "\\sql\\setup.exe", "/q /Action=Install /IACCEPTSQLSERVERLICENSETERMS /Hideconsole /Features=SQLEngine /InstanceName=SQLEXPRESS  /SQLSYSADMINACCOUNTS=\"NT AUTHORITY\\SYSTEM\" /SQLSVCACCOUNT=\"NT AUTHORITY\\SYSTEM\" /BROWSERSVCSTARTUPTYPE=\"Automatic\"");
                label1.Text = "Â–… «·⁄„·Ì… ”Ê›  ” €—ﬁ ﬂÀÌ—« „‰ «·Êﬁ   »—Ã«¡ «·«‰ Ÿ«¡ ............ ";
                process.WaitForExit();
                label1.Text = " „ «·⁄„·Ì… »‰Ã«Õ";
                if (ChekDataBase())
                {
                    OkConnection();
                }
            }
            catch
            {
                label1.Text = "ÕœÀ Œÿ«¡ ";
            }
        }

        private bool ChekDataBase()
        {
            string text =
                @"CREATE TABLE [dbo].[amount_client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_type] [int] NOT NULL,
	[id_client] [int] NOT NULL,
	[amount_in] [decimal](18, 2) NOT NULL,
	[amount_out] [decimal](18, 2) NOT NULL,
	[nots] [nvarchar](max) NOT NULL,
	[Source_Id] [int] NOT NULL,
	[id_fara] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateAdd] [datetime2](0) NOT NULL,
	[DateServer] [datetime2](0) NULL,
 CONSTRAINT [PK_amount_client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[amount_client_type]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[amount_client_type](
	[id] [int] NOT NULL,
	[name] [nvarchar](300) NULL,
	[type] [nvarchar](max) NULL,
 CONSTRAINT [PK_amount_client_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[tel] [nvarchar](100) NOT NULL,
	[adress] [nvarchar](300) NULL,
	[nots] [nvarchar](300) NULL,
	[list_price] [nvarchar](300) NOT NULL,
	[is_stop] [bit] NOT NULL,
	[id_fara] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateServer] [datetime2](0) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[company_info]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[company_info](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NOT NULL,
	[Specialized_in] [nvarchar](max) NULL,
	[tel] [nvarchar](max) NULL,
	[hedar] [nvarchar](max) NULL,
	[footer] [nvarchar](max) NULL,
	[nots] [nvarchar](max) NULL,
	[adress] [nvarchar](max) NULL,
	[image] [varbinary](max) NULL,
 CONSTRAINT [PK_company_info] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fara]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fara](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name_fara] [nvarchar](200) NOT NULL,
	[adress] [nvarchar](200) NULL,
	[tel] [nvarchar](200) NULL,
	[is_stop] [bit] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateServer] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_branch] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[invoice_type]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[invoice_type](
	[id] [int] NOT NULL,
	[name_invoice_type] [nvarchar](200) NOT NULL,
	[frm_name] [nvarchar](200) NULL,
 CONSTRAINT [PK_invoice_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetails]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceHeaderID] [int] NOT NULL,
	[ItemID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ItemQty] [decimal](18, 3) NOT NULL,
	[TotalPrice] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[Total] [decimal](18, 2) NOT NULL,
	[store_id] [int] NOT NULL,
 CONSTRAINT [PK_InvoiceDetails] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceHeader]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceHeader](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_cient] [int] NULL,
	[Discount_type] [int] NOT NULL,
	[Discount_percent] [numeric](18, 2) NOT NULL,
	[Discount] [numeric](18, 2) NOT NULL,
	[Extra_type] [int] NOT NULL,
	[Extra_percent] [numeric](18, 2) NOT NULL,
	[Extra] [numeric](18, 2) NOT NULL,
	[Total_product] [numeric](18, 2) NOT NULL,
	[Net] [numeric](18, 2) NOT NULL,
	[is_agel] [bit] NOT NULL,
	[id_invoice_type] [int] NOT NULL,
	[id_fara] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[DateAdd] [datetime2](0) NOT NULL,
	[DateServer] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_InvoiceHeader] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[list_price]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[list_price](
	[id] [nvarchar](300) NOT NULL,
	[name_row] [nvarchar](300) NOT NULL,
	[sort] [int] NOT NULL,
 CONSTRAINT [PK_list_price] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[code] [nvarchar](200) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[price_buy] [decimal](18, 2) NOT NULL,
	[price_sale] [decimal](18, 2) NOT NULL,
	[price_sale_100] [decimal](18, 2) NOT NULL,
	[price_sale_75] [decimal](18, 2) NOT NULL,
	[price_sale_vip2] [decimal](18, 2) NOT NULL,
	[price_sale_vip1] [decimal](18, 2) NOT NULL,
	[price_1] [decimal](18, 2) NOT NULL,
	[price_2] [decimal](18, 2) NOT NULL,
	[price_3] [decimal](18, 2) NOT NULL,
	[price_4] [decimal](18, 2) NOT NULL,
	[price_5] [decimal](18, 2) NOT NULL,
	[price_6] [decimal](18, 2) NOT NULL,
	[price_7] [decimal](18, 2) NOT NULL,
	[price_8] [decimal](18, 2) NOT NULL,
	[price_9] [decimal](18, 2) NOT NULL,
	[price_10] [decimal](18, 2) NOT NULL,
	[min_mum] [decimal](18, 3) NULL,
	[update_price] [date] NOT NULL,
	[category] [int] NOT NULL,
	[is_stop] [bit] NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[setting]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[setting](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[show_invoice_pay] [bit] NOT NULL,
	[add_invoice_pay] [bit] NOT NULL,
	[update_invoice_pay] [bit] NOT NULL,
	[delete_invoice_pay] [bit] NOT NULL,
	[show_invoice_sale] [bit] NOT NULL,
	[add_invoice_sale] [bit] NOT NULL,
	[update_invoice_sale] [bit] NOT NULL,
	[delete_invoice_sale] [bit] NOT NULL,
	[show_invoice_to_stroe] [bit] NOT NULL,
	[add_invoice_to_stroe] [bit] NOT NULL,
	[update_invoice_to_stroe] [bit] NOT NULL,
	[delete_invoice_to_stroe] [bit] NOT NULL,
	[show_product] [bit] NOT NULL,
	[add_product] [bit] NOT NULL,
	[update_product] [bit] NOT NULL,
	[delete_product] [bit] NOT NULL,
	[update_price_producut] [bit] NOT NULL,
	[update_price_producut_exal] [bit] NOT NULL,
	[kashf_hesab_prodct] [bit] NOT NULL,
	[blance_in_storses] [bit] NOT NULL,
	[store_in_and_out] [bit] NOT NULL,
	[report_mabeat_product] [bit] NOT NULL,
	[show_client] [bit] NOT NULL,
	[add_client] [bit] NOT NULL,
	[update_client] [bit] NOT NULL,
	[delete_client] [bit] NOT NULL,
	[show_amount_client] [bit] NOT NULL,
	[add_amount_client] [bit] NOT NULL,
	[update_amount_client] [bit] NOT NULL,
	[delete_amount_client] [bit] NOT NULL,
	[kashf_hesab_client] [bit] NOT NULL,
	[show_fara] [bit] NOT NULL,
	[add_fara] [bit] NOT NULL,
	[update_fara] [bit] NOT NULL,
	[delete_fara] [bit] NOT NULL,
	[show_store] [bit] NOT NULL,
	[add_store] [bit] NOT NULL,
	[update_store] [bit] NOT NULL,
	[delete_store] [bit] NOT NULL,
	[show_user] [bit] NOT NULL,
	[add_user] [bit] NOT NULL,
	[update_user] [bit] NOT NULL,
	[delete_user] [bit] NOT NULL,
	[show_setting] [bit] NOT NULL,
	[add_setting] [bit] NOT NULL,
	[update_setting] [bit] NOT NULL,
	[delete_setting] [bit] NOT NULL,
	[update_company] [bit] NOT NULL,
	[show_InvoiceHeader_wait] [bit] NOT NULL,
	[add_InvoiceHeader_wait] [bit] NOT NULL,
	[update_InvoiceHeader_wait] [bit] NOT NULL,
	[delete_InvoiceHeader_wait] [bit] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateServer] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_setting] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[store]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[store](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[store_name] [nvarchar](200) NOT NULL,
	[id_fara] [int] NOT NULL,
	[adress] [nvarchar](200) NULL,
	[tel] [nvarchar](200) NULL,
	[is_stop] [bit] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateServer] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_store] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[store_log]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[store_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NOT NULL,
	[ItemQty_in] [decimal](18, 3) NOT NULL,
	[ItemQty_out] [decimal](18, 3) NOT NULL,
	[nots] [nvarchar](max) NOT NULL,
	[Source_Id] [int] NOT NULL,
	[id_type] [int] NOT NULL,
	[store_id] [int] NOT NULL,
	[id_fara] [int] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateAdd] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_store_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [nvarchar](200) NOT NULL,
	[tel] [nvarchar](200) NOT NULL,
	[password] [nvarchar](200) NOT NULL,
	[id_fara] [int] NOT NULL,
	[adress] [nvarchar](200) NULL,
	[id_setting] [int] NOT NULL,
	[is_stop] [bit] NOT NULL,
	[id_user] [int] NOT NULL,
	[DateServer] [datetime2](0) NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[amount_client_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[amount_client_View]
AS
SELECT        dbo.amount_client.id, dbo.amount_client.id_client, dbo.amount_client.DateAdd, dbo.Client.name AS name_client, dbo.amount_client.id_type, dbo.amount_client_type.name AS name_type, dbo.amount_client.amount_in, 
                         dbo.amount_client.amount_out, ISNULL(dbo.amount_client.amount_in - dbo.amount_client.amount_out, 0) AS Balance, dbo.amount_client.nots, dbo.amount_client.Source_Id, dbo.amount_client_type.type, dbo.[user].user_name, 
                         dbo.fara.name_fara, dbo.amount_client.DateServer
FROM            dbo.amount_client INNER JOIN
                         dbo.Client ON dbo.amount_client.id_client = dbo.Client.id INNER JOIN
                         dbo.amount_client_type ON dbo.amount_client.id_type = dbo.amount_client_type.id INNER JOIN
                         dbo.fara ON dbo.amount_client.id_fara = dbo.fara.id INNER JOIN
                         dbo.[user] ON dbo.amount_client.id_user = dbo.[user].id
GO
/****** Object:  View [dbo].[Balance_product_store_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[Balance_product_store_View]
AS
SELECT        dbo.store_log.ItemID, dbo.product.name, dbo.store_log.store_id, SUM(dbo.store_log.ItemQty_in - dbo.store_log.ItemQty_out) AS Balance, dbo.store.store_name
FROM            dbo.product INNER JOIN
                         dbo.store_log ON dbo.product.id = dbo.store_log.ItemID INNER JOIN
                         dbo.store ON dbo.store_log.store_id = dbo.store.id
GROUP BY dbo.store_log.ItemID, dbo.product.name, dbo.store_log.store_id, dbo.store.store_name
GO
/****** Object:  View [dbo].[client_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[client_View]
AS
SELECT        dbo.Client.id, dbo.Client.name, dbo.Client.tel, dbo.Client.adress, dbo.Client.nots, dbo.list_price.name_row, dbo.Client.is_stop, dbo.Client.list_price, ISNULL(SUM(dbo.amount_client.amount_in - dbo.amount_client.amount_out), 
                         0) AS Balance, CASE WHEN ISNULL(SUM(dbo.amount_client.amount_in - dbo.amount_client.amount_out), 0) > 0 THEN N'·Â' WHEN ISNULL(SUM(dbo.amount_client.amount_in - dbo.amount_client.amount_out), 0) 
                         < 0 THEN N'⁄·Ì…' ELSE N'' END AS Balance_type, dbo.Client.id_user, dbo.[user].user_name, dbo.Client.id_fara, dbo.fara.name_fara, dbo.Client.DateServer
FROM            dbo.Client INNER JOIN
                         dbo.list_price ON dbo.Client.list_price = dbo.list_price.id INNER JOIN
                         dbo.[user] ON dbo.Client.id_user = dbo.[user].id INNER JOIN
                         dbo.fara ON dbo.Client.id_fara = dbo.fara.id LEFT OUTER JOIN
                         dbo.amount_client ON dbo.Client.id = dbo.amount_client.id_client
GROUP BY dbo.Client.id, dbo.Client.name, dbo.Client.tel, dbo.Client.adress, dbo.Client.nots, dbo.list_price.name_row, dbo.Client.DateServer, dbo.Client.list_price, dbo.Client.is_stop, dbo.[user].user_name, dbo.Client.id_user, 
                         dbo.Client.id_fara, dbo.fara.name_fara
GO
/****** Object:  View [dbo].[InvoiceDetails_rep_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[InvoiceDetails_rep_View]
AS
SELECT        dbo.InvoiceDetails.InvoiceHeaderID, dbo.product.name + ' ' + dbo.product.code AS namepro, dbo.InvoiceDetails.ItemQty, dbo.InvoiceDetails.Price, dbo.InvoiceDetails.Discount, dbo.InvoiceDetails.Total
FROM            dbo.InvoiceDetails INNER JOIN
                         dbo.product ON dbo.InvoiceDetails.ItemID = dbo.product.id
GO
/****** Object:  View [dbo].[InvoiceHeaderView]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[InvoiceHeaderView]
AS
SELECT        dbo.InvoiceHeader.id, dbo.InvoiceHeader.DateAdd, dbo.InvoiceHeader.id_cient, dbo.Client.name, dbo.InvoiceHeader.Total_product, dbo.InvoiceHeader.Extra, dbo.InvoiceHeader.Discount, dbo.InvoiceHeader.Net, 
                         dbo.InvoiceHeader.is_agel, dbo.InvoiceHeader.Notes, dbo.InvoiceHeader.id_invoice_type, dbo.invoice_type.name_invoice_type, dbo.InvoiceHeader.id_fara, dbo.fara.name_fara, dbo.InvoiceHeader.id_user, 
                         dbo.[user].user_name, dbo.InvoiceHeader.DateServer
FROM            dbo.InvoiceHeader INNER JOIN
                         dbo.invoice_type ON dbo.InvoiceHeader.id_invoice_type = dbo.invoice_type.id INNER JOIN
                         dbo.fara ON dbo.InvoiceHeader.id_fara = dbo.fara.id INNER JOIN
                         dbo.[user] ON dbo.InvoiceHeader.id_user = dbo.[user].id INNER JOIN
                         dbo.Client ON dbo.InvoiceHeader.id_cient = dbo.Client.id
GO
/****** Object:  View [dbo].[InvoiceHeaderView_in]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[InvoiceHeaderView_in]
AS
SELECT        dbo.InvoiceHeader.id, dbo.InvoiceHeader.DateAdd, dbo.invoice_type.name_invoice_type, dbo.InvoiceHeader.Notes, dbo.InvoiceHeader.id_invoice_type, dbo.InvoiceHeader.id_fara, dbo.fara.name_fara, 
                         dbo.InvoiceHeader.id_user, dbo.[user].user_name, dbo.InvoiceHeader.DateServer
FROM            dbo.InvoiceHeader INNER JOIN
                         dbo.invoice_type ON dbo.InvoiceHeader.id_invoice_type = dbo.invoice_type.id INNER JOIN
                         dbo.fara ON dbo.InvoiceHeader.id_fara = dbo.fara.id INNER JOIN
                         dbo.[user] ON dbo.InvoiceHeader.id_user = dbo.[user].id
GO
/****** Object:  View [dbo].[prodcut_get_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[prodcut_get_View]
AS
SELECT        dbo.InvoiceHeader.id, dbo.InvoiceHeader.DateAdd, dbo.InvoiceHeader.id_cient, dbo.Client.name AS Client_name, dbo.InvoiceDetails.ItemID, dbo.product.code, dbo.product.name AS product_name, dbo.InvoiceDetails.ItemQty, 
                         dbo.InvoiceDetails.Total, dbo.InvoiceHeader.is_agel
FROM            dbo.InvoiceDetails INNER JOIN
                         dbo.product ON dbo.InvoiceDetails.ItemID = dbo.product.id INNER JOIN
                         dbo.InvoiceHeader ON dbo.InvoiceDetails.InvoiceHeaderID = dbo.InvoiceHeader.id INNER JOIN
                         dbo.Client ON dbo.InvoiceHeader.id_cient = dbo.Client.id
GO
/****** Object:  View [dbo].[product_min_mum_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[product_min_mum_View]
AS
SELECT  dbo.product.id, dbo.product.name + N' ' + dbo.product.code AS fullname, ISNULL(SUM(dbo.store_log.ItemQty_in - dbo.store_log.ItemQty_out), 0) AS Balance, dbo.product.min_mum, 
                   ABS(ISNULL(SUM(dbo.store_log.ItemQty_in - dbo.store_log.ItemQty_out), 0) - dbo.product.min_mum) AS want
FROM      dbo.store_log INNER JOIN
                   dbo.store ON dbo.store_log.store_id = dbo.store.id RIGHT OUTER JOIN
                   dbo.product ON dbo.product.id = dbo.store_log.ItemID
GROUP BY dbo.product.name + N' ' + dbo.product.code, dbo.product.min_mum, dbo.product.id
HAVING  (dbo.product.min_mum IS NOT NULL)
GO
/****** Object:  View [dbo].[product_serch_seore_Viewaa]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[product_serch_seore_Viewaa]
AS
SELECT        dbo.product.id, dbo.product.name + N' ' + dbo.product.code AS fullname, dbo.product.name, dbo.product.code, dbo.product.price_sale, dbo.product.price_sale_100, dbo.product.price_sale_75, dbo.product.price_sale_vip2, 
                         dbo.product.price_sale_vip1, dbo.product.price_1, dbo.product.price_2, dbo.product.price_3, dbo.product.price_4, dbo.product.price_5, dbo.product.price_6, dbo.product.price_7, dbo.product.price_8, dbo.product.price_9, 
                         dbo.product.price_10, dbo.product.update_price, ISNULL(SUM(dbo.store_log.ItemQty_in - dbo.store_log.ItemQty_out), 0) AS Balance, dbo.product.is_stop, dbo.store_log.store_id, dbo.store.store_name
FROM            dbo.store_log INNER JOIN
                         dbo.store ON dbo.store_log.store_id = dbo.store.id RIGHT OUTER JOIN
                         dbo.product ON dbo.store_log.ItemID = dbo.product.id
GROUP BY dbo.product.id, dbo.product.name, dbo.product.code, dbo.product.price_sale, dbo.product.price_sale_100, dbo.product.price_sale_75, dbo.product.price_sale_vip2, dbo.product.price_sale_vip1, 
                         dbo.product.name + N' ' + dbo.product.code, dbo.product.is_stop, dbo.product.update_price, dbo.store_log.store_id, dbo.store.store_name, dbo.product.price_1, dbo.product.price_2, dbo.product.price_3, dbo.product.price_4, 
                         dbo.product.price_5, dbo.product.price_6, dbo.product.price_7, dbo.product.price_8, dbo.product.price_9, dbo.product.price_10
GO
/****** Object:  View [dbo].[product_serch_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[product_serch_View]
AS
SELECT     dbo.product.id, dbo.product.name + N' ' + dbo.product.code AS fullname, dbo.product.name, dbo.product.code, dbo.product.price_sale, dbo.product.price_sale_100, dbo.product.price_sale_75, dbo.product.price_sale_vip2, dbo.product.price_sale_vip1, dbo.product.price_1, 
                  dbo.product.price_2, dbo.product.price_3, dbo.product.price_4, dbo.product.price_5, dbo.product.price_6, dbo.product.price_7, dbo.product.price_8, dbo.product.price_9, dbo.product.price_10, dbo.product.update_price, ISNULL(SUM(dbo.store_log.ItemQty_in - dbo.store_log.ItemQty_out), 0) 
                  AS Balance, dbo.product.min_mum, dbo.store_log.store_id, dbo.store.store_name, dbo.product.is_stop
FROM        dbo.store_log INNER JOIN
                  dbo.store ON dbo.store_log.store_id = dbo.store.id RIGHT OUTER JOIN
                  dbo.product ON dbo.product.id = dbo.store_log.ItemID
GROUP BY dbo.product.id, dbo.product.name, dbo.product.code, dbo.product.price_sale, dbo.product.price_sale_100, dbo.product.price_sale_75, dbo.product.price_sale_vip2, dbo.product.price_sale_vip1, dbo.product.name + N' ' + dbo.product.code, dbo.product.is_stop, dbo.product.update_price, 
                  dbo.store_log.store_id, dbo.store.store_name, dbo.product.price_1, dbo.product.price_2, dbo.product.price_3, dbo.product.price_4, dbo.product.price_5, dbo.product.price_6, dbo.product.price_7, dbo.product.price_8, dbo.product.price_9, dbo.product.price_10, dbo.product.min_mum
GO
/****** Object:  View [dbo].[store_log_Balance_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[store_log_Balance_View]
AS
SELECT        dbo.product.code, dbo.product.name AS product_name, 0.000 AS Balance_sabk, dbo.store_log.ItemQty_in, dbo.store_log.ItemQty_out, 0.000 AS Balance, dbo.store_log.DateAdd, dbo.product.id AS ItemID, dbo.store.store_name, 
                         dbo.store_log.store_id
FROM            dbo.product INNER JOIN
                         dbo.store_log ON dbo.product.id = dbo.store_log.ItemID INNER JOIN
                         dbo.store ON dbo.store_log.store_id = dbo.store.id
GO
/****** Object:  View [dbo].[store_log_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[store_log_View]
AS
SELECT        dbo.store_log.ItemID, dbo.store_log.DateAdd, dbo.invoice_type.name_invoice_type, dbo.product.code, dbo.product.name AS product_name, dbo.store_log.ItemQty_in, dbo.store_log.ItemQty_out, 
                         ISNULL(dbo.store_log.ItemQty_in - dbo.store_log.ItemQty_out, 0) AS Balance, dbo.store_log.nots, dbo.store_log.Source_Id, dbo.store.store_name, dbo.[user].user_name, dbo.store_log.id_type, dbo.store_log.store_id, 
                         dbo.store_log.id
FROM            dbo.product INNER JOIN
                         dbo.store_log ON dbo.product.id = dbo.store_log.ItemID INNER JOIN
                         dbo.invoice_type ON dbo.store_log.id_type = dbo.invoice_type.id INNER JOIN
                         dbo.store ON dbo.store_log.store_id = dbo.store.id INNER JOIN
                         dbo.fara ON dbo.store_log.id_fara = dbo.fara.id INNER JOIN
                         dbo.[user] ON dbo.store_log.id_user = dbo.[user].id
GO
/****** Object:  View [dbo].[store_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[store_View]
AS
SELECT        dbo.store.id, dbo.store.store_name, dbo.store.id_fara, dbo.fara.name_fara, dbo.store.adress, dbo.store.tel, dbo.store.is_stop, dbo.store.id_user, dbo.[user].user_name, dbo.store.DateServer
FROM            dbo.store INNER JOIN
                         dbo.fara ON dbo.store.id_fara = dbo.fara.id INNER JOIN
                         dbo.[user] ON dbo.store.id_user = dbo.[user].id
GO
/****** Object:  View [dbo].[user_View]    Script Date: 14/12/2024 04:24:50 „ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[user_View]
AS
SELECT        dbo.[user].id, dbo.[user].user_name, dbo.[user].tel, dbo.[user].adress, dbo.[user].id_fara, dbo.fara.name_fara, dbo.[user].password, dbo.[user].id_setting, dbo.setting.name AS name_setting, dbo.[user].is_stop, 
                         dbo.[user].DateServer, user_1.user_name AS user_Add
FROM            dbo.[user] INNER JOIN
                         dbo.fara ON dbo.[user].id_fara = dbo.fara.id INNER JOIN
                         dbo.setting ON dbo.[user].id_setting = dbo.setting.id LEFT OUTER JOIN
                         dbo.[user] AS user_1 ON dbo.[user].id_user = user_1.id
GO
INSERT [dbo].[amount_client_type] ([id], [name], [type]) VALUES (1, N'œ›⁄…  Ê«—œÂ „‰ «·⁄„Ì·', N'add_amount_client')
GO
INSERT [dbo].[amount_client_type] ([id], [name], [type]) VALUES (2, N'œ›⁄… „‰’—›Â «·Ì «·⁄„Ì·', N'add_amount_client')
GO
INSERT [dbo].[amount_client_type] ([id], [name], [type]) VALUES (3, N'»Ì«‰ «”⁄«—', N'frm_InvoiceHeader')
GO
INSERT [dbo].[amount_client_type] ([id], [name], [type]) VALUES (4, N'›« Ê—… „»Ì⁄«  „‰ «·„Œ“‰', N'frm_InvoiceHeader_wait')
GO
SET IDENTITY_INSERT [dbo].[Client] ON 
GO
INSERT [dbo].[Client] ([id], [name], [tel], [adress], [nots], [list_price], [is_stop], [id_fara], [id_user], [DateServer]) VALUES (1, N'⁄„Ì· ‰ﬁœÌ', N'01020304050', N'', N'', N'price_10', 0, 1, 2, CAST(N'2024-03-10T13:44:46.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[company_info] ON 
GO
INSERT [dbo].[company_info] ([id], [name], [Specialized_in], [tel], [hedar], [footer], [nots], [adress], [image]) VALUES (0, N'«·„⁄«œÌ ”Ì Ì ”‰ —', N'«·“ÌÊ  «·⁄ÿ—Ì… Ê„” Õ÷—«  «· Ã„Ì· Ê«·⁄‰«Ì… »«·»‘—…', N'01020304050 - 0124067350', N'TNERH BEAUTY', N'„Ê«⁄Ìœ «·⁄„· ÌÊ„Ì« „‰ «·”«⁄… 9 ’ Õ Ì 1 ’ „⁄«œ« «·Ã„⁄… „‰ ﬂ· «”»Ê⁄', NULL, N'«·„⁄«œÌ ‘ 9 »ÃÊ«— «·»‰ﬂ «·«Â·Ì', 0xFFD8FFE000104A46494600010101006000600000FFDB004300080606070605080707070909080A0C140D0C0B0B0C1912130F141D1A1F1E1D1A1C1C20242E2720222C231C1C2837292C30313434341F27393D38323C2E333432FFDB0043010909090C0B0C180D0D1832211C213232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232323232FFC000110800C800C803012200021101031101FFC4001F0000010501010101010100000000000000000102030405060708090A0BFFC400B5100002010303020403050504040000017D01020300041105122131410613516107227114328191A1082342B1C11552D1F02433627282090A161718191A25262728292A3435363738393A434445464748494A535455565758595A636465666768696A737475767778797A838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE1E2E3E4E5E6E7E8E9EAF1F2F3F4F5F6F7F8F9FAFFC4001F0100030101010101010101010000000000000102030405060708090A0BFFC400B51100020102040403040705040400010277000102031104052131061241510761711322328108144291A1B1C109233352F0156272D10A162434E125F11718191A262728292A35363738393A434445464748494A535455565758595A636465666768696A737475767778797A82838485868788898A92939495969798999AA2A3A4A5A6A7A8A9AAB2B3B4B5B6B7B8B9BAC2C3C4C5C6C7C8C9CAD2D3D4D5D6D7D8D9DAE2E3E4E5E6E7E8E9EAF2F3F4F5F6F7F8F9FAFFDA000C03010002110311003F00F9FE8A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A075AF4FB0F82DADEB5E0DD3F5FD1AE20B96B988C8D6921F2DC6188E18F07A0EB8A00F30A2B7B51F06789B4B98C57BA0EA10BFF00D7BB153F420107F3AA7FD83AC0FF00984DF7FE03BFF850066D15A3FD85AC7FD02AFBFF0001DFFC283A16AE324E977A001924DBBFF8500675156ACACAE350B95B7B68CBC8F9E3D00E4927B003926A58B47D46E13CCB6B0BA9E2248592285995B07B1028B81428AD2FEC1D63FE8157FF00F80CFF00E147F60EB1FF00409BEFFC067FF0A00CEA2B6B4BF0AEB1ACB4A96569BDA16DB22B3AA329F70C4115B43E18788844D248B6B1AAA963BA604E00CF606B3956A70766D262724B76715451456830A28A2800A28A2800A28A2800A28A2800A28A2800A28A28001D6BED4F86B07D9FE1BF87908C1FB0C6DFF7D0CFF5AF8AC57DC1E1C6874CF0469467758A1B7D3A22ECE70142C60924F60280362E2E21B4B779EE268E189065A491C2AA8F524F02B92B9F8ADE06B390A49E24B4661C1F2B7483F350457CF1F14BE245C78DB58782D2578F44B662B6F1671E691FF2D187A9EC0F41EF9AF3BCD007D807E3478047FCC741FA5BCBFF00C4D79E7C4AF8B29E23B683C39E0DB89A5FB61DB713A2323303C08D7383CF73E9C7AD781D7A6FC26D2125B8BBD5A450C61C43167B330C93F5C607E35957AAA8D3737D0993B2B8BAEE970781FC1BF6485964D53523E5CD30EA1072CABE83A0F7CD7B8DAEBDA07C32F06787F4FD6EF0DAEEB6545C44CDB98005CE141C72DFAD789FC48CB78BB418E5CF9184EBD399067F4C575FFB4AFF00C7BF873D375C7F24ACF08DCA929B776F5153BB8DDF53BA1F1AFC024E3FB6CFFE03CBFF00C4D5FB2F8A9E07BF91521F11DA2B31C013168BF560057C67466BA4B3EB3F1CF80DB58913C4FE16922875D89776E461E5DEA7F75B1C124743DFA1EC471B67E238757D17518E48DAD750B58645B9B593868D8020F07B66B9AF83BF135FC35A82687ABCCC747B96023766C8B673DFD94F71DBAFAD7A27C65F075A4DA0DD78B6C246B4D4ED2202578BA5CC4C4290D8EA70783E9C1ED8E6C461635ACDE8D752250523E603D69294F53495D258514514005145140051451400514514005145140051451400E452EE140C92702BDA7E307C45F3AD62F07E9137FA3DBC6897F221E1D940FDD83E808E7D4F1DABC54120E41C63B8A52C58EE24924E493DE801B45145002D7B27C24915BC3979182372DD648F62A31FC8D7997873486D6B588ED7911AA349291D954127F3C63F1AE8FE196B634EF10358CA76C37A028C9E038E57F3E47E22B931D0F6946515BAD48A8AF1691DC7C45D09B56D03ED5029375644C8B8EA57F887E80FE1589F13BC4EBE2CF00F83751DC0DC289E1B819E44AA230DF9F07F1AF4B20152080411820F7AF9F7C5B68FA46BB7BA4C6E45A47399628FB0DC01C8FC303F0AE4CAABF341D37D36228CB4B339EA28A2BD6360AF62F0DFC453AAFC2ED77C25ABCE0DD4360E6C6576E644519F2C9F50071EA38ED5E3B450007AD14514005145140051451400514514005145140051451400514514005145140051451401E81F0A1E01E20BB8A5C6F96D4AA83DC64647E5593E2BF0B5E785B53F35031B369375BCEBDB07201F461FAE2B02C2FEE34DBE86F2D2431CF1306461D8D7B3693AEE9FF103C3F73A6DC2AC776D1E2488F66ECEBEC0E3DC570D773A357DA2D62EC9F97999CAE9DFA1B3E14D717C41E1EB6BD2479D8F2E751D9D7AFE7C1FC6BCABE26C65BC69701012443196C0FF0067935D07C2792582EF57D364FE02ADB7D183153FD2B316E21D6BE2EB065125BCB33C04750542153FC8D73D0A4A96266D6C95FEF2231B4DBE879ED157B57D3DF4AD5AEAC64FBD04AC99F500F07F118AA35EB269ABA370A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A28034EC746BCD52191AC6313BC43734287F7817D42F523E99C558F0EDDCFA4F8A2C265DD1C91DC2AB020838240208FA1359D657971A7DE45776B2B47344C191D4F20D7AF6BDA35BF8B3C230EB90C2B16A4B6E27574182C40CB293DFA1C1ED5856AAA0D29AD1E84C9DB47D4E7746D4C687A6F89B5C46026B9B96B6B5F52C589247D0107F0AD5F877E0FB8B49FFB775152923A9F22161C807AB1F424741EF54FE1DE9435868EF6ED3759E9D91046DC8699BE66723BE38FD3D2BA9F19F8D60F0EDAB5B5B959752917E541C88B3FC4DFD077AE0C44E529BA3495DBDDF646526EEE2B76797FC409A39BC6DA9188E543AA923D42807F515CC5492CAF34AD248C59DD89662724927249A8EBD5A71E58A8F646C959584A28A298C28A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0070AFA0FC30631E05D3CA90545973F5C1CFEB9AF9EEBD63E1C6BA97BA1DCF87A470B72A8E6DF27EF2B03951EE09CFD0FB570E3E9CA74D35D1DCCEAABA4FB1169BAEFFC235F0BED65B503EDB7734891719C124E5B1DF000C7BE2B8CD6F47B9D32DA2B9D56663A95E1F34404E5957FBCE7D49E82B7BC27225EEB1E1FD22EC0CD8CF72CD1B0EF80C3F507F2A87E28DA4B178B3CF724C73C2A6327D86D23F31FAD14AD4EB382DDDDDFF408E8EDDCE1A8A28AEE340A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A2800A28A5A00415F48F873E11C1A9FC2ED24BB369FAF8DD7705DAAE1A32C72AAC3A95DA178EA3F30789F845F0B27F125EC3ADEAF6EC9A342E1A347E3ED4C3A01FEC83D4F7E83BD7D46000300000761401F1FF0089A0D5FC2BE33B4BAD62C3EC9A94720792488661BA50705D4FA919047F2E95ABF16DE39C690221B9D924906064ED3B4E7E9D6BD27F6804B39BC39A35BCCC91CF25FF00C921FE0408779FA636FE9553E19785E6F106B92F8BF53B62BA72C06CF4BB7957EF47B769720F62B91EE58FA573CA92752335D2E4B57699F37515E9DF14FE175CF842FA5D4B4D8A49B4395F28CA0936E4FF00037B7A37E079AF31AE82828A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A28A0028A2B4ACB45BEBF81E7B78E368D012C5A645DA320648620819239A1B495D819B5A9A25FDAE99A925DDD69B6FA8A47F7609D98233762429048F6E9EB4C6D1AFD24B588DB36FBA1983041120C91C1CE3A834ADA35F0B78A731288E50A501957730270085CE793ED4B997715D1EAF17ED17ACC31AC71683A5A222855552E0003A0033C0A7FFC348EBBFF00404D37FEFB93FC6BCA65D0752864547B6CB12E06D75619504B0241201001383CD5036D32DAADC943E4B398C3762C00247E44509A7B30B9E89AD7C5A6F116B369A9EB1E1BD3AF24B442B0432C92189493924AE70C4F1D72381C56FA7ED1BADC6815341D31554600567000F6E6BC82D2CE7BF9FC9B740F26D2DCB05000192492400001568683A8B492A790018D55D99A550BB5BEE90C4E083DB068724B761747A9CFFB446AF730490CFE1FD2A58A452AC8E5D8303D4104F22BCA357BCB5D435192E6D34E8AC23739FB3C4E5914F7C6EE40F6CF14C8F4DBB923BA96384BC76983332B02101380720F3CFA522E9976D3C10AC04C97082489723E6539E47E47F2A775DC2E52A2B54F87F5016C970638BC973857F3E3E4F1C0F9BAF238F7AAD2E9D750C733C90B22C12795216E36BF3F2FD7834B99740BA29D14514C614514500145145001451450014514500145145001451450015ABA5CF14369AA2C8E15A5B4D880FF00137988703F007F2ACBA286AEAC0F53B5D3B59B0FB46996D753A88628239165E4F932AE720FB30C03EFB4F6AAF2DCDB4965A5C825D3FF0073144B21663E7A90E490074C60FE55C9519ACFD92BDD13CA7731EB7A71BB7954DB42897772CD18DC5660D1B04739E7A9C63207CDD05615FEA305DF87EDE258ADE0992E9D8C50A91F2945009C93DC11F8561D25354D2771A8A46D787278A0D51DA678555ADE541E71C21250800FB126BA137F652C775089B4F3235B40A639491006562484EF80A41FA96EB5C2D19A254D377138DDDCEBF4ED434DD3E186D6622417334A6E4C126238D5818C02083B8004B0E7B8A586E6CD2E74ED40DEC1B2C6D8C3247B8EF665DE1768C721B2083DB9CF4AE3E8CD2F6687CA6ACD3C2DE1BB4B7570665BA95D97B8055003F8E0FE5536BBA9FDBA0D3D565572B0069F68C13292412DEA76AAF3589455F22BDC2C2514514C614514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145001451450014514500145145007FFD9)
GO
SET IDENTITY_INSERT [dbo].[company_info] OFF
GO
SET IDENTITY_INSERT [dbo].[fara] ON 
GO
INSERT [dbo].[fara] ([id], [name_fara], [adress], [tel], [is_stop], [id_user], [DateServer]) VALUES (1, N'›—⁄ —∆Ì”Ì 1', N'«·„‰Ì·', N'01020304050', 0, 2, CAST(N'2024-10-22T02:53:57.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[fara] OFF
GO
INSERT [dbo].[invoice_type] ([id], [name_invoice_type], [frm_name]) VALUES (1, N'»Ì«‰ «”⁄«—', N'frm_InvoiceHeader')
GO
INSERT [dbo].[invoice_type] ([id], [name_invoice_type], [frm_name]) VALUES (2, N'„‘ —Ì« ', N'frm_InvoiceHeader_in')
GO
INSERT [dbo].[invoice_type] ([id], [name_invoice_type], [frm_name]) VALUES (3, N'‰ﬁ· „‰ „Œ“‰', N'frm_InvoiceHeader_store')
GO
INSERT [dbo].[invoice_type] ([id], [name_invoice_type], [frm_name]) VALUES (4, N'»Ì«‰ «”⁄«— „‰ «·„Œ“‰', N'frm_InvoiceHeader_add_wait')
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_1', N'price_1', 6)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_10', N'price_10', 15)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_2', N'price_2', 7)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_3', N'price_3', 8)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_4', N'price_4', 9)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_5', N'price_5', 10)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_6', N'price_6', 11)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_7', N'price_7', 12)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_8', N'price_8', 13)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_9', N'price_9', 14)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_sale', N'”⁄— „Õ·', 1)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_sale_100', N'”⁄— 100', 2)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_sale_75', N'”⁄— 75', 3)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_sale_vip1', N'”⁄— VIP1', 4)
GO
INSERT [dbo].[list_price] ([id], [name_row], [sort]) VALUES (N'price_sale_vip2', N'”⁄— VIP2', 5)
GO
SET IDENTITY_INSERT [dbo].[setting] ON 
GO
INSERT [dbo].[setting] ([id], [name], [show_invoice_pay], [add_invoice_pay], [update_invoice_pay], [delete_invoice_pay], [show_invoice_sale], [add_invoice_sale], [update_invoice_sale], [delete_invoice_sale], [show_invoice_to_stroe], [add_invoice_to_stroe], [update_invoice_to_stroe], [delete_invoice_to_stroe], [show_product], [add_product], [update_product], [delete_product], [update_price_producut], [update_price_producut_exal], [kashf_hesab_prodct], [blance_in_storses], [store_in_and_out], [report_mabeat_product], [show_client], [add_client], [update_client], [delete_client], [show_amount_client], [add_amount_client], [update_amount_client], [delete_amount_client], [kashf_hesab_client], [show_fara], [add_fara], [update_fara], [delete_fara], [show_store], [add_store], [update_store], [delete_store], [show_user], [add_user], [update_user], [delete_user], [show_setting], [add_setting], [update_setting], [delete_setting], [update_company], [show_InvoiceHeader_wait], [add_InvoiceHeader_wait], [update_InvoiceHeader_wait], [delete_InvoiceHeader_wait], [id_user], [DateServer]) VALUES (2, N'„œÌ—', 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, CAST(N'2024-12-14T02:31:58.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[setting] OFF
GO
SET IDENTITY_INSERT [dbo].[store] ON 
GO
INSERT [dbo].[store] ([id], [store_name], [id_fara], [adress], [tel], [is_stop], [id_user], [DateServer]) VALUES (1, N'„Œ“‰ «·—∆Ì”Ì2', 1, N'', N'01020304050', 0, 2, CAST(N'2024-10-26T00:29:50.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[store] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 
GO
INSERT [dbo].[user] ([id], [user_name], [tel], [password], [id_fara], [adress], [id_setting], [is_stop], [id_user], [DateServer]) VALUES (2, N'osama', N'123', N'1234', 1, N'', 2, 0, 2, CAST(N'2024-12-14T02:09:04.0000000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[user] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Client]    Script Date: 14/12/2024 04:24:50 „ ******/
ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [IX_Client] UNIQUE NONCLUSTERED 
(
	[tel] ASC,
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_branch]    Script Date: 14/12/2024 04:24:50 „ ******/
ALTER TABLE [dbo].[fara] ADD  CONSTRAINT [IX_branch] UNIQUE NONCLUSTERED 
(
	[name_fara] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_setting]    Script Date: 14/12/2024 04:24:50 „ ******/
ALTER TABLE [dbo].[setting] ADD  CONSTRAINT [IX_setting] UNIQUE NONCLUSTERED 
(
	[name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_store]    Script Date: 14/12/2024 04:24:50 „ ******/
ALTER TABLE [dbo].[store] ADD  CONSTRAINT [IX_store] UNIQUE NONCLUSTERED 
(
	[store_name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_user]    Script Date: 14/12/2024 04:24:50 „ ******/
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [IX_user] UNIQUE NONCLUSTERED 
(
	[tel] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[amount_client] ADD  CONSTRAINT [DF_amount_client_DateServer]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[Client] ADD  CONSTRAINT [DF_Client_DateAdd]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[fara] ADD  CONSTRAINT [DF_fara_DateServer]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[InvoiceHeader] ADD  CONSTRAINT [DF_InvoiceHeader_DateAdd]  DEFAULT (getdate()) FOR [DateAdd]
GO
ALTER TABLE [dbo].[InvoiceHeader] ADD  CONSTRAINT [DF_InvoiceHeader_dateserver]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[setting] ADD  CONSTRAINT [DF_setting_DateServer]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[store] ADD  CONSTRAINT [DF_store_DateServer]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [DF_user_DateServer]  DEFAULT (getdate()) FOR [DateServer]
GO
ALTER TABLE [dbo].[amount_client]  WITH CHECK ADD  CONSTRAINT [FK_amount_client_amount_client_type] FOREIGN KEY([id_type])
REFERENCES [dbo].[amount_client_type] ([id])
GO
ALTER TABLE [dbo].[amount_client] CHECK CONSTRAINT [FK_amount_client_amount_client_type]
GO
ALTER TABLE [dbo].[amount_client]  WITH CHECK ADD  CONSTRAINT [FK_amount_client_Client] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[amount_client] CHECK CONSTRAINT [FK_amount_client_Client]
GO
ALTER TABLE [dbo].[amount_client]  WITH CHECK ADD  CONSTRAINT [FK_amount_client_fara] FOREIGN KEY([id_fara])
REFERENCES [dbo].[fara] ([id])
GO
ALTER TABLE [dbo].[amount_client] CHECK CONSTRAINT [FK_amount_client_fara]
GO
ALTER TABLE [dbo].[amount_client]  WITH CHECK ADD  CONSTRAINT [FK_amount_client_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[amount_client] CHECK CONSTRAINT [FK_amount_client_user]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_list_price] FOREIGN KEY([list_price])
REFERENCES [dbo].[list_price] ([id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_list_price]
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_user]
GO
ALTER TABLE [dbo].[fara]  WITH CHECK ADD  CONSTRAINT [FK_fara_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[fara] CHECK CONSTRAINT [FK_fara_user]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_InvoiceHeader1] FOREIGN KEY([InvoiceHeaderID])
REFERENCES [dbo].[InvoiceHeader] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_InvoiceHeader1]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_product] FOREIGN KEY([ItemID])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_product]
GO
ALTER TABLE [dbo].[InvoiceDetails]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetails_store] FOREIGN KEY([store_id])
REFERENCES [dbo].[store] ([id])
GO
ALTER TABLE [dbo].[InvoiceDetails] CHECK CONSTRAINT [FK_InvoiceDetails_store]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_Client] FOREIGN KEY([id_cient])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_Client]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_fara] FOREIGN KEY([id_fara])
REFERENCES [dbo].[fara] ([id])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_fara]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_invoice_type] FOREIGN KEY([id_invoice_type])
REFERENCES [dbo].[invoice_type] ([id])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_invoice_type]
GO
ALTER TABLE [dbo].[InvoiceHeader]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceHeader_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[InvoiceHeader] CHECK CONSTRAINT [FK_InvoiceHeader_user]
GO
ALTER TABLE [dbo].[setting]  WITH CHECK ADD  CONSTRAINT [FK_setting_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[setting] CHECK CONSTRAINT [FK_setting_user]
GO
ALTER TABLE [dbo].[store]  WITH CHECK ADD  CONSTRAINT [FK_store_fara] FOREIGN KEY([id_fara])
REFERENCES [dbo].[fara] ([id])
GO
ALTER TABLE [dbo].[store] CHECK CONSTRAINT [FK_store_fara]
GO
ALTER TABLE [dbo].[store]  WITH CHECK ADD  CONSTRAINT [FK_store_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[store] CHECK CONSTRAINT [FK_store_user]
GO
ALTER TABLE [dbo].[store_log]  WITH CHECK ADD  CONSTRAINT [FK_store_log_fara] FOREIGN KEY([id_fara])
REFERENCES [dbo].[fara] ([id])
GO
ALTER TABLE [dbo].[store_log] CHECK CONSTRAINT [FK_store_log_fara]
GO
ALTER TABLE [dbo].[store_log]  WITH CHECK ADD  CONSTRAINT [FK_store_log_invoice_type] FOREIGN KEY([id_type])
REFERENCES [dbo].[invoice_type] ([id])
GO
ALTER TABLE [dbo].[store_log] CHECK CONSTRAINT [FK_store_log_invoice_type]
GO
ALTER TABLE [dbo].[store_log]  WITH CHECK ADD  CONSTRAINT [FK_store_log_InvoiceHeader1] FOREIGN KEY([Source_Id])
REFERENCES [dbo].[InvoiceHeader] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[store_log] CHECK CONSTRAINT [FK_store_log_InvoiceHeader1]
GO
ALTER TABLE [dbo].[store_log]  WITH CHECK ADD  CONSTRAINT [FK_store_log_product] FOREIGN KEY([ItemID])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[store_log] CHECK CONSTRAINT [FK_store_log_product]
GO
ALTER TABLE [dbo].[store_log]  WITH CHECK ADD  CONSTRAINT [FK_store_log_store] FOREIGN KEY([store_id])
REFERENCES [dbo].[store] ([id])
GO
ALTER TABLE [dbo].[store_log] CHECK CONSTRAINT [FK_store_log_store]
GO
ALTER TABLE [dbo].[store_log]  WITH CHECK ADD  CONSTRAINT [FK_store_log_user] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[store_log] CHECK CONSTRAINT [FK_store_log_user]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_fara] FOREIGN KEY([id_fara])
REFERENCES [dbo].[fara] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_fara]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_setting] FOREIGN KEY([id_setting])
REFERENCES [dbo].[setting] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_setting]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_user1] FOREIGN KEY([id_user])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_user1]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = ""(H (1[27] 4[34] 2[17] 3) )""
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = ""(H (1 [50] 4 [25] 3))""
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = ""(H (1 [50] 2 [25] 3))""
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = ""(H (4 [30] 2 [40] 3))""
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = ""(H (1 [56] 3))""
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = ""(H (2 [66] 3))""
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = ""(H (4 [50] 3))""
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = ""(V (3))""
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = ""(H (1[56] 4[18] 2) )""
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = ""(H (1 [75] 4))""
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = ""(H (1[66] 2) )""
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = ""(H (4 [60] 2))""
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = ""(H (1) )""
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = ""(V (4))""
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = ""(V (2))""
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = ""store_log""
            Begin Extent = 
               Top = 7
               Left = 46
               Bottom = 173
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = ""store""
            Begin Extent = 
               Top = 7
               Left = 307
               Bottom = 173
               Right = 522
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = ""product""
            Begin Extent = 
               Top = 7
               Left = 568
               Bottom = 173
               Right = 783
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = """"
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1252
         Width = 1878
         Width = 1252
         Width = 1252
         Width = 1252
         Width = 1252
         Width = 1252
         Width = 1252
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 4007
         Alias = 902
         Table = 1165
         Output = 726
         Append = 1400
         NewValue = 1170
         SortType = 1352
         SortOrder = 1415
         GroupBy = 1350
         Filter = 1352
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'product_min_mum_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'product_min_mum_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = ""(H (1[23] 4[41] 2[27] 3) )""
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = ""(H (1 [50] 4 [25] 3))""
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = ""(H (1 [50] 2 [25] 3))""
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = ""(H (4 [30] 2 [40] 3))""
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = ""(H (1 [56] 3))""
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = ""(H (2 [66] 3))""
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = ""(H (4 [50] 3))""
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = ""(V (3))""
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = ""(H (1[56] 4[18] 2) )""
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = ""(H (1 [75] 4))""
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = ""(H (1[66] 2) )""
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = ""(H (4 [60] 2))""
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = ""(H (1) )""
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = ""(V (4))""
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = ""(V (2))""
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = ""store_log""
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = ""store""
            Begin Extent = 
               Top = 6
               Left = 262
               Bottom = 136
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = ""product""
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 428
               Right = 261
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = """"
      End
      Begin ColumnWidths = 27
         Width = 284
         Width = 1500
         Width = 3300
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 6450
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 135' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'product_serch_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'0
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'product_serch_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'product_serch_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = ""(H (1[24] 4[37] 2[20] 3) )""
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = ""(H (1 [50] 4 [25] 3))""
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = ""(H (1 [50] 2 [25] 3))""
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = ""(H (4 [30] 2 [40] 3))""
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = ""(H (1 [56] 3))""
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = ""(H (2 [66] 3))""
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = ""(H (4 [50] 3))""
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = ""(V (3))""
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = ""(H (1[56] 4[18] 2) )""
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = ""(H (1 [75] 4))""
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = ""(H (1[66] 2) )""
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = ""(H (4 [60] 2))""
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = ""(H (1) )""
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = ""(V (4))""
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = ""(V (2))""
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = ""product""
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 19
         End
         Begin Table = ""store_log""
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 136
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = ""invoice_type""
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 251
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = ""store""
            Begin Extent = 
               Top = 138
               Left = 266
               Bottom = 268
               Right = 436
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = ""fara""
            Begin Extent = 
               Top = 252
               Left = 38
               Bottom = 382
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = ""user""
            Begin Extent = 
               Top = 270
               Left = 246
               Bottom = 400
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = """"
      End
      Begin ColumnWidths = 16
         Width = 284
         Width = 1500
         Width = 1500
     ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'store_log_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'    Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'store_log_View'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'store_log_View'
GO
";
            string directoryName = Path.GetDirectoryName(Application.ExecutablePath);
            cn = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = master;Integrated Security=SSPI");
            string text2 = string.Format("\r\nUSE [master]\r\nGO \r\nEXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'{0}\\DBBETTERLIFE.MDF'\r\nGO\r\nUSE [master]\r\nGO\r\nCREATE DATABASE [{0}\\DBBETTERLIFE.MDF]\r\n CONTAINMENT = NONE\r\n ON  PRIMARY \r\n( NAME = N'dbbetterlife', FILENAME = N'{0}\\dbbetterlife.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )\r\n LOG ON \r\n( NAME = N'dbbetterlife_log', FILENAME = N'{0}\\dbbetterlife_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )\r\nGO\r\nUSE [{0}\\DBBETTERLIFE.MDF]\r\nGO\r\n \r\nSET ANSI_NULLS ON\r\nGO\r\nSET QUOTED_IDENTIFIER ON\r\nGO\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n        \r\n", directoryName);
            IEnumerable<string> enumerable = Regex.Split(text2 + text, "^\\s*GO\\s*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            cn.Open();
            try
            {
                new SqlCommand(" DROP DATABASE  [" + directoryName + "\\DBBETTERLIFE.MDF]", cn).ExecuteNonQuery();
            }
            catch
            {
            }
            try
            {
                foreach (string item in enumerable)
                {
                    if (item.Trim() != "")
                    {
                        new SqlCommand(item, cn).ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Number.ToString());
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cn.Close();
            }
            if (!File.Exists(directoryName + "\\dbbetterlife.mdf"))
            {
                return false;
            }
            return true;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string text = DateTime.Now.ToString("ddMMyyyy");
            if (tx_pass.Text == text)
            {
                pan_password.Visible = false;
                pan_server.Visible = true;
            }
            else
            {
                lp_mas_error.Text = "—ﬁ„ ”—Ì Œÿ«¡";
            }
        }
    }
}
