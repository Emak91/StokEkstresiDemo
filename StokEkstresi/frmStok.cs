using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokEkstresi
{
    public partial class frmStok : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmStok()
        {
            InitializeComponent();

        }

        private void frmStok_Load(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            //TestEntities1 entities = new TestEntities1();
            //var liste = entities.sp_stokListesi().ToList();

            //gridControl1.DataSource = liste;
        }

        private void barEditItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string malkodu = null;
            string baslangic = null;
            string bitis = null;
            var _stok = 0;
            malkodu = kodtext.EditValue == null ? "" : kodtext.EditValue.ToString();
            DateTime baslangicTarih = new DateTime();
            DateTime bitisTarih = new DateTime();
            if (baslangıcTarih.EditValue!=null)
            {
                baslangicTarih = Convert.ToDateTime(baslangıcTarih.EditValue);
                baslangic = baslangicTarih.ToString("yyyy/MM/dd");
            }
            else
            {
                baslangicTarih = Convert.ToDateTime("1900/01/01");
                baslangic = baslangicTarih.ToString("yyyy/MM/dd");
            }

            if (bitisTarihi.EditValue!=null)
            {
                bitisTarih = Convert.ToDateTime(bitisTarihi.EditValue);
                bitis = bitisTarih.ToString("yyyy/MM/dd");
            }
            else
            {
                bitisTarih = Convert.ToDateTime("2900/01/01");
                bitis = bitisTarih.ToString("yyyy/MM/dd");
            }
            //DateTime baslangicTarih = Convert.ToDateTime(baslangıcTarih.EditValue);

            //DateTime bitisTarih = Convert.ToDateTime(bitisTarihi.EditValue);
            //bitis = bitisTarih.ToString("yyyy/MM/dd");

            TestEntities entities = new TestEntities();
            if (!string.IsNullOrEmpty(malkodu))
            {
                
                var data = entities.UrunGetir(malkodu, Convert.ToDateTime(baslangic), Convert.ToDateTime(bitis)).ToList();
                foreach (var item in data.ToList())
                {
                    if (item.IslemTur == "Giriş")
                    {
                        _stok += Convert.ToInt32(item.GirisMiktar);
                        item.stok = _stok ;

                    }
                    if (item.IslemTur == "Çıkış")
                    {
                        _stok -= Convert.ToInt32(item.CikisMiktar);
                        item.stok = _stok;
                        
                    }

                }

                gridControl1.DataSource = data;
            }
            else
            {
                var data = entities.sp_stokListesi();
                gridControl1.DataSource = data;
            }
            




        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void excel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Excel Çalışma Kitabı |*.xls",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                FileName = "Rapor.xls"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
                gridView1.ExportToXls(dialog.FileName);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int a = 1300;
            int b = 450;
            Bitmap bm = new Bitmap(a,b);

            gridControl1.DrawToBitmap(bm, new Rectangle(0, 0, a, b));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            printDocument1.Print();
        }
    }
}