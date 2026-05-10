using System;
using System.Drawing;
using System.Windows.Forms;
using Coursework_2;

namespace Курсова_робота
{
    public partial class Form1 : Form
    {
        private Graph myGraph;
        private bool[,] highlightedEdges;
        private int[,] nextMatrix;
        private ShortestPathResult lastResult;

        public Form1()
        {
            InitializeComponent();
            this.gridMatrix.SizeChanged += gridMatrix_SizeChanged;

            lblAlgorithm.Visible = false;
            cmbAlgorithm.Visible = false;
            btnCalculate.Visible = false;

            btnEditMode.Visible = false;
            btnFinishEditing.Visible = false;

            pnlEdit.Visible = false;
            pnlResults.Visible = false;
            pnlEdit.Location = pnlResults.Location;
        }

        private void btnCreateMatrix_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtVertices.Text, out int n) && n >= Const.MIN_VERTICES && n <= Const.MAX_VERTICES)
            {
                if (cmbInputMethod.SelectedIndex != -1)
                {
                    myGraph = new Graph(n);
                    highlightedEdges = new bool[n, n];

                    pnlPathSearch.Visible = false;

                    SetupGrid(n);

                    string selectedMethod = cmbInputMethod.SelectedItem.ToString();
                    if (selectedMethod == "Вручну")
                    {
                        FillMatrixEmpty(n);
                    }
                    else if (selectedMethod == "Рандомно")
                    {
                        myGraph.FillRandom();

                        UpdateGridFromGraph();

                        btnClearMatrix_Click.Visible = true;
                    }

                    gridMatrix.ClearSelection();

                    lblAlgorithm.Visible = true;
                    cmbAlgorithm.Visible = true;
                    btnCalculate.Visible = true;

                    txtAddVertex.Text = (n + 1).ToString();
                    txtAddVertex.Tag = (n + 1).ToString();

                    txtRemoveVertex.Text = n.ToString();
                    txtRemoveVertex.Tag = n.ToString();

                    pnlEdit.Visible = false;
                    pnlResults.Visible = true;

                    gridResult.Visible = false;
                    lblResultTitle.Visible = false;

                    btnEditMode.Visible = true;
                    btnFinishEditing.Visible = false;

                    pbGraph.Invalidate();
                }
                else
                {
                    MessageBox.Show("Оберіть метод заповнення матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show($"Введіть коректну кількість вершин (від {Const.MIN_VERTICES} до {Const.MAX_VERTICES})",
                                "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupGrid(int n)
        {
            gridMatrix.Visible = true;
            gridMatrix.AllowUserToAddRows = false;
            gridMatrix.ColumnCount = n;
            gridMatrix.RowCount = n;
            gridMatrix.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridMatrix.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            gridMatrix.AllowUserToResizeColumns = false;
            gridMatrix.AllowUserToResizeRows = false;

            for (int i = 0; i < n; i++)
            {
                gridMatrix.Columns[i].MinimumWidth = 35;

                gridMatrix.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                gridMatrix.Columns[i].FillWeight = 100;

                gridMatrix.Columns[i].HeaderText = (i + 1).ToString();
                gridMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            UpdateRowHeights();
        }

        private void FillMatrixEmpty(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        gridMatrix.Rows[i].Cells[j].Value = "0";
                        gridMatrix.Rows[i].Cells[j].ReadOnly = true;
                        gridMatrix.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    }
                    else
                    {
                        gridMatrix.Rows[i].Cells[j].Value = "-";
                        gridMatrix.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
        }

        private void UpdateGridFromGraph()
        {
            int[,] matrix = myGraph.GetMatrix();
            int n = myGraph.NumVertices;
            int edgCount = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        gridMatrix.Rows[i].Cells[j].Value = "0";
                        gridMatrix.Rows[i].Cells[j].ReadOnly = true;
                        gridMatrix.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                    }
                    else
                    {
                        if (matrix[i, j] != Const.INF)
                        {
                            gridMatrix.Rows[i].Cells[j].Value = matrix[i, j].ToString();
                            edgCount++;
                        }
                        else
                        {
                            gridMatrix.Rows[i].Cells[j].Value = "-";
                        }
                        gridMatrix.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                    }
                }
            }
            MessageBox.Show($"Згенеровано граф з {edgCount} ребрами", "Рандом");
        }

        private void UpdateRowHeights()
        {
            if (gridMatrix.RowCount > 0)
            {
                int availableHeight = gridMatrix.ClientSize.Height - gridMatrix.ColumnHeadersHeight;
                int n = gridMatrix.RowCount;

                int baseHeight = availableHeight / n;
                int remainder = availableHeight % n;

                if (baseHeight < 25)
                {
                    baseHeight = 25;
                    remainder = 0;
                }

                for (int i = 0; i < n; i++)
                {
                    gridMatrix.Rows[i].Height = baseHeight + (i < remainder ? 1 : 0);
                }
            }
        }

        private void gridMatrix_SizeChanged(object sender, EventArgs e)
        {
            UpdateRowHeights();
            pbGraph?.Invalidate();
        }

        private void txtVertices_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string valStr = txtVertices.Text.Trim();

            if (string.IsNullOrWhiteSpace(valStr))
                return;

            if (int.TryParse(valStr, out int n))
            {
                if (n < Const.MIN_VERTICES || n > Const.MAX_VERTICES)
                {
                    MessageBox.Show($"Число має бути в діапазоні від {Const.MIN_VERTICES} до {Const.MAX_VERTICES}!",
                                    "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                bool isNumber = valStr.All(char.IsDigit) || (valStr.StartsWith("-") && valStr.Substring(1).All(char.IsDigit));

                if (isNumber)
                {
                    MessageBox.Show($"Введене число занадто велике! Кількість вершин має бути від {Const.MIN_VERTICES} до {Const.MAX_VERTICES}!",
                                    "Помилка лімітів", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть коректне ціле число!", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridMatrix_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex == e.ColumnIndex) return;

            string valStr = e.FormattedValue?.ToString()?.Trim();

            if (string.IsNullOrEmpty(valStr))
            {
                gridMatrix.CancelEdit();
                MessageBox.Show("Клітинка не може бути порожньою! Введіть вагу ребра або '-' (якщо зв'язку немає).", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (valStr == "-")
            {
                ClearResults();
                if (pbGraph != null)
                {
                    pbGraph.Invalidate();
                    return;
                }
            }

            if (int.TryParse(valStr, out int weight))
            {
                if (weight < Const.MIN_WEIGHT || weight > Const.MAX_WEIGHT)
                {
                    gridMatrix.CancelEdit();
                    MessageBox.Show($"Вага ребра має бути від {Const.MIN_WEIGHT} до {Const.MAX_WEIGHT}!", "Помилка лімітів", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    ClearResults();
                    if (pbGraph != null)
                    {
                        pbGraph.Invalidate();
                    }
                    btnClearMatrix_Click.Visible = true;
                }
            }
            else
            {
                gridMatrix.CancelEdit();

                bool isNumber = valStr.All(char.IsDigit) || (valStr.StartsWith("-") && valStr.Substring(1).All(char.IsDigit));

                if (isNumber)
                {
                    MessageBox.Show($"Введене число занадто велике! Вага ребра має бути від {Const.MIN_WEIGHT} до {Const.MAX_WEIGHT}!", "Помилка лімітів", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Введіть коректне ціле число або '-'!", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (gridMatrix.RowCount > 0)
            {
                if (cmbAlgorithm.SelectedIndex != -1)
                {
                    Graph graph = CollectGraphFromTable();

                    if (graph != null)
                    {
                        string selectedAlg = cmbAlgorithm.SelectedItem.ToString();
                        IShortestPathAlgorithm algorithm = null;

                        if (selectedAlg == "Алгоритм Флойда-Воршелла")
                        {
                            algorithm = new FloydWarshallMethod();
                        }
                        else if (selectedAlg == "Алгоритм Данцига")
                        {
                            algorithm = new DanzigMethod();
                        }

                        if (algorithm != null)
                        {
                            try
                            {
                                ShortestPathResult result = algorithm.Calculate(graph);

                                myGraph = graph;
                                lastResult = result;

                                if (result.HasNegativeCycle)
                                {
                                    MessageBox.Show("Знайдено контур від'ємної ваги!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    nextMatrix = null;
                                }
                                else
                                {
                                    nextMatrix = result.Next;

                                    int n = graph.NumVertices;
                                    SetupResultGrid(n);

                                    for (int i = 0; i < n; i++)
                                    {
                                        for (int j = 0; j < n; j++)
                                        {
                                            if (i == j)
                                            {
                                                gridResult.Rows[i].Cells[j].Value = "0";
                                                gridResult.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                                            }
                                            else
                                            {
                                                int d = result.Dist[i, j];
                                                if (d >= Const.INF)
                                                {
                                                    gridResult.Rows[i].Cells[j].Value = "-";
                                                }
                                                else
                                                {
                                                    gridResult.Rows[i].Cells[j].Value = d.ToString();
                                                }
                                                gridResult.Rows[i].Cells[j].Style.ForeColor = Color.DarkGreen;
                                            }
                                        }
                                    }
                                    gridResult.ClearSelection();

                                    pnlEdit.Visible = false;
                                    pnlResults.Visible = true;

                                    gridResult.Visible = true;
                                    lblResultTitle.Visible = true;

                                    btnFinishEditing.Visible = false;
                                    btnEditMode.Visible = true;

                                    pnlPathSearch.Visible = true;

                                    txtStartNode.Text = "1";
                                    txtEndNode.Text = n.ToString();

                                    lblPathMessage.Text = "Оберіть вершини та натисніть 'Знайти шлях'";

                                    MessageBox.Show($"Матрицю найкоротших шляхів побудовано!\nКількість ітерацій: {result.Operations}", "Успіх");
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Помилка: {ex.Message}");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Оберіть алгоритм!");
                }
            }
            else
            {
                MessageBox.Show("Спочатку створіть вхідну матрицю!");
            }
        }

        private Graph CollectGraphFromTable()
        {
            int n = gridMatrix.RowCount;
            Graph graph = new Graph(n);
            bool hasError = false;

            for (int i = 0; i < n && !hasError; i++)
            {
                for (int j = 0; j < n && !hasError; j++)
                {
                    if (i != j)
                    {
                        object cellValue = gridMatrix.Rows[i].Cells[j].Value;
                        string valStr = cellValue?.ToString()?.Trim();

                        if (!string.IsNullOrEmpty(valStr) && valStr != "-")
                        {
                            if (int.TryParse(valStr, out int weight))
                            {
                                try
                                {
                                    graph.AddEdge(weight, i, j);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Помилка у клітинці ({i + 1}, {j + 1}): {ex.Message}",
                                                    "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    hasError = true;
                                }
                            }
                            else
                            {
                                MessageBox.Show($"Значення '{valStr}' у клітинці ({i + 1}, {j + 1}) не є коректним числом.",
                                                "Помилка вводу", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                hasError = true;
                            }
                        }
                    }
                }
            }

            if (hasError)
            {
                graph = null;
            }

            return graph;
        }

        private void SetupResultGrid(int n)
        {
            gridResult.Visible = true;
            lblResultTitle.Visible = true;
            gridResult.AllowUserToAddRows = false;
            gridResult.ColumnCount = n;
            gridResult.RowCount = n;
            gridResult.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridResult.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            gridResult.ReadOnly = true;

            for (int i = 0; i < n; i++)
            {
                gridResult.Columns[i].MinimumWidth = 35;
                gridResult.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                gridResult.Columns[i].HeaderText = (i + 1).ToString();
                gridResult.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }

            if (gridResult.RowCount > 0)
            {
                int availableHeight = gridResult.ClientSize.Height - gridResult.ColumnHeadersHeight;
                int rowHeight = availableHeight / n;
                int remainder = availableHeight % n;

                if (rowHeight < 25)
                {
                    rowHeight = 25;
                    remainder = 0;
                }

                for (int i = 0; i < n; i++)
                {
                    if (i < remainder)
                    {
                        gridResult.Rows[i].Height = rowHeight + 1;
                    }
                    else
                    {
                        gridResult.Rows[i].Height = rowHeight;
                    }
                }
            }
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            int n = gridMatrix.RowCount;

            if (n >= Const.MAX_VERTICES)
            {
                MessageBox.Show($"Досягнуто ліміт вершин ({Const.MAX_VERTICES})!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAddVertex.Text))
            {
                MessageBox.Show("Поле позиції не може бути порожнім!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddVertex.Text = (n + 1).ToString();
                return;
            }

            if (int.TryParse(txtAddVertex.Text, out int targetVertex))
            {
                int insertIndex = targetVertex - 1;

                myGraph.AddVertex(insertIndex);
                ClearResults();

                n++;
                txtVertices.Text = n.ToString();

                DataGridViewTextBoxColumn newCol = new DataGridViewTextBoxColumn();
                newCol.MinimumWidth = 35;
                newCol.SortMode = DataGridViewColumnSortMode.NotSortable;
                gridMatrix.Columns.Insert(insertIndex, newCol);
                gridMatrix.Rows.Insert(insertIndex, 1);

                for (int i = 0; i < n; i++)
                {
                    gridMatrix.Columns[i].HeaderText = (i + 1).ToString();
                    gridMatrix.Columns[i].FillWeight = 100;
                    gridMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();

                    if (i == insertIndex)
                    {
                        gridMatrix.Rows[insertIndex].Cells[insertIndex].Value = "0";
                        gridMatrix.Rows[insertIndex].Cells[insertIndex].ReadOnly = true;
                        gridMatrix.Rows[insertIndex].Cells[insertIndex].Style.BackColor = Color.LightGray;
                    }
                    else
                    {
                        gridMatrix.Rows[insertIndex].Cells[i].Value = "-";
                        gridMatrix.Rows[insertIndex].Cells[i].Style.ForeColor = Color.Black;

                        gridMatrix.Rows[i].Cells[insertIndex].Value = "-";
                        gridMatrix.Rows[i].Cells[insertIndex].Style.ForeColor = Color.Black;
                    }
                }

                UpdateRowHeights();
                gridMatrix.ClearSelection();

                txtAddVertex.Text = (n + 1).ToString();
                txtAddVertex.Tag = (n + 1).ToString();
                txtRemoveVertex.Text = n.ToString();
                txtRemoveVertex.Tag = n.ToString();

                pbGraph.Invalidate();
            }
        }

        private void btnRemoveVertex_Click(object sender, EventArgs e)
        {
            int n = gridMatrix.RowCount;

            if (n <= Const.MIN_VERTICES)
            {
                MessageBox.Show($"Досягнуто мінімальної кількості вершин ({Const.MIN_VERTICES})!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRemoveVertex.Text))
            {
                MessageBox.Show("Поле видалення не може бути порожнім!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemoveVertex.Text = n.ToString();
                return;
            }

            if (int.TryParse(txtRemoveVertex.Text, out int targetVertex))
            {
                int removeIndex = targetVertex - 1;

                myGraph.RemoveVertex(removeIndex);
                ClearResults();

                gridMatrix.Columns.RemoveAt(removeIndex);
                gridMatrix.Rows.RemoveAt(removeIndex);

                n--;
                txtVertices.Text = n.ToString();

                for (int i = 0; i < n; i++)
                {
                    gridMatrix.Columns[i].HeaderText = (i + 1).ToString();
                    gridMatrix.Columns[i].FillWeight = 100;
                    gridMatrix.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

                UpdateRowHeights();
                gridMatrix.ClearSelection();

                txtAddVertex.Text = (n + 1).ToString();
                txtAddVertex.Tag = (n + 1).ToString();
                txtRemoveVertex.Text = n.ToString();
                txtRemoveVertex.Tag = n.ToString();

                pbGraph.Invalidate();
            }
        }

        private void btnEditMode_Click(object sender, EventArgs e)
        {
            int n = gridMatrix.RowCount;

            pnlResults.Visible = false;
            pnlEdit.Visible = true;

            btnEditMode.Visible = false;
            btnFinishEditing.Visible = true;
        }

        private void btnFinishEditing_Click(object sender, EventArgs e)
        {
            if (HasAnyEdges())
            {
                btnClearMatrix_Click.Visible = true;
            }
            pnlEdit.Visible = false;
            pnlResults.Visible = true;

            gridResult.Visible = false;
            lblResultTitle.Visible = false;

            btnFinishEditing.Visible = false;
            btnEditMode.Visible = true;
        }

        private void btnFindPath_Click(object sender, EventArgs e)
        {
            int n = gridMatrix.RowCount;

            if (string.IsNullOrWhiteSpace(txtStartNode.Text) || string.IsNullOrWhiteSpace(txtEndNode.Text))
            {
                MessageBox.Show("Поля не можуть бути порожніми! Введіть номери вершин.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtStartNode.Text, out int startNodeVal) || !int.TryParse(txtEndNode.Text, out int endNodeVal))
                return;

            if (n > 0 && nextMatrix != null)
            {
                int start = startNodeVal - 1;
                int end = endNodeVal - 1;

                if (nextMatrix.GetLength(0) != n)
                {
                    MessageBox.Show("Поточний алгоритм не підтримує відновлення шляху.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                highlightedEdges = new bool[n, n];
                string dVal = gridResult.Rows[start].Cells[end].Value?.ToString();

                if (dVal == "-" || string.IsNullOrEmpty(dVal))
                {
                    lblPathMessage.Text = $"Шляху між {start + 1} та {end + 1} не існує.";
                }
                else if (start == end)
                {
                    lblPathMessage.Text = "Ви вже у цій вершині. Відстань: 0.";
                }
                else
                {
                    int curr = start;
                    string pathStr = (start + 1).ToString();
                    int safetyLimit = 0;

                    while (curr != end && safetyLimit < n)
                    {
                        int next = nextMatrix[curr, end];
                        if (next != -1)
                        {
                            highlightedEdges[curr, next] = true;
                            curr = next;
                            pathStr += " -> " + (curr + 1).ToString();
                        }
                        else { safetyLimit = n; }
                        safetyLimit++;
                    }
                    lblPathMessage.Text = $"Знайдений шлях: {pathStr} (Довжина: {dVal})";
                }
                pbGraph.Invalidate();
            }
            else
            {
                MessageBox.Show("Спочатку створіть матрицю найкоротших шляхів!", "Увага");
            }
        }

        private void btnSaveReport_Click(object sender, EventArgs e)
        {
            if (myGraph != null && lastResult != null)
            {
                string selectedAlg;

                if (cmbAlgorithm.SelectedItem != null)
                {
                    selectedAlg = cmbAlgorithm.SelectedItem.ToString();
                }
                else
                {
                    selectedAlg = "Невідомий алгоритм";
                }

                FileService.SaveResultsToFile(myGraph, lastResult, selectedAlg);
            }
            else
            {
                MessageBox.Show("Спочатку розрахуйте матрицю найкоротших шляхів!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbGraph_Paint(object sender, PaintEventArgs e)
        {
            int n = gridMatrix.RowCount;

            if (n > 0)
            {
                Graphics g = e.Graphics;

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int width = pbGraph.Width;
                int height = pbGraph.Height;
                float centerX = width / 2f;
                float centerY = height / 2f;

                float radius = Math.Min(width, height) / 2f - 40;
                int nodeRadius = 16;

                PointF[] points = new PointF[n];

                for (int i = 0; i < n; i++)
                {
                    double angle = 2 * Math.PI * i / n - Math.PI / 2;
                    float x = centerX + (float)(radius * Math.Cos(angle));
                    float y = centerY + (float)(radius * Math.Sin(angle));
                    points[i] = new PointF(x, y);
                }

                Font nodeFont = new Font("Arial", 10, FontStyle.Bold);
                Font weightFont = new Font("Arial", 9, FontStyle.Regular);
                Font highlightWeightFont = new Font("Arial", 10, FontStyle.Bold);

                using (Pen normalPen = new Pen(Color.DarkGray, 2))
                using (Pen highlightPen = new Pen(Color.Red, 4))
                {
                    normalPen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);
                    highlightPen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(6, 6);

                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (i != j)
                            {
                                object cellObj = gridMatrix.Rows[i].Cells[j].Value;
                                string valStr = cellObj?.ToString()?.Trim();

                                if (!string.IsNullOrEmpty(valStr) && valStr != "-")
                                {
                                    if (int.TryParse(valStr, out int weight))
                                    {
                                        float dx = points[j].X - points[i].X;
                                        float dy = points[j].Y - points[i].Y;
                                        float dist = (float)Math.Sqrt(dx * dx + dy * dy);

                                        if (dist > 0)
                                        {

                                            float startX = points[i].X + (dx / dist) * nodeRadius;
                                            float startY = points[i].Y + (dy / dist) * nodeRadius;
                                            float endX = points[j].X - (dx / dist) * nodeRadius;
                                            float endY = points[j].Y - (dy / dist) * nodeRadius;

                                            float midX = startX + (endX - startX) * 0.75f;
                                            float midY = startY + (endY - startY) * 0.75f;

                                            float normalX = -dy / dist;
                                            float normalY = dx / dist;

                                            float textOffsetX = midX + normalX * 15;
                                            float textOffsetY = midY + normalY * 15;

                                            string weightStr = weight.ToString();
                                            SizeF textSize = g.MeasureString(weightStr, weightFont);

                                            if (highlightedEdges != null && highlightedEdges[i, j])
                                            {
                                                g.DrawLine(highlightPen, startX, startY, endX, endY);
                                                g.DrawString(weightStr, highlightWeightFont, Brushes.DarkRed, textOffsetX - textSize.Width / 2, textOffsetY - textSize.Height / 2);
                                            }
                                            else
                                            {
                                                g.DrawLine(normalPen, startX, startY, endX, endY);
                                                g.DrawString(weightStr, weightFont, Brushes.Black, textOffsetX - textSize.Width / 2, textOffsetY - textSize.Height / 2);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < n; i++)
                {
                    g.FillEllipse(Brushes.LightCyan, points[i].X - nodeRadius, points[i].Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);
                    g.DrawEllipse(Pens.Black, points[i].X - nodeRadius, points[i].Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);

                    string nodeText = (i + 1).ToString();
                    SizeF textSize = g.MeasureString(nodeText, nodeFont);
                    g.DrawString(nodeText, nodeFont, Brushes.Black, points[i].X - textSize.Width / 2, points[i].Y - textSize.Height / 2);
                }
            }
        }

        private void ClearResults()
        {
            nextMatrix = null;
            highlightedEdges = null;
            lastResult = null;

            pnlPathSearch.Visible = false;
            gridResult.Visible = false;
            lblResultTitle.Visible = false;

            if (pbGraph != null)
            {
                pbGraph.Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = gridMatrix.RowCount;
            if (n != 0)
            {

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j)
                        {
                            gridMatrix.Rows[i].Cells[j].Value = "0";
                        }
                        else
                        {
                            gridMatrix.Rows[i].Cells[j].Value = "-";
                            gridMatrix.Rows[i].Cells[j].Style.ForeColor = Color.Black;
                        }
                    }
                }

                btnClearMatrix_Click.Visible = false;
                ClearResults();
            }
        }

        private bool HasAnyEdges()
        {
            int n = gridMatrix.RowCount;

            if (n == 0) return false;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    {
                        string valStr = gridMatrix.Rows[i].Cells[j].Value?.ToString()?.Trim();
                        if (!string.IsNullOrEmpty(valStr) && valStr != "-")
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void txtAddVertex_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text)) return;

            int n = gridMatrix.RowCount;
            if (n == 0) return;

            if (!int.TryParse(txt.Text, out int val))
            {
                MessageBox.Show("Введіть коректне ціле число! Літери заборонені.", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txt.Tag != null) txt.Text = txt.Tag.ToString();
                else txt.Text = (n + 1).ToString();
                txt.SelectionStart = txt.Text.Length;
                return;
            }

            if (val < 1 || val > n + 1)
            {
                MessageBox.Show($"Позиція має бути від 1 до {n + 1}!", "Помилка лімітів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txt.Tag != null) txt.Text = txt.Tag.ToString();
                else txt.Text = (n + 1).ToString();
                txt.SelectionStart = txt.Text.Length;
                return;
            }

            txt.Tag = txt.Text;
        }

        private void txtRemoveVertex_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text)) return;

            int n = gridMatrix.RowCount;
            if (n == 0) return;

            if (!int.TryParse(txt.Text, out int val))
            {
                MessageBox.Show("Введіть коректне ціле число! Літери заборонені.", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txt.Tag != null) txt.Text = txt.Tag.ToString();
                else txt.Text = n.ToString();
                txt.SelectionStart = txt.Text.Length;
                return;
            }

            if (val < 1 || val > n)
            {
                MessageBox.Show($"Вершини з таким номером не існує! Введіть від 1 до {n}.", "Помилка лімітів", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (txt.Tag != null) txt.Text = txt.Tag.ToString();
                else txt.Text = n.ToString();
                txt.SelectionStart = txt.Text.Length;
                return;
            }

            txt.Tag = txt.Text;
        }

        private void txtNode_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (string.IsNullOrWhiteSpace(txt.Text)) 
                return;

            int n = gridMatrix.RowCount;

            if (!int.TryParse(txt.Text, out int val))
            {
                MessageBox.Show("Введіть коректні цілі числа! Літери та символи заборонені.", "Помилка формату", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txt.Tag != null)
                {
                    txt.Text = txt.Tag.ToString();
                }
                else
                {
                    txt.Text = "1";
                }

                txt.SelectionStart = txt.Text.Length;
                return;
            }

            if (val < 1 || val > n)
            {
                MessageBox.Show($"Вершини з таким номером не існує! Будь ласка, введіть число від 1 до {n}.", "Помилка лімітів", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (txt.Tag != null)
                {
                    txt.Text = txt.Tag.ToString();
                }
                else
                {
                    txt.Text = "1";
                }

                txt.SelectionStart = txt.Text.Length;
                return;
            }

            txt.Tag = txt.Text;
        }

        private void label6_Click(object sender, EventArgs e) { }
        private void pnlEdit_Paint(object sender, PaintEventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void txtVertices_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Form1_Load(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }

        private void label6_Click_1(object sender, EventArgs e) { }

        private void label7_Click(object sender, EventArgs e) { }

        private void cmbAlgorithm_SelectedIndexChanged(object sender, EventArgs e) { }

        private void numStartNode_ValueChanged(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void pnlPathSearch_Paint(object sender, PaintEventArgs e) { }
    }
}