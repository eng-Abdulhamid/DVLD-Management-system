using CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDPL
{
    
    internal class Shared
    {
        public static void ShowNotificaiton(string Message, string Title, IconType iconType)
        {
            NotificationBuilder Notify = new NotificationBuilder();

            Notify.WithMessage(Message)
            .WithDuration(3)
            .WithTitle(Title)
            .WithType(iconType)
            .WithProgressBar(true)
            .WithSound(false).WithPosition(NotificationPosition.BottomRight);
            Notify.Show();
        }
    }
}
