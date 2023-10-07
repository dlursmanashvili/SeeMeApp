namespace SeeMeForm;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        Task.Run(() => StartUpdateFrameAsync());

    }
    private async Task StartUpdateFrameAsync()
    {
        await UpdateFrameAsync();
    }
    private async Task UpdateFrameAsync()
    {
        string url = "http://192.168.1.148:8080/shot.jpg";

        while (true)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        using (Stream stream = await response.Content.ReadAsStreamAsync())
                        {
                            pictureBox1.Image?.Dispose();
                            pictureBox1.Image = Image.FromStream(stream);
                        }
                    }
                }
                await Task.Delay(100);
            }
            catch (Exception ex)
            {
                // Handle exceptions if necessary
                Console.WriteLine(ex.Message);
            }
        }
    }

}
