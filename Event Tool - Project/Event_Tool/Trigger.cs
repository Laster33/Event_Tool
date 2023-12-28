using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Event_Tool {
    public partial class Trigger : Form {
        JObject rss;
        int index;
        Form1 form;
        int nowIndex;
        string nowType;
        public Trigger(int i, JObject r,Form1 a) {
            InitializeComponent();
            index = i; form = a;
            nowIndex = form.nowIndex; nowType = form.nowType;
            rss = r;
            addCombo();
            showTrigger();
        }

        private void showTrigger() {
            eventCombo.Text = (string)rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][0];
            minNum.Value = (int)rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][1];
            maxNum.Value = (int)rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][2];
        }

        private void addCombo() {
            for(int i = 0; i < form.rss["A1"].Count() ; i++) {
                eventCombo.Items.Add(form.rss["A1"][i]["h1"]);
            }
            for (int i = 0; i < form.rss["A2"].Count(); i++) {
                eventCombo.Items.Add(form.rss["A2"][i]["h1"]);
            }
            for (int i = 0; i < form.rss["B"].Count(); i++) {
                eventCombo.Items.Add(form.rss["B"][i]["h1"]);
            }
        }

        private void saveButton_Click(object sender, EventArgs e) {
            rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][0] = eventCombo.Text;
            rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][1] = (int)minNum.Value;
            rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][2] = (int)maxNum.Value;
            form.rss = rss;
            form.saveProperties();
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][0] = "";
            rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][1] = 0;
            rss[nowType][nowIndex]["choice" + index.ToString() + "results"][2][2] = 0;
            form.rss = rss;
            form.saveProperties();
            this.Close();
        }
    }
}
