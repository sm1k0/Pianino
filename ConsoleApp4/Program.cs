using System;
using System.Media;

namespace Piano
{
    class Program
    {
        static int currentOctave = 4; 
        static int[][] octaves = new int[][] { 
            new int[] {262, 294, 330, 349, 392, 440, 494, 523}, 
            new int[] {523, 587, 659, 698, 784, 880, 988, 1047},
            new int[] {1047, 1175, 1319, 1397, 1568, 1760, 1976, 2093} 
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the piano!");

            while (true) 
            {
                ConsoleKeyInfo key = Console.ReadKey(true); 
                if (key.Key == ConsoleKey.F1 || key.Key == ConsoleKey.F2 || key.Key == ConsoleKey.F3) 
                {
                    currentOctave = key.Key - ConsoleKey.F1 + 1; 
                    Console.WriteLine("Current octave: " + currentOctave);
                }
                else if (key.KeyChar == ' ') 
                {
                    StopSound();
                }
                else 
                {
                    int noteIndex = GetNoteIndex(key.KeyChar); 

                    if (noteIndex >= 0) 
                    {
                        int frequency = octaves[currentOctave - 1][noteIndex]; 
                        PlaySound(frequency); 
                    }
                }
            }
        }

        static void PlaySound(int frequency)
        {
            Console.Beep(frequency, 500); 
        }

        static void StopSound()
        {
            Console.Beep(0, 100); 
        }

        static int GetNoteIndex(char key)
        {
            switch (key)
            {
                case 'a': return 0;
                case 'w': return 1;
                case 's': return 2;
                case 'e': return 3;
                case 'd': return 4;
                case 'f': return 5;
                case 't': return 6;
                case 'g': return 7;
                case 'y': return 8;
                case 'h': return 9;
                case 'u': return 10;
                case 'j': return 11;
                case 'k': return 12;
                default: return -1; 
            }
        }
    }
}
