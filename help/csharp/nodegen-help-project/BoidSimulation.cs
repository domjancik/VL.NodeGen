// Function prompt:
// simulate boid movement iteratively in using Vector2, use two output arguments for positions and velocities, ensure that you stick to the template. Implement all functions, do not use placeholders.

using Stride.Core.Mathematics;
using System.Collections.Generic;
using System.Linq;

namespace nodegen_help_project;

public static class BoidSimulation
{
    public static void SimulateBoidMovement(
        IEnumerable<Vector2> positions,
        IEnumerable<Vector2> velocities,
        float alignmentStrength,
        float cohesionStrength,
        float separationStrength,
        float separationDistance,
        out IEnumerable<Vector2> updatedPositions,
        out IEnumerable<Vector2> updatedVelocities)
    {
        var positionList = positions.ToList();
        var velocityList = velocities.ToList();
        var updatedPositionList = new List<Vector2>();
        var updatedVelocityList = new List<Vector2>();

        for (int i = 0; i < positionList.Count; i++)
        {
            var position = positionList[i];
            var velocity = velocityList[i];

            // Alignment - steer towards the average heading of local flockmates
            Vector2 alignment = CalculateAlignment(i, positionList, velocityList) * alignmentStrength;

            // Cohesion - steer to move toward the average position of local flockmates
            Vector2 cohesion = CalculateCohesion(i, positionList) * cohesionStrength;

            // Separation - steer to avoid crowding local flockmates
            Vector2 separation = CalculateSeparation(i, positionList, separationDistance) * separationStrength;

            // Combine the forces
            Vector2 acceleration = alignment + cohesion + separation;

            // Update velocity and position
            Vector2 newVelocity = velocity + acceleration;
            Vector2 newPosition = position + newVelocity;

            updatedVelocityList.Add(newVelocity);
            updatedPositionList.Add(newPosition);
        }

        updatedPositions = updatedPositionList;
        updatedVelocities = updatedVelocityList;
    }

    private static Vector2 CalculateAlignment(int index, List<Vector2> positions, List<Vector2> velocities)
    {
        Vector2 averageVelocity = Vector2.Zero;
        int count = 0;

        for (int i = 0; i < positions.Count; i++)
        {
            if (i != index)
            {
                averageVelocity += velocities[i];
                count++;
            }
        }

        if (count > 0)
        {
            averageVelocity /= count;
        }

        return averageVelocity - velocities[index];
    }

    private static Vector2 CalculateCohesion(int index, List<Vector2> positions)
    {
        Vector2 centerOfMass = Vector2.Zero;
        int count = 0;

        for (int i = 0; i < positions.Count; i++)
        {
            if (i != index)
            {
                centerOfMass += positions[i];
                count++;
            }
        }

        if (count > 0)
        {
            centerOfMass /= count;
            return centerOfMass - positions[index];
        }

        return Vector2.Zero;
    }

    private static Vector2 CalculateSeparation(int index, List<Vector2> positions, float separationDistance)
    {
        Vector2 separation = Vector2.Zero;
        int count = 0;

        for (int i = 0; i < positions.Count; i++)
        {
            if (i != index)
            {
                Vector2 difference = positions[index] - positions[i];
                float distance = difference.Length();

                if (distance < separationDistance && distance > 0)
                {
                    separation += difference / distance;
                    count++;
                }
            }
        }

        if (count > 0)
        {
            separation /= count;
        }

        return separation;
    }
}
