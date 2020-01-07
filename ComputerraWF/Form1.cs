using ComputerraLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerraWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            placeholderButton.Hide();
            placeholderPictureBox.Hide();
        }

        private List<Button> buttons = new List<Button>();
        private List<PictureBox> colorBoxes = new List<PictureBox>();
        private Dictionary<Type, Color> _colorToClassBinding = new Dictionary<Type, Color>();
        private Thread _backgroundThread;

        private void Form1_Load(object sender, EventArgs e)
        {
            var objectsTypes = Assembly.GetAssembly(typeof(GameObject)).GetTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(GameObject))).ToList();
            //Просто чтобы у объектов были разные цвета
            Random r = new Random();

            for (int i = 0; i < objectsTypes.Count(); ++i)
            {
                buttons.Add(new Button() {
                    Text = objectsTypes[i].Name,
                    Tag = objectsTypes[i],
                    Location = new System.Drawing.Point(placeholderButton.Location.X, placeholderButton.Location.Y + i * placeholderButton.Height),
                    Size = placeholderButton.Size,
                    Parent = groupBox1
                });
                colorBoxes.Add(new PictureBox() {
                    Tag = objectsTypes[i],
                    Location = new System.Drawing.Point(placeholderPictureBox.Location.X, placeholderPictureBox.Location.Y + i * (placeholderPictureBox.Height + 2)),
                    Size = placeholderPictureBox.Size,
                    Parent = groupBox1
                });

                //Для решения замыкания
                int index = i;
                colorBoxes[i].BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                
                buttons[i].Click += (_s, _e) => {
                    if (colorDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    colorBoxes[index].BackColor = colorDialog1.Color;
                };
                colorBoxes[i].Show();
                buttons[i].Show();
            }
            board = new Board(20, 20);
            GameObject.SetLogger((m, t) => {
                if (((MessageType.ObjectLog | MessageType.Placing)).HasFlag(t))
                    if (listBox1.InvokeRequired)
                        listBox1.Invoke((Action)(() => listBox1.Items.Add(m)));
                    else
                        listBox1.Items.Add(m);
            });
            board.FieldUpdated += pictureBox1.Invalidate;

            List<Worker> workers = new List<Worker>();
            int workersCount = 8;
            for (int i = 0; i < workersCount; ++i)
                workers.Add(board.GenerateObject<Worker>());
            board.GenerateObject<Customer>();


            _backgroundThread = new Thread(() => { board.Run(1000, 32); GameObject.Logger("Finished simulation", MessageType.ObjectLog); });
            _backgroundThread.Start();
             //board.Run(20, 32);

        }
        Board board;

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float boxDim = (pictureBox1.Width-1) * 1.0f / board.Rows;
            Graphics g = e.Graphics;
            if (board is null)
                return;
            for (int i = 0; i < board.Rows; ++i)
                for (int j = 0; j < board.Cols; ++j)
                {
                    if (board.Field[i, j] != null)
                        g.FillRectangle(new SolidBrush(colorBoxes.Find(w => (Type)w.Tag == board.Field[i, j].GetType()).BackColor), i * boxDim, j * boxDim, boxDim, boxDim);
                    g.DrawLine(Pens.Black, i * boxDim, j * boxDim, i * boxDim, (j + 1) * boxDim);
                    g.DrawLine(Pens.Black, i * boxDim, j * boxDim, (i + 1) * boxDim, j * boxDim);
                    g.DrawLine(Pens.Black, i * boxDim, (j + 1) * boxDim, (i + 1) * boxDim, (j + 1) * boxDim);
                    g.DrawLine(Pens.Black, (i + 1) * boxDim, j * boxDim, (i + 1) * boxDim, (j + 1) * boxDim);
                    
                }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            board.ExitThread = true;
        }
    }
}
