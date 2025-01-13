using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using Photos;
using Facebook.CoreKit;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Facebook.ShareKit {
	// @interface FBSDKAppInviteContent : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppInviteContent")]
	interface AppInviteContent {
		// @property (copy, nonatomic) NSURL * _Nonnull appLinkURL;
		[Export ("appLinkURL", ArgumentSemantic.Copy)]
		NSUrl AppLinkUrl { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable appInvitePreviewImageURL;
		[NullAllowed]
		[Export ("appInvitePreviewImageURL", ArgumentSemantic.Copy)]
		NSUrl PreviewImageUrl { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable promotionCode;
		[NullAllowed]
		[Export ("promotionCode")]
		string PromotionCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable promotionText;
		[NullAllowed]
		[Export ("promotionText")]
		string PromotionText { get; set; }

		// @property (nonatomic) enum FBSDKAppInviteDestination destination;
		[Export ("destination", ArgumentSemantic.Assign)]
		AppInviteDestination Destination { get; set; }

		// -(instancetype _Nonnull)initWithAppLinkURL:(NSURL * _Nonnull)appLinkURL __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithAppLinkURL:")]
		NativeHandle Constructor (NSUrl appLinkUrl);
	}

	// @interface FBSDKCameraEffectArguments : NSObject <NSCopying, NSObject, NSSecureCoding>
	[BaseType (typeof (NSObject), Name = "FBSDKCameraEffectArguments")]
	interface CameraEffectArguments : INSCopying, INSSecureCoding {
		// -(void)setString:(NSString * _Nullable)string forKey:(NSString * _Nonnull)key;
		[Export ("setString:forKey:")]
		void SetString ([NullAllowed] string aString, string key);

		// -(NSString * _Nullable)stringForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
		[return: NullAllowed]
		[Export ("stringForKey:")]
		string GetString (string key);

		// -(void)setArray:(NSArray<NSString *> * _Nullable)array forKey:(NSString * _Nonnull)key;
		[Export ("setArray:forKey:")]
		void SetArray ([NullAllowed] string [] array, string key);

		// -(NSArray<NSString *> * _Nullable)arrayForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
		[return: NullAllowed]
		[Export ("arrayForKey:")]
		string [] GetArray (string key);
	}

	// @interface FBSDKCameraEffectTextures : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKCameraEffectTextures")]
	interface CameraEffectTextures {
		// -(void)setImage:(UIImage * _Nullable)image forKey:(NSString * _Nonnull)key;
		[Export ("setImage:forKey:")]
		void SetImage ([NullAllowed] UIImage image, string key);

		// -(UIImage * _Nullable)imageForKey:(NSString * _Nonnull)key __attribute__((warn_unused_result("")));
		[return: NullAllowed]
		[Export ("imageForKey:")]
		UIImage GetImage (string key);
	}

	// @interface FBSDKHashtag : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKHashtag")]
	interface Hashtag {
		// -(instancetype _Nonnull)initWithString:(NSString * _Nonnull)string __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithString:")]
		NativeHandle Constructor (string aString);

		// @property (copy, nonatomic) NSString * _Nonnull stringRepresentation;
		[Export ("stringRepresentation")]
		string StringRepresentation { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// @property (readonly, nonatomic) BOOL isValid;
		[Export ("isValid")]
		bool Valid { get; }

		// -(BOOL)isEqual:(id _Nullable)object __attribute__((warn_unused_result("")));
		[Export ("isEqual:")]
		bool Equals ([NullAllowed] NSObject @object);
	}

	// @interface FBSDKMessageDialog : NSObject <FBSDKSharingDialog>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FBSDKMessageDialog")]
	interface MessageDialog : SharingDialog {
		// -(instancetype _Nonnull)initWithContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate;
		[Export ("initWithContent:delegate:")]
		NativeHandle Constructor ([NullAllowed] ISharingContent content, [NullAllowed] SharingDelegate aDelegate);

		// +(FBSDKMessageDialog * _Nonnull)dialogWithContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
		[Static]
		[Export ("dialogWithContent:delegate:")]
		MessageDialog DialogWithContent ([NullAllowed] ISharingContent content, [NullAllowed] SharingDelegate aDelegate);

		// +(FBSDKMessageDialog * _Nonnull)showWithContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
		[Static]
		[Export ("showWithContent:delegate:")]
		MessageDialog ShowWithContent ([NullAllowed] ISharingContent content, [NullAllowed] SharingDelegate aDelegate);
	}
	
	// @protocol FBSDKButtonImpressionLogging <NSObject>
	[Protocol]
	[BaseType (typeof(NSObject), Name = "FBSDKButtonImpressionLogging")]
	interface ButtonImpressionLogging
	{
		// @required @property (readonly, copy, nonatomic) NSDictionary<FBSDKAppEventParameterName,id> * _Nullable analyticsParameters;
		[Abstract]
		[NullAllowed, Export ("analyticsParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AnalyticsParameters { get; }

		// @required @property (readonly, copy, nonatomic) FBSDKAppEventName _Nonnull impressionTrackingEventName;
		[Abstract]
		[Export ("impressionTrackingEventName")]
		string ImpressionTrackingEventName { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull impressionTrackingIdentifier;
		[Abstract]
		[Export ("impressionTrackingIdentifier")]
		string ImpressionTrackingIdentifier { get; }
	}

	// @interface FBSDKSendButton : FBSDKButton <FBSDKButtonImpressionLogging, FBSDKSharingButton>
	[BaseType (typeof(Button), Name = "FBSDKSendButton")]
	interface SendButton : SharingButton, ButtonImpressionLogging
	{
		// @property (nonatomic, strong) FBSDKMessageDialog * _Nullable dialog;
		[NullAllowed, Export ("dialog", ArgumentSemantic.Strong)]
		MessageDialog Dialog { get; set; }
	
		// @property (readonly, copy, nonatomic) NSDictionary<FBSDKAppEventParameterName,id> * _Nullable analyticsParameters;
		[NullAllowed, Export ("analyticsParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AnalyticsParameters { get; }
	
		// @property (readonly, nonatomic) FBSDKAppEventName _Nonnull impressionTrackingEventName;
		[Export ("impressionTrackingEventName")]
		string ImpressionTrackingEventName { get; }
	
		// @property (readonly, copy, nonatomic) NSString * _Nonnull impressionTrackingIdentifier;
		[Export ("impressionTrackingIdentifier")]
		string ImpressionTrackingIdentifier { get; }
	
		// @property (readonly, getter = isImplicitlyDisabled, nonatomic) BOOL implicitlyDisabled;
		[Export ("implicitlyDisabled")]
		bool ImplicitlyDisabled { [Bind ("isImplicitlyDisabled")] get; }
	
		// -(void)configureButton;
		[Export ("configureButton")]
		void ConfigureButton ();
	}

	// @interface FBSDKShareButton : FBSDKButton <FBSDKSharingButton>
	[BaseType (typeof(Button), Name = "FBSDKShareButton")]
	interface ShareButton : SharingButton {
		// @property (readonly, copy, nonatomic) NSDictionary<FBSDKAppEventParameterName,id> * _Nullable analyticsParameters;
		[NullAllowed, Export ("analyticsParameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AnalyticsParameters { get; }
	
		// @property (readonly, nonatomic) FBSDKAppEventName _Nonnull impressionTrackingEventName;
		[Export ("impressionTrackingEventName")]
		string ImpressionTrackingEventName { get; }
	
		// @property (readonly, copy, nonatomic) NSString * _Nonnull impressionTrackingIdentifier;
		[Export ("impressionTrackingIdentifier")]
		string ImpressionTrackingIdentifier { get; }
	
		// @property (readonly, getter = isImplicitlyDisabled, nonatomic) BOOL implicitlyDisabled;
		[Export ("implicitlyDisabled")]
		bool ImplicitlyDisabled { [Bind ("isImplicitlyDisabled")] get; }
	
		// -(void)configureButton;
		[Export ("configureButton")]
		void ConfigureButton ();
	
		// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)coder __attribute__((objc_designated_initializer));
		// [Export ("initWithCoder:")]
		// [DesignatedInitializer]
		// NativeHandle Constructor (NSCoder coder);
	}

	// @interface FBSDKShareCameraEffectContent : NSObject
	[BaseType (typeof(NSObject), Name = "FBSDKShareCameraEffectContent")]
	interface ShareCameraEffectContent {
		// @property (copy, nonatomic) NSString * _Nonnull effectID;
		[Export ("effectID")]
		string EffectId { get; set; }

		// @property (nonatomic, strong) FBSDKCameraEffectArguments * _Nonnull effectArguments;
		[Export ("effectArguments", ArgumentSemantic.Strong)]
		CameraEffectArguments EffectArguments { get; set; }

		// @property (nonatomic, strong) FBSDKCameraEffectTextures * _Nonnull effectTextures;
		[Export ("effectTextures", ArgumentSemantic.Strong)]
		CameraEffectTextures EffectTextures { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable contentURL;
		[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; set; }

		// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
		[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
		Hashtag Hashtag { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
		[Export ("peopleIDs", ArgumentSemantic.Copy)]
		string[] PeopleIds { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable placeID;
		[NullAllowed, Export ("placeID")]
		string PlaceId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ref;
		[NullAllowed, Export ("ref")]
		string Ref { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable pageID;
		[NullAllowed, Export ("pageID")]
		string PageId { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
		[NullAllowed, Export ("shareUUID")]
		string ShareUuid { get; }
	}

	// @interface FBSDKShareDialog : NSObject <FBSDKSharingDialog>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FBSDKShareDialog")]
	interface ShareDialog : SharingDialog {
		// @property (nonatomic, weak) UIViewController * _Nullable fromViewController;
		[NullAllowed, Export ("fromViewController", ArgumentSemantic.Weak)]
		UIViewController FromViewController { get; set; }

		// @property (nonatomic) enum FBSDKShareDialogMode mode;
		[Export ("mode", ArgumentSemantic.Assign)]
		ShareDialogMode Mode { get; set; }

		// -(instancetype _Nonnull)initWithViewController:(UIViewController * _Nullable)viewController content:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((objc_designated_initializer));
		[Export ("initWithViewController:content:delegate:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] UIViewController viewController, [NullAllowed] ISharingContent content, [NullAllowed] SharingDelegate @delegate);

		// +(FBSDKShareDialog * _Nonnull)dialogWithViewController:(UIViewController * _Nullable)viewController withContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate __attribute__((warn_unused_result("")));
		[Static]
		[Export ("dialogWithViewController:withContent:delegate:")]
		ShareDialog DialogWithViewController ([NullAllowed] UIViewController viewController, [NullAllowed] ISharingContent content, [NullAllowed] SharingDelegate aDelegate);

		// +(FBSDKShareDialog * _Nonnull)showFromViewController:(UIViewController * _Nullable)viewController withContent:(id<FBSDKSharingContent> _Nullable)content delegate:(id<FBSDKSharingDelegate> _Nullable)delegate;
		[Static]
		[Export ("showFromViewController:withContent:delegate:")]
		ShareDialog ShowFromViewController ([NullAllowed] UIViewController viewController, [NullAllowed] ISharingContent content, [NullAllowed] SharingDelegate aDelegate);
	}

	// @interface FBSDKShareLinkContent : NSObject
	[BaseType (typeof(NSObject), Name = "FBSDKShareLinkContent")]
	interface ShareLinkContent {
		// @property (copy, nonatomic) NSString * _Nullable quote;
		[NullAllowed]
		[Export ("quote")]
		string Quote { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable contentURL;
		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; set; }

		// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
		[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
		Hashtag Hashtag { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
		[Export ("peopleIDs", ArgumentSemantic.Copy)]
		string[] PeopleIds { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable placeID;
		[NullAllowed]
		[Export ("placeID")]
		string PlaceId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ref;
		[NullAllowed]
		[Export ("ref")]
		string Ref { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable pageID;
		[NullAllowed, Export ("pageID")]
		string PageId { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
		[NullAllowed]
		[Export ("shareUUID")]
		string ShareUuid { get; }
	}

	interface IShareMedia { }

	// @protocol FBSDKShareMedia <NSObject>
	[Protocol (Name = "FBSDKShareMedia")]
	interface ShareMedia { }

	// @interface FBSDKShareMediaContent : NSObject
	[BaseType (typeof(NSObject), Name = "FBSDKShareMediaContent")]
	interface ShareMediaContent {
		// @property (copy, nonatomic) NSArray<id<FBSDKShareMedia>> * _Nonnull media;
		[Export ("media", ArgumentSemantic.Copy)]
		IShareMedia[] Media { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable contentURL;
		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; set; }

		// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
		[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
		Hashtag Hashtag { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
		[Export ("peopleIDs", ArgumentSemantic.Copy)]
		string[] PeopleIds { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable placeID;
		[NullAllowed]
		[Export ("placeID")]
		string PlaceId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ref;
		[NullAllowed]
		[Export ("ref")]
		string Ref { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable pageID;
		[NullAllowed, Export ("pageID")]
		string PageId { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
		[NullAllowed]
		[Export ("shareUUID")]
		string ShareUuid { get; }
	}

	// @interface FBSDKSharePhoto : NSObject <FBSDKShareMedia>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FBSDKSharePhoto")]
	interface SharePhoto : ShareMedia {
		// @property (nonatomic, strong) UIImage * _Nullable image;
		[NullAllowed]
		[Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable imageURL;
		[NullAllowed]
		[Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; set; }

		// @property (nonatomic, strong) PHAsset * _Nullable photoAsset;
		[NullAllowed]
		[Export ("photoAsset", ArgumentSemantic.Strong)]
		PHAsset PhotoAsset { get; set; }

		// @property (nonatomic) BOOL isUserGenerated;
		[Export ("isUserGenerated")]
		bool UserGenerated { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable caption;
		[NullAllowed]
		[Export ("caption")]
		string Caption { get; set; }

		// -(instancetype _Nonnull)initWithImage:(UIImage * _Nonnull)image isUserGenerated:(BOOL)isUserGenerated;
		[Export ("initWithImage:isUserGenerated:")]
		NativeHandle Constructor (UIImage image, bool isUserGenerated);

		// -(instancetype _Nonnull)initWithImageURL:(NSURL * _Nonnull)imageURL isUserGenerated:(BOOL)isUserGenerated;
		[Export ("initWithImageURL:isUserGenerated:")]
		NativeHandle Constructor (NSUrl imageURL, bool isUserGenerated);

		// -(instancetype _Nonnull)initWithPhotoAsset:(PHAsset * _Nonnull)photoAsset isUserGenerated:(BOOL)isUserGenerated;
		[Export ("initWithPhotoAsset:isUserGenerated:")]
		NativeHandle Constructor (PHAsset photoAsset, bool isUserGenerated);
	}

	// @interface FBSDKSharePhotoContent : NSObject
	[BaseType (typeof(NSObject), Name = "FBSDKSharePhotoContent")]
	interface SharePhotoContent : SharingContent, ISharingContent {
		// @property (copy, nonatomic) NSArray<FBSDKSharePhoto *> * _Nonnull photos;
		[Export ("photos", ArgumentSemantic.Copy)]
		SharePhoto[] Photos { get; set; }
	}

	// @interface FBSDKShareVideo : NSObject <FBSDKShareMedia>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FBSDKShareVideo")]
	interface ShareVideo : ShareMedia {
		// @property (copy, nonatomic) NSData * _Nullable data;
		[NullAllowed, Export ("data", ArgumentSemantic.Copy)]
		NSData Data { get; set; }

		// @property (nonatomic, strong) PHAsset * _Nullable videoAsset;
		[NullAllowed, Export ("videoAsset", ArgumentSemantic.Strong)]
		PHAsset VideoAsset { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable videoURL;
		[NullAllowed, Export ("videoURL", ArgumentSemantic.Copy)]
		NSUrl VideoUrl { get; set; }

		// @property (nonatomic, strong) FBSDKSharePhoto * _Nullable previewPhoto;
		[NullAllowed, Export ("previewPhoto", ArgumentSemantic.Strong)]
		SharePhoto PreviewPhoto { get; set; }

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data previewPhoto:(FBSDKSharePhoto * _Nullable)previewPhoto;
		[Export ("initWithData:previewPhoto:")]
		NativeHandle Constructor (NSData data, [NullAllowed] SharePhoto previewPhoto);

		// -(instancetype _Nonnull)initWithVideoAsset:(PHAsset * _Nonnull)videoAsset previewPhoto:(FBSDKSharePhoto * _Nullable)previewPhoto;
		[Export ("initWithVideoAsset:previewPhoto:")]
		NativeHandle Constructor (PHAsset videoAsset, [NullAllowed] SharePhoto previewPhoto);

		// -(instancetype _Nonnull)initWithVideoURL:(NSURL * _Nonnull)videoURL previewPhoto:(FBSDKSharePhoto * _Nullable)previewPhoto;
		[Export ("initWithVideoURL:previewPhoto:")]
		NativeHandle Constructor (NSUrl videoURL, [NullAllowed] SharePhoto previewPhoto);
	}

	// @interface FBSDKShareVideoContent : NSObject
	[BaseType (typeof(NSObject), Name = "FBSDKShareVideoContent")]
	interface ShareVideoContent {
		// @property (nonatomic, strong) FBSDKShareVideo * _Nonnull video;
		[Export ("video", ArgumentSemantic.Strong)]
		ShareVideo Video { get; set; }

		// @property (copy, nonatomic) NSURL * _Nullable contentURL;
		[NullAllowed]
		[Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; set; }

		// @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
		[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
		Hashtag Hashtag { get; set; }

		// @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
		[Export ("peopleIDs", ArgumentSemantic.Copy)]
		string[] PeopleIds { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable placeID;
		[NullAllowed]
		[Export ("placeID")]
		string PlaceId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable ref;
		[NullAllowed]
		[Export ("ref")]
		string Ref { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable pageID;
		[NullAllowed]
		[Export ("pageID")]
		string PageId { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
		[NullAllowed]
		[Export ("shareUUID")]
		string ShareUuid { get; }
	}

	interface ISharing {

	}

	// @protocol FBSDKSharing
	[Protocol (Name = "FBSDKSharing")]
	interface Sharing {
		[Wrap ("WeakDelegate"), Abstract]
		[NullAllowed]
		SharingDelegate Delegate { get; set; }

		// @required @property (nonatomic, weak) id<FBSDKSharingDelegate> _Nullable delegate;
		[Abstract]
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @required @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
		[Abstract]
		[NullAllowed]
		[Export ("shareContent", ArgumentSemantic.Strong)]
		ISharingContent ShareContent { get; set; }

		// @required @property (nonatomic) BOOL shouldFailOnDataError;
		[Abstract]
		[Export ("shouldFailOnDataError")]
		bool ShouldFailOnDataError { get; set; }

		// @required -(BOOL)validateWithError:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("validateWithError:")]
		bool ValidateWithError ([NullAllowed] out NSError error);
	}

	interface ISharingDialog {

	}
	
	// @protocol FBSDKSharingDialog <FBSDKSharing>
	[Protocol (Name = "FBSDKSharingDialog")]
	interface SharingDialog : Sharing {
		// @required @property (readonly, nonatomic) BOOL canShow;
		[Abstract]
		[Export ("canShow")]
		bool CanShow { get; }

		// @required -(BOOL)show;
		[Abstract]
		[Export ("show")]
		bool Show ();
	}

	interface ISharingDelegate {

	}

	// @protocol FBSDKSharingDelegate <NSObject>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingDelegate")]
	interface SharingDelegate {

		// @required -(void)sharer:(id<FBSDKSharing> _Nonnull)sharer didCompleteWithResults:(NSDictionary<NSString *,id> * _Nonnull)results;
		[Abstract]
		[Export ("sharer:didCompleteWithResults:")]
		void Sharer (ISharing sharer, NSDictionary<NSString, NSObject> results);

		// @required -(void)sharer:(id<FBSDKSharing> _Nonnull)sharer didFailWithError:(NSError * _Nonnull)error;
		[Abstract]
		[Export ("sharer:didFailWithError:")]
		void Sharer (ISharing sharer, NSError error);

		// @required -(void)sharerDidCancel:(id<FBSDKSharing> _Nonnull)sharer;
		[Abstract]
		[Export ("sharerDidCancel:")]
		void SharerDidCancel (ISharing sharer);
	}

	interface ISharingButton {

	}

	// @protocol FBSDKSharingButton <NSObject>
	[Protocol (Name = "FBSDKSharingButton")]
	interface SharingButton {
		// @required @property (nonatomic, strong) id<FBSDKSharingContent> _Nullable shareContent;
		[Abstract]
		[NullAllowed, Export ("shareContent", ArgumentSemantic.Strong)]
		ISharingContent ShareContent { get; set; }
	}
	
	// @protocol FBSDKSharingValidatable
	[Protocol (Name = "FBSDKSharingValidatable")]
	interface SharingValidatable
	{
		// @required -(BOOL)validateWithOptions:(FBSDKShareBridgeOptions)options error:(NSError * _Nullable * _Nullable)error;
		[Abstract]
		[Export ("validateWithOptions:error:")]
		bool Error (ShareBridgeOptions options, [NullAllowed] out NSError error);
	}

	interface ISharingContent {

	}

	// @protocol FBSDKSharingContent <FBSDKSharingValidatable, NSObject>
#if NET
    [Model]
#else
	[Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSharingContent")]
	interface SharingContent : SharingValidatable {
		// @required @property (copy, nonatomic) NSURL * _Nullable contentURL;
		[Abstract]
		[NullAllowed, Export ("contentURL", ArgumentSemantic.Copy)]
		NSUrl ContentUrl { get; set; }

		// @required @property (nonatomic, strong) FBSDKHashtag * _Nullable hashtag;
		[Abstract]
		[NullAllowed, Export ("hashtag", ArgumentSemantic.Strong)]
		Hashtag Hashtag { get; set; }

		// @required @property (copy, nonatomic) NSArray<NSString *> * _Nonnull peopleIDs;
		[Abstract]
		[Export ("peopleIDs", ArgumentSemantic.Copy)]
		string[] PeopleIds { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable placeID;
		[Abstract]
		[NullAllowed, Export ("placeID")]
		string PlaceId { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable ref;
		[Abstract]
		[NullAllowed, Export ("ref")]
		string Ref { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable pageID;
		[Abstract]
		[NullAllowed, Export ("pageID")]
		string PageId { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable shareUUID;
		[Abstract]
		[NullAllowed, Export ("shareUUID")]
		string ShareUuid { get; }

		// @required -(NSDictionary<NSString *,id> * _Nonnull)addParameters:(NSDictionary<NSString *,id> * _Nonnull)existingParameters bridgeOptions:(FBSDKShareBridgeOptions)bridgeOptions __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("addParameters:bridgeOptions:")]
		NSDictionary<NSString, NSObject> BridgeOptions (NSDictionary<NSString, NSObject> existingParameters, ShareBridgeOptions bridgeOptions);
	}
}
