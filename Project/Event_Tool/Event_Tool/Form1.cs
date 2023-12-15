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
        JObject rss;
        string album;
        JArray A1;
        JArray A2;
        JArray B;
        string nowSelected;
        JToken nowEditing;
        int nowIndex;
        string nowType;
        NumericUpDown[] results1;
        NumericUpDown[] results2;
        NumericUpDown[] results3;
        NumericUpDown[] results4;

        FolderBrowserDialog albumDialog;
        public Form1() {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            results1 = new NumericUpDown[]{ budgetNum1, politicNum1, stabilNum1, radicalNum1, armyNum1, globalNum1, eastNum1, westNum1, militaryNum1, cultNum1 };
            results2 = new NumericUpDown[]{ budgetNum2, politicNum2, stabilNum2, radicalNum2, armyNum2, globalNum2, eastNum2, westNum2, militaryNum2, cultNum2 };
            results3 = new NumericUpDown[]{ budgetNum3, politicNum3, stabilNum3, radicalNum3, armyNum3, globalNum3, eastNum3, westNum3, militaryNum3, cultNum3 };
            results4 = new NumericUpDown[]{ budgetNum4, politicNum4, stabilNum4, radicalNum4, armyNum4, globalNum4, eastNum4, westNum4, militaryNum4, cultNum4 };

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

        public void listEvents() {
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

        //Seçenek sonuçlarının ayrı objeler yapmak yerine 2 liste halinde yapmayı düşünüyorum, listedeki sıralama türü belirtir, 1. liste sayılar, 2. liste true-false

        //private void showResults(int x, NumericUpDown[] array) {
        //    if (rss[nowType][nowEditing]["choice" + x.ToString() + "results"] != null) {
        //        for (int i = 0; i < array.Length; i++) {
        //            array[i].Value = (int)rss[nowType][nowEditing]["choice" + x.ToString() + "results"][i];
        //        }
        //    }
        //}

        public void showProperties() {
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
        }

        public void saveProperties() {
            rss[nowType][nowIndex]["h1"] = titleText.Text;
            rss[nowType][nowIndex]["pic"] = imageBox.Tag.ToString();
            rss[nowType][nowIndex]["explanation"] = descText.Text;
            rss[nowType][nowIndex]["choice1"] = choiceText.Text;
            rss[nowType][nowIndex]["choice2"] = choiceText2.Text;
            rss[nowType][nowIndex]["choice3"] = choiceText3.Text;
            rss[nowType][nowIndex]["choice4"] = choiceText4.Text;

            saveFile();
        }

        public void createEvent() {
            JObject newEvent = new JObject {
                { "h1", (string)searchText.Text },
                { "pic", "" }
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
                saveProperties();
            }
        }

        public void deleteEvent() {
            rss[nowType][nowIndex].Remove();

            nowType = "";
            nowIndex = 0;
            nowEditing = null;

            typeCombo.Text = titleText.Text = descText.Text = choiceText.Text = choiceText2.Text = choiceText3.Text = choiceText4.Text = ""; 
            imageBox.Tag = imageBox.Image = null;

            saveFile();
            listEvents();
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
    }
}
