using Android.Runtime;
using System;
using System.Linq;


namespace Xamarin.Facebook.Share.Widget
{
	public partial class ShareButtonBase
	{
		static Delegate cb_setEnabled_Z;
#pragma warning disable 0169
		static Delegate GetSetEnabled_ZHandler()
		{
			if (cb_setEnabled_Z == null)
				cb_setEnabled_Z = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, bool>)n_SetEnabled_Z);
			return cb_setEnabled_Z;
		}

		static void n_SetEnabled_Z(IntPtr jnienv, IntPtr native__this, bool enabled)
		{
			global::Xamarin.Facebook.Share.Widget.ShareButtonBase __this = global::Java.Lang.Object.GetObject<global::Xamarin.Facebook.Share.Widget.ShareButtonBase>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			__this.SetEnabled(enabled);
		}
#pragma warning restore 0169

		static IntPtr id_setEnabled_Z;
		// Metadata.xml XPath method reference: path="/api/package[@name='com.facebook.share.widget']/class[@name='ShareButtonBase']/method[@name='setEnabled' and count(parameter)=1 and parameter[1][@type='boolean']]"
		[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
		public unsafe void SetEnabled(bool enabled)
		{
			if (id_setEnabled_Z == IntPtr.Zero)
				id_setEnabled_Z = JNIEnv.GetMethodID(class_ref, "setEnabled", "(Z)V");
			try
			{
				JValue* __args = stackalloc JValue[1];
				__args[0] = new JValue(enabled);

				if (GetType() == ThresholdType)
					JNIEnv.CallVoidMethod(((global::Java.Lang.Object)this).Handle, id_setEnabled_Z, __args);
				else
					JNIEnv.CallNonvirtualVoidMethod(((global::Java.Lang.Object)this).Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setEnabled", "(Z)V"), __args);
			}
			finally
			{
			}
		}
	}

	public partial class GameRequestDialog
	{
		protected override global::System.Collections.IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}
	}

	public partial class MessageDialog
	{
		protected override global::System.Collections.IList _OrderedModeHandlers()
		{
			return OrderedModeHandlers.ToList();
		}
	}
}

