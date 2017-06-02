# Xam.Plugin.PopupMenu
A simple popup menu for Xamarin Forms.
This project is not supposed to be feature rich, it is simple a ready quick and lightweight implementation for when you need a menu displayed over a view.

## Nuget
https://www.nuget.org/packages/Xam.Plugin.PopupMenu/

## Images
![alt text](http://i.imgur.com/eWWPDov.png "Popup Menu 1.1.0")

## Changelog
* Version 1.1.0 -> Support binding via the ItemsSourceProperty
* Version 1.0.0 -> Internal only (Don't use this one)

## Donations
PayPal: ryandixon1993@gmail.com
I can't thank you guys enough for the support on my other plugins!

## Setup
iOS Only) Call the PopupEffect.Init method to make sure the linker picks this up correctly
1) Create a new PopupMenu Object
2) Either manually set the ItemsSource, or use SetBinding
3) Call ShowPopup on the PopupMenu, passing in the root view you wish for the popup to inherit from
4) Attach an event to OnItemSelected, this will return the PopupMenu and the selected string

## iOS Specifics
* At the moment, the cancel button text can be changed via the PopupEffect object in the iOS project
* The direction of the popover on the iPad can be set in the PopupEffect object in the iOS project

## Platform Support
*Please note: I have only put in platforms I have tested myself.*
* Xamarin.iOS : iOS 8 +
* Xamarin.Droid : API 14 +
* Windows Phone/Store RT : 8.1 +
* Windows UWP : 10 +
* Xamarin Forms : 2.3.3.180

## Feature Requests
DM me on LinkedIn: http://linkedin.radsrc.com
