using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace VTFeter
{

    public partial class Form1 : Form
    {
        List<KeyValuePair<string, string>> customField;
        string[] launchArgs;
        public Form1()
        {
            InitializeComponent();
            customField = new List<KeyValuePair<string, string>>();
            launchArgs = Environment.GetCommandLineArgs();
            deserializeData();
            if (!File.Exists(Application.StartupPath + "/VTFLib.zip"))
            {
                MessageBox.Show("VTFLib has not been found, downloading...");
                using (var client = new WebClient())
                {
                    client.DownloadFile("https://sharex.imgonzo.dev/f/RFINNBDQ.zip", Application.StartupPath + "/VTFLib.zip");
                    MessageBox.Show("VTFCmd has been downloaded!");
                    System.IO.Compression.ZipFile.ExtractToDirectory(Application.StartupPath + "/VTFLib.zip", Application.StartupPath);
                }
            }

            shellCheck.Checked = File.Exists(getSendtoPath());
        }

        public string getSendtoPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\\Microsoft\\Windows\\SendTo\\Convert to VTF and VMT.lnk";
        }

        void serializeData()
        {
            List<KeyValuePair<string, string>> vmtData = new List<KeyValuePair<string, string>>(customField);
            if (checkBM.Checked)
            {
                vmtData.Add(new KeyValuePair<string, string>("$bumpmap", bumpMap.Text));
            }
            if (checkAdd.Checked)
            {
                vmtData.Add(new KeyValuePair<string, string>("$additive", "1"));
            }
            if (checkAlpha.Checked)
            {
                vmtData.Add(new KeyValuePair<string, string>("$vertexalpha", "1"));
            }

            var vmtParams = new VMTParams
            {
                ShaderName = shaderKind.Text,
                BasePath = vmtPath.Text,
                CustomField = vmtData
            };

            string jsonString = JsonSerializer.Serialize(vmtParams);
            File.WriteAllText(Application.StartupPath + "/vmt.json", jsonString);
        }

        void deserializeData()
        {
            if (File.Exists(Application.StartupPath + "/vmt.json"))
            {
                VMTParams? vmtParams = JsonSerializer.Deserialize<VMTParams>(File.ReadAllText(Application.StartupPath + "/vmt.json"));
                if (vmtParams != null)
                {
                    shaderKind.Text = vmtParams.ShaderName;
                    vmtPath.Text = vmtParams.BasePath;
                    List<KeyValuePair<string, string>> toSerialize = vmtParams.CustomField;
                    if (toSerialize != null)
                    {
                        for (int i = 0; i < toSerialize.Count; i++)
                        {
                            string key = toSerialize[i].Key;
                            if (key == "$bumpmap")
                            {
                                checkBM.Checked = true;
                                bumpMap.Text = toSerialize[i].Value;
                            }
                            else if (key == "$additive")
                            {
                                checkAdd.Checked = true;
                            }
                            else if (key == "$vertexalpha")
                            {
                                checkAlpha.Checked = true;
                            }
                            else
                                addCustomField(toSerialize[i].Key, toSerialize[i].Value);
                        }
                    }
                }
            }
        }

        public string writeVMT(string fileName)
        {
            string vmtInfo = "\"" + shaderKind.Text + "\" {\n";
            vmtInfo += "\t\"$baseTexture\" \"" + vmtPath.Text + "/" + fileName + "\"\n";
            if (checkBM.Checked)
            {
                vmtInfo += "\t\"$bumpmap\" \"" + bumpMap.Text + "\"\n";
            }

            if (checkAdd.Checked)
            {
                vmtInfo += "\t\"$additive\" \"1\"\n";
            }

            if (checkAlpha.Checked)
            {
                vmtInfo += "\t\"$vertexalpha\" \"1\"\n";
            }

            if (checkColor.Checked)
            {
                vmtInfo += "\t\"$vertexcolor\" \"1\"\n";
            }

            for (int i = 0; i < customField.Count; i++)
            {
                vmtInfo += "\t\"" + customField[i].Key + "\" \"" + customField[i].Value + "\"\n";
            }
            vmtInfo += "}";
            return vmtInfo;
        }

        void addCustomField(string key = "$field", string value = "1")
        {
            int slotIndex = customField.Count;

            TextBox fieldName = new TextBox();
            fieldName.Parent = flowLayout;
            fieldName.Size = new Size(150, 23);
            fieldName.TabIndex = 1;
            fieldName.Text = key;
            fieldName.TextChanged += (s, ev) =>
            {
                customField[slotIndex] = new KeyValuePair<string, string>(fieldName.Text, customField[slotIndex].Value);
                serializeData();
            };

            TextBox fieldValue = new TextBox();
            fieldValue.Parent = flowLayout;
            fieldValue.Size = new Size(90, 23);
            fieldValue.TabIndex = 2;
            fieldValue.Text = value;
            fieldValue.TextChanged += (s, ev) =>
            {
                customField[slotIndex] = new KeyValuePair<string, string>(customField[slotIndex].Key, fieldValue.Text);
                serializeData();
            };

            Button fieldRemove = new Button();
            fieldRemove.Parent = flowLayout;
            fieldRemove.Size = new Size(32, 23);
            fieldRemove.TabIndex = 3;
            fieldRemove.Text = "-";
            fieldRemove.Click += (s, ev) =>
            {
                fieldName.Dispose();
                fieldValue.Dispose();
                fieldRemove.Dispose();
                customField.RemoveAt(slotIndex);
                serializeData();
            };

            customField.Add(new KeyValuePair<string, string>(fieldName.Text, fieldValue.Text));
        }

        private void addField_Click(object sender, EventArgs e)
        {
            addCustomField();
        }

        private void checkBM_CheckedChanged(object sender, EventArgs e)
        {
            serializeData();
        }

        private void shaderKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            serializeData();
        }

        private void bumpMap_TextChanged(object sender, EventArgs e)
        {
            serializeData();
        }

        private void vmtPath_TextChanged(object sender, EventArgs e)
        {
            serializeData();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            if (launchArgs.Length <= 1) return;
            for (int i = 1; i < launchArgs.Length; i++)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(launchArgs[i]);
                string filePathWithoutDirection = Path.GetDirectoryName(launchArgs[i]);
                string result = writeVMT(fileNameWithoutExtension);
                if (result != "")
                {
                    File.WriteAllText(filePathWithoutDirection + "\\" + fileNameWithoutExtension + ".vmt", result);
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = Application.StartupPath + "/vtfcmd.exe";
                    startInfo.Arguments = "-file \"" + launchArgs[i] + "\" -format \"dxt5\" -resize";
                    Process.Start(startInfo);
                }
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            string clipboard = "";
            if (launchArgs.Length <= 1) return;

            for (int i = 1; i < launchArgs.Length; i++)
            {
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(launchArgs[i]);
                string filePathWithoutDirection = Path.GetDirectoryName(launchArgs[i]);
                string result = writeVMT(fileNameWithoutExtension);
                if (result != "")
                {
                    clipboard += result + "\n";
                }
            }

            Clipboard.SetText(clipboard);
        }

        private void shellCheck_CheckedChanged(object sender, EventArgs e)
        {
            string path = getSendtoPath();
            File.Delete(path);
            if (shellCheck.Checked)
            {
                IWshRuntimeLibrary.WshShell link = new IWshRuntimeLibrary.WshShell();
                IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)link.CreateShortcut(path);
                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.Description = "Convert to VTF/VMT";
                shortcut.Save();
            }
        }
    }
    public class VMTParams
    {
        public string? ShaderName { get; set; }
        public string? BasePath { get; set; }
        public List<KeyValuePair<string, string>>? CustomField { get; set; }
    }
}