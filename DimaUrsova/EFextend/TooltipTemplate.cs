using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace DimaUrsova.EFextend
{
    public class TooltipTemplate
    {
        public static System.Windows.Controls.ToolTip Template(Page page, string name)
        {
            System.Windows.Controls.ToolTip toolTip = new System.Windows.Controls.ToolTip();
            StackPanel stackpanel = new StackPanel();
            TextBlock tblock = new TextBlock();
            tblock.Text = name;
            tblock.Background = new SolidColorBrush(Colors.Black);
            tblock.Padding = new System.Windows.Thickness(10, 0, 0, 0);
            tblock.Foreground = new SolidColorBrush(Colors.White);
            tblock.Height = 20;
            stackpanel.Background = new SolidColorBrush(Colors.Transparent);
            stackpanel.Children.Add(tblock);
            Frame frame = new Frame();
            Viewbox vb = new Viewbox();
            vb.Stretch = Stretch.UniformToFill;
            frame.Width = 900;
            frame.Height = 400;
            frame.Content = page;
            frame.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            vb.Child = frame;
            stackpanel.Children.Add(vb);
            
            Border border = new Border();
            border.CornerRadius = new System.Windows.CornerRadius(15);
            border.Child = stackpanel;
            border.Width = 900/4;
            border.Height = 400/4;
            DropShadowEffect shadow = new DropShadowEffect();
            shadow.BlurRadius = 5;
            shadow.ShadowDepth = 5;
            border.Effect = shadow;
            toolTip.Content = border;
            vb.StretchDirection = StretchDirection.DownOnly;
            vb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            toolTip.Background = new SolidColorBrush(Colors.Transparent);
            toolTip.BorderBrush = new SolidColorBrush(Colors.Transparent);
            return toolTip;

        }
    }
}
