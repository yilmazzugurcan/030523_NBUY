using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _030523_NBUY
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        okulEntities db = new okulEntities();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Ogrenci.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            ogr.Adi = txtOgrAd.Text;
            ogr.Soyadi = txtOgrSoyad.Text;
            db.Ogrenci.Add(ogr);
            db.SaveChanges();
            dataGridView1.DataSource = db.Ogrenci.ToList();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Dersler.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var query = from item in db.Notlar
                        select new
                        {
                           item.NotId,item.OgrenciId,item.Ders,
                           item.Sinav1,item.Sinav2,item.Sinav3,
                           item.Ortalama,item.Durum
                        };
            dataGridView1.DataSource = query.ToList();
        }
    }
}
