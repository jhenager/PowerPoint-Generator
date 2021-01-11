﻿using System;
using System.Windows.Forms;
using Microsoft.Office.Interop.PowerPoint;
using Application = Microsoft.Office.Interop.PowerPoint.Application;

namespace powerPointGenerator.Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
      
        private async void submit_Click(object sender, EventArgs e)
        {
            var response = await Shared.RestHelper.Get((titleBox.Text + " " + bodyBox.Text));
            var jo = Newtonsoft.Json.Linq.JObject.Parse(response);
            var imgId = jo["items"][0]["link"].ToString();
            var imgId2 = jo["items"][1]["link"].ToString();
            var imgId3 = jo["items"][2]["link"].ToString();
            var imgId4 = jo["items"][3]["link"].ToString();
            var imgId5 = jo["items"][4]["link"].ToString();
            var imgId6 = jo["items"][5]["link"].ToString();
            var imgId7 = jo["items"][6]["link"].ToString();
            var imgId8 = jo["items"][7]["link"].ToString();
            var imgId9 = jo["items"][8]["link"].ToString();
            if (imgId != null) { pictureBox1.ImageLocation = imgId; };
            if (imgId2 != null) { pictureBox2.ImageLocation = imgId2; };
            if (imgId3 != null) { pictureBox3.ImageLocation = imgId3; };
            if (imgId4 != null) { pictureBox4.ImageLocation = imgId4; };
            if (imgId5 != null) { pictureBox5.ImageLocation = imgId5; };
            if (imgId6 != null) { pictureBox6.ImageLocation = imgId6; };
            if (imgId7 != null) { pictureBox7.ImageLocation = imgId7; };
            if (imgId8 != null) { pictureBox8.ImageLocation = imgId8; };
            if (imgId9 != null) { pictureBox9.ImageLocation = imgId9; };
     
        }

     
        private void button1_Click(object sender, EventArgs e)
        {
            Application pptApplication = new Application();

            Microsoft.Office.Interop.PowerPoint.Slides slides;
            Microsoft.Office.Interop.PowerPoint._Slide slide;
            Microsoft.Office.Interop.PowerPoint.TextRange objText;

            // Create the Presentation File
            Presentation pptPresentation = pptApplication.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoTrue);

            Microsoft.Office.Interop.PowerPoint.CustomLayout customLayout = pptPresentation.SlideMaster.CustomLayouts[Microsoft.Office.Interop.PowerPoint.PpSlideLayout.ppLayoutText];

            // Create new Slide
            slides = pptPresentation.Slides;
            slide = slides.AddSlide(1, customLayout);

            // Add title
            objText = slide.Shapes[1].TextFrame.TextRange;
            objText.Text = titleBox.Text;
            objText.Font.Name = "Arial";
            objText.Font.Size = 60;

            // Add body
            objText = slide.Shapes[2].TextFrame.TextRange;
            objText.Text = bodyBox.Text;
            objText.Font.Name = "Arial";
            objText.Font.Size = 30;

            Microsoft.Office.Interop.PowerPoint.Shape sheetShape = slides[1].Shapes[1];
            // Add Picture
            var img1 = slides[1].Shapes.AddPicture(pictureBox1.ImageLocation, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoTrue, sheetShape.Left+300, sheetShape.Top+300, sheetShape.Height-500, sheetShape.Width+200);
            img1.ScaleHeight(1,Microsoft.Office.Core.MsoTriState.msoTrue);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

