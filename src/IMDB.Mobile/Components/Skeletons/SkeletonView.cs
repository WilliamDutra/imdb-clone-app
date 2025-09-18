using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Mobile.Components.Skeletons
{
    public class SkeletonView : BoxView
    {
        public SkeletonView()
        {
            Color = Color.FromHex("#c0c0c0");
            //var smoothAnimation = new Animation();

            //smoothAnimation.WithConcurrent(f => Opacity = f, start: 0.3, end: 1, Easing.SinIn);
            //smoothAnimation.WithConcurrent(f => Opacity = f, start: 1, end: 0.3, Easing.SinInOut);

            //this.Animate(name: "FadeInOut",
            //    animation: smoothAnimation,
            //    rate: 20,
            //    length: 1500,
            //    easing: Easing.SinIn,
            //    finished: null,
            //    repeat: () => true);
        }
    }
}
