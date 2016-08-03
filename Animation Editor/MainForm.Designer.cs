namespace Animation_Editor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.listObject = new System.Windows.Forms.ListBox();
            this.picAnim = new System.Windows.Forms.PictureBox();
            this.listLayer = new System.Windows.Forms.ListBox();
            this.btn_double_adv = new System.Windows.Forms.Button();
            this.btn_double_ret = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_previous = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.btn_removeAt = new System.Windows.Forms.Button();
            this.btn_removeLast = new System.Windows.Forms.Button();
            this.btn_clear = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ItemTool_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_OpenProj = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_SaveProj = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Exp = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_End = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Layer = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Grid = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Previous = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Layer1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Layer2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Layer3 = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Anim = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Play = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Object = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_OpenObj = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_ClearList = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_CloseObj = new System.Windows.Forms.ToolStripMenuItem();
            this.ponteiroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esquerdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.centroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.direitaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTool_Lang = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_layer1 = new System.Windows.Forms.Button();
            this.btn_layer2 = new System.Windows.Forms.Button();
            this.btn_layer3 = new System.Windows.Forms.Button();
            this.btn_removeAll = new System.Windows.Forms.Button();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.vs_x = new System.Windows.Forms.HScrollBar();
            this.vs_width = new System.Windows.Forms.HScrollBar();
            this.vs_height = new System.Windows.Forms.VScrollBar();
            this.vs_y = new System.Windows.Forms.VScrollBar();
            this.lbllistob = new System.Windows.Forms.Label();
            this.lblFrame = new System.Windows.Forms.Label();
            this.fixObject = new System.Windows.Forms.CheckBox();
            this.txt_x = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_y = new System.Windows.Forms.TextBox();
            this.lblstatus = new System.Windows.Forms.Label();
            this.txt_framerate = new System.Windows.Forms.TextBox();
            this.lblframetime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picAnim)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listObject
            // 
            this.listObject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listObject.FormattingEnabled = true;
            this.listObject.Location = new System.Drawing.Point(12, 57);
            this.listObject.Name = "listObject";
            this.listObject.ScrollAlwaysVisible = true;
            this.listObject.Size = new System.Drawing.Size(123, 420);
            this.listObject.TabIndex = 0;
            this.listObject.DoubleClick += new System.EventHandler(this.listObject_DoubleClick);
            this.listObject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listObject_MouseDown);
            // 
            // picAnim
            // 
            this.picAnim.BackColor = System.Drawing.Color.Black;
            this.picAnim.Location = new System.Drawing.Point(182, 156);
            this.picAnim.Name = "picAnim";
            this.picAnim.Size = new System.Drawing.Size(416, 295);
            this.picAnim.TabIndex = 1;
            this.picAnim.TabStop = false;
            this.picAnim.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picAnim_MouseClick);
            this.picAnim.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picAnim_MouseDown);
            this.picAnim.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picAnim_MouseMove);
            this.picAnim.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picAnim_MouseUp);
            // 
            // listLayer
            // 
            this.listLayer.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLayer.FormattingEnabled = true;
            this.listLayer.Location = new System.Drawing.Point(652, 201);
            this.listLayer.Name = "listLayer";
            this.listLayer.ScrollAlwaysVisible = true;
            this.listLayer.Size = new System.Drawing.Size(120, 277);
            this.listLayer.TabIndex = 2;
            this.listLayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listLayer_MouseDown);
            // 
            // btn_double_adv
            // 
            this.btn_double_adv.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_double_adv.Location = new System.Drawing.Point(490, 66);
            this.btn_double_adv.Name = "btn_double_adv";
            this.btn_double_adv.Size = new System.Drawing.Size(50, 21);
            this.btn_double_adv.TabIndex = 3;
            this.btn_double_adv.Text = ">>";
            this.btn_double_adv.UseVisualStyleBackColor = true;
            this.btn_double_adv.Click += new System.EventHandler(this.btn_double_adv_Click);
            // 
            // btn_double_ret
            // 
            this.btn_double_ret.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_double_ret.Location = new System.Drawing.Point(239, 64);
            this.btn_double_ret.Name = "btn_double_ret";
            this.btn_double_ret.Size = new System.Drawing.Size(50, 21);
            this.btn_double_ret.TabIndex = 4;
            this.btn_double_ret.Text = "<<";
            this.btn_double_ret.UseVisualStyleBackColor = true;
            this.btn_double_ret.Click += new System.EventHandler(this.btn_double_ret_Click);
            // 
            // btn_next
            // 
            this.btn_next.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.Location = new System.Drawing.Point(546, 66);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(92, 21);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "Próximo";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_previous
            // 
            this.btn_previous.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_previous.Location = new System.Drawing.Point(141, 64);
            this.btn_previous.Name = "btn_previous";
            this.btn_previous.Size = new System.Drawing.Size(92, 21);
            this.btn_previous.TabIndex = 6;
            this.btn_previous.Text = "Anterior";
            this.btn_previous.UseVisualStyleBackColor = true;
            this.btn_previous.Click += new System.EventHandler(this.btn_previous_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.Location = new System.Drawing.Point(141, 90);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(115, 21);
            this.btn_add.TabIndex = 7;
            this.btn_add.Text = "Adicionar";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // btn_removeAt
            // 
            this.btn_removeAt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeAt.Location = new System.Drawing.Point(262, 90);
            this.btn_removeAt.Name = "btn_removeAt";
            this.btn_removeAt.Size = new System.Drawing.Size(115, 21);
            this.btn_removeAt.TabIndex = 8;
            this.btn_removeAt.Text = "Remover Este";
            this.btn_removeAt.UseVisualStyleBackColor = true;
            this.btn_removeAt.Click += new System.EventHandler(this.btn_removeAt_Click);
            // 
            // btn_removeLast
            // 
            this.btn_removeLast.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeLast.Location = new System.Drawing.Point(402, 90);
            this.btn_removeLast.Name = "btn_removeLast";
            this.btn_removeLast.Size = new System.Drawing.Size(115, 21);
            this.btn_removeLast.TabIndex = 9;
            this.btn_removeLast.Text = "Remover Último";
            this.btn_removeLast.UseVisualStyleBackColor = true;
            this.btn_removeLast.Click += new System.EventHandler(this.btn_removeLast_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.Location = new System.Drawing.Point(523, 90);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(115, 21);
            this.btn_clear.TabIndex = 10;
            this.btn_clear.Text = "Remover Todos";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemTool_File,
            this.ItemTool_Layer,
            this.ItemTool_Anim,
            this.ItemTool_Object,
            this.ItemTool_Lang});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ItemTool_File
            // 
            this.ItemTool_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemTool_OpenProj,
            this.ItemTool_SaveProj,
            this.ItemTool_Exp,
            this.ItemTool_End});
            this.ItemTool_File.Name = "ItemTool_File";
            this.ItemTool_File.Size = new System.Drawing.Size(63, 20);
            this.ItemTool_File.Text = "Arquivo";
            // 
            // ItemTool_OpenProj
            // 
            this.ItemTool_OpenProj.Name = "ItemTool_OpenProj";
            this.ItemTool_OpenProj.Size = new System.Drawing.Size(157, 22);
            this.ItemTool_OpenProj.Text = "Abrir Projeto";
            this.ItemTool_OpenProj.Click += new System.EventHandler(this.ItemTool_OpenProj_Click);
            // 
            // ItemTool_SaveProj
            // 
            this.ItemTool_SaveProj.Name = "ItemTool_SaveProj";
            this.ItemTool_SaveProj.Size = new System.Drawing.Size(157, 22);
            this.ItemTool_SaveProj.Text = "Salvar Projeto";
            this.ItemTool_SaveProj.Click += new System.EventHandler(this.ItemTool_SaveProj_Click);
            // 
            // ItemTool_Exp
            // 
            this.ItemTool_Exp.Name = "ItemTool_Exp";
            this.ItemTool_Exp.Size = new System.Drawing.Size(157, 22);
            this.ItemTool_Exp.Text = "Exportar";
            this.ItemTool_Exp.Click += new System.EventHandler(this.ItemTool_Exp_Click);
            // 
            // ItemTool_End
            // 
            this.ItemTool_End.Name = "ItemTool_End";
            this.ItemTool_End.Size = new System.Drawing.Size(157, 22);
            this.ItemTool_End.Text = "Sair";
            this.ItemTool_End.Click += new System.EventHandler(this.ItemTool_End_Click);
            // 
            // ItemTool_Layer
            // 
            this.ItemTool_Layer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemTool_Grid,
            this.ItemTool_Previous,
            this.ItemTool_Next,
            this.ItemTool_Layer1,
            this.ItemTool_Layer2,
            this.ItemTool_Layer3});
            this.ItemTool_Layer.Name = "ItemTool_Layer";
            this.ItemTool_Layer.Size = new System.Drawing.Size(67, 20);
            this.ItemTool_Layer.Text = "Camada";
            // 
            // ItemTool_Grid
            // 
            this.ItemTool_Grid.Checked = true;
            this.ItemTool_Grid.CheckOnClick = true;
            this.ItemTool_Grid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ItemTool_Grid.Name = "ItemTool_Grid";
            this.ItemTool_Grid.Size = new System.Drawing.Size(221, 22);
            this.ItemTool_Grid.Text = "Grade";
            // 
            // ItemTool_Previous
            // 
            this.ItemTool_Previous.Checked = true;
            this.ItemTool_Previous.CheckOnClick = true;
            this.ItemTool_Previous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ItemTool_Previous.Name = "ItemTool_Previous";
            this.ItemTool_Previous.Size = new System.Drawing.Size(221, 22);
            this.ItemTool_Previous.Text = "Mostrar Quadro Anterior";
            // 
            // ItemTool_Next
            // 
            this.ItemTool_Next.Checked = true;
            this.ItemTool_Next.CheckOnClick = true;
            this.ItemTool_Next.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ItemTool_Next.Name = "ItemTool_Next";
            this.ItemTool_Next.Size = new System.Drawing.Size(221, 22);
            this.ItemTool_Next.Text = "Mostrar Quadro Posterior";
            // 
            // ItemTool_Layer1
            // 
            this.ItemTool_Layer1.Checked = true;
            this.ItemTool_Layer1.CheckOnClick = true;
            this.ItemTool_Layer1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ItemTool_Layer1.Name = "ItemTool_Layer1";
            this.ItemTool_Layer1.Size = new System.Drawing.Size(221, 22);
            this.ItemTool_Layer1.Text = "Camada 1";
            // 
            // ItemTool_Layer2
            // 
            this.ItemTool_Layer2.Checked = true;
            this.ItemTool_Layer2.CheckOnClick = true;
            this.ItemTool_Layer2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ItemTool_Layer2.Name = "ItemTool_Layer2";
            this.ItemTool_Layer2.Size = new System.Drawing.Size(221, 22);
            this.ItemTool_Layer2.Text = "Camada 2";
            // 
            // ItemTool_Layer3
            // 
            this.ItemTool_Layer3.Checked = true;
            this.ItemTool_Layer3.CheckOnClick = true;
            this.ItemTool_Layer3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ItemTool_Layer3.Name = "ItemTool_Layer3";
            this.ItemTool_Layer3.Size = new System.Drawing.Size(221, 22);
            this.ItemTool_Layer3.Text = "Camada 3";
            // 
            // ItemTool_Anim
            // 
            this.ItemTool_Anim.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemTool_Play});
            this.ItemTool_Anim.Name = "ItemTool_Anim";
            this.ItemTool_Anim.Size = new System.Drawing.Size(76, 20);
            this.ItemTool_Anim.Text = "Animação";
            // 
            // ItemTool_Play
            // 
            this.ItemTool_Play.Name = "ItemTool_Play";
            this.ItemTool_Play.Size = new System.Drawing.Size(98, 22);
            this.ItemTool_Play.Text = "Play";
            this.ItemTool_Play.Click += new System.EventHandler(this.ItemTool_Play_Click);
            // 
            // ItemTool_Object
            // 
            this.ItemTool_Object.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemTool_OpenObj,
            this.ItemTool_ClearList,
            this.ItemTool_CloseObj,
            this.ponteiroToolStripMenuItem});
            this.ItemTool_Object.Name = "ItemTool_Object";
            this.ItemTool_Object.Size = new System.Drawing.Size(64, 20);
            this.ItemTool_Object.Text = "Objetos";
            // 
            // ItemTool_OpenObj
            // 
            this.ItemTool_OpenObj.Name = "ItemTool_OpenObj";
            this.ItemTool_OpenObj.Size = new System.Drawing.Size(165, 22);
            this.ItemTool_OpenObj.Text = "Abrir";
            this.ItemTool_OpenObj.Click += new System.EventHandler(this.ItemTool_OpenObj_Click);
            // 
            // ItemTool_ClearList
            // 
            this.ItemTool_ClearList.Name = "ItemTool_ClearList";
            this.ItemTool_ClearList.Size = new System.Drawing.Size(165, 22);
            this.ItemTool_ClearList.Text = "Limpar Lista";
            this.ItemTool_ClearList.Click += new System.EventHandler(this.ItemTool_ClearList_Click);
            // 
            // ItemTool_CloseObj
            // 
            this.ItemTool_CloseObj.Name = "ItemTool_CloseObj";
            this.ItemTool_CloseObj.Size = new System.Drawing.Size(165, 22);
            this.ItemTool_CloseObj.Text = "Fechar Ponteiro";
            this.ItemTool_CloseObj.Click += new System.EventHandler(this.ItemTool_CloseObj_Click);
            // 
            // ponteiroToolStripMenuItem
            // 
            this.ponteiroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topoToolStripMenuItem,
            this.esquerdaToolStripMenuItem,
            this.centroToolStripMenuItem,
            this.direitaToolStripMenuItem,
            this.fimToolStripMenuItem});
            this.ponteiroToolStripMenuItem.Enabled = false;
            this.ponteiroToolStripMenuItem.Name = "ponteiroToolStripMenuItem";
            this.ponteiroToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.ponteiroToolStripMenuItem.Text = "Ponteiro";
            // 
            // topoToolStripMenuItem
            // 
            this.topoToolStripMenuItem.CheckOnClick = true;
            this.topoToolStripMenuItem.Name = "topoToolStripMenuItem";
            this.topoToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.topoToolStripMenuItem.Text = "Topo";
            // 
            // esquerdaToolStripMenuItem
            // 
            this.esquerdaToolStripMenuItem.CheckOnClick = true;
            this.esquerdaToolStripMenuItem.Name = "esquerdaToolStripMenuItem";
            this.esquerdaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.esquerdaToolStripMenuItem.Text = "Esquerda";
            // 
            // centroToolStripMenuItem
            // 
            this.centroToolStripMenuItem.Checked = true;
            this.centroToolStripMenuItem.CheckOnClick = true;
            this.centroToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.centroToolStripMenuItem.Name = "centroToolStripMenuItem";
            this.centroToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.centroToolStripMenuItem.Text = "Centro";
            // 
            // direitaToolStripMenuItem
            // 
            this.direitaToolStripMenuItem.CheckOnClick = true;
            this.direitaToolStripMenuItem.Name = "direitaToolStripMenuItem";
            this.direitaToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.direitaToolStripMenuItem.Text = "Direita";
            // 
            // fimToolStripMenuItem
            // 
            this.fimToolStripMenuItem.CheckOnClick = true;
            this.fimToolStripMenuItem.Name = "fimToolStripMenuItem";
            this.fimToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.fimToolStripMenuItem.Text = "Fim";
            // 
            // ItemTool_Lang
            // 
            this.ItemTool_Lang.Name = "ItemTool_Lang";
            this.ItemTool_Lang.Size = new System.Drawing.Size(60, 20);
            this.ItemTool_Lang.Text = "Idioma";
            // 
            // btn_layer1
            // 
            this.btn_layer1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_layer1.Location = new System.Drawing.Point(652, 36);
            this.btn_layer1.Name = "btn_layer1";
            this.btn_layer1.Size = new System.Drawing.Size(120, 21);
            this.btn_layer1.TabIndex = 12;
            this.btn_layer1.Text = "Camada 1";
            this.btn_layer1.UseVisualStyleBackColor = true;
            this.btn_layer1.Click += new System.EventHandler(this.btn_camada1_Click);
            // 
            // btn_layer2
            // 
            this.btn_layer2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_layer2.Location = new System.Drawing.Point(652, 63);
            this.btn_layer2.Name = "btn_layer2";
            this.btn_layer2.Size = new System.Drawing.Size(120, 21);
            this.btn_layer2.TabIndex = 13;
            this.btn_layer2.Text = "Camada 2";
            this.btn_layer2.UseVisualStyleBackColor = true;
            this.btn_layer2.Click += new System.EventHandler(this.btn_camada2_Click);
            // 
            // btn_layer3
            // 
            this.btn_layer3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_layer3.Location = new System.Drawing.Point(652, 90);
            this.btn_layer3.Name = "btn_layer3";
            this.btn_layer3.Size = new System.Drawing.Size(120, 21);
            this.btn_layer3.TabIndex = 14;
            this.btn_layer3.Text = "Camada 3";
            this.btn_layer3.UseVisualStyleBackColor = true;
            this.btn_layer3.Click += new System.EventHandler(this.btn_camada3_Click);
            // 
            // btn_removeAll
            // 
            this.btn_removeAll.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_removeAll.Location = new System.Drawing.Point(652, 115);
            this.btn_removeAll.Name = "btn_removeAll";
            this.btn_removeAll.Size = new System.Drawing.Size(120, 21);
            this.btn_removeAll.TabIndex = 16;
            this.btn_removeAll.Text = "Remover Todos";
            this.btn_removeAll.UseVisualStyleBackColor = true;
            this.btn_removeAll.Click += new System.EventHandler(this.btn_removeAll_Click);
            // 
            // btn_down
            // 
            this.btn_down.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_down.Location = new System.Drawing.Point(652, 169);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(120, 21);
            this.btn_down.TabIndex = 18;
            this.btn_down.Text = "Mover para Baixo";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_up
            // 
            this.btn_up.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_up.Location = new System.Drawing.Point(652, 142);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(120, 21);
            this.btn_up.TabIndex = 17;
            this.btn_up.Text = "Mover para Cima";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // vs_x
            // 
            this.vs_x.Location = new System.Drawing.Point(182, 129);
            this.vs_x.Maximum = 425;
            this.vs_x.Name = "vs_x";
            this.vs_x.Size = new System.Drawing.Size(420, 17);
            this.vs_x.TabIndex = 20;
            this.vs_x.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vs_x_Scroll);
            // 
            // vs_width
            // 
            this.vs_width.Location = new System.Drawing.Point(182, 466);
            this.vs_width.Maximum = 425;
            this.vs_width.Name = "vs_width";
            this.vs_width.Size = new System.Drawing.Size(420, 17);
            this.vs_width.TabIndex = 21;
            this.vs_width.Value = 192;
            this.vs_width.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vs_width_Scroll);
            // 
            // vs_height
            // 
            this.vs_height.Location = new System.Drawing.Point(621, 156);
            this.vs_height.Maximum = 329;
            this.vs_height.Name = "vs_height";
            this.vs_height.Size = new System.Drawing.Size(17, 281);
            this.vs_height.TabIndex = 22;
            this.vs_height.Value = 192;
            this.vs_height.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vs_height_Scroll);
            // 
            // vs_y
            // 
            this.vs_y.Location = new System.Drawing.Point(146, 156);
            this.vs_y.Maximum = 329;
            this.vs_y.Name = "vs_y";
            this.vs_y.Size = new System.Drawing.Size(20, 281);
            this.vs_y.TabIndex = 23;
            this.vs_y.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vs_y_Scroll);
            // 
            // lbllistob
            // 
            this.lbllistob.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllistob.Location = new System.Drawing.Point(12, 35);
            this.lbllistob.Name = "lbllistob";
            this.lbllistob.Size = new System.Drawing.Size(123, 16);
            this.lbllistob.TabIndex = 24;
            this.lbllistob.Text = "Lista de Objetos";
            this.lbllistob.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFrame
            // 
            this.lblFrame.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrame.Location = new System.Drawing.Point(295, 66);
            this.lblFrame.Name = "lblFrame";
            this.lblFrame.Size = new System.Drawing.Size(189, 18);
            this.lblFrame.TabIndex = 25;
            this.lblFrame.Text = "Quadro: 0 / 0";
            this.lblFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fixObject
            // 
            this.fixObject.AutoSize = true;
            this.fixObject.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fixObject.Location = new System.Drawing.Point(146, 36);
            this.fixObject.Name = "fixObject";
            this.fixObject.Size = new System.Drawing.Size(54, 17);
            this.fixObject.TabIndex = 26;
            this.fixObject.Text = "Fixar";
            this.fixObject.UseVisualStyleBackColor = true;
            // 
            // txt_x
            // 
            this.txt_x.Location = new System.Drawing.Point(225, 36);
            this.txt_x.Name = "txt_x";
            this.txt_x.Size = new System.Drawing.Size(42, 19);
            this.txt_x.TabIndex = 27;
            this.txt_x.Text = "0";
            this.txt_x.TextChanged += new System.EventHandler(this.txt_x_TextChanged);
            this.txt_x.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_x_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(206, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "X";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(273, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_y
            // 
            this.txt_y.Location = new System.Drawing.Point(299, 36);
            this.txt_y.Name = "txt_y";
            this.txt_y.Size = new System.Drawing.Size(42, 19);
            this.txt_y.TabIndex = 29;
            this.txt_y.Text = "0";
            this.txt_y.TextChanged += new System.EventHandler(this.txt_y_TextChanged);
            this.txt_y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_y_KeyPress);
            // 
            // lblstatus
            // 
            this.lblstatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstatus.Location = new System.Drawing.Point(179, 483);
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(419, 16);
            this.lblstatus.TabIndex = 31;
            this.lblstatus.Text = "X: 0 Y: 0 Comprimento: 0 Altura: 0";
            this.lblstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_framerate
            // 
            this.txt_framerate.Location = new System.Drawing.Point(463, 38);
            this.txt_framerate.Name = "txt_framerate";
            this.txt_framerate.Size = new System.Drawing.Size(42, 19);
            this.txt_framerate.TabIndex = 32;
            this.txt_framerate.Text = "60";
            this.txt_framerate.TextChanged += new System.EventHandler(this.txt_framerate_TextChanged);
            this.txt_framerate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_framerate_KeyPress);
            // 
            // lblframetime
            // 
            this.lblframetime.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblframetime.Location = new System.Drawing.Point(347, 39);
            this.lblframetime.Name = "lblframetime";
            this.lblframetime.Size = new System.Drawing.Size(110, 16);
            this.lblframetime.TabIndex = 33;
            this.lblframetime.Text = "Tempo do Quadro";
            this.lblframetime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 518);
            this.Controls.Add(this.lblframetime);
            this.Controls.Add(this.txt_framerate);
            this.Controls.Add(this.lblstatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_y);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_x);
            this.Controls.Add(this.fixObject);
            this.Controls.Add(this.lblFrame);
            this.Controls.Add(this.lbllistob);
            this.Controls.Add(this.vs_y);
            this.Controls.Add(this.vs_height);
            this.Controls.Add(this.vs_width);
            this.Controls.Add(this.vs_x);
            this.Controls.Add(this.btn_down);
            this.Controls.Add(this.btn_up);
            this.Controls.Add(this.btn_removeAll);
            this.Controls.Add(this.btn_layer3);
            this.Controls.Add(this.btn_layer2);
            this.Controls.Add(this.btn_layer1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_removeLast);
            this.Controls.Add(this.btn_removeAt);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.btn_previous);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_double_ret);
            this.Controls.Add(this.btn_double_adv);
            this.Controls.Add(this.listLayer);
            this.Controls.Add(this.picAnim);
            this.Controls.Add(this.listObject);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Animação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picAnim)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listObject;
        private System.Windows.Forms.PictureBox picAnim;
        private System.Windows.Forms.ListBox listLayer;
        private System.Windows.Forms.Button btn_double_adv;
        private System.Windows.Forms.Button btn_double_ret;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_previous;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Button btn_removeAt;
        private System.Windows.Forms.Button btn_removeLast;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btn_layer1;
        private System.Windows.Forms.Button btn_layer2;
        private System.Windows.Forms.Button btn_layer3;
        private System.Windows.Forms.Button btn_removeAll;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_File;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Layer;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Anim;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Object;
        private System.Windows.Forms.HScrollBar vs_x;
        private System.Windows.Forms.HScrollBar vs_width;
        private System.Windows.Forms.VScrollBar vs_height;
        private System.Windows.Forms.VScrollBar vs_y;
        private System.Windows.Forms.Label lbllistob;
        private System.Windows.Forms.Label lblFrame;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_SaveProj;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_OpenProj;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Exp;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_End;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Grid;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Previous;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Next;
        private System.Windows.Forms.CheckBox fixObject;
        private System.Windows.Forms.TextBox txt_x;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_y;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Play;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_OpenObj;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_ClearList;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_CloseObj;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Layer1;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Layer2;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Layer3;
        private System.Windows.Forms.ToolStripMenuItem ponteiroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esquerdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem centroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem direitaToolStripMenuItem;
        private System.Windows.Forms.Label lblstatus;
        private System.Windows.Forms.TextBox txt_framerate;
        private System.Windows.Forms.Label lblframetime;
        private System.Windows.Forms.ToolStripMenuItem ItemTool_Lang;
    }
}

