   M S B A M L   `   `   `  ����D  @MeansTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:MeansTest	MeansTest  5   	       MeansTest.Appointments   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:MeansTest     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Appointments��5	   	   $��641.412��6   $��761.565��6/    � WindowState$ 	Maximized=�6?   .��5
      � ���	#FFFFFFDE.+�5   
   �� -   5         ��Name$
 View��5      $��View Appointments��6   $
��Left=�6;   $��
382,10,0,0q�6V   $	��Top=�6j   $	��140��6�   $
��Bold"�6�   $��14(�6�   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ Black��6#   � 5      $ 	#FFE9F2FF��6#    � Offset$ 0.513Q�65   � 5      $ 	#FFE9F2FF��6#   $ 0.178Q�65   5      5      �� 5   
   -   5        $ Create��5      $��Make Appointment��6!   $
��Left=�6<   $��594,404,0,0q�6W   $	��Top=�6l   $	��141��6�   $
��Bold"�6�   $��14(�6�   ��5      �� 5      $ 0.5,1&�6&   $ 0.5,0&�67   .��5      � $ Black��6#   $ 0Q�61   � 5      $ 	#FFF5FF2C��6#   $ 0.461Q�65   � 5      $ 	#FF8E9419��6#   $ 0.126Q�65   5      5      �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $	��204��6>   $��	10,39,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��725��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5        	  Name$	 Picky��5      $
��Left=�6$   $��	10,10,0,0q�6?   $	��Top=�6R   �� 5   
   -   5        
 ��Name$
 	ClientBox��5      $
��Left=�6%   $	��308��6@   $��	7,278,0,0q�6M   $	��Top=�6`   $	��301��6x   �� 5    
   $��Clients:��6   $
��Left=�6#   $��	7,248,0,0q�6>   $	��Top=�6Q    J� RenderTransformOrigin$ 3.312,1.192&�6i   $
��Bold"�6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5"   
   -   5          Name$ selectDateTime��5"      $
��Left=�66   $��464,320,0,0q�6Q   $	��Top=�6f   $	��271��6~   �� 5#   
   $+��%Make Appointment For Selected Client:��6   $
��Left=�6@   $��328,248,0,0q�6[   $	��Top=�6p   $
��Bold"�6�   �� 5$   
   $��Select a Date and Time��6   $
��Left=�61   $��328,314,0,0q�6L   $	��Top=�6a   �� 5%   
   $��Notes:��6   $
��Left=�6!   $��328,340,0,0q�6<   $	��Top=�6Q   $ 1.111,0.215&�6i   �� 5&   
   -   5        $ practitionerNotes��5&      $
��Left=�6-   $��54��6H   $��382,345,0,0q�6T   $
 Wrap=�6i   $	��Top=�6}   $	��353��6�   �� 5'   
   -   5         ��Name$ label��5'      $5��/(Leave blank to view all upcoming appointments)��6   $
��Left=�6Y   $��	112,8,0,0q�6t   $	��Top=�6�   5)      5*      