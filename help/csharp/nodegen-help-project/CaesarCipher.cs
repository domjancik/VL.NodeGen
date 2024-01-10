
///Generated VL (vvvv gamma) Node using ChatGPT April 4, 2023
///Via the NodeGen Node Set available at: https://github.com/domjancik/VL.NodeGen
///For more examples, see:
///https://thegraybook.vvvv.org/reference/extending/writing-nodes.html#examples

namespace nodegen_help_project;

public static class CaesarCipher
{
    public static string EncryptString(string input, int shift)
    {
        char[] buffer = input.ToCharArray();
        for (int i = 0; i < buffer.Length; i++)
        {
            char letter = buffer[i];
            if (char.IsLetter(letter))
            {
                char offset = char.IsUpper(letter) ? 'A' : 'a';
                letter = (char)((((letter + shift) - offset) % 26) + offset);
            }
            buffer[i] = letter;
        }
        return new string(buffer);
    }
}
