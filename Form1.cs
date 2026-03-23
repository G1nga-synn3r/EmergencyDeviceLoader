using System.Management;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO.Ports;
using System.Drawing;

namespace EmergencyDeviceLoader;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        this.Load += Form1_Load;
        btnRefresh.Click += BtnRefresh_Click;
        btnConnect.Click += btnConnect_Click;
    }

    private SerialPort? currentPort = null;


    /// <summary>
    /// Handles the form load event to automatically detect EDL ports on startup.
    /// </summary>
    private void Form1_Load(object? sender, EventArgs e)
    {
        DetectEDLPorts();
    }

    /// <summary>
    /// Handles the btnRefresh click event to manually detect EDL ports.
    /// </summary>
    private void BtnRefresh_Click(object? sender, EventArgs e)
    {
        DetectEDLPorts();
    }

    /// <summary>
    /// Detects Qualcomm EDL devices (9008) connected via USB and populates the comboEDLPorts ComboBox.
    /// Uses WMI Win32_PnPEntity to query for matching devices and extracts COM port information.
    /// </summary>
    private void DetectEDLPorts()
    {
        comboEDLPorts.Items.Clear();
        btnConnect.Enabled = false;

        try
        {
            using var searcher = new ManagementObjectSearcher(
                "SELECT Caption, Description, DeviceID FROM Win32_PnPEntity");
            using var devices = searcher.Get();

            var edlPorts = new List<string>();

            foreach (ManagementObject device in devices)
            {
                var caption = device["Caption"]?.ToString() ?? "";
                var description = device["Description"]?.ToString() ?? "";
                var deviceId = device["DeviceID"]?.ToString() ?? "";

                var searchText = $"{caption} {description} {deviceId}".ToLowerInvariant();

                bool isEdlDevice = searchText.Contains("9008") ||
                                   searchText.Contains("qdloader") ||
                                   searchText.Contains("qualcomm hs-usb") ||
                                   searchText.Contains("vid_05c6&pid_9008");

                if (isEdlDevice)
                {
                    var comPort = ExtractComPort(caption, deviceId);
                    string displayText;

                    if (!string.IsNullOrEmpty(comPort))
                    {
                        var portName = GetFriendlyPortName(caption, description);
                        displayText = $"{comPort} - {portName}";
                    }
                    else
                    {
                        displayText = string.IsNullOrEmpty(caption) 
                            ? "Qualcomm 9008 Device" 
                            : caption;
                    }

                    if (!edlPorts.Contains(displayText))
                    {
                        edlPorts.Add(displayText);
                    }
                }
            }

            edlPorts.Sort();

            foreach (var port in edlPorts)
            {
                comboEDLPorts.Items.Add(port);
            }

            if (edlPorts.Count > 0)
            {
                comboEDLPorts.SelectedIndex = 0;
                btnConnect.Enabled = true;
                lblStatus.Text = $"Detected {edlPorts.Count} EDL port(s)";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                comboEDLPorts.Items.Add("No EDL devices detected");
                comboEDLPorts.SelectedIndex = 0;
                lblStatus.Text = "No Qualcomm 9008 device found";
                lblStatus.ForeColor = Color.Red;
            }
        }
        catch (UnauthorizedAccessException)
        {
            MessageBox.Show("WMI access error - run as administrator?", "Access Denied",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "WMI access denied";
            lblStatus.ForeColor = Color.Red;
        }
        catch (ManagementException ex)
        {
            MessageBox.Show($"WMI query error: {ex.Message}", "WMI Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "WMI query failed";
            lblStatus.ForeColor = Color.Red;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error detecting ports: {ex.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            lblStatus.Text = "Detection failed";
            lblStatus.ForeColor = Color.Red;
        }
    }

    /// <summary>
    /// Extracts the COM port number from a device caption or device ID.
    /// </summary>
    /// <param name="caption">The device caption string.</param>
    /// <param name="deviceId">The device ID string.</param>
    /// <returns>The COM port number (e.g., "COM5") or null if not found.</returns>
    private static string? ExtractComPort(string caption, string deviceId)
    {
        var match = Regex.Match(caption, @"\(COM\d+\)", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            return match.Value.Trim('(', ')');
        }

        match = Regex.Match(deviceId, @"(COM\d+)", RegexOptions.IgnoreCase);
        if (match.Success)
        {
            return match.Groups[1].Value;
        }

        return null;
    }

    /// <summary>
     /// Gets a friendly port name based on the device caption and description.
     /// </summary>
     /// <param name="caption">The device caption.</param>
     /// <param name="description">The device description.</param>
     /// <returns>A formatted port name string.</returns>
     private static string GetFriendlyPortName(string caption, string description)
     {
         var text = $"{caption} {description}".ToLowerInvariant();

         if (text.Contains("qdloader"))
             return "Qualcomm HS-USB QDLoader 9008";
         if (text.Contains("qualcomm hs-usb"))
             return "Qualcomm HS-USB";
         if (text.Contains("9008"))
             return "Qualcomm 9008";

         return "Qualcomm Device";
     }

     /// <summary>
     /// Handles the btnConnect click event to open the selected serial port.
     /// </summary>
     private void btnConnect_Click(object? sender, EventArgs e)
     {
         // Get the selected item from comboEDLPorts
         var selectedItem = comboEDLPorts.SelectedItem?.ToString() ?? string.Empty;
         if (string.IsNullOrWhiteSpace(selectedItem) || selectedItem.StartsWith("No EDL"))
         {
             MessageBox.Show("Please select a valid EDL port first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             return;
         }

         // Parse the COMx part (e.g. split by " - " or regex)
         string? portName = null;
         var parts = selectedItem.Split(new[] { " - " }, StringSplitOptions.None);
         if (parts.Length >= 1)
         {
             var firstPart = parts[0].Trim();
             if (firstPart.StartsWith("COM", StringComparison.InvariantCultureIgnoreCase))
             {
                 portName = firstPart;
             }
         }

         if (string.IsNullOrEmpty(portName))
         {
             // Fallback: use regex to find COM\d+ in the selected item
             var match = Regex.Match(selectedItem, @"COM\d+", RegexOptions.IgnoreCase);
             if (match.Success)
             {
                 portName = match.Value;
             }
         }

         if (string.IsNullOrEmpty(portName))
         {
             MessageBox.Show("Could not parse COM port from selection.", "Parsing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return;
         }

         try
         {
             // Close any existing port
             currentPort?.Close();

             // Create and configure new SerialPort
             currentPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
             currentPort.ReadTimeout = 2000;
             currentPort.WriteTimeout = 2000;

             // Open the port
             currentPort.Open();

             // Update UI
             txtLog.AppendText($"✅ Connected to {portName} at 115200 8N1\r\n");
             lblStatus.Text = "Connected ✓";
             lblStatus.ForeColor = Color.Green;
             btnConnect.Enabled = false;
             btnRefresh.Enabled = false;
         }
         catch (Exception ex)
         {
             txtLog.AppendText($"❌ Failed: {ex.Message}\r\n");
             lblStatus.Text = "Connection failed";
             lblStatus.ForeColor = Color.Red;
             MessageBox.Show("Could not open port.\n\nTip: Run as Administrator + make sure phone is in EDL mode and drivers are installed.", "EDL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
     }
 }
