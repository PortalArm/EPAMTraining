using ComputerraLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerraWF
{
    public partial class SetupForm : Form
    {
        public int[] OutputParameters { get; private set; }
        public SetupForm()
        {
            InitializeComponent();
            placeholderLabel.Hide();
            PlaceholderBox.Hide();
            CreateControlsDynamically();
        }
        TextBox[] inputBoxes;
        Label[] labels;
        private void CreateControlsDynamically()
        {
            var objectsTypes = Assembly.GetAssembly(typeof(GameObject)).GetTypes().Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(GameObject))).ToList();

            inputBoxes = new TextBox[objectsTypes.Count];
            labels = new Label[objectsTypes.Count];
            for (int i = 0; i < objectsTypes.Count; ++i)
            {
                inputBoxes[i] = new TextBox() {
                    Location = new System.Drawing.Point(PlaceholderBox.Location.X, PlaceholderBox.Location.Y + i * (PlaceholderBox.Height + 1)),
                    Size = PlaceholderBox.Size,
                    Anchor = AnchorStyles.Right | AnchorStyles.Top,
                    Parent = this,
                    Tag = objectsTypes[i],
                    Text = "0"
                };
                inputBoxes[i].Show();

                labels[i] = new Label() {
                    Location = new System.Drawing.Point(placeholderLabel.Location.X, placeholderLabel.Location.Y + i * (placeholderLabel.Height + 8)),
                    AutoSize = true,
                    Parent = this,
                    Text = $"Кол-во объектов {objectsTypes[i].Name}:"
                };
                labels[i].Show();
            }

            var lastBox = inputBoxes.Last();
            startButton.Location = new System.Drawing.Point(startButton.Location.X, lastBox.Location.Y + lastBox.Height + 5);
            AutoSize = true;


            //Начальные значения
            GetTextBoxByType(typeof(Work)).Text = "6";
            GetTextBoxByType(typeof(Worker)).Text = "12";
            GetTextBoxByType(typeof(Customer)).Text = "2";
            GetTextBoxByType(typeof(Boss)).Text = "1";
            GetTextBoxByType(typeof(Trap)).Text = "1";

        }

        private TextBox GetTextBoxByType(Type type) => inputBoxes.First(w => (Type)w.Tag == type);
        private void startButton_Click(object sender, EventArgs e)
        {
            int rows = Convert.ToInt32(RowsBox.Text),
                cols = Convert.ToInt32(ColsBox.Text),
                tickdur = Convert.ToInt32(TickDurationBox.Text),
                tickcount = Convert.ToInt32(TickCountBox.Text);
            int nullobj = Convert.ToInt32(GetTextBoxByType(typeof(NullObject)).Text),
                trap = Convert.ToInt32(GetTextBoxByType(typeof(Trap)).Text),
                work = Convert.ToInt32(GetTextBoxByType(typeof(Work)).Text),
             bigboss = Convert.ToInt32(GetTextBoxByType(typeof(BigBoss)).Text),
                boss = Convert.ToInt32(GetTextBoxByType(typeof(Boss)).Text),
            customer = Convert.ToInt32(GetTextBoxByType(typeof(Customer)).Text),
              worker = Convert.ToInt32(GetTextBoxByType(typeof(Worker)).Text);

            OutputParameters = new[] { rows, cols, tickdur, tickcount, nullobj, trap, work, bigboss, boss, customer, worker };
            DialogResult = DialogResult.OK;
            Hide();

        }
    }
}
