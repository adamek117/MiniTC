   M S B A M L   `   `   `  ????A  =MiniTC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MiniTC.ViewModelMiniTC.ViewModel  5      )clr-namespace:MiniTC.ViewMiniTC.View  5          MiniTC.View.PanelTC   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4	viewmodelclr-namespace:MiniTC.ViewModel     5      +localclr-namespace:MiniTC.View     5        ? 	Resources  5      %  MiniTC.ViewModel.PanelViewModel   pvm??%   &	          5   
   61   5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $
??200* ?6    ? RowDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $	??10* ?6   ?? 5      $??1* ?6   .+?5   
   ?? -   5         ??Name$
 path??5      $?? 0??6"   $??0??60   $??	80,5,67,5q?6@   $
??path??5      $??15(?6   ?? 5!   
   -   5         ??Name$ 	path_text??5!      $??0??6%   $??0??62   $??
130,5,10,5q?6B   $??10(?5"       ?? 
IsReadOnly . ??63   ?? *MyText+ ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType" >??? 5$   
   -   5        $ 
drive_name??5$      $?? 1??6(   $??0??66   $??	100,2,0,3q?6F   $??drive??5%      $??15(?6!   ?? 5'   
   $??Center=?6   $??Center=?5(      $??0,0,0,0q?5)      $??1??5*      $??50??5+   I   $??26??6T   	 ? DataContext	 6   ?? 
 ?? Source#
 [  .+?5,      ?? -   5         ??Name$ drive_combobox??5,      $
??Left=?5-      $??Center=?5.      $??43??5/      $??22??50      $??10(?51      ??52      ?? *	ItmSource+ ?? " >?$ FindAncestor=? ?? SelectedItem 53      ?? *ItmSelection+ ?? " >?$ FindAncestor=?54      56      ?? 58   
   -   5         ??Name$ listbox??58      $??0??6$   $??2??64   $??5q?6A   ??59      ?? *
ListSource+ ?? " >?$ FindAncestor=? 5:      ?? *ListSelection+ ?? " >?$ FindAncestor=?5;      5<      5=      