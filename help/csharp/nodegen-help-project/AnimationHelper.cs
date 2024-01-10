// Function prompt:
// Surprise me with some nice animation based on a time parameter

///Generated VL (vvvv gamma) Node using ChatGPT April 1, 2023
///Via the NodeGen Node Set available at: https://github.com/domjancik/VL.NodeGen
///For more examples, see:
///https://thegraybook.vvvv.org/reference/extending/writing-nodes.html#examples

using Stride.Core.Mathematics;

namespace nodegen_help_project;

public static class AnimationHelper
{
    public static float Oscillate(float time, float frequency, float amplitude)
    {
        return amplitude * (float)Math.Sin(2 * Math.PI * frequency * time);
    }

    public static float Rotate(float time, float speed)
    {
        return time * speed % 360;
    }

    public static Vector2 Spiral(float time, float speed, float expansionRate)
    {
        float angle = Rotate(time, speed);
        float radius = expansionRate * time;
        return new Vector2(radius * (float)Math.Cos(angle), radius * (float)Math.Sin(angle));
    }
}
