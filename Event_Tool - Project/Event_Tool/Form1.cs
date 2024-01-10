using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Event_Tool {

    public partial class Form1 : Form {
        public JObject rss;
        string album;
        JArray A1;
        JArray A2;
        JArray B;
        string nowSelected;
        JToken nowEditing;
        public int nowIndex;
        public string nowType;
        NumericUpDown[] results1;
        NumericUpDown[] results2;
        NumericUpDown[] results3;
        NumericUpDown[] results4;
        CheckBox[] checks1;
        CheckBox[] checks2;
        CheckBox[] checks3;
        CheckBox[] checks4;

        FolderBrowserDialog albumDialog;
        public Form1() {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            results1 = new NumericUpDown[]{ budgetNum1, politicNum1, stabilNum1, radicalNum1, armyNum1, globalNum1, eastNum1, westNum1, peopleNum1, militaryNum1, cultNum1 };
            results2 = new NumericUpDown[]{ budgetNum2, politicNum2, stabilNum2, radicalNum2, armyNum2, globalNum2, eastNum2, westNum2, peopleNum2, militaryNum2, cultNum2 };
            results3 = new NumericUpDown[]{ budgetNum3, politicNum3, stabilNum3, radicalNum3, armyNum3, globalNum3, eastNum3, westNum3, peopleNum3, militaryNum3, cultNum3 };
            results4 = new NumericUpDown[]{ budgetNum4, politicNum4, stabilNum4, radicalNum4, armyNum4, globalNum4, eastNum4, westNum4, peopleNum4, militaryNum4, cultNum4 };

            checks1 = new CheckBox[] { budget1, politic1, stabil1, radical1, army1, global1, east1, west1, people1, military1, cult1 };
            checks2 = new CheckBox[] { budget2, politic2, stabil2, radical2, army2, global2, east2, west2, people2, military2, cult2 };
            checks3 = new CheckBox[] { budget3, politic3, stabil3, radical3, army3, global3, east3, west3, people3, military3, cult3 };
            checks4 = new CheckBox[] { budget4, politic4, stabil4, radical4, army4, global4, east4, west4, people4, military4, cult4 };
        }

        private void saveFile() {
            var finalJson = JsonConvert.SerializeObject(rss, Formatting.Indented);
            System.IO.File.WriteAllText(fileDialog.FileName, finalJson);
        }

        private void getJson(){
            string jsonFile;
            Console.WriteLine(fileDialog.FileName);
            using (var reader = new StreamReader(fileDialog.FileName)) {
                jsonFile = reader.ReadToEnd();
            }
            rss = JObject.Parse(jsonFile);
            A1 = (JArray)rss["A1"];
            A2 = (JArray)rss["A2"];
            B = (JArray)rss["B"];
        }

        private void findEvents(JArray array) {
            for (int i = 0; i < array.Count; i++) {
                if (((string)array[i]["h1"]).IndexOf(searchText.Text, StringComparison.OrdinalIgnoreCase) >= 0)
                    treeView1.Nodes.Add((string)array[i]["h1"]);
            }
        }

        private void getEvents(JArray array) {
            for (int i = 0; i < array.Count; i++) {
                if (((string)array[i]["h1"]) == nowSelected) {
                    nowEditing = array[i];
                    nowIndex = i;
                    if(array == A1) nowType = "A1";
                    else if (array == A2) nowType = "A2";
                    else if (array == B) nowType = "B";
                }
            }
        }

        private void listEvents() {
            treeView1.Nodes.Clear();

            if(searchCombo.Text == "Hepsi") {
                findEvents(A1);
                findEvents(A2);
                findEvents(B);
            } else {
                if(searchCombo.Text == "A1") findEvents(A1);
                else if(searchCombo.Text == "A2") findEvents(A2);
                else if (searchCombo.Text == "B") findEvents(B);
            }
        }

        private void showProperties() {
            typeCombo.Text = nowType;
            titleText.Text = (string)nowEditing["h1"];
            imageBox.Tag = (string)nowEditing["pic"];
            descText.Text = (string)nowEditing["explanation"];
            choiceText.Text = (string)nowEditing["choice1"];
            choiceText2.Text = (string)nowEditing["choice2"];
            choiceText3.Text = (string)nowEditing["choice3"];
            choiceText4.Text = (string)nowEditing["choice4"];

            if (album != null && (string)nowEditing["pic"] != "") imageBox.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), album + "\\" + (string)(nowEditing["pic"])));
            else imageBox.Image = null;

            for (int i = 0; i < results1.Length; i++) {
                results1[i].Value = (int)nowEditing["choice1results"][0][i];
                results2[i].Value = (int)nowEditing["choice2results"][0][i];
                results3[i].Value = (int)nowEditing["choice3results"][0][i];
                results4[i].Value = (int)nowEditing["choice4results"][0][i];

                checks1[i].Checked = (bool)nowEditing["choice1results"][1][i];
                checks2[i].Checked = (bool)nowEditing["choice2results"][1][i];
                checks3[i].Checked = (bool)nowEditing["choice3results"][1][i];
                checks4[i].Checked = (bool)nowEditing["choice4results"][1][i];
            }
        }

        public void saveProperties() {
            rss[nowType][nowIndex]["h1"] = titleText.Text;
            rss[nowType][nowIndex]["pic"] = imageBox.Tag.ToString();
            rss[nowType][nowIndex]["explanation"] = descText.Text;
            rss[nowType][nowIndex]["choice1"] = choiceText.Text;
            rss[nowType][nowIndex]["choice2"] = choiceText2.Text;
            rss[nowType][nowIndex]["choice3"] = choiceText3.Text;
            rss[nowType][nowIndex]["choice4"] = choiceText4.Text;

            for (int i = 0; i < results1.Length; i++) {
                rss[nowType][nowIndex]["choice1results"][0][i] = (int)results1[i].Value;
                rss[nowType][nowIndex]["choice2results"][0][i] = (int)results2[i].Value;
                rss[nowType][nowIndex]["choice3results"][0][i] = (int)results3[i].Value;
                rss[nowType][nowIndex]["choice4results"][0][i] = (int)results4[i].Value;

                rss[nowType][nowIndex]["choice1results"][1][i] = checks1[i].Checked;
                rss[nowType][nowIndex]["choice2results"][1][i] = checks2[i].Checked;
                rss[nowType][nowIndex]["choice3results"][1][i] = checks3[i].Checked;
                rss[nowType][nowIndex]["choice4results"][1][i] = checks4[i].Checked;
            }

            saveFile();
        }

        private void createEvent() {
            JObject newEvent = new JObject {
                new JProperty("h1", (string)searchText.Text),
                new JProperty("pic", ""),
                new JProperty("explanation", ""),
                new JProperty("choice1", ""),
                new JProperty("choice2", ""),
                new JProperty("choice3", ""),
                new JProperty("choice4", ""),
                new JProperty("conditions",
                    new JArray(
                        new JArray(-1, "", 0),
                        new JArray(-1, "", 0),
                        new JArray(-1, "", 0),
                        new JArray(-1, "", 0)
                    )
                ),
                new JProperty("choice1results",
                    new JArray(
                        new JArray(0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                        new JArray(true, true, true, true, true, true, true, true, true, true),
                        new JArray("", 0, 0)
                    )
                ),
                new JProperty("choice2results",
                    new JArray(
                        new JArray(0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                        new JArray(true, true, true, true, true, true, true, true, true, true),
                        new JArray("", 0, 0)
                    )
                ),
                new JProperty("choice3results",
                    new JArray(
                        new JArray(0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                        new JArray(true, true, true, true, true, true, true, true, true, true),
                        new JArray("", 0, 0)
                    )
                ),
                new JProperty("choice4results",
                    new JArray(
                        new JArray(0, 0, 0, 0, 0, 0, 0, 0, 0, 0),
                        new JArray(true, true, true, true, true, true, true, true, true, true),
                        new JArray("", 0, 0)
                    )
                )
            };

            if(searchCombo.Text != "Hepsi") {
                ((JArray)rss[searchCombo.Text]).Add(newEvent);

                saveFile();

                nowType = searchCombo.Text;
                switch (nowType) {
                    case "A1": nowIndex = A1.Count - 1; break;
                    case "A2": nowIndex = A2.Count - 1; break;
                    case "B": nowIndex = B.Count - 1; break;}
                nowEditing = rss[nowType][nowIndex];

                listEvents();
                showProperties();
            }
        }

        private void deleteEvent() {
            rss[nowType][nowIndex].Remove();

            nowType = "";
            nowIndex = 0;
            nowEditing = null;

            typeCombo.Text = titleText.Text = descText.Text = choiceText.Text = choiceText2.Text = choiceText3.Text = choiceText4.Text = ""; 
            imageBox.Tag = imageBox.Image = null;

            saveFile();
            listEvents();
        }

        private void setTrigger(int i) {
            Trigger a = new Trigger(i, rss, this);
            a.Show();
        }

        // Component Events

        private void searchText_TextChanged(object sender, EventArgs e) {
            listEvents();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            nowSelected = treeView1.SelectedNode.Text;

            getEvents(A1);
            getEvents(A2);
            getEvents(B);

            showProperties();
        }

        private void buttonSave_Click(object sender, EventArgs e) {
            saveProperties();
            listEvents();
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            showProperties();
        }

        private void searchCombo_SelectedIndexChanged(object sender, EventArgs e) {
            listEvents();
        }

        private void fileButton_Click(object sender, EventArgs e) {
            fileDialog.ShowDialog();
        }

        private void fileDialog_FileOk(object sender, CancelEventArgs e) {
            getJson();
            searchCombo.Text = "Hepsi";
            fileButton.ForeColor = Color.Green;
            buttonSave.Enabled = true;
            buttonReset.Enabled = true;
            buttonDelete.Enabled = true;
            buttonAdd.Enabled = true;
            searchCombo.Enabled = true;
            resultButton1.Enabled = true;
            resultButton2.Enabled = true;
            resultButton3.Enabled = true;
            resultButton4.Enabled = true;
            conditionsButoon.Enabled = true;
            listEvents();
        }

        private void imageButton_Click(object sender, EventArgs e) {
            if(album != null) imageDialog.ShowDialog();
        }

        private void imageDialog_FileOk(object sender, CancelEventArgs e) {
            imageBox.Image = Image.FromFile(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),imageDialog.FileName));
            imageBox.Tag = Path.GetFileName(imageDialog.FileName);
        }

        private void albumButton_Click(object sender, EventArgs e) {
            albumDialog = new FolderBrowserDialog();
            DialogResult result = albumDialog.ShowDialog();
            if (result == DialogResult.OK) {
                album = albumDialog.SelectedPath;
                albumButton.ForeColor = Color.Green;
                imageDialog.InitialDirectory = album;
                if(nowEditing != null) showProperties();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            deleteEvent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            createEvent();
        }

        private void conditionsButoon_Click(object sender, EventArgs e) {
            Conditions a = new Conditions(rss, nowType, nowIndex, this);
            a.Show();
        }

        private void resultButton1_Click(object sender, EventArgs e) {
            setTrigger(1);
        }

        private void resultButton2_Click(object sender, EventArgs e) {
            setTrigger(2);
        }

        private void resultButton3_Click(object sender, EventArgs e) {
            setTrigger(3);
        }

        private void resultButton4_Click(object sender, EventArgs e) {
            setTrigger(4);
        }
    }
}
