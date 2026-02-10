using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Udp_WPF
{
    public partial class MainWindow : Window
    {
        private bool isListening = false;
        private UdpClient udpListener;
        private TcpListener tcpListener;

        public MainWindow()
        {
            InitializeComponent();
        }

        
        private async Task SendUdpAsync(string ip, int port, string message)
        {
            try
            {
                using UdpClient udp = new UdpClient();
                byte[] data = Encoding.UTF8.GetBytes(message);
                await udp.SendAsync(data, data.Length, ip, port);

                Dispatcher.Invoke(() =>
                    lsbGetMessage.Items.Add($"UDP → {ip}:{port} : {message}")
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"UDP hiba: {ex.Message}");
            }
        }

        
        private async Task SendTcpAsync(string ip, int port, string message)
        {
            try
            {
                using TcpClient tcp = new TcpClient();
                await tcp.ConnectAsync(ip, port);
                using NetworkStream stream = tcp.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(message);
                await stream.WriteAsync(data, 0, data.Length);

                Dispatcher.Invoke(() =>
                    lsbGetMessage.Items.Add($"TCP → {ip}:{port} : {message}")
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"TCP hiba: {ex.Message}");
            }
        }

        
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ip = tbxIP.Text.Trim();
                int port = int.Parse(tbxPort.Text.Trim());
                string message = tbxMessage.Text.Trim();

                if (string.IsNullOrEmpty(message)) return;

                string mode = ((ComboBoxItem)cmbMode.SelectedItem).Content.ToString();

                if (mode == "UDP")
                    await SendUdpAsync(ip, port, message);
                else
                    await SendTcpAsync(ip, port, message);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba: {ex.Message}");
            }
        }

        
        private async void StartUdpListener(int port)
        {
            udpListener = new UdpClient(port);
            try
            {
                while (true)
                {
                    var result = await udpListener.ReceiveAsync();
                    string msg = Encoding.UTF8.GetString(result.Buffer);

                    Dispatcher.Invoke(() =>
                        lsbGetMessage.Items.Add($"UDP fogadva {result.RemoteEndPoint}: {msg}")
                    );
                }
            }
            catch (ObjectDisposedException) { }
            catch (Exception ex)
            {
                Dispatcher.Invoke(() => MessageBox.Show($"UDP listener hiba: {ex.Message}"));
            }
            finally
            {
                udpListener?.Dispose();
                udpListener = null;
            }
        }

       
        private async void StartTcpListener(int port)
        {
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            try
            {
                while (true)
                {
                    TcpClient client = await tcpListener.AcceptTcpClientAsync();
                    _ = HandleTcpClientAsync(client); 
                }
            }
            catch (ObjectDisposedException) {  }
            catch (Exception ex)
            {
                MessageBox.Show($"TCP listener hiba: {ex.Message}");
            }
            finally
            {
                tcpListener?.Stop();
                tcpListener = null;
            }
        }

        private async Task HandleTcpClientAsync(TcpClient client)
        {
            try
            {
                using NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Dispatcher.Invoke(() =>
                        lsbGetMessage.Items.Add($"TCP fogadva: {msg}")
                    );
                }
            }
            catch {  }
            finally
            {
                client.Close();
            }
        }

        private void btnStartListen_Click(object sender, RoutedEventArgs e)
        {
            string mode = ((ComboBoxItem)cmbMode.SelectedItem).Content.ToString();
            int port = int.Parse(tbxPort.Text.Trim());

            if (isListening)
            {
                isListening = false;
                udpListener?.Close();
                tcpListener?.Stop();
                btnStartListen.Content = "Figyelés indítása";
            }
            else
            {
                isListening = true;
                btnStartListen.Content = "Figyelés leállítása";

                if (mode == "UDP")
                    StartUdpListener(port);
                else
                    StartTcpListener(port);
            }
        }
    }
}