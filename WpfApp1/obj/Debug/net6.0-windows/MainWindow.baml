   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	   -   5          � Title$  Snake��5   	   $	��600��6   $	��800��6$      BackgroundColor#��[  5	   	     	TextColor#��[ 5
   	    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � ColumnDefinitions 5   
    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ Score��5      $��Center=�5      $��Score: 0��5      $��22(�5      $��30��5      $��20q�5      $
��Wrap=�6    $��Center=�65   �� 5    
   -   5         ��Name$ 
GridBorder��5       $��1��5!        GridlineColor#��[ 5"      $	��1.5q�5#      $��Center=�5$      $��Center=�5%       �� EdgeMode$ Aliased=�5&      ._�5'      A� -   5         A�Name$ GameGrid��5'      $	��400��5(      $	��400��5)        GirdBackgroundColor#��[ 5*       J� SnapsToDevicePixels$
 True��5+      	 �� BitmapScalingMode$	 HighQuality=�5,      5.      50      �� 51   
   -   5        
 ��Name$
 StartButton��51      $��Start��52      $
��Left=�6   $��688,123,0,0q�68   $��1��6M   $	��Top=�6Z   #��[ 53      #��[ 54      $��50��6W   $��16(�6b   $��Normal"�6p   ���#ffff55      58      59      