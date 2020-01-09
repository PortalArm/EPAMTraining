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
        private Thread _backgroundThread;
        private Board _board;

        private void InitializeColorChangeButtons()
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

                colorBoxes[i].BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));

                //Для решения замыкания
                int index = i;
                buttons[i].Click += (_s, _e) => {
                    if (colorDialog1.ShowDialog() != DialogResult.OK)
                        return;

                    colorBoxes[index].BackColor = colorDialog1.Color;
                };
                colorBoxes[i].Show();
                buttons[i].Show();
            }
        }

        private void InitializeBoard(int rows, int cols)
        {
            _board = new Board(rows, cols);
            GameObject.SetLogger(ProcessMessage);
            _board.FieldUpdated += pictureBox1.Invalidate;

        }

        private void AddObjects(int nullObjects = 0, int traps = 0, int works = 0, int bigbosses = 0, int bosses = 0, int customers = 0, int workers = 0)
        {
            for (int i = 0; i < nullObjects; ++i)
                _board.GenerateObject<NullObject>();

            for (int i = 0; i < traps; ++i)
                _board.GenerateObject<Trap>();

            for (int i = 0; i < works; ++i)
                _board.GenerateObject<Work>();

            for (int i = 0; i < bigbosses; ++i)
                _board.GenerateObject<BigBoss>();

            for (int i = 0; i < bosses; ++i)
                _board.GenerateObject<Boss>();

            for (int i = 0; i < customers; ++i)
                _board.GenerateObject<Customer>();

            for (int i = 0; i < workers; ++i)
                _board.GenerateObject<Worker>();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeColorChangeButtons();
            InitializeBoard(20, 20);
            AddObjects(nullObjects: 4, traps: 16, workers: 8, customers: 2);

            _backgroundThread = new Thread(() => { _board.Run(1000, 32); });
            _backgroundThread.Start();
        }

        private void ProcessMessage(string message, MessageType type)
        {
            if (type.HasFlag(MessageType.SimulationInfo))
                message = message.PadLeft(32).PadRight(64);//new string(m.Prepend('-').Append('-').ToArray());

            if (((MessageType.Managing | MessageType.Working | MessageType.Talking | MessageType.SimulationInfo | MessageType.InteractingWithTrap | MessageType.Placing)).HasFlag(type))
                if (listBox1.InvokeRequired)
                    listBox1.Invoke((Action)(() => listBox1.Items.Add(message)));
                else
                    listBox1.Items.Add(message);
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            float boxDim = (pictureBox1.Width - 1) * 1.0f / _board.Rows;
            Graphics g = e.Graphics;
            if (_board is null)
                return;
            for (int i = 0; i < _board.Rows; ++i)
                for (int j = 0; j < _board.Cols; ++j)
                {
                    if (_board.Field[i, j] != null)
                        g.FillRectangle(new SolidBrush(colorBoxes.Find(w => (Type)w.Tag == _board.Field[i, j].GetType()).BackColor), i * boxDim, j * boxDim, boxDim, boxDim);
                    g.DrawLine(Pens.Black, i * boxDim, j * boxDim, i * boxDim, (j + 1) * boxDim);
                    g.DrawLine(Pens.Black, i * boxDim, j * boxDim, (i + 1) * boxDim, j * boxDim);
                    g.DrawLine(Pens.Black, i * boxDim, (j + 1) * boxDim, (i + 1) * boxDim, (j + 1) * boxDim);
                    g.DrawLine(Pens.Black, (i + 1) * boxDim, j * boxDim, (i + 1) * boxDim, (j + 1) * boxDim);
                }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _board.ExitThread = true;
        }
    }
}
