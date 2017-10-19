namespace Xam.Animations.Samples.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public class HomeViewModel : INotifyPropertyChanged
    {
        public string Title => this.animations[current].Key;

        public string NextTitle => this.animations[(current + 1) % animations.Length].Key;

        public IAnimation Current => this.animations[current].Value;

        private int current = 0;

        private KeyValuePair<string,IAnimation>[] animations =
        {
            new KeyValuePair<string, IAnimation>("FadeIn", Animations.FadeIn()),
            new KeyValuePair<string, IAnimation>("FadeOut", Animations.FadeOut()),
            new KeyValuePair<string, IAnimation>("ScaleIn", Animations.ScaleIn()),
            new KeyValuePair<string, IAnimation>("ScaleOut", Animations.ScaleOut()),
            new KeyValuePair<string, IAnimation>("ScaleInFromTop", Animations.ScaleInFromTop()),
            new KeyValuePair<string, IAnimation>("ScaleOutFromTop", Animations.ScaleOutFromTop()),
            new KeyValuePair<string, IAnimation>("ScaleInFromBottom", Animations.ScaleInFromBottom()),
            new KeyValuePair<string, IAnimation>("ScaleOutFromBottom", Animations.ScaleOutFromBottom()),
            new KeyValuePair<string, IAnimation>("ScaleInFromLeft", Animations.ScaleInFromLeft()),
            new KeyValuePair<string, IAnimation>("ScaleOutFromLeft", Animations.ScaleOutFromLeft()),
            new KeyValuePair<string, IAnimation>("ScaleInFromRight", Animations.ScaleInFromRight()),
            new KeyValuePair<string, IAnimation>("ScaleOutFromRight", Animations.ScaleOutFromRight()),
            new KeyValuePair<string, IAnimation>("SlideUpIn", Animations.SlideUpIn()),
            new KeyValuePair<string, IAnimation>("SlideUpOut", Animations.SlideUpOut()),
            new KeyValuePair<string, IAnimation>("SlideDownIn", Animations.SlideDownIn()),
            new KeyValuePair<string, IAnimation>("SlideDownOut", Animations.SlideDownOut()),
            new KeyValuePair<string, IAnimation>("SlideRightIn", Animations.SlideRightIn()),
            new KeyValuePair<string, IAnimation>("SlideRightOut", Animations.SlideRightOut()),
            new KeyValuePair<string, IAnimation>("SlideLeftIn", Animations.SlideLeftIn()),
            new KeyValuePair<string, IAnimation>("SlideLeftOut", Animations.SlideLeftOut()),
        };

        public void Next()
        {
            current = (current + 1) % animations.Length;
            this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Title)));
            this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(NextTitle)));
            this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(Current)));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
