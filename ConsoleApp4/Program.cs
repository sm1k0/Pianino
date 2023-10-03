using System;
using System.Media;

namespace Piano
{
    class Program
    {
        static int currentOctave = 4; 
        static int[][] octaves = new int[][] { 
            new int[] {131, 147, 165, 175, 196, 220, 247}, 
            new int[] {262, 294, 330, 349, 392, 440, 494}, 
            new int[] {523, 587, 659, 698, 784, 880, 988} 
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
                    Console.Beep(1047, 500);
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

        static int GetNoteIndex(char key)
        {
            switch (key)
            {
                case 'a': return 0;
                case 's': return 1;
                case 'd': return 2;
                case 'f': return 3;
                case 'g': return 4;
                case 'h': return 5;
                case 'j': return 6;
                default: return -1; 
            }
        }
    }
}