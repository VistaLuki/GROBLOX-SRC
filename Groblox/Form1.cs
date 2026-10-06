using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Groblox
{
    public partial class Groblox : Form
    {
        private string ApplicationDirectory
        {
            get { return Application.StartupPath; }
        }

        private string MapsDirectory
        {
            get { return Path.Combine(ApplicationDirectory, "maps"); }
        }

        private string ClientPath
        {
            get
            {
                return Path.Combine(
                    ApplicationDirectory,
                    "client",
                    "RobloxApp.exe"
                );
            }
        }

        public Groblox()
        {
            InitializeComponent();
        }

        private void Groblox_Load(object sender, EventArgs e)
        {
            LoadMaps();
        }



        private bool StartRoblox(string arguments)
        {
            if (!File.Exists(ClientPath))
            {
                MessageBox.Show(
                    this,
                    "Could not find RobloxApp.exe:\r\n\r\n" +
                    ClientPath,
                    "Client Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            string clientDirectory =
                Path.GetDirectoryName(ClientPath);

            if (String.IsNullOrEmpty(clientDirectory))
            {
                MessageBox.Show(
                    this,
                    "Could not determine the Roblox client directory.",
                    "Groblox",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            try
            {
                ProcessStartInfo startInfo =
                    new ProcessStartInfo();

                startInfo.FileName = ClientPath;
                startInfo.Arguments = arguments;
                startInfo.WorkingDirectory = clientDirectory;
                startInfo.UseShellExecute = false;

                Process.Start(startInfo);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Failed to start Roblox:\r\n\r\n" +
                    ex.Message,
                    "Launch Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }
        }


        private string GetSelectedMapPath()
        {
            if (mapTreeView.SelectedNode == null)
                return null;

            if (mapTreeView.SelectedNode.Tag == null)
                return null;

            return mapTreeView.SelectedNode.Tag.ToString();
        }

        private bool TryGetSelectedMap(out string mapPath)
        {
            mapPath = String.Empty;

            string selectedPath =
                GetSelectedMapPath();

            if (String.IsNullOrEmpty(selectedPath))
            {
                MessageBox.Show(
                    this,
                    "Please select a .rbxl map.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return false;
            }

            if (!File.Exists(selectedPath))
            {
                MessageBox.Show(
                    this,
                    "Map not found:\r\n\r\n" +
                    selectedPath,
                    "Map Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return false;
            }

            mapPath = selectedPath;

            return true;
        }

        private string GetRelativeMapPath(string mapPath)
        {
            string relativePath =
                GetRelativePath(
                    ApplicationDirectory,
                    mapPath
                );

            return "..\\" + relativePath;
        }

        private void PlaySolo_Click(object sender, EventArgs e)
        {
            string playerName =
                username.Text.Trim();

            if (String.IsNullOrEmpty(playerName))
            {
                MessageBox.Show(
                    this,
                    "Please enter a username.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                username.Focus();

                return;
            }

            string mapPath;

            if (!TryGetSelectedMap(out mapPath))
                return;

            string relativeMapPath =
                GetRelativeMapPath(mapPath);

            string script =
                "_G.name='" +
                EscapeLuaString(playerName) +
                "'; " +
                "dofile('rbxasset://Play_Solo.lua')";

            string arguments =
                "\"" +
                relativeMapPath +
                "\" -script \"" +
                script +
                "\"";

            StartRoblox(arguments);
        }

        private void PlayServer_Click(object sender, EventArgs e)
        {
            string serverIp =
                ip.Text.Trim();

            string serverPort =
                port.Text.Trim();

            string playerName =
                username.Text.Trim();

            if (String.IsNullOrEmpty(serverIp))
            {
                MessageBox.Show(
                    this,
                    "Please enter a server IP.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                ip.Focus();

                return;
            }

            int parsedPort;

            if (!Int32.TryParse(
                serverPort,
                out parsedPort) ||
                parsedPort < 1 ||
                parsedPort > 65535)
            {
                MessageBox.Show(
                    this,
                    "Invalid Port! Please enter a valid port between 1 and 65535.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                port.Focus();

                return;
            }

            if (String.IsNullOrEmpty(playerName))
            {
                MessageBox.Show(
                    this,
                    "Please enter a username.",
                    "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                username.Focus();

                return;
            }

            string script =
                "_G.server='" +
                EscapeLuaString(serverIp) +
                "'; " +

                "_G.port=" +
                parsedPort.ToString() +
                "; " +

                "_G.name='" +
                EscapeLuaString(playerName) +
                "'; " +

                "dofile('rbxasset://Join.lua')";

            string arguments =
                "-script \"" +
                script +
                "\"";

            StartRoblox(arguments);
        }

        private void HostServer_Click(object sender, EventArgs e)
        {
            string serverPort =
                port.Text.Trim();

            int parsedPort;

            if (!Int32.TryParse(
                serverPort,
                out parsedPort) ||
                parsedPort < 1 ||
                parsedPort > 65535)
            {
                MessageBox.Show(
                    this,
                    "Please enter a valid port between 1 and 65535.",
                    "Invalid Port",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                port.Focus();

                return;
            }

            string mapPath;

            if (!TryGetSelectedMap(out mapPath))
                return;

            string relativeMapPath =
                GetRelativeMapPath(mapPath);

            string script =
                "_G.port=" +
                parsedPort.ToString() +
                "; " +
                "dofile('rbxasset://Host.lua')";

            string arguments =
                "\"" +
                relativeMapPath +
                "\" -script \"" +
                script +
                "\"";

            StartRoblox(arguments);
        }

        private void LoadMaps()
        {
            mapTreeView.BeginUpdate();

            try
            {
                mapTreeView.Nodes.Clear();

                if (!Directory.Exists(MapsDirectory))
                    return;

                TreeNode rootNode =
                    new TreeNode("Maps");

                mapTreeView.Nodes.Add(rootNode);

                AddDirectoryNodes(
                    MapsDirectory,
                    rootNode
                );

                rootNode.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    this,
                    "Failed to load maps:\r\n\r\n" +
                    ex.Message,
                    "Map Loading Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                mapTreeView.EndUpdate();
            }
        }

        private void AddDirectoryNodes(
            string directoryPath,
            TreeNode parentNode)
        {
            string[] directories;
            string[] files;

            try
            {
                directories =
                    Directory.GetDirectories(
                        directoryPath
                    );

                files =
                    Directory.GetFiles(
                        directoryPath,
                        "*.rbxl"
                    );
            }
            catch
            {
                return;
            }

            Array.Sort(directories);
            Array.Sort(files);

            foreach (string directory in directories)
            {
                TreeNode folderNode =
                    new TreeNode(
                        Path.GetFileName(directory)
                    );

                parentNode.Nodes.Add(folderNode);

                AddDirectoryNodes(
                    directory,
                    folderNode
                );
            }

            foreach (string file in files)
            {
                TreeNode fileNode =
                    new TreeNode(
                        Path.GetFileName(file)
                    );

                fileNode.Tag = file;

                parentNode.Nodes.Add(fileNode);
            }
        }

        private string GetRelativePath(
            string basePath,
            string targetPath)
        {
            Uri baseUri =
                new Uri(
                    EnsureTrailingSlash(
                        Path.GetFullPath(basePath)
                    )
                );

            Uri targetUri =
                new Uri(
                    Path.GetFullPath(targetPath)
                );

            Uri relativeUri =
                baseUri.MakeRelativeUri(targetUri);

            return Uri.UnescapeDataString(
                relativeUri.ToString()
            ).Replace(
                '/',
                Path.DirectorySeparatorChar
            );
        }

        private string EnsureTrailingSlash(string path)
        {
            if (!path.EndsWith(
                Path.DirectorySeparatorChar.ToString()))
            {
                return path +
                    Path.DirectorySeparatorChar;
            }

            return path;
        }

        private static string EscapeLuaString(string value)
        {
            return value
                .Replace("\\", "\\\\")
                .Replace("'", "\\'");
        }

    }
}