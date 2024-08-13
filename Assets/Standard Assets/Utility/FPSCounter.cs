using System;
using UnityEngine;
using UnityEngine.UI; // 使用 UI 系统

namespace UnityStandardAssets.Utility
{
    [RequireComponent(typeof(Text))]
    public class FPSCounter : MonoBehaviour
    {
        const float fpsMeasurePeriod = 0.5f;
        private int m_FpsAccumulator = 0;
        private float m_FpsNextPeriod = 0;
        private int m_CurrentFps;
        const string display = "{0} FPS";
        private Text m_Text; // 使用 Text 组件

        private void Start()
        {
            m_FpsNextPeriod = Time.realtimeSinceStartup + fpsMeasurePeriod;
            m_Text = GetComponent<Text>(); // 获取 Text 组件
        }

        private void Update()
        {
            // measure average frames per second
            m_FpsAccumulator++;
            if (Time.realtimeSinceStartup > m_FpsNextPeriod)
            {
                m_CurrentFps = (int)(m_FpsAccumulator / fpsMeasurePeriod);
                m_FpsAccumulator = 0;
                m_FpsNextPeriod += fpsMeasurePeriod;
                m_Text.text = string.Format(display, m_CurrentFps); // 更新 Text 组件的文本
            }
        }
    }
}
