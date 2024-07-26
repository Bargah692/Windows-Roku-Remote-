using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WindowsRokuRemoteApp
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        const string RokuIp = "replace with your roku IP"; // Replace with your Roku device IP address

        static async Task Main(string[] args)
        {
            bool running = true;

            Console.WriteLine("Press a key to choose an action:");
            Console.WriteLine("Up Arrow - Move Up");
            Console.WriteLine("Down Arrow - Move Down");
            Console.WriteLine("Left Arrow - Move Left");
            Console.WriteLine("Right Arrow - Move Right");
            Console.WriteLine("Enter - Select");
            Console.WriteLine("P - Play");
            Console.WriteLine("S - Stop");
            Console.WriteLine("R - Rewind");
            Console.WriteLine("F - FastForward");
            Console.WriteLine("I - InstantReplay");
            Console.WriteLine("M - Mute");
            Console.WriteLine("U - Unmute");
            Console.WriteLine("V - VolumeUp");
            Console.WriteLine("D - VolumeDown");
            Console.WriteLine("H - Home");
            Console.WriteLine("B - Back");
            Console.WriteLine("Q - Quit");

            while (running)
            {
                
                var key = Console.ReadKey(intercept: true); // intercept: true to prevent key from appearing in console
                Console.WriteLine(); // Move to the next line after the key press

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        await SendRokuCommand("Up");
                        Console.Beep();
                        break;
                    case ConsoleKey.DownArrow:
                        await SendRokuCommand("Down");
                        Console.Beep();
                        break;
                    case ConsoleKey.LeftArrow:
                        await SendRokuCommand("Left");
                        Console.Beep();
                        break;
                    case ConsoleKey.RightArrow:
                        await SendRokuCommand("Right");
                        Console.Beep();
                        break;
                    case ConsoleKey.Enter:
                        await SendRokuCommand("Select");
                        Console.Beep();
                        break;
                    case ConsoleKey.P:
                        await SendRokuCommand("Play");
                        Console.Beep();
                        break;
                    case ConsoleKey.S:
                        await SendRokuCommand("Stop");
                        Console.Beep();
                        break;
                    case ConsoleKey.R:
                        await SendRokuCommand("Rewind");
                        Console.Beep();
                        break;
                    case ConsoleKey.F:
                        await SendRokuCommand("FastForward");
                        Console.Beep();
                        break;
                    case ConsoleKey.I:
                        await SendRokuCommand("InstantReplay");
                        Console.Beep();
                        break;
                    case ConsoleKey.M:
                        await SendRokuCommand("Mute");
                        Console.Beep();
                        break;
                    case ConsoleKey.U:
                        await SendRokuCommand("Unmute");
                        Console.Beep();
                        break;
                    case ConsoleKey.V:
                        await SendRokuCommand("VolumeUp");
                        Console.Beep();
                        break;
                    case ConsoleKey.D:
                        await SendRokuCommand("VolumeDown");
                        Console.Beep();
                        break;
                    case ConsoleKey.H:
                        await SendRokuCommand("Home");
                        Console.Beep();
                        break;
                    case ConsoleKey.B:
                        await SendRokuCommand("Back");
                        Console.Beep();
                        break;
                    case ConsoleKey.Q:
                        Console.Beep();
                        running = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid key. Please press a valid key.");
                        await Task.Delay(250);
                        Console.Clear();
                        Console.WriteLine("Press a key to choose an action:");
                        Console.WriteLine("Up Arrow - Move Up");
                        Console.WriteLine("Down Arrow - Move Down");
                        Console.WriteLine("Left Arrow - Move Left");
                        Console.WriteLine("Right Arrow - Move Right");
                        Console.WriteLine("Enter - Select");
                        Console.WriteLine("P - Play");
                        Console.WriteLine("S - Stop");
                        Console.WriteLine("R - Rewind");
                        Console.WriteLine("F - FastForward");
                        Console.WriteLine("I - InstantReplay");
                        Console.WriteLine("M - Mute");
                        Console.WriteLine("U - Unmute");
                        Console.WriteLine("V - VolumeUp");
                        Console.WriteLine("D - VolumeDown");
                        Console.WriteLine("H - Home");
                        Console.WriteLine("B - Back");
                        Console.WriteLine("Q - Quit");
                        break;
                }
            }
        }

        static async Task SendRokuCommand(string command)
        {
            try
            {
                var url = $"http://{RokuIp}:8060/keypress/{command}";
                var response = await client.PostAsync(url, null);
                response.EnsureSuccessStatusCode();
                //Console.WriteLine($"Command '{command}' sent successfully.");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Request error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Unexpected error: {e.Message}");
            }
        }
    }
}
