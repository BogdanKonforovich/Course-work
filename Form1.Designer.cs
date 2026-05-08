namespace Курсова_робота
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtVertices = new TextBox();
            btnCreateMatrix = new Button();
            gridMatrix = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            cmbInputMethod = new ComboBox();
            label3 = new Label();
            cmbAlgorithm = new ComboBox();
            lblAlgorithm = new Label();
            btnCalculate = new Button();
            gridResult = new DataGridView();
            lblResultTitle = new Label();
            pnlResults = new Panel();
            btnEditMode = new Button();
            pnlEdit = new Panel();
            txtAddVertex = new TextBox();
            txtRemoveVertex = new TextBox();
            btnFinishEditing = new Button();
            btnRemoveVertex = new Button();
            label5 = new Label();
            btnAddVertex = new Button();
            label4 = new Label();
            pbGraph = new PictureBox();
            btnFindPath = new Button();
            lblPathMessage = new Label();
            pnlPathSearch = new Panel();
            txtEndNode = new TextBox();
            txtStartNode = new TextBox();
            label7 = new Label();
            label6 = new Label();
            btnSaveReport = new Button();
            btnClearMatrix_Click = new Button();
            ((System.ComponentModel.ISupportInitialize)gridMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridResult).BeginInit();
            pnlResults.SuspendLayout();
            pnlEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbGraph).BeginInit();
            pnlPathSearch.SuspendLayout();
            SuspendLayout();
            // 
            // txtVertices
            // 
            txtVertices.Location = new Point(91, 40);
            txtVertices.Name = "txtVertices";
            txtVertices.Size = new Size(125, 27);
            txtVertices.TabIndex = 0;
            txtVertices.TextChanged += txtVertices_TextChanged;
            txtVertices.Validating += txtVertices_Validating;
            // 
            // btnCreateMatrix
            // 
            btnCreateMatrix.Location = new Point(89, 145);
            btnCreateMatrix.Name = "btnCreateMatrix";
            btnCreateMatrix.Size = new Size(168, 29);
            btnCreateMatrix.TabIndex = 1;
            btnCreateMatrix.Text = "Створити матрицю";
            btnCreateMatrix.UseVisualStyleBackColor = true;
            btnCreateMatrix.Click += btnCreateMatrix_Click;
            // 
            // gridMatrix
            // 
            gridMatrix.BackgroundColor = SystemColors.Control;
            gridMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridMatrix.Location = new Point(89, 183);
            gridMatrix.Name = "gridMatrix";
            gridMatrix.RowHeadersWidth = 51;
            gridMatrix.Size = new Size(473, 292);
            gridMatrix.TabIndex = 2;
            gridMatrix.Visible = false;
            gridMatrix.CellContentClick += dataGridView1_CellContentClick;
            gridMatrix.CellValidating += gridMatrix_CellValidating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 9);
            label1.Name = "label1";
            label1.Size = new Size(317, 20);
            label1.TabIndex = 3;
            label1.Text = "Введіть кількість вершин графа (від 2 до 20):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 122);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 4;
            // 
            // cmbInputMethod
            // 
            cmbInputMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbInputMethod.FormattingEnabled = true;
            cmbInputMethod.Items.AddRange(new object[] { "Вручну", "Рандомно" });
            cmbInputMethod.Location = new Point(91, 111);
            cmbInputMethod.Name = "cmbInputMethod";
            cmbInputMethod.Size = new Size(151, 28);
            cmbInputMethod.TabIndex = 5;
            cmbInputMethod.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(89, 79);
            label3.Name = "label3";
            label3.Size = new Size(257, 20);
            label3.TabIndex = 6;
            label3.Text = "Введіть спосіб заповнення матриці";
            label3.Click += label3_Click;
            // 
            // cmbAlgorithm
            // 
            cmbAlgorithm.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAlgorithm.FormattingEnabled = true;
            cmbAlgorithm.Items.AddRange(new object[] { "Алгоритм Флойда-Воршелла", "Алгоритм Данцига" });
            cmbAlgorithm.Location = new Point(3, 44);
            cmbAlgorithm.Name = "cmbAlgorithm";
            cmbAlgorithm.Size = new Size(241, 28);
            cmbAlgorithm.TabIndex = 7;
            cmbAlgorithm.SelectedIndexChanged += cmbAlgorithm_SelectedIndexChanged;
            // 
            // lblAlgorithm
            // 
            lblAlgorithm.AutoSize = true;
            lblAlgorithm.Location = new Point(3, 11);
            lblAlgorithm.Name = "lblAlgorithm";
            lblAlgorithm.Size = new Size(189, 20);
            lblAlgorithm.TabIndex = 8;
            lblAlgorithm.Text = "Оберіть алгоритм пошуку";
            // 
            // btnCalculate
            // 
            btnCalculate.Location = new Point(3, 96);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(200, 54);
            btnCalculate.TabIndex = 9;
            btnCalculate.Text = "Створити матрицю найкоротших шляхів";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Visible = false;
            btnCalculate.Click += btnCalculate_Click;
            // 
            // gridResult
            // 
            gridResult.BackgroundColor = SystemColors.Control;
            gridResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridResult.Location = new Point(0, 189);
            gridResult.Name = "gridResult";
            gridResult.RowHeadersWidth = 51;
            gridResult.Size = new Size(473, 292);
            gridResult.TabIndex = 10;
            gridResult.Visible = false;
            gridResult.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // lblResultTitle
            // 
            lblResultTitle.AutoSize = true;
            lblResultTitle.Location = new Point(3, 166);
            lblResultTitle.Name = "lblResultTitle";
            lblResultTitle.Size = new Size(220, 20);
            lblResultTitle.TabIndex = 11;
            lblResultTitle.Text = "Матриця найкоротших шляхів";
            lblResultTitle.Visible = false;
            // 
            // pnlResults
            // 
            pnlResults.Controls.Add(gridResult);
            pnlResults.Controls.Add(btnCalculate);
            pnlResults.Controls.Add(lblResultTitle);
            pnlResults.Controls.Add(cmbAlgorithm);
            pnlResults.Controls.Add(lblAlgorithm);
            pnlResults.Location = new Point(91, 481);
            pnlResults.Name = "pnlResults";
            pnlResults.Size = new Size(487, 503);
            pnlResults.TabIndex = 12;
            // 
            // btnEditMode
            // 
            btnEditMode.Location = new Point(350, 40);
            btnEditMode.Name = "btnEditMode";
            btnEditMode.Size = new Size(214, 29);
            btnEditMode.TabIndex = 13;
            btnEditMode.Text = "Змінити кількість вершин";
            btnEditMode.UseVisualStyleBackColor = true;
            btnEditMode.Click += btnEditMode_Click;
            // 
            // pnlEdit
            // 
            pnlEdit.Controls.Add(txtAddVertex);
            pnlEdit.Controls.Add(txtRemoveVertex);
            pnlEdit.Controls.Add(btnFinishEditing);
            pnlEdit.Controls.Add(btnRemoveVertex);
            pnlEdit.Controls.Add(label5);
            pnlEdit.Controls.Add(btnAddVertex);
            pnlEdit.Controls.Add(label4);
            pnlEdit.Location = new Point(33, 824);
            pnlEdit.Name = "pnlEdit";
            pnlEdit.Size = new Size(422, 219);
            pnlEdit.TabIndex = 14;
            pnlEdit.Visible = false;
            pnlEdit.Paint += pnlEdit_Paint;
            // 
            // txtAddVertex
            // 
            txtAddVertex.Location = new Point(17, 56);
            txtAddVertex.Name = "txtAddVertex";
            txtAddVertex.Size = new Size(125, 27);
            txtAddVertex.TabIndex = 9;
            txtAddVertex.TextChanged += txtAddVertex_TextChanged;
            // 
            // txtRemoveVertex
            // 
            txtRemoveVertex.Location = new Point(223, 56);
            txtRemoveVertex.Name = "txtRemoveVertex";
            txtRemoveVertex.Size = new Size(125, 27);
            txtRemoveVertex.TabIndex = 8;
            txtRemoveVertex.TextChanged += txtRemoveVertex_TextChanged;
            // 
            // btnFinishEditing
            // 
            btnFinishEditing.Location = new Point(108, 167);
            btnFinishEditing.Name = "btnFinishEditing";
            btnFinishEditing.Size = new Size(192, 29);
            btnFinishEditing.TabIndex = 7;
            btnFinishEditing.Text = "Завершити редагування";
            btnFinishEditing.UseVisualStyleBackColor = true;
            btnFinishEditing.Visible = false;
            btnFinishEditing.Click += btnFinishEditing_Click;
            // 
            // btnRemoveVertex
            // 
            btnRemoveVertex.Location = new Point(223, 110);
            btnRemoveVertex.Name = "btnRemoveVertex";
            btnRemoveVertex.Size = new Size(94, 29);
            btnRemoveVertex.TabIndex = 6;
            btnRemoveVertex.Text = "Видалити";
            btnRemoveVertex.UseVisualStyleBackColor = true;
            btnRemoveVertex.Click += btnRemoveVertex_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(223, 22);
            label5.Name = "label5";
            label5.Size = new Size(144, 20);
            label5.TabIndex = 3;
            label5.Text = "Видалити вершину:";
            // 
            // btnAddVertex
            // 
            btnAddVertex.Location = new Point(17, 110);
            btnAddVertex.Name = "btnAddVertex";
            btnAddVertex.Size = new Size(94, 29);
            btnAddVertex.TabIndex = 2;
            btnAddVertex.Text = "Додати";
            btnAddVertex.UseVisualStyleBackColor = true;
            btnAddVertex.Click += btnAddVertex_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 22);
            label4.Name = "label4";
            label4.Size = new Size(146, 20);
            label4.TabIndex = 0;
            label4.Text = "Додати на позицію:";
            // 
            // pbGraph
            // 
            pbGraph.BackColor = Color.White;
            pbGraph.BorderStyle = BorderStyle.FixedSingle;
            pbGraph.Location = new Point(663, 166);
            pbGraph.Name = "pbGraph";
            pbGraph.Size = new Size(849, 516);
            pbGraph.TabIndex = 15;
            pbGraph.TabStop = false;
            pbGraph.Click += pictureBox1_Click;
            pbGraph.Paint += pbGraph_Paint;
            // 
            // btnFindPath
            // 
            btnFindPath.Location = new Point(425, 79);
            btnFindPath.Name = "btnFindPath";
            btnFindPath.Size = new Size(132, 29);
            btnFindPath.TabIndex = 18;
            btnFindPath.Text = "Знайти шлях";
            btnFindPath.UseVisualStyleBackColor = true;
            btnFindPath.Click += btnFindPath_Click;
            // 
            // lblPathMessage
            // 
            lblPathMessage.AutoSize = true;
            lblPathMessage.Location = new Point(17, 137);
            lblPathMessage.Name = "lblPathMessage";
            lblPathMessage.Size = new Size(138, 20);
            lblPathMessage.TabIndex = 19;
            lblPathMessage.Text = "Знайдений шлях: -";
            lblPathMessage.Click += label6_Click;
            // 
            // pnlPathSearch
            // 
            pnlPathSearch.Controls.Add(txtEndNode);
            pnlPathSearch.Controls.Add(txtStartNode);
            pnlPathSearch.Controls.Add(label7);
            pnlPathSearch.Controls.Add(label6);
            pnlPathSearch.Controls.Add(btnSaveReport);
            pnlPathSearch.Controls.Add(btnFindPath);
            pnlPathSearch.Controls.Add(lblPathMessage);
            pnlPathSearch.Location = new Point(663, 709);
            pnlPathSearch.Name = "pnlPathSearch";
            pnlPathSearch.Size = new Size(849, 258);
            pnlPathSearch.TabIndex = 20;
            pnlPathSearch.Visible = false;
            pnlPathSearch.Paint += pnlPathSearch_Paint;
            // 
            // txtEndNode
            // 
            txtEndNode.Location = new Point(239, 81);
            txtEndNode.Name = "txtEndNode";
            txtEndNode.Size = new Size(125, 27);
            txtEndNode.TabIndex = 25;
            txtEndNode.TextChanged += txtNode_TextChanged;
            // 
            // txtStartNode
            // 
            txtStartNode.Location = new Point(17, 81);
            txtStartNode.Name = "txtStartNode";
            txtStartNode.Size = new Size(125, 27);
            txtStartNode.TabIndex = 24;
            txtStartNode.TextChanged += txtNode_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(239, 42);
            label7.Name = "label7";
            label7.Size = new Size(131, 20);
            label7.TabIndex = 23;
            label7.Text = "Кінцева вершина";
            label7.Click += label7_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 42);
            label6.Name = "label6";
            label6.Size = new Size(150, 20);
            label6.TabIndex = 22;
            label6.Text = "Початкова вершина";
            label6.Click += label6_Click_1;
            // 
            // btnSaveReport
            // 
            btnSaveReport.Location = new Point(17, 211);
            btnSaveReport.Name = "btnSaveReport";
            btnSaveReport.Size = new Size(111, 29);
            btnSaveReport.TabIndex = 21;
            btnSaveReport.Text = "Зберегти звіт";
            btnSaveReport.UseVisualStyleBackColor = true;
            btnSaveReport.Click += btnSaveReport_Click;
            // 
            // btnClearMatrix_Click
            // 
            btnClearMatrix_Click.Location = new Point(398, 145);
            btnClearMatrix_Click.Name = "btnClearMatrix_Click";
            btnClearMatrix_Click.Size = new Size(166, 29);
            btnClearMatrix_Click.TabIndex = 21;
            btnClearMatrix_Click.Text = "Очистити матрицю";
            btnClearMatrix_Click.UseVisualStyleBackColor = true;
            btnClearMatrix_Click.Visible = false;
            btnClearMatrix_Click.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1524, 1055);
            Controls.Add(btnClearMatrix_Click);
            Controls.Add(pnlPathSearch);
            Controls.Add(pbGraph);
            Controls.Add(pnlEdit);
            Controls.Add(btnEditMode);
            Controls.Add(gridMatrix);
            Controls.Add(pnlResults);
            Controls.Add(label3);
            Controls.Add(cmbInputMethod);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCreateMatrix);
            Controls.Add(txtVertices);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)gridMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridResult).EndInit();
            pnlResults.ResumeLayout(false);
            pnlResults.PerformLayout();
            pnlEdit.ResumeLayout(false);
            pnlEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbGraph).EndInit();
            pnlPathSearch.ResumeLayout(false);
            pnlPathSearch.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVertices;
        private Button btnCreateMatrix;
        private DataGridView gridMatrix;
        private Label label1;
        private Label label2;
        private ComboBox cmbInputMethod;
        private Label label3;
        private ComboBox cmbAlgorithm;
        private Label lblAlgorithm;
        private Button btnCalculate;
        private DataGridView gridResult;
        private Label lblResultTitle;
        private Panel pnlResults;
        private Button btnEditMode;
        private Panel pnlEdit;
        private Label label4;
        private Label label5;
        private Button btnFinishEditing;
        private PictureBox pbGraph;
        private Button btnFindPath;
        private Label lblPathMessage;
        private Panel pnlPathSearch;
        private Button btnSaveReport;
        private Label label6;
        private Label label7;
        private Button btnClearMatrix_Click;
        private TextBox txtStartNode;
        private TextBox txtEndNode;
        private TextBox txtAddVertex;
        private TextBox txtRemoveVertex;
        private Button btnRemoveVertex;
        private Button btnAddVertex;
    }
}
