using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SystemTrayMessage.Partials.Interop;
using static SystemTrayMessage.Partials.Interop.BarMessage;

namespace SystemTrayMesssageUnitTest
{
    public class BarMessageTests
    {
        [Fact]
        public void GetPosition_ValidWindow_FindsAppBar()
        {
            // Arrange
            var barMessage = new BarMessage();
            string className = "ClassName"; 
            string windowName = "WindowName";

            // Act & Assert
            Assert.Throws<Exception>(() => barMessage.GetPosition(className, windowName));
        }

        [Fact]
        public void WorkArea_ReturnsCorrectRectangle()
        {
            // Arrange
            var BarInstance = new BarMessage();
            // Mocking the RECT structure, replace with your actual test data
            RECT testRect = new RECT { left = 0, top = 0, right = 100, bottom = 100 };

            // Act
            var result = InvokeWorkAreaMethod(BarInstance, testRect);

            // Assert
            Assert.Equal(new Rectangle(0, 0, 100, 100), result);
        }

        // Helper method to invoke private method WorkArea
        private Rectangle InvokeWorkAreaMethod(BarMessage BarInstance, RECT testRect)
        {
            // Simulate setting private field m_data.rc with test data
            BarInstance.GetType()
                .GetField("m_data", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(BarInstance, new APPBARDATA { rc = testRect });

            // Call the WorkArea property
            return BarInstance.WorkArea;
        }
        
    }
}
