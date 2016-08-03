using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Animation_Editor
{
    public partial class MainForm : Form
    {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString", CharSet=CharSet.Unicode)]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString", CharSet = CharSet.Unicode)]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        #region Language
        private int maxLang;
        private string buttonPlay = "Play";
        private string buttonPause = "Pause";
        private string frame;

        private string x;
        private string y;
        private string width;
        private string height;

        private string msg, msgTitle;
        private List<string> langName = new List<string>();
        #endregion

        private int currentFrame = 0;
        private int layerSel = 0;
        private int frameRate = 60;
        private int frameCount;
        private int tick;

        public List<ObjectFile> objectList = new List<ObjectFile>();

        //#######
        private int fps, fpsTick, fpsCount;
        //##############
        private Bitmap currentObject;
        private int currentIndex;
        private Point mousePosition;
        private bool mouseDown = false;
        private bool play = false;
        //################
        private Pen pen_y, pen_x;
        private ImageAttributes imgAtt;
        private bool gameRunning = true;
        private Graphics g;
        private Bitmap backBuffer = new Bitmap(416, 320);
        private Bitmap grid = new Bitmap(416, 320);

        private Rectangle cutScreen = new Rectangle(0, 0, 192, 192);
        private Rectangle selectedRect;
        //#################

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Show();

            ReadConfig();

            string lang = GetIniValue("LANGUAGE", "Current", Application.StartupPath + @"\Config.ini");

            ChangeLanguage(lang);

            cutScreen = new Rectangle(vs_x.Value, vs_y.Value, vs_width.Value, vs_height.Value);
            lblstatus.Text = x + ": " + vs_x.Value + " " + y + " : " + vs_y.Value + " " + width + " : " + vs_width.Value + " " + height + ": " + vs_height.Value;

            RenderLoop();
        }

        #region Botoes de Camada

        private void RefreshLayer()
        {
            if (Static.frame.Count == 0) { return; }

            listLayer.Items.Clear();

            listLayer.BeginUpdate();

            for (int n = 0; n < Static.frame[currentFrame].camada_1.Count; n++)
            {
                listLayer.Items.Add(Static.frame[currentFrame].camada_1[n].name);
            }

            listLayer.EndUpdate();
        }

        private void btn_camada1_Click(object sender, EventArgs e)
        {
            layerSel = 0;
            RefreshLayer();
        }

        private void btn_camada2_Click(object sender, EventArgs e)
        {
            layerSel = 1;

            RefreshLayer();
        }

        private void btn_camada3_Click(object sender, EventArgs e)
        {
            layerSel = 2;

            RefreshLayer();
        }

        private void btn_removeAll_Click(object sender, EventArgs e)
        {
            if (Static.frame.Count == 0) { return; }

            listLayer.Items.Clear();

            if (layerSel == 0) { Static.frame[currentFrame].camada_1.Clear(); }
            if (layerSel == 1) { Static.frame[currentFrame].camada_2.Clear(); }
            if (layerSel == 2) { Static.frame[currentFrame].camada_3.Clear(); }
        }

        private void btn_down_Click(object sender, EventArgs e)
        {
            int index = listLayer.SelectedIndex;
            object swap = listLayer.SelectedItem;
            Frame item;

            if (Static.frame.Count == 0) { return; }

            List<Frame> list = new List<Frame>();

            if (layerSel == 0) { list = Static.frame[currentFrame].camada_1; }
            if (layerSel == 1) { list = Static.frame[currentFrame].camada_2; }
            if (layerSel == 2) { list = Static.frame[currentFrame].camada_3; }

            item = list[index];

            if (index != -1 && (index + 1) < list.Count)
            {
                list.RemoveAt(index);
                list.Insert(index + 1, item);
            }

            if (index != -1 && (index + 1) < listLayer.Items.Count)
            {
                listLayer.Items.RemoveAt(index);
                listLayer.Items.Insert(index + 1, swap);
                listLayer.SelectedIndex = index + 1;
            }
        }

        private void btn_up_Click(object sender, EventArgs e)
        {
            int index = listLayer.SelectedIndex;
            object swap = listLayer.SelectedItem;
            Frame item;

            if (Static.frame.Count == 0) { return; }

            if (index == 0) { return; }

            List<Frame> list = new List<Frame>();

            if (layerSel == 0) { list = Static.frame[currentFrame].camada_1; }
            if (layerSel == 1) { list = Static.frame[currentFrame].camada_2; }
            if (layerSel == 2) { list = Static.frame[currentFrame].camada_3; }

            item = list[index];

            list.RemoveAt(index);
            list.Insert(index - 1, item);

            listLayer.Items.RemoveAt(index);
            listLayer.Items.Insert(index - 1, swap);
            listLayer.SelectedIndex = index - 1;
        }

        private void listLayer_MouseDown(object sender, MouseEventArgs e)
        {
            if (Static.frame.Count == 0) { return; }

            int index = listLayer.SelectedIndex;

            if (index == -1) { return; }

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                List<Frame> list = new List<Frame>();

                if (layerSel == 0) { list = Static.frame[currentFrame].camada_1; }
                if (layerSel == 1) { list = Static.frame[currentFrame].camada_2; }
                if (layerSel == 2) { list = Static.frame[currentFrame].camada_3; }

                /* txtTransp.Text = list(ObjListBox2.SelectedIndex).Trans
                 TextBox1.Text = list(ObjListBox2.SelectedIndex).Position.X
                 TextBox2.Text = list(ObjListBox2.SelectedIndex).Position.Y
                 TextBox3.Text = list(ObjListBox2.SelectedIndex).Size.Width
                 TextBox4.Text = list(ObjListBox2.SelectedIndex).Size.Height
                 TextBox5.Text = ListFrame(CurrentIndexF).FrameRate */

                selectedRect = list[index].screenRect;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                listLayer.Items.RemoveAt(index);
                selectedRect = new Rectangle(0, 0, 0, 0);

                if (layerSel == 0) { Static.frame[currentFrame].camada_1.RemoveAt(index); }
                if (layerSel == 1) { Static.frame[currentFrame].camada_2.RemoveAt(index); }
                if (layerSel == 2) { Static.frame[currentFrame].camada_3.RemoveAt(index); }
            }
        }

        #endregion

        #region Botões "Camada"
 
        #endregion

        #region Botões "Arquivo"
        private void ItemTool_End_Click(object sender, EventArgs e)
        {
            gameRunning = false;
        }
        private void ItemTool_Exp_Click(object sender, EventArgs e)
        {
            if (Static.frame.Count == 0) { return; }

            SaveFileDialog dialogBox = new SaveFileDialog();

            dialogBox.InitialDirectory = Application.StartupPath + @"\Animation\";
            dialogBox.Filter = "Anim Files (*.anim)|*.anim";
            dialogBox.FilterIndex = 1;

            if (dialogBox.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            Bitmap buffer = new Bitmap(416, 320);
            Bitmap imgFinal = new Bitmap(cutScreen.Size.Width * Static.frame.Count - 1, cutScreen.Size.Height);
            Graphics gBuffer;

            for (int f = 0; f < Static.frame.Count; f++)
            {
                gBuffer = Graphics.FromImage(buffer);
                gBuffer.Clear(Color.Transparent);

                for (int n = 0; n < Static.frame[f].camada_1.Count; n++)
                {
                    gBuffer.DrawImage(Static.frame[f].camada_1[n].img, Static.frame[f].camada_1[n].screenRect);
                }

                for (int n = 0; n < Static.frame[f].camada_2.Count; n++)
                {
                    gBuffer.DrawImage(Static.frame[f].camada_2[n].img, Static.frame[f].camada_2[n].screenRect);
                }

                for (int n = 0; n < Static.frame[f].camada_3.Count; n++)
                {
                    gBuffer.DrawImage(Static.frame[f].camada_3[n].img, Static.frame[f].camada_3[n].screenRect);
                }

                gBuffer.Dispose();

                gBuffer = Graphics.FromImage(imgFinal);
                gBuffer.DrawImage(buffer, new Rectangle(f * (cutScreen.Size.Width), 0, cutScreen.Size.Width, cutScreen.Size.Height), cutScreen, GraphicsUnit.Pixel);
                g.Dispose();

                Application.DoEvents();
            }

            g.Dispose();

            byte[] bKey = Crypt.Crypt.CreateKey("123456");
            byte[] bytIV = Crypt.Crypt.CreateIV("123456");

            Crypt.Crypt.EncryptOrDecryptFile(imgFinal, dialogBox.FileName, bKey, bytIV, Crypt.Crypt.CryptoAction.ActionEncrypt);

            string[] tempStr = dialogBox.FileName.Split('\\');
            string[] tempExt = tempStr[tempStr.GetUpperBound(0)].Split('.');

            FileStream fStream;
            BinaryWriter writer;

            fStream = new FileStream(Application.StartupPath + @"\Animation\" + tempExt[0] + ".dat", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            writer = new BinaryWriter(fStream);

            imgFinal.Save(Application.StartupPath + @"\Animation\" + tempExt[0] + ".png");

            writer.Write(Static.frame.Count - 1);
            writer.Write(frameRate);
            writer.Write(imgFinal.Width);
            writer.Write(imgFinal.Height);
            writer.Write(cutScreen.Width);
            writer.Write(cutScreen.Height);
            writer.Write(tempExt[0]);
            writer.Close();
            fStream.Close();
            fStream.Dispose();

            MessageBox.Show(msg, msgTitle);
        }

        private void ItemTool_OpenProj_Click(object sender, EventArgs e)
        {
            OpenProject();
        }

        private void ItemTool_SaveProj_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void ItemTool_Engine_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Botões "Object"
        private void ItemTool_OpenObj_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogBox = new OpenFileDialog();

            dialogBox.InitialDirectory = Application.StartupPath + @"\Object\";
            dialogBox.Filter = "PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp| All Files (*.*)|*.*";
            dialogBox.FilterIndex = 1;
            dialogBox.Multiselect = true;

            if (dialogBox.ShowDialog() == DialogResult.Cancel) { return; }

            listObject.BeginUpdate();

            foreach (string file in dialogBox.FileNames)
            {
                string[] tempStr = file.Split('\\');
                string[] tempExt = tempStr[tempStr.GetUpperBound(0)].Split('.');

                objectList.Add(new ObjectFile());
                objectList[objectList.Count - 1].name = tempExt[0];
                objectList[objectList.Count - 1].img = new Bitmap(file);

                listObject.Items.Add(tempExt[0]);

                Application.DoEvents();
            }

            listObject.EndUpdate();
        }

        private void ItemTool_ClearList_Click(object sender, EventArgs e)
        {
            listObject.BeginUpdate();
            listObject.Items.Clear();
            listObject.EndUpdate();

            objectList.Clear();
        }
        private void ItemTool_CloseObj_Click(object sender, EventArgs e)
        {
            currentObject = null;
            currentIndex = 0;
        }

        #endregion
 
        #region Botões "Animação"
        private void ItemTool_Play_Click(object sender, EventArgs e)
        {
            if (ItemTool_Play.Text == buttonPlay)
            {
                currentObject = null;
                currentIndex = 0;
                ItemTool_Play.Text = buttonPause;
                play = true;
            }
            else
            {
                play = false;
                ItemTool_Play.Text = buttonPlay;
            }
        }
        #endregion

        #region Botões de Frames

        private void txt_framerate_TextChanged(object sender, EventArgs e)
        {
            if (txt_framerate.Text.Length == 0) { txt_framerate.Text = "0"; }
            frameRate = int.Parse(txt_framerate.Text.Trim());            
        }

        private void txt_x_TextChanged(object sender, EventArgs e)
        {
            if (txt_x.Text.Length == 0) { txt_x.Text = "0"; }
        }
        private void txt_y_TextChanged(object sender, EventArgs e)
        {
            if (txt_y.Text.Length == 0) { txt_y.Text = "0"; }
        }

        private void txt_framerate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false) { return; }
        }
        private void txt_x_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false) { return; }
        }

        private void txt_y_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false) { return; }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Static.frame.Add(new Layer());
            lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
        }

        private void btn_removeAt_Click(object sender, EventArgs e)
        {
            int index = Static.frame.Count;

            if (index == 0) { return; }

            if (Static.frame.Contains(Static.frame[currentFrame]))
            {
                if (currentFrame > 0) 
                {
                    if ((currentFrame + 1) == index) 
                    {
                        currentFrame -= 1;
                        selectedRect = new Rectangle(0, 0, 0, 0);
                    }
                }

                Static.frame.RemoveAt(currentFrame);
                RefreshLayer();

                string text;

                if (index == 1)
                {
                    currentFrame = 0;
                    text = frame + ": " + currentFrame + " / " + Static.frame.Count;
                }
                else
                {
                    text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
                }

                lblFrame.Text = text;
            }
        }

        private void btn_removeLast_Click(object sender, EventArgs e)
        {
            int index = Static.frame.Count;

            if (index == 0) { return; }

            if ((currentFrame +1) == index) 
            { 
                currentFrame -= 1;
                selectedRect = new Rectangle(0, 0, 0, 0);
            }

            Static.frame.RemoveAt(index - 1);
            RefreshLayer();

            string text;
            if (index == 1)
            {
                currentFrame = 0;
                text = frame + ": " + currentFrame + " / " + Static.frame.Count;
            }
            else
            {
                text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
            }

            lblFrame.Text = text;
        }

        private void btn_clear_click(object sender, EventArgs e)
        {
            currentFrame = 0;
            lblFrame.Text = frame + ": 0 / 0";
            selectedRect = new Rectangle(0, 0, 0, 0);

            listLayer.Items.Clear();

            Static.frame.Clear();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (currentFrame > 0)
            {
                currentFrame -= 1;
                lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
                selectedRect = new Rectangle(0, 0, 0, 0);

                RefreshLayer();
                // ObjListBox2.Items.Clear()
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (currentFrame < (Static.frame.Count - 1))
            {
                currentFrame += 1;
                lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
                selectedRect = new Rectangle(0, 0, 0, 0);

                RefreshLayer();
                // ObjListBox2.Items.Clear()
            }
        }

        private void btn_double_ret_Click(object sender, EventArgs e)
        {
            if (currentFrame > 4)
            {
                currentFrame -= 5;
                lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
                selectedRect = new Rectangle(0, 0, 0, 0);

                RefreshLayer();
                //ObjListBox2.Items.Clear()
            }
        }

        private void btn_double_adv_Click(object sender, EventArgs e)
        {
            if (currentFrame < (Static.frame.Count - 5))
            {
                currentFrame += 5;
                lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;
                selectedRect = new Rectangle(0, 0, 0, 0);

                RefreshLayer();
                //ObjListBox2.Items.Clear()
            }
        }

        #endregion

        #region Render Loop
        public void RenderLoop()
        {
            float[][] ptArray = {new float[] {1, 0, 0, 0, 0}, new float[] {0, 1, 0, 0, 0}, new float[] {0, 0, 1, 0, 0}, new float[] {0, 0, 0, 0.2F, 0}, new float[] {0, 0, 0, 0, 1}};
            ColorMatrix matrix = new ColorMatrix(ptArray);
            imgAtt = new ImageAttributes();
            imgAtt.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            pen_y = new Pen(new SolidBrush(Color.FromArgb(90, Color.Yellow)));
            pen_x = new Pen(new SolidBrush(Color.FromArgb(90, Color.LimeGreen)));
                    
            g = Graphics.FromImage(grid);

            for (int x = 0; x < 13; x++)
            {
                g.DrawLine(Pens.AliceBlue, x * 32, 0, x * 32, 320);
            }

            for (int y = 0; y < 10; y++)
            {
                g.DrawLine(Pens.AliceBlue, 0, y * 32, 416, y * 32);
            }

            while (gameRunning)
            {
                g = Graphics.FromImage(backBuffer);
                g.Clear(Color.Black);


                if (play == false)
                {
                    //####################################################################
                    // Desenha todas as camadas
                    #region Desenho Camadas

                    if (ItemTool_Previous.Checked)
                    {
                        if (Static.frame.Count > 1)
                        {
                            if (currentFrame > 0) { RenderLayerBefore(currentFrame - 1, pen_y); }
                        }
                    }

                    RenderLayer(currentFrame);

                    if (ItemTool_Next.Checked)
                    {
                        if ((currentFrame + 1) < Static.frame.Count) { RenderLayerBefore(currentFrame + 1, pen_x); }
                    }

                    #endregion
                    //####################################################################
                    // Desenhar o Grid
                    if (ItemTool_Grid.Checked) { g.DrawImage(grid, 0, 0); }

                    g.DrawRectangle(Pens.Coral, selectedRect);

                    //####################################################################
                    //Desenha o Item selecionado
                    if (currentObject != null)
                    {
                        g.DrawImage(currentObject, new Point(mousePosition.X - currentObject.Width / 2, mousePosition.Y - currentObject.Height / 2));
                        g.DrawRectangle(Pens.Peru, new Rectangle(new Point(mousePosition.X - currentObject.Width / 2, mousePosition.Y - currentObject.Height / 2), new Size(currentObject.Width, currentObject.Height)));
                    }
                    //####################################################################

                    g.DrawRectangle(new Pen(Brushes.Red, 2), cutScreen);
                }
                else
                {
                    // ################ ANIM PLAY ##############
                    if (Environment.TickCount >= (tick + frameRate))
                    {
                        frameCount++;
                        tick = Environment.TickCount;

                        if (frameCount > Static.frame.Count - 1) { frameCount = 0; }
                    }

                    RenderLayer(frameCount);
                    //###########################################
                }

                //FPSSS
                g.DrawString("FPS: " + fps, new Font("Verdana", 9), Brushes.Coral, new PointF(350, 5));

                g.Dispose();
                g = picAnim.CreateGraphics();
                g.DrawImage(backBuffer, 0, 0);
                g.Dispose();

                
                if (Environment.TickCount >= (fpsTick + 1000))
                {
                    fpsTick = Environment.TickCount;
                    fps = fpsCount; 
                    fpsCount = 0;
                } else
                { 
                    fpsCount++; 
                }

                Application.DoEvents();
            }

            Application.Exit();
        }

        public void RenderLayer(int frameNum)
        {
            if (Static.frame.Count != 0)
            {
                if (ItemTool_Layer1.Checked)
                {
                    for (int n = 0; n < Static.frame[frameNum].camada_1.Count; n++)
                    {
                        g.DrawImage(Static.frame[frameNum].camada_1[n].img, Static.frame[frameNum].camada_1[n].screenRect);
                    }
                }

                if (ItemTool_Layer2.Checked)
                {
                    for (int n = 0; n < Static.frame[frameNum].camada_2.Count; n++)
                    {
                        g.DrawImage(Static.frame[frameNum].camada_2[n].img, Static.frame[frameNum].camada_2[n].screenRect);
                    }
                }

                if (ItemTool_Layer3.Checked)
                {
                    for (int n = 0; n < Static.frame[frameNum].camada_3.Count; n++) 
                    {
                        g.DrawImage(Static.frame[frameNum].camada_3[n].img, Static.frame[frameNum].camada_3[n].screenRect);
                    }
                }
            }
        }

        public void RenderLayerBefore(int layer_num, Pen pen)
        {
            if (ItemTool_Layer1.Checked)
            {
                for (int n = 0; n < Static.frame[layer_num].camada_1.Count; n++)
                {
                    g.DrawImage(Static.frame[layer_num].camada_1[n].img, Static.frame[layer_num].camada_1[n].screenRect, 0, 0, Static.frame[layer_num].camada_1[n].img.Width, Static.frame[layer_num].camada_1[n].img.Height, GraphicsUnit.Pixel, imgAtt);
                    g.DrawRectangle(pen, Static.frame[layer_num].camada_1[n].screenRect);
                }
            }

            if (ItemTool_Layer2.Checked)
            {
                for (int n = 0; n < Static.frame[layer_num].camada_2.Count; n++)
                {
                    g.DrawImage(Static.frame[layer_num].camada_2[n].img, Static.frame[layer_num].camada_2[n].screenRect, 0, 0, Static.frame[layer_num].camada_2[n].img.Width, Static.frame[layer_num].camada_2[n].img.Height, GraphicsUnit.Pixel, imgAtt);
                    g.DrawRectangle(pen, Static.frame[layer_num].camada_2[n].screenRect);
                }
            }

            if (ItemTool_Layer3.Checked)
            {
                for (int n = 0; n < Static.frame[layer_num].camada_3.Count; n++)
                {
                    g.DrawImage(Static.frame[layer_num].camada_3[n].img, Static.frame[layer_num].camada_3[n].screenRect, 0, 0, Static.frame[layer_num].camada_3[n].img.Width, Static.frame[layer_num].camada_3[n].img.Height, GraphicsUnit.Pixel, imgAtt);
                    g.DrawRectangle(pen, Static.frame[layer_num].camada_3[n].screenRect);
                }
            }

        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            gameRunning = false;
            e.Cancel = false;
        }

        private void listObject_DoubleClick(object sender, EventArgs e)
        {
            if (listObject.SelectedIndex == -1) { return; }

            currentObject = objectList[listObject.SelectedIndex].img;
            currentIndex = listObject.SelectedIndex;
        }

        #region "picAnim"
        private void picAnim_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void picAnim_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void picAnim_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = picAnim.PointToClient(MousePosition);
        }

        private void picAnim_MouseClick(object sender, MouseEventArgs e)
        {
            if (currentObject == null) { return; }
            if (Static.frame.Count == 0) { return; }
            if (ItemTool_Play.Text == "Pause") { return; }

            List<Frame> list = new List<Frame>();

            if (layerSel == 0) { list = Static.frame[currentFrame].camada_1; }
            if (layerSel == 1) { list = Static.frame[currentFrame].camada_2; }
            if (layerSel == 2) { list = Static.frame[currentFrame].camada_3; }

            list.Add(new Frame());
            list[list.Count - 1].img = currentObject;

            if (fixObject.Checked == true)
            {
                list[list.Count - 1].screenRect = new Rectangle(new Point(int.Parse(txt_x.Text.Trim()), int.Parse(txt_y.Text.Trim())), new Size(currentObject.Width, currentObject.Height));
            }
            else
            {
                list[list.Count - 1].screenRect = new Rectangle(new Point(mousePosition.X - currentObject.Width / 2, mousePosition.Y - currentObject.Height / 2), new Size(currentObject.Width, currentObject.Height));
            }

            list[list.Count - 1].name = objectList[currentIndex].name;

            RefreshLayer();
        }
        #endregion

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) { }
            if (e.KeyCode == Keys.S) { }
            if (e.KeyCode == Keys.A) { }
            if (e.KeyCode == Keys.D) { }
        }

        #region "Scroll Bar"
        private void vs_y_Scroll(object sender, ScrollEventArgs e)
        {
            cutScreen.X = vs_x.Value;
            cutScreen.Y = vs_y.Value;
            cutScreen.Width = vs_width.Value;
            cutScreen.Height = vs_height.Value;
            lblstatus.Text = x + ": " + vs_x.Value + " " + y + " : " + vs_y.Value + " " + width + " : " + vs_width.Value + " " + height + ": " + vs_height.Value;
        }

        private void vs_x_Scroll(object sender, ScrollEventArgs e)
        {
            cutScreen.X = vs_x.Value;
            cutScreen.Y = vs_y.Value;
            cutScreen.Width = vs_width.Value;
            cutScreen.Height = vs_height.Value;
            lblstatus.Text = x + ": " + vs_x.Value + " " + y + " : " + vs_y.Value + " " + width + " : " + vs_width.Value + " " + height + ": " + vs_height.Value;
        }

        private void vs_width_Scroll(object sender, ScrollEventArgs e)
        {
            cutScreen.X = vs_x.Value;
            cutScreen.Y = vs_y.Value;
            cutScreen.Width = vs_width.Value;
            cutScreen.Height = vs_height.Value;
            lblstatus.Text = x + ": " + vs_x.Value + " " + y + " : " + vs_y.Value + " " + width + " : " + vs_width.Value + " " + height + ": " + vs_height.Value;
        }

        private void vs_height_Scroll(object sender, ScrollEventArgs e)
        {
            cutScreen.X =  vs_x.Value;
            cutScreen.Y = vs_y.Value;
            cutScreen.Width = vs_width.Value;
            cutScreen.Height = vs_height.Value;
            lblstatus.Text = x + ": " + vs_x.Value + " " + y + " : " + vs_y.Value + " " + width + " : " + vs_width.Value + " " + height + ": " + vs_height.Value;
        }
        #endregion     

        private void listObject_MouseDown(object sender, MouseEventArgs e)
        {
            int index = listObject.SelectedIndex;

            if (index == -1) { return; }
            
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (index == currentIndex) { currentObject = null; }

                listObject.Items.RemoveAt(index);
                objectList.RemoveAt(index); 
            }
        }

        //################################################################
        //################################################################
        //################################################################
        private void SaveProject()
        {
            if (Static.frame.Count == 0) { return; }

            SaveFileDialog dialogBox = new SaveFileDialog();

            dialogBox.InitialDirectory = Application.StartupPath + @"\Project\";
            dialogBox.Filter = "Project Files (*.proj)|*.proj";
            dialogBox.FilterIndex = 1;

            if (dialogBox.ShowDialog() == DialogResult.Cancel) { return; }

            FileStream fStream = new FileStream(dialogBox.FileName, FileMode.Create);
            BinaryFormatter sFile = new BinaryFormatter();

            sFile.Serialize(fStream, Static.frame);
            sFile.Serialize(fStream, cutScreen);
            sFile.Serialize(fStream, frameRate);
            fStream.Close();

        }
        private void OpenProject()
        {
            OpenFileDialog dialogBox = new OpenFileDialog();
 
            dialogBox.InitialDirectory = Application.StartupPath + @"\Project\";
            dialogBox.Filter = "Project Files (*.proj)|*.proj";
            dialogBox.FilterIndex = 1;

            if (dialogBox.ShowDialog() == DialogResult.Cancel) { return; }

            FileStream fStream = new FileStream(dialogBox.FileName, FileMode.Open);
            BinaryFormatter sFile = new BinaryFormatter();

            Static.frame = (List<Layer>)sFile.Deserialize(fStream);
            cutScreen = (Rectangle)sFile.Deserialize(fStream);
            frameRate = (int)sFile.Deserialize(fStream);
            fStream.Close();

            txt_framerate.Text = "" + frameRate;
            currentFrame = 0;
            layerSel = 0;
            frameCount = 0;
            currentObject = null;
            currentIndex = 0;

            lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count;

            vs_x.Value = cutScreen.X;
            vs_y.Value = cutScreen.Y;
            vs_width.Value = cutScreen.Width;
            vs_height.Value = cutScreen.Height;

            lblstatus.Text = x + ": " + vs_x.Value + " " + y + ": " + vs_y.Value + " " + width + ": " + vs_width.Value + " " + height + ": " + vs_height.Value;
        }

        //###############################################################
        //################################################################
        //################################################################


        //###################    macoratti     ############################
        //################## LANGUAGE FUNCTIONS ###########################
        private void ReadConfig()
        {
            maxLang = Convert.ToInt32(GetIniValue("LANGUAGE", "MaxLanguage", Application.StartupPath + @"\Config.ini"));
        
            for (int n = 0; n <= maxLang; n++)
            {
                langName.Add(GetIniValue("LANGUAGE", "Language_" + n, Application.StartupPath + @"\Config.ini"));
                ItemTool_Lang.DropDownItems.Add(langName[n]);
                ItemTool_Lang.DropDownItems[n].Click += ChangeLanguage;
            }
        }
        private void ChangeLanguage(string file)
        {
            WriteIniValue("LANGUAGE", "Current", file, Application.StartupPath + @"\Config.ini");

            string fontName =GetIniValue("FONT", "FontName", Application.StartupPath + @"\Language\" + file + ".ini");
            int fontSize = Convert.ToInt32(GetIniValue("FONT", "FontSize", Application.StartupPath + @"\Language\" + file + ".ini"));

            ItemTool_File.Text = GetIniValue("FILE_MENU", "File", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_File.Font = new Font(fontName, fontSize);
            ItemTool_OpenProj.Text = GetIniValue("FILE_MENU", "OpenProject", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_OpenProj.Font = new Font(fontName, fontSize);
            ItemTool_SaveProj.Text = GetIniValue("FILE_MENU", "SaveProject", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_SaveProj.Font = new Font(fontName, fontSize);
            ItemTool_Exp.Text = GetIniValue("FILE_MENU", "Export", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Exp.Font = new Font(fontName, fontSize);
            ItemTool_End.Text = GetIniValue("FILE_MENU", "Quit", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_End.Font = new Font(fontName, fontSize);

            ItemTool_Layer.Text = GetIniValue("LAYER_MENU", "Layer", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Layer.Font = new Font(fontName, fontSize);
            ItemTool_Grid.Text = GetIniValue("LAYER_MENU", "Grid", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Grid.Font = new Font(fontName, fontSize);
            ItemTool_Previous.Text = GetIniValue("LAYER_MENU", "ShowPrevious", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Previous.Font = new Font(fontName, fontSize);
            ItemTool_Next.Text = GetIniValue("LAYER_MENU", "ShowNext", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Next.Font = new Font(fontName, fontSize);
            ItemTool_Layer1.Text = GetIniValue("LAYER_MENU", "Layer1", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Layer1.Font = new Font(fontName, fontSize);
            ItemTool_Layer2.Text = GetIniValue("LAYER_MENU", "Layer2", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Layer2.Font = new Font(fontName, fontSize);
            ItemTool_Layer3.Text = GetIniValue("LAYER_MENU", "Layer3", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Layer3.Font = new Font(fontName, fontSize);

            ItemTool_Anim.Text = GetIniValue("ANIM_MENU", "Animation", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Anim.Font = new Font(fontName, fontSize);
            buttonPlay = GetIniValue("ANIM_MENU", "Play", Application.StartupPath + @"\Language\" + file + ".ini");
            buttonPause = GetIniValue("ANIM_MENU", "Pause", Application.StartupPath + @"\Language\" + file + ".ini");

            if (play) { ItemTool_Play.Text = buttonPause;}
            else { ItemTool_Play.Text = buttonPlay; }

            ItemTool_Object.Text = GetIniValue("OBJECT_MENU", "Object", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Object.Font = new Font(fontName, fontSize);
            ItemTool_OpenObj.Text = GetIniValue("OBJECT_MENU", "Open", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_OpenObj.Font = new Font(fontName, fontSize);
            ItemTool_ClearList.Text = GetIniValue("OBJECT_MENU", "ClearList", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_ClearList.Font = new Font(fontName, fontSize);
            ItemTool_CloseObj.Text = GetIniValue("OBJECT_MENU", "ClosePointer", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_CloseObj.Font = new Font(fontName, fontSize);

            ItemTool_Lang.Text = GetIniValue("LANGUAGE_MENU", "Language", Application.StartupPath + @"\Language\" + file + ".ini");
            ItemTool_Lang.Font = new Font(fontName, fontSize);

            x = GetIniValue("LABEL_CUTSCREEN", "X", Application.StartupPath + @"\Language\" + file + ".ini");
            y = GetIniValue("LABEL_CUTSCREEN", "Y", Application.StartupPath + @"\Language\" + file + ".ini");
            width = GetIniValue("LABEL_CUTSCREEN", "Width", Application.StartupPath + @"\Language\" + file + ".ini");
            height = GetIniValue("LABEL_CUTSCREEN", "Height", Application.StartupPath + @"\Language\" + file + ".ini");

            lblstatus.Text = x + ": " + vs_x.Value + " " + y + " : " + vs_y.Value + " " + width + " : " + vs_width.Value + " " + height + ": " + vs_height.Value;
            lblstatus.Font = new Font(fontName, fontSize);

            fixObject.Text = GetIniValue("FRAME", "Fix", Application.StartupPath + @"\Language\" + file + ".ini");
            fixObject.Font = new Font(fontName, fontSize);
            lblframetime.Text = GetIniValue("FRAME", "FrameTime", Application.StartupPath + @"\Language\" + file + ".ini");
            lblframetime.Font = new Font(fontName, fontSize);
            btn_previous.Text = GetIniValue("FRAME", "Previous", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_previous.Font = new Font(fontName, fontSize);
            btn_next.Text = GetIniValue("FRAME", "Next", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_next.Font = new Font(fontName, fontSize);
            frame = GetIniValue("FRAME", "Frame", Application.StartupPath + @"\Language\" + file + ".ini");
            lblFrame.Font = new Font(fontName, fontSize);
            btn_add.Text = GetIniValue("FRAME", "Add", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_add.Font = new Font(fontName, fontSize);
            btn_removeAt.Text = GetIniValue("FRAME", "RemoveThis", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_removeAt.Font = new Font(fontName, fontSize);
            btn_removeLast.Text = GetIniValue("FRAME", "RemoveLast", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_removeLast.Font = new Font(fontName, fontSize);
            btn_clear.Text = GetIniValue("FRAME", "RemoveAll", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_clear.Font = new Font(fontName, fontSize);

            if (currentFrame == 0) { lblFrame.Text = frame + ": " + currentFrame + " / " + Static.frame.Count; }
            else { lblFrame.Text = frame + ": " + (currentFrame + 1) + " / " + Static.frame.Count; }
            

            lbllistob.Text = GetIniValue("LAYER_LIST", "ObjectList", Application.StartupPath + @"\Language\" + file + ".ini");
            lbllistob.Font = new Font(fontName, fontSize);

            btn_layer1.Text = GetIniValue("LAYER_MENU", "Layer1", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_layer1.Font = new Font(fontName, fontSize);
            btn_layer2.Text = GetIniValue("LAYER_MENU", "Layer2", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_layer2.Font = new Font(fontName, fontSize);
            btn_layer3.Text = GetIniValue("LAYER_MENU", "Layer3", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_layer3.Font = new Font(fontName, fontSize);
            btn_removeAll.Text = GetIniValue("FRAME", "RemoveAll", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_removeAll.Font = new Font(fontName, fontSize);
            btn_up.Text = GetIniValue("LAYER_LIST", "MoveUp", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_up.Font = new Font(fontName, fontSize);
            btn_down.Text = GetIniValue("LAYER_LIST", "MoveDown", Application.StartupPath + @"\Language\" + file + ".ini");
            btn_down.Font = new Font(fontName, fontSize);

            msgTitle = GetIniValue("MESSAGE", "MsgTitle", Application.StartupPath + @"\Language\" + file + ".ini");
            msg = GetIniValue("MESSAGE", "Msg", Application.StartupPath + @"\Language\" + file + ".ini");

            this.Text = GetIniValue("WINDOW", "Title", Application.StartupPath + @"\Language\" + file + ".ini");
        }

        private void ChangeLanguage(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = (ToolStripDropDownItem)sender;
            string file = item.Text;

            ChangeLanguage(file);
        }

        private string GetIniValue(string section, string key,string nomeArquivo)
        {
            int chars = 1000;
            StringBuilder buffer = new StringBuilder(chars);

            string sDefault = "";
            if (GetPrivateProfileString(section, key, sDefault, buffer, chars, nomeArquivo) != 0)
            {
                return buffer.ToString();
            }
            else
            {
                int err = Marshal.GetLastWin32Error();
                return null;
            }
        }
    
        private bool WriteIniValue(string section, string key, string value, string nomeArquivo)
        {
            return WritePrivateProfileString(section, key, value, nomeArquivo);
        }
        //#################################################################
        //#################################################################

    }
}

