using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace NieR.Automata.Editor
{
    public partial class Main : Form
    {
        private readonly string _saveDirectory;
        private readonly Regex _nonHexRegex = new Regex("[^A-Fa-f0-9]", RegexOptions.Compiled);

        private string _savePath;
        private readonly Save _save;

        private readonly ComboBox _itemSelectionBox;
        private readonly ComboBox _chipSelectionBox;

        public Main()
        {
            InitializeComponent();

            var myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            _saveDirectory = Path.Combine(myDocumentsPath, "My Games", "NieR_Automata");
            _save = new Save();

            _itemSelectionBox = new ComboBox();
            _itemSelectionBox.Font = inventoryListView.Font;
            _itemSelectionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _itemSelectionBox.Items.AddRange(Item.Items.OrderBy(m => m.Value.Name).Cast<object>().ToArray());
            _itemSelectionBox.DisplayMember = "Value";
            _itemSelectionBox.ValueMember = "Key";
            
            _chipSelectionBox = new ComboBox();
            _chipSelectionBox.Font = chipsListView.Font;
            _chipSelectionBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _chipSelectionBox.Items.AddRange(Chip.Chips.OrderBy(m => m.Value.Name).Cast<object>().ToArray());
            _chipSelectionBox.DisplayMember = "Value";
            _chipSelectionBox.ValueMember = "Key";
        }

        private void Main_Load(object sender, System.EventArgs e)
        {
            if (File.Exists(Path.Combine(_saveDirectory, "SlotData_0.dat")))
                load1ToolStripMenuItem.Enabled = true;
            if (File.Exists(Path.Combine(_saveDirectory, "SlotData_1.dat")))
                load2ToolStripMenuItem.Enabled = true;
            if (File.Exists(Path.Combine(_saveDirectory, "SlotData_2.dat")))
                load3ToolStripMenuItem.Enabled = true;
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://ko-fi.com/C0C01KYIH");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new OpenFileDialog
            {
                Filter = "Save file (*.dat)|*.dat",
                InitialDirectory = _saveDirectory
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                LoadSave(dialog.FileName);
        }

        private void load1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSave(Path.Combine(_saveDirectory, "SlotData_0.dat"));
        }

        private void load2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSave(Path.Combine(_saveDirectory, "SlotData_1.dat"));
        }

        private void load3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSave(Path.Combine(_saveDirectory, "SlotData_2.dat"));
        }

        private void LoadSave(string path)
        {
            var fileInfo = new FileInfo(path);

            if (!fileInfo.Exists)
            {
                MessageBox.Show("The selected file does not exist.", "File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fileInfo.Length != Save.SaveSize)
            {
                MessageBox.Show("The selected file's size does not match the expected value.", "Invalid file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var data = File.ReadAllBytes(path);
            _save.Load(data);
            _savePath = path;

            headerIdBox.Text = new SoapHexBinary(_save.HeaderId).ToString();
            characterNameBox.Text = _save.Name;
            moneyUpDown.Value = _save.Money;
            experienceUpDown.Value = _save.Experience;

            inventoryListView.SetObjects(_save.Inventory);
            corpseInventoryListView.SetObjects(_save.CorpseInventory);
            chipsListView.SetObjects(_save.Chips);
            weaponsListView.SetObjects(_save.Weapons);

            tabControl.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var backupPath = $"{_savePath}.bak";
            var createBackupResponse = MessageBox.Show("Would you like to create a backup before saving?",
                                                       "Create backup?", 
                                                       MessageBoxButtons.YesNoCancel, 
                                                       MessageBoxIcon.Information);
            if (createBackupResponse == DialogResult.Cancel)
                return;
            if (createBackupResponse == DialogResult.Yes)
                File.Copy(_savePath, backupPath, true);

            var data = _save.Write();
            File.WriteAllBytes(_savePath, data);
        }

        private void headerIdBox_TextChanged(object sender, EventArgs e)
        {
            if (_nonHexRegex.IsMatch(headerIdBox.Text))
                headerIdBox.Text = _nonHexRegex.Replace(headerIdBox.Text, string.Empty);
        }

        private void experienceUpDown_ValueChanged(object sender, EventArgs e)
        {
            var level = Experience.GetLevelFromExperience((int)experienceUpDown.Value);
            var nextLevelExp = Experience.GetExperienceToNextLevel((int)experienceUpDown.Value);
            levelLabel.Text = $"{level} (+{nextLevelExp} to next level)";
        }

        private void inventoryListView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            var item = e.RowObject as Item;
            if (e.Column == itemNameColumn || e.Column == corpseItemNameColumn)
            {
                _itemSelectionBox.Bounds = e.CellBounds;

                if (item != null)
                    _itemSelectionBox.SelectedItem = Item.Items.FirstOrDefault(m => m.Key == item.Id);
                else
                    _itemSelectionBox.SelectedIndex = 0;

                e.AutoDispose = false;
                e.Control = _itemSelectionBox;
            }
            else if (item != null && e.Control is NumericUpDown numericUpDown)
            {
                numericUpDown.Minimum = 1;
                numericUpDown.Maximum = 99;
                numericUpDown.Value = Math.Min(99, Math.Max(1, item.Quantity));
            }
        }

        private void inventoryListView_CellEditFinished(object sender, CellEditEventArgs e)
        {
            _itemSelectionBox.Bounds = Rectangle.Empty;

            if (e.RowObject is Item item &&
                (e.Column == itemNameColumn || e.Column == corpseItemNameColumn) &&
                _itemSelectionBox.SelectedItem is KeyValuePair<int, Item> selectedItem)
            {
                item.ChangeType(selectedItem.Key);
                e.NewValue = item.Name;
                ((ObjectListView)sender).UpdateObject(e.RowObject);
            }
        }

        private void chipsListView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            var chip = e.RowObject as Chip;

            if (e.Column == chipsNameColumn)
            {
                _chipSelectionBox.Bounds = e.CellBounds;

                if (chip != null)
                    _chipSelectionBox.SelectedItem = Chip.Chips.FirstOrDefault(m => m.Key == chip.Type);
                else
                    _chipSelectionBox.SelectedIndex = 0;

                e.AutoDispose = false;
                e.Control = _chipSelectionBox;
            }
            else if (chip != null && e.Control is NumericUpDown numericUpDown)
            {
                if (e.Column == chipsLevelColumn)
                {
                    numericUpDown.Minimum = 0;
                    numericUpDown.Maximum = 8;
                    numericUpDown.Value = Math.Min(8, Math.Max(0, chip.Level));
                }
                else if (e.Column == chipsWeightColumn)
                {
                    numericUpDown.Minimum = 1;
                    numericUpDown.Maximum = 99;
                    numericUpDown.Value = Math.Min(99, Math.Max(1, chip.Weight));
                }
            }
        }

        private void chipsListView_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            _chipSelectionBox.Bounds = Rectangle.Empty;

            if (e.RowObject is Chip chip)
            {
                if (e.Column == chipsNameColumn
                    && _chipSelectionBox.SelectedItem is KeyValuePair<int, Chip> selectedChip
                    && chip.Type != selectedChip.Key)
                {
                    chip.ChangeType(selectedChip.Key);
                    e.NewValue = chip.Name;
                    return;
                }
                if (e.Control is NumericUpDown numericUpDown)
                {
                    if (e.Column == chipsLevelColumn)
                    {
                        chip.Level = (int)numericUpDown.Value;
                        e.NewValue = chip.Level;
                        return;
                    }
                    if (e.Column == chipsWeightColumn)
                    {
                        chip.Weight = (int)numericUpDown.Value;
                        e.NewValue = chip.Weight;
                        return;
                    }
                }
            }

            e.Cancel = true;
        }

        private void weaponsListView_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.RowObject is Weapon weapon 
                && e.Column == weaponLevelColumn 
                && e.Control is NumericUpDown numericUpDown)
            {
                numericUpDown.Minimum = 1;
                numericUpDown.Maximum = 4;
                numericUpDown.Value = Math.Min(4, Math.Max(0, weapon.Level));
            }
        }
    }
}
