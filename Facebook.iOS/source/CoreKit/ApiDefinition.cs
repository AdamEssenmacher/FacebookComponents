using System;

using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
using WebKit;

#if !NET
using NativeHandle = System.IntPtr;
#endif

namespace Facebook.CoreKit {
	interface AccessTokenDidChangeEventArgs {
		[Export ("FBSDKAccessTokenChangeNewKey")]
		AccessToken NewToken { get; }

		[Export ("FBSDKAccessTokenDidChangeUserIDKey")]
		bool DidChangeUserIdToken { get; }

		[Export ("FBSDKAccessTokenChangeOldKey")]
		AccessToken OldToken { get; }

		[Export ("FBSDKAccessTokenDidExpire")]
		bool DidExpireKey { get; }
	}

	// @interface FBSDKAccessToken : NSObject <NSCopying, NSObject, NSSecureCoding, FBSDKAccessTokenProviding, FBSDKTokenStringProviding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAccessToken")]
	interface AccessToken : INSCopying, INSSecureCoding {

		// extern NS_SWIFT_NAME(AccessTokenDidChange) const NSNotificationName FBSDKAccessTokenDidChangeNotification __attribute__((swift_name("AccessTokenDidChange")));
		[Notification (typeof (AccessTokenDidChangeEventArgs))]
		[Field ("FBSDKAccessTokenDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		// extern NS_SWIFT_NAME(AccessTokenChangeNewKey) NSString *const FBSDKAccessTokenChangeNewKey __attribute__((swift_name("AccessTokenChangeNewKey")));
		[Field ("FBSDKAccessTokenChangeNewKey", "__Internal")]
		NSString NewTokenKey { get; }

		// extern NS_SWIFT_NAME(AccessTokenDidChangeUserIDKey) NSString *const FBSDKAccessTokenDidChangeUserIDKey __attribute__((swift_name("AccessTokenDidChangeUserIDKey")));
		[Field ("FBSDKAccessTokenDidChangeUserIDKey", "__Internal")]
		NSString UserIdKey { get; }

		// extern NS_SWIFT_NAME(AccessTokenChangeOldKey) NSString *const FBSDKAccessTokenChangeOldKey __attribute__((swift_name("AccessTokenChangeOldKey")));
		[Field ("FBSDKAccessTokenChangeOldKey", "__Internal")]
		NSString OldTokenKey { get; }

		// extern NS_SWIFT_NAME(AccessTokenDidExpireKey) NSString *const FBSDKAccessTokenDidExpireKey __attribute__((swift_name("AccessTokenDidExpireKey")));
		[Field ("FBSDKAccessTokenDidExpireKey", "__Internal")]
		NSString DidExpireKey { get; }

		// @property (copy, nonatomic, class) NS_SWIFT_NAME(current) FBSDKAccessToken * currentAccessToken __attribute__((swift_name("current")));
		[Static]
		[Export ("currentAccessToken", ArgumentSemantic.Copy)]
		AccessToken CurrentAccessToken { get; set; }

		// @property (readonly, getter = isCurrentAccessTokenActive, assign, nonatomic, class) BOOL currentAccessTokenIsActive;
		[Static]
		[Export ("isCurrentAccessTokenActive")]
		bool CurrentAccessTokenIsActive { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appID;
		[Export ("appID")]
		string AppId { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull dataAccessExpirationDate;
		[Export ("dataAccessExpirationDate", ArgumentSemantic.Copy)]
		NSDate DataAccessExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * declinedPermissions __attribute__((swift_private));
		[Export ("declinedPermissions", ArgumentSemantic.Copy)]
		NSSet DeclinedPermissions { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * expiredPermissions __attribute__((swift_private));
		[Export ("expiredPermissions", ArgumentSemantic.Copy)]
		NSSet ExpiredPermissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull expirationDate;
		[Export ("expirationDate", ArgumentSemantic.Copy)]
		NSDate ExpirationDate { get; }

		// @property (readonly, copy, nonatomic) NS_REFINED_FOR_SWIFT NSSet<NSString *> * permissions __attribute__((swift_private));
		[Export ("permissions", ArgumentSemantic.Copy)]
		NSSet Permissions { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull refreshDate;
		[Export ("refreshDate", ArgumentSemantic.Copy)]
		NSDate RefreshDate { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
		[Export ("tokenString", ArgumentSemantic.Copy)]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull userID;
		[Export ("userID", ArgumentSemantic.Copy)]
		string UserId { get; }

		// @property (readonly, getter = isExpired, assign, nonatomic) BOOL expired;
		[Export ("isExpired", ArgumentSemantic.Assign)]
		bool IsExpired { get; }

		// @property (readonly, getter = isDataAccessExpired, assign, nonatomic) BOOL dataAccessExpired;
		[Export ("isDataAccessExpired")]
		bool IsDataAccessExpired { get; }

		// -(instancetype _Nonnull)initWithTokenString:(NSString * _Nonnull)tokenString permissions:(NSArray<NSString *> * _Nonnull)permissions declinedPermissions:(NSArray<NSString *> * _Nonnull)declinedPermissions expiredPermissions:(NSArray<NSString *> * _Nonnull)expiredPermissions appID:(NSString * _Nonnull)appID userID:(NSString * _Nonnull)userID expirationDate:(NSDate * _Nullable)expirationDate refreshDate:(NSDate * _Nullable)refreshDate dataAccessExpirationDate:(NSDate * _Nullable)dataAccessExpirationDate __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithTokenString:permissions:declinedPermissions:expiredPermissions:appID:userID:expirationDate:refreshDate:dataAccessExpirationDate:")]
		NativeHandle Constructor (string tokenString, string [] permissions, string [] declinedPermissions, string [] expiredPermissions, string appId, string userId, [NullAllowed] NSDate expirationDate, [NullAllowed] NSDate refreshDate, [NullAllowed] NSDate dataAccessExpirationDate);

		// -(BOOL)hasGranted:(NSString * _Nonnull)permission __attribute__((swift_name("hasGranted(permission:)")));
		[Export ("hasGranted:")]
		bool HasGranted (string permission);

		// -(BOOL)isEqualToAccessToken:(FBSDKAccessToken * _Nonnull)token;
		[Export ("isEqualToAccessToken:")]
		bool Equals (AccessToken token);

		// +(void)refreshCurrentAccessTokenWithCompletion:(FBSDKGraphRequestCompletion _Nullable)completion;
		[Static]
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("refreshCurrentAccessToken:")]
		void RefreshCurrentAccessToken ([NullAllowed] GraphRequestCompletionHandler completionHandler);
	}

	// @interface FBSDKAppEvents : NSObject <FBSDKEventLogging, FBSDKAppEventsConfiguring, FBSDKApplicationActivating, FBSDKApplicationLifecycleObserving, FBSDKApplicationStateSetting, FBSDKSourceApplicationTracking, FBSDKUserIDProviding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppEvents")]
	interface AppEvents {

		// @property (readonly, nonatomic, strong, class) FBSDKAppEvents * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		AppEvents Shared { get; }

		// extern const NSNotificationName FBSDKAppEventsLoggingResultNotification __attribute__((swift_name("AppEventsLoggingResult")));
		[Notification]
		[Field ("FBSDKAppEventsLoggingResultNotification", "__Internal")]
		NSString LoggingResultNotification { get; }

		// extern NS_SWIFT_NAME(AppEventsOverrideAppIDBundleKey) NSString *const FBSDKAppEventsOverrideAppIDBundleKey __attribute__((swift_name("AppEventsOverrideAppIDBundleKey")));
		[Field ("FBSDKAppEventsOverrideAppIDBundleKey", "__Internal")]
		NSString OverrideAppIdBundleKey { get; }

		// @property (nonatomic) FBSDKAppEventsFlushBehavior flushBehavior;
		[Export ("flushBehavior", ArgumentSemantic.Assign)]
		AppEventsFlushBehavior FlushBehavior { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable loggingOverrideAppID;
		[NullAllowed]
		[Export ("loggingOverrideAppID")]
		string LoggingOverrideAppId { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable userID;
		[NullAllowed]
		[Export ("userID")]
		string UserId { get; set; }

		// @property (readonly, nonatomic) NSString * _Nonnull anonymousID;
		[Export ("anonymousID")]
		string AnonymousId { get; }

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName;
		[Protected]
		[Export ("logEvent:")]
		void LogEvent (NSString eventName);

		[Wrap ("LogEvent (eventName.GetConstant ())")]
		void LogEvent (AppEventName eventName);

		[Wrap ("LogEvent (new NSString (eventName))")]
		void LogEvent (string eventName);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum;
		[Protected]
		[Export ("logEvent:valueToSum:")]
		void LogEvent (NSString eventName, double valueToSum);

		[Wrap ("LogEvent (eventName.GetConstant (), valueToSum)")]
		void LogEvent (AppEventName eventName, double valueToSum);

		[Wrap ("LogEvent (new NSString (eventName), valueToSum)")]
		void LogEvent (string eventName, double valueToSum);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Protected]
		[Export ("logEvent:parameters:")]
		void LogEvent (NSString eventName, [NullAllowed] NSDictionary parameters);

		[Wrap ("LogEvent (eventName.GetConstant (), parameters)")]
		void LogEvent (AppEventName eventName, [NullAllowed] NSDictionary parameters);

		[Wrap ("LogEvent (new NSString (eventName), parameters)")]
		void LogEvent (string eventName, [NullAllowed] NSDictionary parameters);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(double)valueToSum parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters;
		[Protected]
		[Export ("logEvent:valueToSum:parameters:")]
		void LogEvent (NSString eventName, double valueToSum, [NullAllowed] NSDictionary parameters);

		[Wrap ("LogEvent (eventName.GetConstant (), valueToSum, parameters)")]
		void LogEvent (AppEventName eventName, double valueToSum, [NullAllowed] NSDictionary parameters);

		[Wrap ("LogEvent (new NSString (eventName), valueToSum, parameters)")]
		void LogEvent (string eventName, double valueToSum, [NullAllowed] NSDictionary parameters);

		// -(void)logEvent:(FBSDKAppEventName _Nonnull)eventName valueToSum:(NSNumber * _Nullable)valueToSum parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters accessToken:(FBSDKAccessToken * _Nullable)accessToken;
		[Protected]
		[Export ("logEvent:valueToSum:parameters:accessToken:")]
		void LogEvent (NSString eventName, [NullAllowed] NSNumber valueToSum, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		[Wrap ("LogEvent (eventName.GetConstant (), valueToSum, parameters, accessToken)")]
		void LogEvent (AppEventName eventName, [NullAllowed] NSNumber valueToSum, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		[Wrap ("LogEvent (new NSString (eventName), valueToSum, parameters, accessToken)")]
		void LogEvent (string eventName, [NullAllowed] NSNumber valueToSum, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// -(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency __attribute__((swift_name("logPurchase(amount:currency:)")));
		[Export ("logPurchase:currency:")]
		void LogPurchase (double purchaseAmount, string currency);

		// -(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters __attribute__((swift_name("logPurchase(amount:currency:parameters:)")));
		[Export ("logPurchase:currency:parameters:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters);

		// -(void)logPurchase:(double)purchaseAmount currency:(NSString * _Nonnull)currency parameters:(NSDictionary<FBSDKAppEventParameterName,id> * _Nullable)parameters accessToken:(FBSDKAccessToken * _Nullable)accessToken __attribute__((swift_name("logPurchase(amount:currency:parameters:accessToken:)")));
		[Export ("logPurchase:currency:parameters:accessToken:")]
		void LogPurchase (double purchaseAmount, string currency, [NullAllowed] NSDictionary parameters, [NullAllowed] AccessToken accessToken);

		// -(void)logPushNotificationOpen:(NSDictionary<NSString *,id> * _Nonnull)payload __attribute__((swift_name("logPushNotificationOpen(payload:)")));
		[Export ("logPushNotificationOpen:")]
		void LogPushNotificationOpen (NSDictionary payload);

		// -(void)logPushNotificationOpen:(NSDictionary<NSString *,id> * _Nonnull)payload action:(NSString * _Nonnull)action __attribute__((swift_name("logPushNotificationOpen(payload:action:)")));
		[Export ("logPushNotificationOpen:action:")]
		void LogPushNotificationOpen (NSDictionary payload, string action);

		// -(void)logProductItem:(NSString * _Nonnull)itemID availability:(FBSDKProductAvailability)availability condition:(FBSDKProductCondition)condition description:(NSString * _Nonnull)description imageLink:(NSString * _Nonnull)imageLink link:(NSString * _Nonnull)link title:(NSString * _Nonnull)title priceAmount:(double)priceAmount currency:(NSString * _Nonnull)currency gtin:(NSString * _Nullable)gtin mpn:(NSString * _Nullable)mpn brand:(NSString * _Nullable)brand parameters:(NSDictionary<NSString *,id> * _Nullable)parameters __attribute__((swift_name("logProductItem(id:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:)")));
		[Export ("logProductItem:availability:condition:description:imageLink:link:title:priceAmount:currency:gtin:mpn:brand:parameters:")]
		void LogProductItem (string itemId, ProductAvailability availability, ProductCondition condition, string description, string imageLink, string link, string title, double priceAmount, string currency, [NullAllowed] string gtin, [NullAllowed] string mpn, [NullAllowed] string brand, [NullAllowed] NSDictionary parameters);

		// -(void)activateApp;
		[Export ("activateApp")]
		void ActivateApp ();

		// -(void)setPushNotificationsDeviceToken:(NSData * _Nullable)deviceToken;
		[Export ("setPushNotificationsDeviceToken:")]
		void SetPushNotificationsDeviceToken ([NullAllowed] NSData deviceToken);

		// -(void)setPushNotificationsDeviceTokenString:(NSString * _Nullable)deviceTokenString __attribute__((swift_name("setPushNotificationsDeviceToken(_:)")));
		[Export ("setPushNotificationsDeviceTokenString:")]
		void SetPushNotificationsDeviceToken ([NullAllowed] string deviceTokenString);

		// -(void)flush;
		[Export ("flush")]
		void Flush ();

		// -(FBSDKGraphRequest * _Nullable)requestForCustomAudienceThirdPartyIDWithAccessToken:(FBSDKAccessToken * _Nullable)accessToken __attribute__((swift_name("requestForCustomAudienceThirdPartyID(accessToken:)")));
		[Export ("requestForCustomAudienceThirdPartyIDWithAccessToken:")]
		GraphRequest RequestForCustomAudienceThirdPartyId ([NullAllowed] AccessToken accessToken);

		// -(void)setUserEmail:(NSString * _Nullable)email firstName:(NSString * _Nullable)firstName lastName:(NSString * _Nullable)lastName phone:(NSString * _Nullable)phone dateOfBirth:(NSString * _Nullable)dateOfBirth gender:(NSString * _Nullable)gender city:(NSString * _Nullable)city state:(NSString * _Nullable)state zip:(NSString * _Nullable)zip country:(NSString * _Nullable)country __attribute__((swift_name("setUser(email:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:)")));
		[Export ("setUserEmail:firstName:lastName:phone:dateOfBirth:gender:city:state:zip:country:")]
		void SetUserEmail ([NullAllowed] string email, [NullAllowed] string firstName, [NullAllowed] string lastName, [NullAllowed] string phone, [NullAllowed] string dateOfBirth, [NullAllowed] string gender, [NullAllowed] string city, [NullAllowed] string state, [NullAllowed] string zip, [NullAllowed] string country);

		// -(NSString * _Nullable)getUserData;
		[return: NullAllowed]
		[Export ("getUserData")]
		string GetUserData ();

		// -(void)clearUserData;
		[Export ("clearUserData")]
		void ClearUserData ();

		// -(void)setUserData:(NSString * _Nullable)data forType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Export ("setUserData:forType:")]
		void SetUserData ([NullAllowed] string data, string type);

		// -(void)clearUserDataForType:(FBSDKAppEventUserDataType _Nonnull)type;
		[Export ("clearUserDataForType:")]
		void ClearUserDataForType (string type);

		// -(void)setIsUnityInitialized:(BOOL)isUnityInitialized;
		[Export ("setIsUnityInitialized:")]
		void SetIsUnityInitialized (bool isUnityInitialized);

		// -(void)sendEventBindingsToUnity;
		[Export ("sendEventBindingsToUnity")]
		void SendEventBindingsToUnity ();
	}

	// @interface FBSDKApplicationDelegate : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKApplicationDelegate")]
	interface ApplicationDelegate {

		// @property (readonly, nonatomic, strong, class) FBSDKApplicationDelegate * _Nonnull sharedInstance;
		[Static]
		[Export ("sharedInstance", ArgumentSemantic.Strong)]
		ApplicationDelegate SharedInstance { get; }

		// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication annotation:(id _Nullable)annotation;
		[Export ("application:openURL:sourceApplication:annotation:")]
		bool OpenUrl (UIApplication application, NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// -(BOOL)application:(UIApplication * _Nonnull)application openURL:(NSURL * _Nonnull)url options:(NSDictionary<UIApplicationOpenURLOptionsKey,id> * _Nonnull)options;
		[Export ("application:openURL:options:")]
		bool OpenUrl (UIApplication application, NSUrl url, NSDictionary options);

		// -(BOOL)application:(UIApplication * _Nonnull)application didFinishLaunchingWithOptions:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
		[Export ("application:didFinishLaunchingWithOptions:")]
		bool FinishedLaunching ([NullAllowed] UIApplication application, [NullAllowed] NSDictionary launchOptions);

		// -(void)initializeSDK;
		[Export ("initializeSDK")]
		void InitializeSdk ();
	}
	
	// @protocol FBSDKAppLink
	[Protocol (Name = "FBSDKAppLink")]
	interface AppLinkProtocol
	{
		// @required @property (readonly, nonatomic, strong) NSURL * _Nullable sourceURL;
		[Abstract]
		[NullAllowed, Export ("sourceURL", ArgumentSemantic.Strong)]
		NSUrl SourceUrl { get; }

		// @required @property (readonly, copy, nonatomic) NSArray<id<FBSDKAppLinkTarget>> * _Nonnull targets;
		[Abstract]
		[Export ("targets", ArgumentSemantic.Copy)]
		AppLinkTarget[] Targets { get; }

		// @required @property (readonly, nonatomic, strong) NSURL * _Nullable webURL;
		[Abstract]
		[NullAllowed, Export ("webURL", ArgumentSemantic.Strong)]
		NSUrl WebUrl { get; }

		// @required @property (readonly, getter = isBackToReferrer, assign, nonatomic) BOOL backToReferrer;
		[Abstract]
		[Export ("backToReferrer")]
		bool BackToReferrer { [Bind ("isBackToReferrer")] get; }
	}

	// @interface FBSDKAppLink : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLink")]
	interface AppLink : AppLinkProtocol, INativeObject {
		/// extern NSString *const FBSDKAppLinkVersion __attribute__((swift_name("AppLinkVersion")));
		[Field ("FBSDKAppLinkVersion", "__Internal")]
		NSString Version { get; }

		// -(instancetype _Nonnull)initWithSourceURL:(NSURL * _Nullable)sourceURL targets:(NSArray<id<FBSDKAppLinkTarget>> * _Nonnull)targets webURL:(NSURL * _Nullable)webURL;
		[Export ("initWithSourceURL:targets:webURL:")]
		NativeHandle Constructor ([NullAllowed] NSUrl sourceURL, AppLinkTarget[] targets, [NullAllowed] NSUrl webURL);

		// -(instancetype _Nonnull)initWithSourceURL:(NSURL * _Nullable)sourceURL targets:(NSArray<id<FBSDKAppLinkTarget>> * _Nonnull)targets webURL:(NSURL * _Nullable)webURL isBackToReferrer:(BOOL)isBackToReferrer __attribute__((objc_designated_initializer));
		[Export ("initWithSourceURL:targets:webURL:isBackToReferrer:")]
		[DesignatedInitializer]
		NativeHandle Constructor ([NullAllowed] NSUrl sourceURL, AppLinkTarget[] targets, [NullAllowed] NSUrl webURL, bool isBackToReferrer);
	}

	// typedef void (^FBSDKAppLinkNavigationBlock)(FBSDKAppLinkNavigationType, NSError * _Nullable);
	delegate void AppLinkNavigationBlockHandler (AppLinkNavigationType navType, [NullAllowed] NSError error);

	// @interface FBSDKAppLinkNavigation : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkNavigation")]
	interface AppLinkNavigation {
		// @property (nonatomic, strong, class) id<FBSDKAppLinkResolving> _Nonnull defaultResolver;
		[Static]
		[Export ("defaultResolver", ArgumentSemantic.Strong)]
		IAppLinkResolving DefaultResolver { get; set; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull extras;
		[Export ("extras", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Extras { get; }

		// @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull appLinkData;
		[Export ("appLinkData", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLink;
		[Export ("appLink", ArgumentSemantic.Strong)]
		AppLink AppLink { get; }

		// @property (readonly, nonatomic) FBSDKAppLinkNavigationType navigationType;
		[Export ("navigationType")]
		AppLinkNavigationType GetNavigationType ();

		// -(instancetype _Nonnull)initWithAppLink:(FBSDKAppLink * _Nullable)appLink extras:(NSDictionary<NSString *,id> * _Nonnull)extras appLinkData:(NSDictionary<NSString *,id> * _Nonnull)appLinkData __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithAppLink:extras:appLinkData:")]
		NativeHandle Constructor ([NullAllowed] AppLink appLink, NSDictionary<NSString, NSObject> extras, NSDictionary<NSString, NSObject> appLinkData);

		// +(NSDictionary<NSString *,NSDictionary<NSString *,NSString *> *> * _Nonnull)callbackAppLinkDataForAppWithName:(NSString * _Nonnull)appName url:(NSString * _Nonnull)url __attribute__((warn_unused_result("")));
		[Static]
		[Export ("callbackAppLinkDataForAppWithName:url:")]
		NSDictionary<NSString, NSDictionary<NSString, NSString>> GetCallbackAppLinkData (string appName, string url);

		// -(void)navigate:(FBSDKAppLinkNavigationBlock _Nullable)handler;
		[Export ("navigate:")]
		void Navigate ([NullAllowed] AppLinkNavigationBlockHandler handler);

		// +(void)resolveAppLink:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkBlock _Nonnull)handler;
		[Async]
		[Static]
		[Export ("resolveAppLink:handler:")]
		void ResolveAppLink (NSUrl destination, AppLinkBlockHandler handler);

		// +(void)resolveAppLink:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkBlock _Nonnull)handler;
		[Async]
		[Static]
		[Export ("resolveAppLink:resolver:handler:")]
		void ResolveAppLink (NSUrl destination, IAppLinkResolving resolver, AppLinkBlockHandler handler);

		// +(FBSDKAppLinkNavigationType)navigationTypeForLink:(FBSDKAppLink * _Nonnull)appLink __attribute__((warn_unused_result("")));
		[Static]
		[Export ("navigationTypeForLink:")]
		AppLinkNavigationType GetNavigationType (AppLink link);

		// +(void)navigateToURL:(NSURL * _Nonnull)destination handler:(FBSDKAppLinkNavigationBlock _Nonnull)handler;
		[Async]
		[Static]
		[Export ("navigateToURL:handler:")]
		void Navigate (NSUrl destination, AppLinkNavigationBlockHandler handler);

		// +(void)navigateToURL:(NSURL * _Nonnull)destination resolver:(id<FBSDKAppLinkResolving> _Nonnull)resolver handler:(FBSDKAppLinkNavigationBlock _Nonnull)handler;
		[Async]
		[Static]
		[Export ("navigateToURL:resolver:handler:")]
		void Navigate (NSUrl destination, IAppLinkResolving resolver, AppLinkNavigationBlockHandler handler);
	}

	// typedef void (^FBSDKAppLinksBlock)(NSDictionary<NSURL *,FBSDKAppLink *> * _Nonnull, NSError * _Nullable);
	delegate void AppLinksBlockHandler (NSDictionary<NSUrl, AppLink> appLinks, [NullAllowed] NSError error);

	// @interface FBSDKAppLinkResolver : NSObject<AppLinkResolving>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolver")]
	interface AppLinkResolver : AppLinkResolving {
		// -(void)appLinksFrom:(NSArray<NSURL *> * _Nonnull)urls handler:(FBSDKAppLinksBlock _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)));
		[Async]
		[Export ("appLinksFrom:handler:")]
		void GetAppLinks (NSUrl [] urls, AppLinksBlockHandler handler);
	}

	// typedef void (^FBSDKAppLinkBlock)(FBSDKAppLink * _Nullable, NSError * _Nullable);
	delegate void AppLinkBlockHandler ([NullAllowed] AppLink appLink, [NullAllowed] NSError error);

	interface IAppLinkResolving { }

	// @protocol FBSDKAppLinkResolving <NSObject>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkResolving")]
	interface AppLinkResolving {
		// @required -(void)appLinkFromURL:(NSURL * _Nonnull)url handler:(FBSDKAppLinkBlock _Nonnull)handler __attribute__((availability(ios_app_extension, unavailable)));
		[Abstract]
		[Export ("appLinkFromURL:handler:")]
		void Handler (NSUrl url, AppLinkBlockHandler handler);
	}

	interface IAppLinkTargetProtocol { }

	// @protocol FBSDKAppLinkTarget
	[Protocol (Name = "FBSDKAppLinkTarget")]
	interface AppLinkTargetProtocol
	{
		// @required +(instancetype _Nonnull)appLinkTargetWithURL:(NSURL * _Nullable)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName __attribute__((swift_name("init(url:appStoreId:appName:)")));
		[Static, Abstract]
		[Export ("appLinkTargetWithURL:appStoreId:appName:")]
		IAppLinkTargetProtocol Create ([NullAllowed] NSUrl url, [NullAllowed] string appStoreId, string appName);

		// @required @property (readonly, nonatomic) NSURL * _Nullable URL;
		[Abstract]
		[NullAllowed, Export ("URL")]
		NSUrl Url { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable appStoreId;
		[Abstract]
		[NullAllowed, Export ("appStoreId")]
		string AppStoreId { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull appName;
		[Abstract]
		[Export ("appName")]
		string AppName { get; }
	}
	
	// @interface FBSDKAppLinkTarget : NSObject <FBSDKAppLinkTarget>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkTarget")]
	interface AppLinkTarget : AppLinkTargetProtocol {
		// -(instancetype _Nonnull)initWithURL:(NSURL * _Nullable)url appStoreId:(NSString * _Nullable)appStoreId appName:(NSString * _Nonnull)appName __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithURL:appStoreId:appName:")]
		NativeHandle Constructor ([NullAllowed] NSUrl url, [NullAllowed] string appStoreId, string appName);

		// @property (readonly, copy, nonatomic) NSURL * _Nullable URL;
		[NullAllowed]
		[Export ("URL", ArgumentSemantic.Strong)]
		NSUrl Url { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable appStoreId;
		[NullAllowed]
		[Export ("appStoreId")]
		string AppStoreId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull appName;
		[Export ("appName")]
		string AppName { get; }
	}

	// typedef void (^FBSDKURLBlock)(NSURL * _Nullable, NSError * _Nullable);
	delegate void UrlBlockHandler ([NullAllowed] NSUrl url, [NullAllowed] NSError error);

	// @interface FBSDKAppLinkUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAppLinkUtility")]
	interface AppLinkUtility {

		// +(void)fetchDeferredAppLink:(FBSDKURLBlock _Nullable)handler;
		[Static]
		[Async]
		[Export ("fetchDeferredAppLink:")]
		void FetchDeferredAppLink (UrlBlockHandler handler);

		// +(NSString * _Nullable)appInvitePromotionCodeFromURL:(NSURL * _Nonnull)url;
		[Static]
		[Export ("appInvitePromotionCodeFromURL:")]
		string AppInvitePromotionCode (NSUrl url);

		// +(BOOL)isMatchURLScheme:(NSString * _Nonnull)scheme;
		[Static]
		[Export ("isMatchURLScheme:")]
		bool IsMatchUrlScheme (string scheme);
	}

	// @interface FBSDKImpressionLoggingButton : UIButton
	[BaseType (typeof(UIButton), Name = "FBSDKImpressionLoggingButton")]
	interface ImpressionLoggingButton { }

	// @interface FBSDKButton : FBSDKImpressionLoggingButton
	[BaseType (typeof (ImpressionLoggingButton), Name = "FBSDKButton")]
	interface Button {
	}

	[Static]
	interface Errors {
		// extern NS_SWIFT_NAME(ErrorDomain) const NSErrorDomain FBSDKErrorDomain __attribute__((swift_name("ErrorDomain")));
		[Field ("FBSDKErrorDomain", "__Internal")]
		NSString DomainKey { get; }

		// extern NS_SWIFT_NAME(ErrorArgumentCollectionKey) const NSErrorUserInfoKey FBSDKErrorArgumentCollectionKey __attribute__((swift_name("ErrorArgumentCollectionKey")));
		[Field ("FBSDKErrorArgumentCollectionKey", "__Internal")]
		NSString ArgumentCollectionKey { get; }

		// extern NS_SWIFT_NAME(ErrorArgumentNameKey) const NSErrorUserInfoKey FBSDKErrorArgumentNameKey __attribute__((swift_name("ErrorArgumentNameKey")));
		[Field ("FBSDKErrorArgumentNameKey", "__Internal")]
		NSString ArgumentNameKey { get; }

		// extern NS_SWIFT_NAME(ErrorArgumentValueKey) const NSErrorUserInfoKey FBSDKErrorArgumentValueKey __attribute__((swift_name("ErrorArgumentValueKey")));
		[Field ("FBSDKErrorArgumentValueKey", "__Internal")]
		NSString ArgumentValueKey { get; }

		// extern NS_SWIFT_NAME(ErrorDeveloperMessageKey) const NSErrorUserInfoKey FBSDKErrorDeveloperMessageKey __attribute__((swift_name("ErrorDeveloperMessageKey")));
		[Field ("FBSDKErrorDeveloperMessageKey", "__Internal")]
		NSString DeveloperMessageKey { get; }

		// extern NS_SWIFT_NAME(ErrorLocalizedDescriptionKey) const NSErrorUserInfoKey FBSDKErrorLocalizedDescriptionKey __attribute__((swift_name("ErrorLocalizedDescriptionKey")));
		[Field ("FBSDKErrorLocalizedDescriptionKey", "__Internal")]
		NSString LocalizedDescriptionKey { get; }

		// extern NS_SWIFT_NAME(ErrorLocalizedTitleKey) const NSErrorUserInfoKey FBSDKErrorLocalizedTitleKey __attribute__((swift_name("ErrorLocalizedTitleKey")));
		[Field ("FBSDKErrorLocalizedTitleKey", "__Internal")]
		NSString LocalizedTitleKey { get; }
	}

	[Static]
	interface GraphRequestErrors {
		// extern NS_SWIFT_NAME(GraphRequestErrorKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorKey __attribute__((swift_name("GraphRequestErrorKey")));
		[Field ("FBSDKGraphRequestErrorKey", "__Internal")]
		NSString ErrorKey { get; }

		// extern NS_SWIFT_NAME(GraphRequestErrorGraphErrorCodeKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorCodeKey __attribute__((swift_name("GraphRequestErrorGraphErrorCodeKey")));
		[Field ("FBSDKGraphRequestErrorGraphErrorCodeKey", "__Internal")]
		NSString GraphErrorCodeKey { get; }

		// extern NS_SWIFT_NAME(GraphRequestErrorGraphErrorSubcodeKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorGraphErrorSubcodeKey __attribute__((swift_name("GraphRequestErrorGraphErrorSubcodeKey")));
		[Field ("FBSDKGraphRequestErrorGraphErrorSubcodeKey", "__Internal")]
		NSString GraphErrorSubcodeKey { get; }

		// extern NS_SWIFT_NAME(GraphRequestErrorHTTPStatusCodeKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorHTTPStatusCodeKey __attribute__((swift_name("GraphRequestErrorHTTPStatusCodeKey")));
		[Field ("FBSDKGraphRequestErrorHTTPStatusCodeKey", "__Internal")]
		NSString HttpStatusCodeKey { get; }

		// extern NS_SWIFT_NAME(GraphRequestErrorParsedJSONResponseKey) const NSErrorUserInfoKey FBSDKGraphRequestErrorParsedJSONResponseKey __attribute__((swift_name("GraphRequestErrorParsedJSONResponseKey")));
		[Field ("FBSDKGraphRequestErrorParsedJSONResponseKey", "__Internal")]
		NSString ParsedJsonResponseKey { get; }
	}

	// typedef void (^FBSDKCodeBlock)();
	delegate void CodeBlockHandler ();

	// typedef void (^FBSDKErrorBlock)(NSError * _Nullable);
	delegate void ErrorBlockHandler ([NullAllowed] NSError error);

	// typedef void (^FBSDKSuccessBlock)(BOOL, NSError * _Nullable);
	delegate void SuccessBlockHandler (bool success, [NullAllowed] NSError error);

	interface IErrorRecoveryAttempting { }

	// @protocol FBSDKErrorRecoveryAttempting <NSObject>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKErrorRecoveryAttempting")]
	interface ErrorRecoveryAttempting {
		// @required -(void)attemptRecoveryFromError:(NSError * _Nonnull)error completionHandler:(void (^ _Nonnull)(BOOL))completionHandler __attribute__((swift_name("attemptRecovery(from:completion:)")));
		[Abstract]
		[Export ("attemptRecoveryFromError:completionHandler:")]
		void AttemptRecovery (NSError error, Action<bool> completionHandler);
	}

	interface IGraphErrorRecoveryProcessorDelegate { }

	// @protocol FBSDKGraphErrorRecoveryProcessorDelegate <NSObject>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessorDelegate")]
	interface GraphErrorRecoveryProcessorDelegate {

		// @required -(void)processorDidAttemptRecovery:(FBSDKGraphErrorRecoveryProcessor * _Nonnull)processor didRecover:(BOOL)didRecover error:(NSError * _Nullable)error;
		[Abstract]
		[Export ("processorDidAttemptRecovery:didRecover:error:")]
		void DidAttemptRecovery (GraphErrorRecoveryProcessor processor, bool didRecover, [NullAllowed] NSError error);

		// @optional -(BOOL)processorWillProcessError:(FBSDKGraphErrorRecoveryProcessor * _Nonnull)processor error:(NSError * _Nullable)error;
		[Export ("processorWillProcessError:error:")]
		bool WillProcessError (GraphErrorRecoveryProcessor processor, [NullAllowed] NSError error);
	}

	// @interface FBSDKGraphErrorRecoveryProcessor : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGraphErrorRecoveryProcessor")]
	interface GraphErrorRecoveryProcessor {

		// -(instancetype _Nonnull)initWithAccessTokenString:(NSString * _Nonnull)accessTokenString;
		[Export ("initWithAccessTokenString:")]
		NativeHandle Constructor (string accessTokenString);

		// -(BOOL)processError:(NSError * _Nonnull)error request:(id<FBSDKGraphRequest> _Nonnull)request delegate:(id<FBSDKGraphErrorRecoveryProcessorDelegate> _Nullable)delegate;
		[Export ("processError:request:delegate:")]
		bool ProcessError (NSError error, GraphRequest request, [NullAllowed] IGraphErrorRecoveryProcessorDelegate aDelegate);
	}

	interface IGraphRequestProtocol { }

	// @protocol FBSDKGraphRequest
	[Protocol (Name = "FBSDKGraphRequest")]
	interface GraphRequestProtocol
	{
		// @required @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull parameters;
		[Abstract]
		[Export ("parameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Parameters { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable tokenString;
		[Abstract]
		[NullAllowed, Export ("tokenString")]
		string TokenString { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull graphPath;
		[Abstract]
		[Export ("graphPath")]
		string GraphPath { get; }

		// @required @property (readonly, copy, nonatomic) FBSDKHTTPMethod _Nonnull HTTPMethod;
		[Abstract]
		[Export ("HTTPMethod")]
		HttpMethod HttpMethod { get; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Abstract]
		[Export ("version")]
		string Version { get; }

		// @required @property (readonly, assign, nonatomic) FBSDKGraphRequestFlags flags;
		[Export ("flags", ArgumentSemantic.Assign)]
		GraphRequestFlags GetFlags ();

		// @required @property (getter = isGraphErrorRecoveryDisabled, nonatomic) BOOL graphErrorRecoveryDisabled;
		[Export ("isGraphErrorRecoveryDisabled")]
		bool IsGraphErrorRecoveryDisabled ();

		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disable);

		// @required @property (readonly, nonatomic) BOOL hasAttachments;
		[Export ("hasAttachments")]
		bool HasAttachments ();

		// @required -(id<FBSDKGraphRequestConnecting> _Nonnull)startWithCompletion:(FBSDKGraphRequestCompletion _Nullable)completion;
		[Abstract]
		[Export ("startWithCompletion:")]
		IGraphRequestConnecting Start ([NullAllowed] GraphRequestCompletionHandler completion);

		// @required -(NSString * _Nonnull)formattedDescription;
		[Export ("formattedDescription")]
		string GetFormattedDescription ();
	}

	// @interface FBSDKGraphRequest : NSObject <FBSDKGraphRequest>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequest")]
	interface GraphRequest : GraphRequestProtocol {
		// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath;
		[Export ("initWithGraphPath:")]
		NativeHandle Constructor (string graphPath);

		// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
		[Internal]
		[Export ("initWithGraphPath:HTTPMethod:")]
		NativeHandle Constructor (string graphPath, NSString method);

		[Wrap ("this (graphPath, method.GetConstant ())")]
		NativeHandle Constructor (string graphPath, HttpMethod method);

		[Wrap ("this (graphPath, new NSString (method))")]
		NativeHandle Constructor (string graphPath, string method);

		// -(instancetype)initWithGraphPath:(NSString *)graphPath parameters:(NSDictionary *)parameters;
		[Export ("initWithGraphPath:parameters:")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters);

		// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
		[Internal]
		[Export ("initWithGraphPath:parameters:HTTPMethod:")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters, NSString method);

		[Wrap ("this (graphPath, parameters, method.GetConstant ())")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters, HttpMethod method);

		[Wrap ("this (graphPath, parameters, new NSString (method))")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters, string method);

		// -(instancetype _Nonnull)initWithGraphPath:(NSString * _Nonnull)graphPath parameters:(NSDictionary<NSString *,id> * _Nonnull)parameters tokenString:(NSString * _Nullable)tokenString version:(NSString * _Nullable)version HTTPMethod:(FBSDKHTTPMethod _Nonnull)method;
		[DesignatedInitializer]
		[Internal]
		[Export ("initWithGraphPath:parameters:tokenString:version:HTTPMethod:")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, [NullAllowed] NSString method);

		[Wrap ("this (graphPath, parameters, tokenString, version, method.GetConstant ())")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, HttpMethod method);

		[Wrap ("this (graphPath, parameters, tokenString, version, new NSString (method))")]
		NativeHandle Constructor (string graphPath, [NullAllowed] NSDictionary parameters, [NullAllowed] string tokenString, [NullAllowed] string version, string method);

		// @property (copy, nonatomic) NSDictionary<NSString *,id> * _Nonnull parameters;
		[Export ("parameters", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> Parameters { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable tokenString;
		[NullAllowed]
		[Export ("tokenString")]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull graphPath;
		[Export ("graphPath")]
		string GraphPath { get; }

		// @property (readonly, copy, nonatomic) FBSDKHTTPMethod _Nonnull HTTPMethod;
		[BindAs (typeof (HttpMethod))]
		[Export ("HTTPMethod")]
		NSString HttpMethod { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull version;
		[Export ("version")]
		string Version { get; }

		// -(void)setGraphErrorRecoveryDisabled:(BOOL)disable __attribute__((swift_name("setGraphErrorRecovery(disabled:)")));
		[Export ("setGraphErrorRecoveryDisabled:")]
		void SetGraphErrorRecoveryDisabled (bool disable);

		// -(id<FBSDKGraphRequestConnecting> _Nonnull)startWithCompletion:(FBSDKGraphRequestCompletion _Nullable)completion;
		[Export ("startWithCompletion:")]
		IGraphRequestConnecting Start ([NullAllowed] GraphRequestCompletionHandler handler);
	}

	// typedef void (^FBSDKGraphRequestCompletion)(id<FBSDKGraphRequestConnecting> _Nullable, id _Nullable, NSError * _Nullable);
	delegate void GraphRequestCompletionHandler([NullAllowed] IGraphRequestConnecting connection, [NullAllowed] NSObject result, [NullAllowed] NSError error);

	interface IGraphRequestConnecting { }

	[Protocol (Name = "FBSDKGraphRequestConnecting")]
	interface GraphRequestConnecting
	{
		// @required @property (assign, nonatomic) NSTimeInterval timeout;
		[Abstract]
		[Export ("timeout")]
		double Timeout { get; set; }

		// @required @property (nonatomic, weak) id<FBSDKGraphRequestConnectionDelegate> _Nullable delegate;
		[Abstract]
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		IGraphRequestConnectionDelegate Delegate { get; set; }
		
		// @required -(void)addRequest:(id<FBSDKGraphRequest> _Nonnull)request completion:(FBSDKGraphRequestCompletion _Nonnull)handler;
		[Abstract]
		[Export ("addRequest:completion:")]
		void AddRequest (IGraphRequestProtocol request, GraphRequestCompletionHandler handler);

		// @required -(void)start;
		[Abstract]
		[Export ("start")]
		void Start ();

		// @required -(void)cancel;
		[Abstract]
		[Export ("cancel")]
		void Cancel ();
	}

	interface IGraphRequestConnectionDelegate { }

	// @protocol FBSDKGraphRequestConnectionDelegate <NSObject>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestConnectionDelegate")]
	interface GraphRequestConnectionDelegate {

		// @optional -(void)requestConnectionWillBeginLoading:(id<FBSDKGraphRequestConnecting> _Nonnull)connection;
		[Export ("requestConnectionWillBeginLoading:")]
		void WillBeginLoading (IGraphRequestConnecting connection);

		// @optional -(void)requestConnectionDidFinishLoading:(id<FBSDKGraphRequestConnecting> _Nonnull)connection;
		[Export ("requestConnectionDidFinishLoading:")]
		void DidFinishLoading (IGraphRequestConnecting connection);

		// @optional -(void)requestConnection:(id<FBSDKGraphRequestConnecting> _Nonnull)connection didFailWithError:(NSError * _Nonnull)error;
		[Export ("requestConnection:didFailWithError:")]
		void DidFail (IGraphRequestConnecting connection, NSError error);

		// @optional -(void)requestConnection:(id<FBSDKGraphRequestConnecting> _Nonnull)connection didSendBodyData:(NSInteger)bytesWritten totalBytesWritten:(NSInteger)totalBytesWritten totalBytesExpectedToWrite:(NSInteger)totalBytesExpectedToWrite;
		[Export ("requestConnection:didSendBodyData:totalBytesWritten:totalBytesExpectedToWrite:")]
		void DidSendBodyData (IGraphRequestConnecting connection, nint bytesWritten, nint totalBytesWritten, nint totalBytesExpectedToWrite);
	}

	// @interface FBSDKGraphRequestConnection : NSObject
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestConnection")]
	interface GraphRequestConnection : GraphRequestConnecting {

		// extern NS_SWIFT_NAME(NonJSONResponseProperty) NSString *const FBSDKNonJSONResponseProperty __attribute__((swift_name("NonJSONResponseProperty")));
		[Field ("FBSDKNonJSONResponseProperty", "__Internal")]
		NSString NonJsonResponsePropertyKey { get; }

		// @property (assign, nonatomic, class) NSTimeInterval defaultConnectionTimeout;
		[Static]
		[Export ("defaultConnectionTimeout")]
		double DefaultConnectionTimeout { get; set; }

		// @property (nonatomic, weak) id<FBSDKGraphRequestConnectionDelegate> _Nullable delegate;
		[NullAllowed]
		[Export ("delegate", ArgumentSemantic.Weak)]
		IGraphRequestConnectionDelegate Delegate { get; set; }

		// @property (assign, nonatomic) NSTimeInterval timeout;
		[Export ("timeout", ArgumentSemantic.Assign)]
		double Timeout { get; set; }

		// @property (readonly, retain, nonatomic) NSHTTPURLResponse * _Nullable urlResponse;
		[NullAllowed]
		[Export ("URLResponse", ArgumentSemantic.Retain)]
		NSHttpUrlResponse UrlResponse { get; }

		// @property (nonatomic) NSOperationQueue * _Nullable delegateQueue;
		[Export ("delegateQueue", ArgumentSemantic.Retain)]
		NSOperationQueue DelegateQueue { get; set; }

		// -(void)addRequest:(id<FBSDKGraphRequest> _Nonnull)request completion:(FBSDKGraphRequestCompletion _Nonnull)completion;
		[Async (ResultTypeName = "GraphRequestResult")]
		[Export ("addRequest:completion:")]
		void AddRequest (IGraphRequestProtocol request, GraphRequestCompletionHandler handler);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// -(void)start;
		[Export ("start")]
		void Start ();

		// -(void)overrideGraphAPIVersion:(NSString * _Nonnull)version;
		[Export ("overrideGraphAPIVersion:")]
		void OverrideGraphApiVersion (string version);
	}

	// @interface FBSDKGraphRequestDataAttachment : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKGraphRequestDataAttachment")]
	interface GraphRequestDataAttachment {
		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data filename:(NSString * _Nonnull)filename contentType:(NSString * _Nonnull)contentType __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithData:filename:contentType:")]
		NativeHandle Constructor ([NullAllowed] NSData data, string filename, string contentType);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull contentType;
		[Export ("contentType", ArgumentSemantic.Copy)]
		string ContentType { get; }

		// @property (readonly, nonatomic, strong) NSData * _Nonnull data;
		[Export ("data", ArgumentSemantic.Strong)]
		NSData Data { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull filename;
		[Export ("filename", ArgumentSemantic.Copy)]
		string Filename { get; }
	}
	
	// @protocol FBSDKAppLinkEventPosting
	[Protocol (Name = "FBSDKAppLinkEventPosting")]
	interface AppLinkEventPosting
	{
		// @required -(void)postNotificationForEventName:(NSString * _Nonnull)name args:(NSDictionary<NSString *,id> * _Nonnull)args __attribute__((swift_name("postNotification(eventName:arguments:)")));
		[Abstract]
		[Export ("postNotificationForEventName:args:")]
		void PostNotification (string eventName, NSDictionary<NSString, NSObject> args);
	}

	// @interface FBSDKMeasurementEvent : NSObject <FBSDKAppLinkEventPosting>
	[BaseType (typeof (NSObject), Name = "FBSDKMeasurementEvent")]
	interface MeasurementEvent : AppLinkEventPosting { }

	interface IMutableCopying { }

	// @protocol FBSDKMutableCopying <NSCopying, NSObject, NSMutableCopying>
#if NET
    [Model]
#else
    [Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKMutableCopying")]
	interface MutableCopying : INSCopying, INSMutableCopying {

		// @required -(id _Nonnull)mutableCopy;
		[New]
		[Abstract]
		[Export ("mutableCopy")]
		NSObject MutableCopy ();
	}

	interface ProfileDidChangeEventArgs {
		// extern NS_SWIFT_NAME(ProfileChangeOldKey) NSString *const FBSDKProfileChangeOldKey __attribute__((swift_name("ProfileChangeOldKey")));
		[Export ("FBSDKProfileChangeOldKey")]
		Profile OldProfile { get; }

		// extern NS_SWIFT_NAME(ProfileChangeNewKey) NSString *const FBSDKProfileChangeNewKey __attribute__((swift_name("ProfileChangeNewKey")));
		[Export ("FBSDKProfileChangeNewKey")]
		Profile NewProfile { get; }
	}

	// typedef void (^FBSDKProfileBlock)(FBSDKProfile * _Nullable, NSError * _Nullable);
	delegate void ProfileBlockHandler ([NullAllowed] Profile profile, [NullAllowed] NSError error);

	// @interface FBSDKLocation : NSObject <NSCopying, NSObject, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FBSDKLocation")]
	interface Location : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull id;
		[Export ("id", ArgumentSemantic.Strong)]
		string Id { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nonnull name;
		[Export ("name", ArgumentSemantic.Strong)]
		string Name { get; }

		// +(instancetype _Nullable)locationFromDictionary:(NSDictionary<NSString *,NSString *> * _Nonnull)dictionary;
		[Static]
		[Export ("locationFromDictionary:")]
		[return: NullAllowed]
		Location LocationFromDictionary (NSDictionary<NSString, NSString> dictionary);
	}

	// @interface FBSDKUserAgeRange : NSObject <NSCopying, NSObject, NSSecureCoding>
	[DisableDefaultCtor]
	[BaseType (typeof(NSObject), Name = "FBSDKUserAgeRange")]
	interface UserAgeRange : INSCopying, INSSecureCoding
	{
		// @property (readonly, nonatomic, strong) NSNumber * _Nullable min;
		[NullAllowed, Export ("min", ArgumentSemantic.Strong)]
		NSNumber Min { get; }

		// @property (readonly, nonatomic, strong) NSNumber * _Nullable max;
		[NullAllowed, Export ("max", ArgumentSemantic.Strong)]
		NSNumber Max { get; }

		// +(instancetype _Nullable)ageRangeFromDictionary:(NSDictionary<NSString *,NSNumber *> * _Nonnull)dictionary;
		[Static]
		[Export ("ageRangeFromDictionary:")]
		[return: NullAllowed]
		UserAgeRange AgeRangeFromDictionary (NSDictionary<NSString, NSNumber> dictionary);
	}

	// @interface FBSDKProfile : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKProfile")]
	interface Profile : INSCopying, INSSecureCoding {

		// extern NS_SWIFT_NAME(ProfileDidChange) const NSNotificationName FBSDKProfileDidChangeNotification __attribute__((swift_name("ProfileDidChange")));
		[Notification (typeof (ProfileDidChangeEventArgs))]
		[Field ("FBSDKProfileDidChangeNotification", "__Internal")]
		NSString DidChangeNotification { get; }

		// extern NS_SWIFT_NAME(ProfileChangeOldKey) NSString *const FBSDKProfileChangeOldKey __attribute__((swift_name("ProfileChangeOldKey")));
		[Field ("FBSDKProfileChangeOldKey", "__Internal")]
		NSString OldProfileKey { get; }

		// extern NS_SWIFT_NAME(ProfileChangeNewKey) NSString *const FBSDKProfileChangeNewKey __attribute__((swift_name("ProfileChangeNewKey")));
		[Field ("FBSDKProfileChangeNewKey", "__Internal")]
		NSString NewProfileKey { get; }

		// -(instancetype _Nonnull)initWithUserID:(FBSDKUserIdentifier _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate permissions:(NSSet<NSString *> * _Nullable)permissions;
		[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:permissions:")]
		NativeHandle Constructor (string userId, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkURL, [NullAllowed] NSDate refreshDate, [NullAllowed] NSSet<NSString> permissions);

		// -(instancetype _Nonnull)initWithUserID:(FBSDKUserIdentifier _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate imageURL:(NSURL * _Nullable)imageURL email:(NSString * _Nullable)email friendIDs:(NSArray<NSString *> * _Nullable)friendIDs birthday:(NSDate * _Nullable)birthday ageRange:(FBSDKUserAgeRange * _Nullable)ageRange hometown:(FBSDKLocation * _Nullable)hometown location:(FBSDKLocation * _Nullable)location gender:(NSString * _Nullable)gender permissions:(NSSet<NSString *> * _Nullable)permissions;
		[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:imageURL:email:friendIDs:birthday:ageRange:hometown:location:gender:permissions:")]
		NativeHandle Constructor (string userId, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkURL, [NullAllowed] NSDate refreshDate, [NullAllowed] NSUrl imageURL, [NullAllowed] string email, [NullAllowed] string[] friendIDs, [NullAllowed] NSDate birthday, [NullAllowed] UserAgeRange ageRange, [NullAllowed] Location hometown, [NullAllowed] Location location, [NullAllowed] string gender, [NullAllowed] NSSet<NSString> permissions);

		// -(instancetype _Nonnull)initWithUserID:(FBSDKUserIdentifier _Nonnull)userID firstName:(NSString * _Nullable)firstName middleName:(NSString * _Nullable)middleName lastName:(NSString * _Nullable)lastName name:(NSString * _Nullable)name linkURL:(NSURL * _Nullable)linkURL refreshDate:(NSDate * _Nullable)refreshDate imageURL:(NSURL * _Nullable)imageURL email:(NSString * _Nullable)email friendIDs:(NSArray<NSString *> * _Nullable)friendIDs birthday:(NSDate * _Nullable)birthday ageRange:(FBSDKUserAgeRange * _Nullable)ageRange hometown:(FBSDKLocation * _Nullable)hometown location:(FBSDKLocation * _Nullable)location gender:(NSString * _Nullable)gender isLimited:(BOOL)isLimited permissions:(NSSet<NSString *> * _Nullable)permissions __attribute__((objc_designated_initializer));
		[DesignatedInitializer]
		[Export ("initWithUserID:firstName:middleName:lastName:name:linkURL:refreshDate:imageURL:email:friendIDs:birthday:ageRange:hometown:location:gender:isLimited:permissions:")]
		NativeHandle Constructor (string userId, [NullAllowed] string firstName, [NullAllowed] string middleName, [NullAllowed] string lastName, [NullAllowed] string name, [NullAllowed] NSUrl linkURL, [NullAllowed] NSDate refreshDate, [NullAllowed] NSUrl imageURL, [NullAllowed] string email, [NullAllowed] string[] friendIDs, [NullAllowed] NSDate birthday, [NullAllowed] UserAgeRange ageRange, [NullAllowed] Location hometown, [NullAllowed] Location location, [NullAllowed] string gender, bool isLimited, [NullAllowed] NSSet<NSString> permissions);

		// @property (readonly, copy, nonatomic) FBSDKUserIdentifier _Nonnull userID;
		[Export ("userID")]
		string UserId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable firstName;
		[NullAllowed]
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable middleName;
		[NullAllowed]
		[Export ("middleName")]
		string MiddleName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable lastName;
		[NullAllowed]
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable name;
		[NullAllowed]
		[Export ("name")]
		string Name { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable linkURL;
		[NullAllowed, Export ("linkURL", ArgumentSemantic.Copy)]
		NSUrl LinkURL { get; }

		// @property (readonly, copy, nonatomic) NSDate * _Nonnull refreshDate;
		[NullAllowed]
		[Export ("refreshDate")]
		NSDate RefreshDate { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable imageURL;
		[NullAllowed, Export ("imageURL", ArgumentSemantic.Copy)]
		NSUrl ImageUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (nonatomic, class) BOOL isUpdatedWithAccessTokenChange;
		[Static]
		[Export ("isUpdatedWithAccessTokenChange")]
		bool UpdatedWithAccessTokenChange { get; set; }

		// +(void)loadCurrentProfileWithCompletion:(FBSDKProfileBlock _Nullable)completion;
		[Async]
		[Static]
		[Export ("loadCurrentProfileWithCompletion:")]
		void LoadCurrentProfile ([NullAllowed] ProfileBlockHandler completion);

		// -(NSURL * _Nullable)imageURLForPictureMode:(enum FBSDKProfilePictureMode)pictureMode size:(CGSize)size __attribute__((warn_unused_result("")));
		[return: NullAllowed]
		[Export ("imageURLForPictureMode:size:")]
		NSUrl GetImageUrl (ProfilePictureMode mode, CGSize size);
	}

	// @interface FBSDKProfilePictureView : UIView
	[BaseType (typeof (UIView), Name = "FBSDKProfilePictureView")]
	interface ProfilePictureView {
		[Export ("initWithFrame:")]
		NativeHandle Constructor (CGRect frame);

		// -(instancetype _Nonnull)initWith:(CGRect)frame profile:(FBSDKProfile * _Nullable)profile __attribute__((objc_designated_initializer));
		[Export ("initWith:profile:")]
		[DesignatedInitializer]
		NativeHandle Constructor (CGRect frame, [NullAllowed] Profile profile);

		// -(instancetype _Nonnull)initWithProfile:(FBSDKProfile * _Nullable)profile;
		[Export ("initWithProfile:")]
		NativeHandle Constructor ([NullAllowed] Profile profile);

		// @property (assign, nonatomic) FBSDKProfilePictureMode pictureMode;
		[Export ("pictureMode", ArgumentSemantic.Assign)]
		ProfilePictureMode PictureMode { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull profileID;
		[Export ("profileID", ArgumentSemantic.Copy)]
		string ProfileId { get; set; }

		// -(void)setNeedsImageUpdate;
		[Export ("setNeedsImageUpdate")]
		void SetNeedsImageUpdate ();
	}

	// @protocol FBSDKSettings
#if NET
    [Model]
#else
	[Model (AutoGeneratedName = true)]
#endif
	[Protocol]
	[BaseType (typeof (NSObject), Name = "FBSDKSettings")]
	interface SettingsProtocol
	{
		// @required @property (readonly, copy, nonatomic) NSString * _Nonnull sdkVersion;
		[Abstract]
		[Export ("sdkVersion")]
		string SdkVersion { get; }

		// @required @property (readonly, nonatomic) BOOL isAutoLogAppEventsEnabled;
		[Abstract]
		[Export ("isAutoLogAppEventsEnabled")]
		bool AutoLogAppEventsEnabled { get; }

		// @required @property (nonatomic) BOOL isCodelessDebugLogEnabled;
		[Abstract]
		[Export ("isCodelessDebugLogEnabled")]
		bool CodelessDebugLogEnabled { get; set; }

		// @required @property (nonatomic) BOOL isAdvertiserIDCollectionEnabled;
		[Abstract]
		[Export ("isAdvertiserIDCollectionEnabled")]
		bool AdvertiserIdCollectionEnabled { get; set; }

		// @required @property (readonly, nonatomic) BOOL isSKAdNetworkReportEnabled;
		[Abstract]
		[Export ("isSKAdNetworkReportEnabled")]
		bool SKAdNetworkReportEnabled { get; }

		// @required @property (nonatomic) BOOL isGraphErrorRecoveryEnabled;
		[Abstract]
		[Export ("isGraphErrorRecoveryEnabled")]
		bool GraphErrorRecoveryEnabled { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable appID;
		[Abstract]
		[NullAllowed]
		[Export ("appID")]
		string AppId { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable appURLSchemeSuffix;
		[Abstract]
		[NullAllowed]
		[Export ("appURLSchemeSuffix")]
		string AppUrlSchemeSuffix { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable clientToken;
		[Abstract]
		[NullAllowed]
		[Export ("clientToken")]
		string ClientToken { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable userAgentSuffix;
		[Abstract]
		[NullAllowed]
		[Export ("userAgentSuffix")]
		string UserAgentSuffix { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable displayName;
		[Abstract]
		[NullAllowed, Export ("displayName")]
		string DisplayName { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nullable facebookDomainPart;
		[Abstract]
		[NullAllowed]
		[Export ("facebookDomainPart")]
		string FacebookDomainPart { get; set; }

		// @required @property (copy, nonatomic) NSSet<FBSDKLoggingBehavior> * _Nonnull loggingBehaviors;
		[Abstract]
		[Export ("loggingBehaviors", ArgumentSemantic.Copy)]
		NSSet<NSString> LoggingBehaviors { get; set; }

		// @required @property (copy, nonatomic) NSString * _Nonnull graphAPIVersion;
		[Abstract]
		[Export ("graphAPIVersion")]
		string GraphAPIVersion { get; set; }

		// @required @property (nonatomic) BOOL isAdvertiserTrackingEnabled;
		[Abstract]
		[Export ("isAdvertiserTrackingEnabled")]
		bool AdvertiserTrackingEnabled { get; set; }

		// @required -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options;
		[Abstract]
		[Export ("setDataProcessingOptions:")]
		void SetDataProcessingOptions ([NullAllowed] string[] options);

		// @required @property (readonly, nonatomic) BOOL isDataProcessingRestricted;
		[Abstract]
		[Export ("isDataProcessingRestricted")]
		bool DataProcessingRestricted { get; }

		// @required @property (readonly, nonatomic) BOOL isATETimeSufficientlyDelayed;
		[Abstract]
		[Export ("isATETimeSufficientlyDelayed")]
		bool ATETimeSufficientlyDelayed { get; }

		// @required @property (readonly, nonatomic) FBSDKAdvertisingTrackingStatus advertisingTrackingStatus;
		[Abstract]
		[Export ("advertisingTrackingStatus")]
		AdvertisingTrackingStatus AdvertisingTrackingStatus { get; }

		// @required @property (readonly, copy, nonatomic) NSDate * _Nullable installTimestamp;
		[Abstract]
		[NullAllowed, Export ("installTimestamp", ArgumentSemantic.Copy)]
		NSDate InstallTimestamp { get; }

		// @required @property (readonly, copy, nonatomic) NSDate * _Nullable advertiserTrackingEnabledTimestamp;
		[Abstract]
		[NullAllowed, Export ("advertiserTrackingEnabledTimestamp", ArgumentSemantic.Copy)]
		NSDate AdvertiserTrackingEnabledTimestamp { get; }

		// @required @property (nonatomic) BOOL isEventDataUsageLimited;
		[Abstract]
		[Export ("isEventDataUsageLimited")]
		bool EventDataUsageLimited { get; set; }

		// @required @property (nonatomic) BOOL shouldUseTokenOptimizations;
		[Abstract]
		[Export ("shouldUseTokenOptimizations")]
		bool ShouldUseTokenOptimizations { get; set; }

		// @required @property (readonly, copy, nonatomic) NSString * _Nullable graphAPIDebugParameterValue;
		[Abstract]
		[NullAllowed, Export ("graphAPIDebugParameterValue")]
		string GraphApiDebugParameterValue { get; }

		// @required @property (nonatomic) BOOL shouldUseCachedValuesForExpensiveMetadata;
		[Abstract]
		[Export ("shouldUseCachedValuesForExpensiveMetadata")]
		bool ShouldUseCachedValuesForExpensiveMetadata { get; set; }

		// @required @property (readonly, copy, nonatomic) NSDictionary<NSString *,id> * _Nullable persistableDataProcessingOptions;
		[Abstract]
		[NullAllowed, Export ("persistableDataProcessingOptions", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> PersistableDataProcessingOptions { get; }

		// @required @property (nonatomic) BOOL isDomainErrorEnabled;
		[Abstract]
		[Export ("isDomainErrorEnabled")]
		bool DomainErrorEnabled { get; set; }

		// @required -(void)setDataProcessingOptions:(NSArray<NSString *> * _Nullable)options country:(int32_t)country state:(int32_t)state;
		[Abstract]
		[Export ("setDataProcessingOptions:country:state:")]
		void SetDataProcessingOptions ([NullAllowed] string[] options, int country, int state);
	}

	// @interface FBSDKSettings : NSObject <FBSDKSettingsLogging, FBSDKSettings, FBSDKClientTokenProviding>
	[BaseType (typeof(NSObject), Name = "FBSDKSettings")]
	interface Settings : SettingsProtocol
	{
		// @property (readonly, nonatomic, strong, class) FBSDKSettings * _Nonnull sharedSettings;
		[Static]
		[Export ("sharedSettings", ArgumentSemantic.Strong)]
		Settings SharedSettings { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull defaultGraphAPIVersion;
		[Export ("defaultGraphAPIVersion")]
		string DefaultGraphApiVersion { get; }

		// @property (nonatomic) CGFloat JPEGCompressionQuality;
		[Export ("JPEGCompressionQuality")]
		nfloat JpegCompressionQuality { get; set; }

		// -(void)enableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
		[Export ("enableLoggingBehavior:")]
		void EnableLoggingBehavior (string loggingBehavior);

		// -(void)disableLoggingBehavior:(FBSDKLoggingBehavior _Nonnull)loggingBehavior;
		[Export ("disableLoggingBehavior:")]
		void DisableLoggingBehavior (string loggingBehavior);
	}

	// @interface FBSDKURL : NSObject <FBSDKAppLinkURL>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKURL")]
	interface Url {
		// +(instancetype _Nonnull)URLWithURL:(NSURL * _Nonnull)url __attribute__((swift_name("init(url:)")));
		[Static]
		[Export ("URLWithURL:")]
		Url Create (NSUrl url);

		// +(instancetype _Nonnull)URLWithInboundURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication __attribute__((swift_name("init(inboundURL:sourceApplication:)")));
		[Static]
		[Export ("URLWithInboundURL:sourceApplication:")]
		Url Create (NSUrl url, string sourceApplication);

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull targetURL;
		[Export ("targetURL", ArgumentSemantic.Strong)]
		NSUrl TargetUrl { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull targetQueryParameters;
		[Export ("targetQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> TargetQueryParameters { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull appLinkData;
		[NullAllowed]
		[Export ("appLinkData", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkData { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull appLinkExtras;
		[NullAllowed]
		[Export ("appLinkExtras", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> AppLinkExtras { get; }

		// @property (readonly, nonatomic, strong) FBSDKAppLink * _Nonnull appLinkReferer;
		[NullAllowed]
		[Export ("appLinkReferer", ArgumentSemantic.Strong)]
		AppLink AppLinkReferer { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull inputURL;
		[Export ("inputURL", ArgumentSemantic.Strong)]
		NSUrl InputUrl { get; }

		// @property (readonly, nonatomic, strong) NSDictionary<NSString *,id> * _Nonnull inputQueryParameters;
		[Export ("inputQueryParameters", ArgumentSemantic.Strong)]
		NSDictionary<NSString, NSObject> InputQueryParameters { get; }

		// @property (readonly, getter = isAutoAppLink, nonatomic) BOOL isAutoAppLink;
		[Export ("isAutoAppLink")]
		bool IsAutoAppLink { [Bind ("isAutoAppLink")] get; }
	}

	// @interface FBSDKUtility : NSObject
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKUtility")]
	interface Utility {

		// +(NSDictionary<NSString *,NSString *> * _Nonnull)dictionaryWithQueryString:(NSString * _Nonnull)queryString __attribute__((swift_name("dictionary(withQuery:)")));
		[Static]
		[Export ("dictionaryWithQueryString:")]
		NSDictionary CreateDictionary (string queryString);

		// +(NSString * _Nonnull)queryStringWithDictionary:(NSDictionary<NSString *,id> * _Nonnull)dictionary error:(NSError * _Nullable * _Nullable)errorRef __attribute__((swift_name("query(from:)"))) __attribute__((swift_error("nonnull_error")));
		[Static]
		[Export ("queryStringWithDictionary:error:")]
		string CreateQueryString ([NullAllowed] NSDictionary dictionary, out NSError errorRef);

		// +(NSString * _Nonnull)URLDecode:(NSString * _Nonnull)value __attribute__((swift_name("decode(urlString:)")));
		[Static]
		[Export ("URLDecode:")]
		string UrlDecode (string value);

		// +(NSString * _Nonnull)URLEncode:(NSString * _Nonnull)value __attribute__((swift_name("encode(urlString:)")));
		[Static]
		[Export ("URLEncode:")]
		string UrlEncode (string value);

		// +(dispatch_source_t _Nonnull)startGCDTimerWithInterval:(double)interval block:(dispatch_block_t _Nonnull)block;
		[Internal]
		[Static]
		[Export ("startGCDTimerWithInterval:block:")]
		IntPtr _StartGcdTimer (double interval, Action block);

		[Static]
		[Wrap ("new DispatchSource.Timer (_StartGcdTimer (interval, block))")]
		DispatchSource StartGcdTimer (double interval, Action block);

		// +(void)stopGCDTimer:(dispatch_source_t _Nonnull)timer;
		[Internal]
		[Static]
		[Export ("stopGCDTimer:")]
		void _StopGcdTimer (IntPtr timer);

		[Static]
		[Wrap ("_StopGcdTimer (timer.Handle)")]
		void StopGcdTimer (DispatchSource timer);

		// +(NSString * _Nullable)SHA256Hash:(NSObject * _Nonnull)input __attribute__((swift_name("sha256Hash(_:)")));
		[Static]
		[return: NullAllowed]
		[Export ("SHA256Hash:")]
		string SHA256Hash ([NullAllowed] NSObject input);
	}

	// @interface FBSDKWebViewAppLinkResolver : NSObject <FBSDKAppLinkResolving>
	[BaseType (typeof (NSObject), Name = "FBSDKWebViewAppLinkResolver")]
	interface WebViewAppLinkResolver : AppLinkResolving {
		// @property (readonly, nonatomic, strong, class) NS_SWIFT_NAME(shared) FBSDKWebViewAppLinkResolver * sharedInstance __attribute__((swift_name("shared")));
		[Static]
		[Export ("sharedInstance", ArgumentSemantic.Strong)]
		WebViewAppLinkResolver SharedInstance { get; }
	}

	// @interface FBSDKAuthenticationToken : NSObject <NSCopying, NSObject, NSSecureCoding, FBSDKAuthenticationTokenProviding>
	[DisableDefaultCtor]
	[BaseType (typeof (NSObject), Name = "FBSDKAuthenticationToken")]
	interface AuthenticationToken : INSCopying, INSSecureCoding {

		// @property (copy, nonatomic, class) NS_SWIFT_NAME(current) FBSDKAuthenticationToken * currentAuthenticationToken __attribute__((swift_name("current")));
		[Static]
		[NullAllowed, Export ("currentAuthenticationToken", ArgumentSemantic.Copy)]
		AuthenticationToken CurrentAuthenticationToken { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull tokenString;
		[Export ("tokenString")]
		string TokenString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
		[Export ("nonce")]
		string Nonce { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull graphDomain;
		[Export ("graphDomain")]
		string GraphDomain { get; }
	}
}
