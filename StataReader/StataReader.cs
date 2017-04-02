using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfToText;
using System.Collections;
using System.IO;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace StataReader
{
    public partial class StataReader : Form
    {
        private List<String> selectedFiles;
        private List<String> tempFiles = new List<String>();
        private List<DataPoint> dataPoints;

        public StataReader()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private class DataPoint
        {
            public Dictionary<String, String> hits = new Dictionary<String, String>();
            public int id;
            public DataPoint(int _id)
            {
                id = _id;
            }

        }

        private void InitializeOpenFileDialog()
        {
            this.openFileDialog.Filter =
                "PDF files *.pdf|*.PDF|" +
                "All files (*.*)|*.*";

            // Allow the user to select multiple images.
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Select Stata PDF Files";
        }

        private void buttonSelectFiles_Click(object sender, EventArgs e)
        {
            selectedFiles = new List<String>();

            DialogResult dr = this.openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Read the files
                foreach (String file in openFileDialog.FileNames)
                {
                    try
                    {
                        selectedFiles.Add(file);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to laod file: " + file.Substring(file.LastIndexOf('\\')) + ". You may not have permission to read the file, or it may be corrupt.\n\nReported error: " + ex.Message, "Error");
                    }
                }
                updateFileListView();
            }
        }

        public void updateFileListView()
        {
            this.listBoxSelectedFiles.Items.Clear();

            foreach (String file in selectedFiles)
                this.listBoxSelectedFiles.Items.Add(file.Substring(file.LastIndexOf('\\')));

            // Enable parse tool if files are selected
            if (selectedFiles.Count > 0)
                this.groupBox_filters.Enabled = true;
        }

        private void buttonParse_Click(object sender, EventArgs e)
        {
            updatePDFTempFiles();

            dataPoints = new List<DataPoint>();
            int dataId = 0;

            Boolean searchOn = false;
            SearchObject activeObject = null;
            SearchObject firstObject = null;
            SearchObject mostRecentObject = null;

            int valDisplacement = 1;
            int displaceCounter = 0;

            DataPoint point = new DataPoint(dataId);

            foreach (String file in tempFiles)
            {
                String fileText = File.ReadAllText(file);

                foreach (String line in fileText.Split('\n'))
                {
                    if (!searchOn)
                    {
                        foreach (SearchObject searchObj in SearchFilter.ActiveSearchFilter)
                        {
                            if (line.Contains(searchObj.text))
                            {
                                if (firstObject == null)
                                    firstObject = searchObj;
                                activeObject = searchObj;
                                searchOn = true;

                                // If data search object has loopes
                                if ((firstObject != null) && (activeObject == firstObject))
                                {
                                    dataPoints.Add(point);
                                    dataId++;
                                    point = new DataPoint(dataId);
                                }
                            }
                        }
                    }
                    else
                    {
                        displaceCounter++;
                        if (displaceCounter == valDisplacement)
                        {
                            point.hits.Add(activeObject.text, cleanLine(line));
                            searchOn = false;
                            activeObject = null;
                            displaceCounter = 0;
                        }
                    }
                }
            }

            populateTreeView(dataPoints);

            this.groupBoxSave.Enabled = true;

            // Finally, clean up disk
            cleanUpTempFiles();

        }

        private void updatePDFTempFiles()
        {
            // Save text data to temp storage
            PDFParser pdfParser = new PDFParser();

            foreach (String file in selectedFiles)
            {
                string outFileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";

                if (pdfParser.ExtractText(file, outFileName))
                {
                    Console.WriteLine("FILE READ OK");
                    Console.WriteLine(outFileName);
                    tempFiles.Add(outFileName);
                }
                else
                    MessageBox.Show("Unable to properly read the text from PDF: " + file + ". Data not included in output.", "Error");
            }
        }

        private void populateTreeView(List<DataPoint> dataPoints)
        {
            treeViewParsedFiles.Nodes.Clear();

            var topNode = new TreeNode("All Data Objects");
            treeViewParsedFiles.Nodes.Add(topNode);
            string currentGroup = null;
            var treeNodes = new List<TreeNode>();
            var childNodes = new List<TreeNode>();
            foreach (DataPoint point in dataPoints)
            {
                if (currentGroup == point.id.ToString())
                    childNodes.Add(new TreeNode(point.id.ToString()));
                else
                {
                    if (childNodes.Count > 0)
                    {
                        treeNodes.Add(new TreeNode(currentGroup, childNodes.ToArray()));
                        childNodes = new List<TreeNode>();
                    }

                    foreach (var kvp in point.hits)
                        childNodes.Add(new TreeNode(kvp.Key.ToString() + " = " + kvp.Value.ToString()));

                    currentGroup = point.id.ToString();
                }
            }
            if (childNodes.Count > 0)
            {
                treeNodes.Add(new TreeNode(currentGroup, childNodes.ToArray()));
            }
            treeViewParsedFiles.Nodes[0].Nodes.AddRange(treeNodes.ToArray());
            treeViewParsedFiles.ExpandAll();
        }


        private String cleanLine(String inString)
        {
            String str = inString.Trim();
            return str;
        }


        private void cleanUpTempFiles()
        {
            foreach (String file in tempFiles)
            {
                try { File.Delete(file); }
                catch { }
            }
            tempFiles.Clear();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("EXCEL could not be started. Check that your office installation and project references are correct.", "Error");
                    return;
                }
                xlApp.Visible = true;

                Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                Worksheet ws = (Worksheet)wb.Worksheets[1];

                if (ws == null)
                    MessageBox.Show("Worksheet could not be created. Check that your office installation and project references are correct.", "Error");

                int colCount;
                int rowCounter = 1;
                foreach (DataPoint dp in dataPoints)
                {
                    colCount = 1;
                    foreach (var kvp in dp.hits)
                    {
                        ws.Cells[1, colCount] = kvp.Key;
                        ws.Cells[rowCounter, colCount] = kvp.Value;
                        colCount++;
                    }
                    rowCounter++;
                }
                MessageBox.Show("Data copied to Excel.", "Success");
            }
            catch
            {
                MessageBox.Show("Unable to write data to Excel. Do not interupt until complete.", "Error");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("StataReader\n2017\nZachary Rzotkiewicz\n", "About");
        }

        private void button_default_z_Click(object sender, EventArgs e)
        {
            SearchFilter.LoadDefaultZAbs();
            UpdateFilterList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchFilter.LoadDefaultTAbsSpearman();
            UpdateFilterList();
        }

        private void UpdateFilterList()
        {
            listBox_filters.Items.Clear();
            foreach (var item in SearchFilter.ActiveSearchFilter)
                listBox_filters.Items.Add(item.text);
            enableGenerateBox();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            String newval = textBox_newval.Text.Trim();
            if (SearchFilter.FilterEntryExists(newval))
            {
                MessageBox.Show("Cannot add duplicate filter.", "Error");
                return;
            }
            SearchFilter.ActiveSearchFilter.Add(new SearchObject(newval));
            UpdateFilterList();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            int selected = listBox_filters.SelectedIndex;
            SearchFilter.RemoveItem(selected);
            UpdateFilterList();
        }

        private void enableGenerateBox()
        {
            if (SearchFilter.ActiveSearchFilter.Count == 0)
                this.groupBoxParse.Enabled = false;
            else
                this.groupBoxParse.Enabled = true;
        }

        private void button_savefilter_Click(object sender, EventArgs e)
        {
            String allText = "";
            foreach (var obj in SearchFilter.ActiveSearchFilter)
                allText = allText + obj.text + "\n";

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "StataReader Filter files (*.srff)|*.srff";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog.OpenFile();
                fs.Write(Encoding.UTF8.GetBytes(allText), 0, allText.Length - 1);
                fs.Close();
            }
        }

        private void button_openfilter_Click(object sender, EventArgs e)
        {
            String rawText = null;
            Stream fs = null;
            OpenFileDialog openDial = new OpenFileDialog();
            openDial.Filter = "StataReader Filter files (*.srff)|*.srff";
            openDial.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openDial.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((fs = openDial.OpenFile()) != null)
                    {
                        using (fs)
                        {
                            StreamReader sr = new StreamReader(fs);
                            rawText = sr.ReadToEnd();
                        }
                        if (rawText == null)
                            throw new Exception("Unable to read file contents.");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to open / read file. " + ex.ToString(), "Error");
                    return;
                }

                try
                {
                    SearchFilter.ActiveSearchFilter = new List<SearchObject>();
                    foreach (String item in rawText.Split('\n'))
                    {
                        if (!String.IsNullOrEmpty(item))
                        {
                            if (!SearchFilter.FilterEntryExists(item))
                            {
                                SearchFilter.ActiveSearchFilter.Add(new SearchObject(item));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid srf file:\n" + ex.ToString(), "Error");
                }
                UpdateFilterList();
            }
        }

    }
}
