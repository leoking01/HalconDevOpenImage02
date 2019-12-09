using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using HalconDotNet;

namespace HalconDevOpenImage02
{
    public partial class Form1 : Form
    {
        HDevelopExport hd = new HDevelopExport();

        public Form1()
        {
            InitializeComponent();
        }

        //readImgae
        private void button1_Click(object sender, EventArgs e)
        {
            hd.ReadPicture(hSmartWindowControl1.HalconWindow);
        }

        //imageProc
        private void button2_Click(object sender, EventArgs e)
        {
            hd.Process();
        }
    }

    public class HDevelopExport
    {
        public HTuple hv_ExpDefaultWinHandle;
        HObject ho_Image, ho_ImageGray;
        HTuple hv_Width, hv_Height;
        //初始化halcon
        public void InitHalcon()
        {
            // Default settings used in HDevelop 
            HOperatorSet.SetSystem("do_low_error", "false");
        }
        public void ReadPicture(HTuple Window)
        {
            //读图并显示
            hv_ExpDefaultWinHandle = Window;
            //HOperatorSet.GenEmptyObj(out ho_Image);
            //ho_Image.Dispose();
            HOperatorSet.ReadImage(out ho_Image, Application.StartupPath +"/../../1.jpg");
            HTuple wid,hei;
            HOperatorSet.GetImageSize( ho_Image, out wid, out hei  );
            HOperatorSet.SetPart(hv_ExpDefaultWinHandle, 0, 0, hei, wid  );
            HOperatorSet.DispObj(ho_Image, hv_ExpDefaultWinHandle);
            HOperatorSet.GetImageSize(ho_Image, out hv_Width, out hv_Height);
        }
        public void Process()
        {
            //处理程序
            //HOperatorSet.GenEmptyObj(out ho_ImageGray);
            //ho_ImageGray.Dispose();
            //HOperatorSet.Rgb3ToGray(ho_Image, ho_Image, ho_Image, out ho_ImageGray);
            HOperatorSet.Rgb1ToGray(ho_Image  , out ho_ImageGray);
            HOperatorSet.DispObj(ho_ImageGray, hv_ExpDefaultWinHandle);
            //ho_Image.Dispose();
            //ho_ImageGray.Dispose();
        }
    }
}
