using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHeaterApp
{
    public class MainNavigationPageFlyoutMenuItem
    {
        public MainNavigationPageFlyoutMenuItem()
        {
            TargetType = typeof(MainNavigationPageFlyoutMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}