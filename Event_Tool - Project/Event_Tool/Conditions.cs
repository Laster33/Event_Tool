using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Event_Tool {
    public partial class Conditions : Form {
        JObject rss;
        string nowType;
        int nowIndex;
        ComboBox[] values;
        ComboBox[] conds;
        NumericUpDown[] nums;
        Form1 form;
        string[] words;
        public Conditions(JObject a, string b, int c, Form1 d) {
            InitializeComponent();
            //words = new string[] { "income", "stability", "politicalPower", "radicalism", "army", "globalThreat", "east", "west", "military", "cult" };
            condCombo1.SelectedIndex = condCombo2.SelectedIndex = condCombo3.SelectedIndex = condCombo4.SelectedIndex = 0;
            rss = a; nowType = b; nowIndex = c;
            values = new ComboBox[] { valueCombo1, valueCombo2, valueCombo3, valueCombo4 };
            conds = new ComboBox[] { condCombo1, condCombo2, condCombo3, condCombo4 };
            nums = new NumericUpDown[] { condNum1, condNum2, condNum3, condNum4 };
            form = d;
            showConditions();
        }

        public void showConditions() {
            for (int i = 0; i < values.Length; i++) {
                values[i].SelectedIndex = (int)rss[nowType][nowIndex]["conditions"][i][0];
                conds[i].Text = (string)rss[nowType][nowIndex]["conditions"][i][1];
                nums[i].Value = (int)rss[nowType][nowIndex]["conditions"][i][2];
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            for(int i = 0; i < 4; i++) {
                rss[nowType][nowIndex]["conditions"][i][0] = values[i].SelectedIndex;
                rss[nowType][nowIndex]["conditions"][i][1] = conds[i].Text;
                rss[nowType][nowIndex]["conditions"][i][2] = (int)nums[i].Value;
            }
            form.rss = rss;
            form.saveProperties();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            for (int i = 0; i < 4; i++) {
                rss[nowType][nowIndex]["conditions"][i][0] = -1;
                rss[nowType][nowIndex]["conditions"][i][1] = ">";
                rss[nowType][nowIndex]["conditions"][i][2] = 0;
            }
            form.rss = rss;
            form.saveProperties();
            this.Close();
        }
    }
}
