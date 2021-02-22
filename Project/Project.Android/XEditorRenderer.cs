using System;
using Xamarin.Forms;
using Project.Droid.Helpers;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Project.Helper;
using Android.Content;

[assembly: ExportRenderer(typeof(XEditor), typeof(XEditorRenderer))]
namespace Project.Droid.Helpers
{
 
    public class XEditorRenderer : EditorRenderer
        {
        public XEditorRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                }
            }
        }
    }
