
///Generated VL (vvvv gamma) Node using ChatGPT 2022-12-01
///Via the NodeGen Node Set available at: https://github.com/domjancik/VL.NodeGen
///For more examples, see:
///https://thegraybook.vvvv.org/reference/extending/writing-nodes.html#examples

namespace test_namespace
{
    public static class BreathAnimation
    {
        public static float GetBreathStage(float time)
        {
            float breathDuration = 5.0f; // Duration of one complete breath cycle in seconds
            float inhaleDuration = breathDuration * 0.4f; // Duration of inhale phase as a fraction of breathDuration
            float exhaleDuration = breathDuration * 0.6f; // Duration of exhale phase as a fraction of breathDuration

            float breathTime = time % breathDuration; // Time within one breath cycle

            if (breathTime < inhaleDuration)
            {
                // Inhale phase
                float t = breathTime / inhaleDuration; // Normalized time within inhale phase
                return EaseInOutQuad(t, 0.0f, 1.0f, 1.0f);
            }
            else
            {
                // Exhale phase
                float t = (breathTime - inhaleDuration) / exhaleDuration; // Normalized time within exhale phase
                return EaseInOutQuad(t, 1.0f, -1.0f, 1.0f);
            }
        }

        // Easing function for smooth animation
        private static float EaseInOutQuad(float t, float b, float c, float d)
        {
            t /= d / 2.0f;
            if (t < 1.0f)
                return c / 2.0f * t * t + b;
            t--;
            return -c / 2.0f * (t * (t - 2.0f) - 1.0f) + b;
        }
    }
}
