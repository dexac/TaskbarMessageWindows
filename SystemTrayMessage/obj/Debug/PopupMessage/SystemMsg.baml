   M S B A M L   `   `   `  ����L  HSystemTrayMessage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:SystemTrayMessage.PopupMessageSystemTrayMessage.PopupMessage  5      W0clr-namespace:SystemTrayMessage.Partials.Interop"SystemTrayMessage.Partials.Interop  5      .    (SystemTrayMessage.PopupMessage.SystemMsg   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      >local,clr-namespace:SystemTrayMessage.PopupMessage     5      ?tb0clr-namespace:SystemTrayMessage.Partials.Interop     5      -   5          >�Name$  uMessage��5      $	��145��6    $	��280��6-    � 	Resources 5       
  FadeIn g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value  HighlightCloseButton  FadeCloseButton  FadeBack  FadeOut��%�  &	        &	 
    &	 �    &	 �    &	 �    �� 5   
   .��5	      U� $ 00:00:00X�6,   $
 grid��6A   $ (UIElement.Opacity)�6^   .\�5
      �� $ 00:00:00��6'   $ 0Q�6:   �� 5      $ 00:00:01��6'   $
 0.95Q�6:   �� 5      $ 00:00:03��6'   $
 0.95Q�6:   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��6A   $ (UIElement.Opacity)�6b   .\�5      �� $ 00:00:00��6'   $	 0.4Q�6:   �� 5      $ 00:00:00.3000000��6'   $ 1Q�6B   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $ imgClose��6A   $ (UIElement.Opacity)�6b   .\�5      �� $ 00:00:00��6'   $ 1Q�6:   �� 5      $ 00:00:00.3000000��6'   $	 0.4Q�6B   5      5      �� 5   
   .��5      U� $ 00:00:00X�6,   $
 grid��6A   $ (UIElement.Opacity)�6^   .\�5      �� $ 00:00:00��6'   $ 1Q�6:   �� 5      $ 00:00:00.3000000��6'   $ 1Q�6B   5      5       �� 5!   
   -   5        .��5#      U� $ 00:00:00X�6,   $
 grid��6A   $ (UIElement.Opacity)�6^   .\�5$      �� $ 00:00:00��6'   $ 1Q�6:   �� 5%      $ 00:00:00.3000000��6'   $	 0.2Q�6B   5&      5'      5(       � Triggers 5)      :� 5*   
    :� RoutedEvent$# tb:TaskbarIcon.BalloonShowing��6   .[�5+      �� -   5        	 ��Name$	 FadeIn_BeginStoryboard��5+   C   #��[  6   6C   5,      :� 5-   
   $ Mouse.MouseEnter��6   
 :� 
SourceName$
 imgClose��66   .[�5.      �� -   5        $*	 $HighlightCloseButton_BeginStoryboard��5.   Q   #��[ 6   6Q   5/      :� 50   
   $ Mouse.MouseLeave��6   $
 imgClose��66   .[�51      �� -   5        $%	 FadeCloseButton_BeginStoryboard��51   L   #��[ 6   6L   52      :� 53   
   $ Mouse.MouseEnter��6   .[�54      ��  �� BeginStoryboardName$ FadeIn_BeginStoryboard��6   �� 55      -   5        $	 FadeBack_BeginStoryboard1��55      #��[ 6A   56      :� 57   
   $# tb:TaskbarIcon.BalloonClosing��6   .[�58      �� -   5        $	 FadeOut_BeginStoryboard��58   D   #��[ 6   6D   59      .��5<      � -   5         �Name$
 grid��5<      $��10q�6   .+�5>   
   �� $��Stretch=�6   $��5,5,5,5q�6/   $��2q�6@   
������ ���	#FFEEEEEE �� CornerRadius$ 12��6�    J� Effect 5?      3  -System.Windows.Media.Effects.DropShadowEffect  5@         Color$ 	#FF747474��6#   5B      �� 5C   
   $��72,20,10,10q�6   $
��Bold"�6)   ���	#FFF7443D��6R   �� *
SenderName+ �� UpdateSourceTrigger$ PropertyChanged=��� 5D   
   $
��Left=�6   $��	12,25,0,0q�6+   $��55��6>   $��55��6I   $��/Assets/pptest-p.png��5E      $
��Fill=�6.   $	��Top=�6=   �� 5F   
   $��
72,50,10,0q�6   $	��Top=�6(   ���	#FF565656$
��Wrap=�6W   �� 5G      �6   �� *MessageSender+$ PropertyChanged=� �� 5H      �6   �� *MessageDate+$ PropertyChanged=� �� Mode$ OneWay=�5I      F� 5J   
   ���	#FFFFFFFF �� Stretch$
 Fill=�6    $��72,44.2,34,0q�6/   $	��Top=�6E   $��1��6]   ���Ѐ����`����`	 J� SnapsToDevicePixels . ��5L      �� 5M       �� EndPoint$ 	0.973,0.5&�6&    �� 
StartPoint$ 	0.005,0.5&�6;   .��5N      �  � Color$ White��6#    � Offset$ 1Q�61   � 5O      $ Silver��6#   $ 0Q�62   5P      5R      �� 5S   
   $��
72,10,10,0q�6   $	��Top=�5T      $
��23.2��5U      $
��Wrap=�5W      ���	#FFECAD25$
��Bold"�5Y      ��5V      ��  �� Path$ BalloonText� �� ElementName$ uMessage��$ Default=�5Y      �� 5Z   
   -	   5         ��Name$ imgClose��5[   b   $��Right=�5Z      $��	0,10,10,0q�6,   $	��Top=�6?   $��16��6W   $��16��6b   $��/Assets/close-p.png��5[      $
��Fill=�6-    J� Opacity$	 0.4Q�6<    � ToolTip$ Close Message��6J   5\      5^      5_      