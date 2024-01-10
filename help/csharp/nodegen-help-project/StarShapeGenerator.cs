// Function prompt:
// Create a star shape, with number of ends, inner and outer radius as input and Vector2 list output

using Stride.Core.Mathematics;
using System.Collections.Generic;

namespace nodegen_help_project;

public static class StarShapeGenerator
{
    public static IEnumerable<Vector2> CreateStar(int numberOfEnds, float innerRadius, float outerRadius)
    {
        if (numberOfEnds < 2 || innerRadius <= 0 || outerRadius <= 0 || innerRadius >= outerRadius)
            yield break;

        float angleStep = MathUtil.TwoPi / (numberOfEnds * 2);
        float currentAngle = 0;

        for (int i = 0; i < numberOfEnds * 2; i++)
        {
            float radius = (i % 2 == 0) ? outerRadius : innerRadius;
            Vector2 point = new Vector2(
                radius * MathF.Cos(currentAngle),
                radius * MathF.Sin(currentAngle)
            );
            yield return point;
            currentAngle += angleStep;
        }
    }
}
