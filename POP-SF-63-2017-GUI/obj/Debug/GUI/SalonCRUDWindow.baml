   M S B A M L   `   `   `  ����M  IPOP-SF-63-2017-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:POP_SF_63_2017_GUI.GUIPOP_SF_63_2017_GUI.GUI  5   	   ,    &POP_SF_63_2017_GUI.GUI.SalonCRUDWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:POP_SF_63_2017_GUI.GUI     5   	     � Title$  SalonCRUDWindow��5   	   $��540.376��6!   $��913.929��62   .��5	      � $��0,0,13,0q�6    � RowDefinitions 5
   
   �� 5      $	��37* �6   �� 5      $
��206* �6   �� 5      $	��27* �6   .+�5   
   �� -   5         ��Name$ header��5      $��Salon��6    $
��Left=�5      $	��Top=�6+   $��10,10,-306,0q�6C   $��35��5      $	��588��6   $��2��6(   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $
��Left=�5      $	��379��6-   $��10,0,0,0q�5      $��1��6$   $	��Top=�5      $	��873��6*      
IsReadOnly .    CanUserAddRows .   �� SelectedItem 5      ��  �� Path$ IzabraniSalon�5      �� 5   
   -   5         ��Name$ btnIzlaz��5      $
��Left=�6#   $	��Top=�5      $��89��6)   $��	794,0,0,0q�5      $��2��6$   $��25��5      .��64   Izlaz5      �� 5    
   -   5        $ btnDodaj��5       $��Dodaj��6#   $
��Left=�5!      $	��Top=�6,   $��75��5"      $��10,0,0,0q�5#      $��2��6#   $��25��5$      �� 5%   
   -   5        $ 	btnObrisi��5%      $��Obrisi��6$   $
��Left=�5&      $	��Top=�6,   $��75��5'      $��	170,0,0,0q�5(      $��2��6$   $��25��5)      �� 5*   
   -   5        $ 	btnIzmeni��5*      $��Izmeni��6$   $
��Left=�5+      $	��Top=�6,   $��75��5,      $��90,0,0,0q�6   $��2��5-      $��25��6   5.      5/      50      